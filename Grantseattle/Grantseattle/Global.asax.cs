using InventoryERP.Core;
using InventoryERP.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InventoryERP.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Bootstrapper.Run();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.ToString().ToLower();

            if (!HttpContext.Current.Request.IsLocal && !url.StartsWith("http://www.") && !url.StartsWith("https://www."))
            {
                if (url.StartsWith("http://"))
                {
                    url = "http://www." + url.Remove(0, 7);

                }

                if (url.StartsWith("https://"))
                {
                    url = "https://www." + url.Remove(0, 8);
                }

                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", url);
            }

            if (!HttpContext.Current.Request.IsLocal && url.StartsWith("http://"))
            {
                url = "https://" + url.Remove(0, 7);

                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", url);
            }
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            Authentication.LoadAuthenticationInformation();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (App.Configurations.ProductionMode.Value)
            {
                Exception exception = Server.GetLastError();

                Response.Clear();

                HttpException httpException = exception as HttpException;

                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Errors");

                if (httpException == null)
                {
                    string errorCode1 = CreateErrorLogFile(HttpContext.Current, exception);

                    HttpContext.Current.Server.ClearError();
                    routeData.Values.Add("action", "Index");
                    routeData.Values.Add("errorCode", errorCode1);
                }

                //It's an Http Exception, Let's handle it.
                else
                {
                    switch (httpException.GetHttpCode())
                    {
                        case 404:
                            {
                                string errorCode = CreateErrorLogFile(HttpContext.Current, exception);

                                HttpContext.Current.Server.ClearError();
                                // Page not found.
                                routeData.Values.Add("action", "Http404");
                                routeData.Values.Add("errorCode", errorCode);
                                break;
                            }
                        case 500:
                            {
                                string errorCode = CreateErrorLogFile(HttpContext.Current, exception);

                                HttpContext.Current.Server.ClearError();
                                routeData.Values.Add("action", "Http500");
                                routeData.Values.Add("errorCode", errorCode);
                                break;
                            }

                        // Here you can handle Views to other error codes.
                        // I choose a General error template  
                        default:
                            routeData.Values.Add("action", "Index");
                            break;
                    }
                }

                // Pass exception details to the target error View.
                routeData.Values.Add("error", exception);

                // Clear the error on server.
                Server.ClearError();
                Response.StatusCode = 500;
                Response.ContentType = "text/HTML";

                // Avoid IIS7 getting in the middle
                Response.TrySkipIisCustomErrors = true;

                // Call target Controller and pass the routeData.
                IController errorController = new ErrorsController();
                errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            }
        }

        private static void EnsureLogFileFolder(string logFileFolderPath)
        {
            if (!string.IsNullOrEmpty(logFileFolderPath) && !System.IO.Directory.Exists(logFileFolderPath))
            {
                System.IO.Directory.CreateDirectory(logFileFolderPath);
            }
        }

        private static string CreateErrorLogFile(HttpContext context, Exception exception)
        {
            //var logFileFolderPath = context.Request.PhysicalApplicationPath + "logs\\";
            var logFileFolderPath = System.IO.Path.Combine(context.Server.MapPath("~/"), "logs");

            EnsureLogFileFolder(logFileFolderPath);
            var errorCode = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            var fileName = "{0}.log".FormatWith(errorCode);
            var fullPath = System.IO.Path.Combine(logFileFolderPath, fileName);

            try
            {
                using (var textWriter = new System.IO.StreamWriter(fullPath))
                {
                    textWriter.WriteLine(exception.ToString());
                }
            }
            catch (Exception) { }

            return errorCode;
        }
    }
}
