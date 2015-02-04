using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace InventoryERP.Core
{
    public class LinkHelper
    {
        public static string Domain
        {
            get
            {
                string domain = string.Empty;

                string applicationPath = CurrentRequest.ApplicationPath;
                if (applicationPath == "/") applicationPath = string.Empty;

                string requestPath = CurrentRequest.Url.AbsolutePath.Substring(applicationPath.Length);
                string host = CurrentRequest.Url.Host;
                string port = CurrentRequest.Url.Port.ToString();

                if (CurrentRequest.Url.IsDefaultPort)
                    domain = "http://" + host + applicationPath;
                else
                    domain = "http://" + host + ":" + port + applicationPath;

                return domain;
            }
        }

        private static HttpRequest CurrentRequest
        {
            get
            {
                var current = HttpContext.Current;
                Check.Argument.Null(current, "httpcontext", "No httpcontext is available");

                var request = current.Request;
                Check.Argument.Null(request, "request", "No request available on current httpcontext.");

                return request;
            }
        }

    }
}
    