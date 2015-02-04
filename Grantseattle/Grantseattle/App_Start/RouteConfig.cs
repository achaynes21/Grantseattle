using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InventoryERP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            #region Search
            routes.MapRoute(
                          name: "RentPropertySearch",
                          url: "RentProperty-Search",
                          defaults: new { controller = "Search", action = "RentPropertySearch" }
                      );
            routes.MapRoute(
                          name: "PropertySearch",
                          url: "Property-Search",
                          defaults: new { controller = "Search", action = "PropertySearch" }
                      );

            #endregion
            #region Client
            routes.MapRoute(
                        name: "ClientHome",
                        url: "Client",
                        defaults: new { controller = "Client", action = "Index" }
                    );
            routes.MapRoute(
                       name: "ClientContactUs",
                       url: "ContactUs",
                       defaults: new { controller = "Client", action = "ContactUs" }
                   );
            routes.MapRoute(
                       name: "ClientAboutUs",
                       url: "AboutUs",
                       defaults: new { controller = "Client", action = "AboutUs" }
                   );
            routes.MapRoute(
                       name: "ClientNews",
                       url: "News",
                       defaults: new { controller = "Client", action = "News" }
                   );
            routes.MapRoute(
                       name: "ClientBlog",
                       url: "Blogging",
                       defaults: new { controller = "Client", action = "Blog" }
                   );
            routes.MapRoute(
                       name: "ClientFavourite",
                       url: "MyFavourite",
                       defaults: new { controller = "Client", action = "MyFavourite" }
                   );
            routes.MapRoute(
                       name: "ClientService",
                       url: "ourServices",
                       defaults: new { controller = "Client", action = "OurService" }
                   );
            routes.MapRoute(
            name: "AddToFavourite",
            url: "AddTo-Favourite",
            defaults: new { controller = "Client", action = "AddToFavourite" }
        );
            routes.MapRoute(
            name: "ContactUsPost",
            url: "ContactUs-Post",
            defaults: new { controller = "Client", action = "ContactUsPost" }
        );
            
            #endregion

            #region BlogPost
            routes.MapRoute(
                         name: "BlogPostCreate",
                         url: "Blog-Post",
                         defaults: new { controller = "Blogpost", action = "Create" }
                     );
            routes.MapRoute(
                        name: "BlogPostList",
                        url: "BlogPost-List",
                        defaults: new { controller = "Blogpost", action = "Index" }
                    );
            routes.MapRoute(
                        name: "BlogPostDetails",
                        url: "BlogPost-Details",
                        defaults: new { controller = "Blogpost", action = "Details" }
                    );
            routes.MapRoute(
                        name: "BlogPostEdit",
                        url: "BlogPost-Edit",
                        defaults: new { controller = "Blogpost", action = "Edit" }
                    );
            routes.MapRoute(
                        name: "BlogPostDelete",
                        url: "BlogPost-Delete",
                        defaults: new { controller = "Blogpost", action = "Delete" }
                    );

            #endregion

            #region Blog
            routes.MapRoute(
                          name: "BlogList",
                          url: "Blog-List",
                          defaults: new { controller = "Blog", action = "Index" }
                      );
            routes.MapRoute(
                          name: "CreateBlog",
                          url: "Blog-Create",
                          defaults: new { controller = "Blog", action = "Create" }
                      );
            routes.MapRoute(
                          name: "DetailsBlog",
                          url: "blog-Detail",
                          defaults: new { controller = "Blog", action = "Details" }
                      );
            routes.MapRoute(
                          name: "BlogEdit",
                          url: "Blog-Edit",
                          defaults: new { controller = "Blog", action = "Edit" }
                      );
            routes.MapRoute(
                        name: "BlogDelete",
                        url: "Blog-Delete",
                        defaults: new { controller = "Blog", action = "Delete" }
                    );
            #endregion

            #region Route for PropertyListing Controller
            routes.MapRoute(
                          name: "MakePropertyPurpose",
                          url: "Create-Property-Purpose",
                          defaults: new { controller = "PropertyListing", action = "MakePropertyPurpose" }
                      );
            routes.MapRoute(
                          name: "MakePropertyLocation",
                          url: "Make-Property-Location",
                          defaults: new { controller = "PropertyListing", action = "MakePropertyLocation" }
                      );

            routes.MapRoute(
                          name: "CreatePropertyType",
                          url: "Create-PropertyType",
                          defaults: new { controller = "PropertyListing", action = "CreatePropertyType" }
                      );
            routes.MapRoute(
                          name: "PropertyTypeList",
                          url: "PropertyType-List",
                          defaults: new { controller = "PropertyListing", action = "PropertyTypeList" }
                      );
            routes.MapRoute(
                          name: "PropertyTypeDetails",
                          url: "PropertyType-Details",
                          defaults: new { controller = "PropertyListing", action = "PropertyTypeDetails" }
                      );
            routes.MapRoute(
                         name: "PropertyTypeDelete",
                         url: "PropertyType-Delete",
                         defaults: new { controller = "PropertyListing", action = "PropertyTypeDelete" }
                     );
            routes.MapRoute(
                         name: "PropertyTypeEdit",
                         url: "PropertyType-Edit",
                         defaults: new { controller = "PropertyListing", action = "PropertyTypeEdit" }
                     );
            routes.MapRoute(
                         name: "PropertyRegistration",
                         url: "Property-Registration",
                         defaults: new { controller = "PropertyListing", action = "PropertyRegistration" }
                     );
            routes.MapRoute(
                          name: "IndexPropertyListing",
                          url: "DefaultMethod",
                          defaults: new { controller = "PropertyListing", action = "Index" }
                      );



            routes.MapRoute(
                         name: "GetPropertyModelView",
                         url: "GetPropertyModelView",
                         defaults: new { controller = "PropertyListing", action = "GetPropertyModelView" }
                     );
            routes.MapRoute(
                         name: "FinallyPropertySave",
                         url: "FinallyPropertySave",
                         defaults: new { controller = "PropertyListing", action = "FinallyPropertySave" }
                     );
            #endregion

            #region Routes for News Controlller
            routes.MapRoute(
               name: "PublishNews",
               url: "Publish-News",
               defaults: new { controller = "NewsPortal", action = "PublishNews" }
           );
            routes.MapRoute(
               name: "NewsList",
               url: "News-List",
               defaults: new { controller = "NewsPortal", action = "NewsList" }
           );
            routes.MapRoute(
               name: "Edit",
               url: "Edit",
               defaults: new { controller = "NewsPortal", action = "Edit" }
           );
            routes.MapRoute(
               name: "details",
               url: "details",
               defaults: new { controller = "NewsPortal", action = "details" }
           );
            routes.MapRoute(
               name: "Delete",
               url: "Delete",
               defaults: new { controller = "NewsPortal", action = "Delete" }
           );

            #endregion

            #region Routes for Agent Controlller
            routes.MapRoute(
               name: "Create",
               url: "Create-Agent",
               defaults: new { controller = "Agent", action = "Create" }
           );
            routes.MapRoute(
               name: "AgentList",
               url: "Agent-List",
               defaults: new { controller = "Agent", action = "AgentList" }
           );
            routes.MapRoute(
               name: "AgentEdit",
               url: "Agent-Edit",
               defaults: new { controller = "Agent", action = "Edit" }
           );
            routes.MapRoute(
               name: "AgentDetails",
               url: "Agent-Details",
               defaults: new { controller = "Agent", action = "Details" }
           );
            routes.MapRoute(
               name: "AgentDelete",
               url: "Agent-Delete",
               defaults: new { controller = "Agent", action = "Delete" }
           );
            #endregion

            #region Routes for Item Controlller

            routes.MapRoute(
               name: "CreateItem",
               url: "create-item",
               defaults: new { controller = "Item", action = "CreateItem" }
           );

            routes.MapRoute(
               name: "ItemList",
               url: "items",
               defaults: new { controller = "Item", action = "ViewItems" }
           );

            #endregion

            #region Routes for Account Controller

            routes.MapRoute(
                name: "LogInWithFacebook",
                url: "log-in-with-facebook",
                defaults: new { controller = "Account", action = "LogInWithFacebook" }
            );

            routes.MapRoute(
                name: "SignUpWithFacebook",
                url: "sign-up-with-facebook",
                defaults: new { controller = "Account", action = "SignUpWithFacebook" }
            );

            routes.MapRoute(
                name: "EmailExist",
                url: "email-exist",
                defaults: new { controller = "Account", action = "EmailExist" }
            );

            routes.MapRoute(
                name: "SignUp",
                url: "sign-up",
                defaults: new { controller = "Account", action = "SignUp" }
            );


            routes.MapRoute(
                name: "SignIn",
                url: "",
                defaults: new { controller = "Account", action = "SignIn" }
            );

            routes.MapRoute(
                name: "SignOut",
                url: "sign-out",
                defaults: new { controller = "Account", action = "SignOut" }
            );

            routes.MapRoute(
                name: "ForgotPassword",
                url: "forgot-password",
                defaults: new { controller = "Account", action = "ForgotPassword" }
            );

            //routes.MapRoute(
            //    name: "EmailConfirmation",
            //    url: "confirm-email",
            //    defaults: new { controller = MVC.Account.Name, action = MVC.Account.ActionNames.EmailConfirmation }
            //);

            //routes.MapRoute(
            //    name: "ResetPassword",
            //    url: "reset-password",
            //    defaults: new { controller = MVC.Account.Name, action = MVC.Account.ActionNames.ResetPassword }
            //);

            //routes.MapRoute(
            //    name: "reset-password",
            //    url: "reset-password",
            //    defaults: new { controller = MVC.Account.Name, action = MVC.Account.ActionNames.ResetPassword, code = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "confirm-email",
            //    url: "confirm-email",
            //    defaults: new { controller = MVC.Account.Name, action = MVC.Account.ActionNames.EmailConfirmation }
            //);
            routes.MapRoute(
                name: "CreateAdmin",
                url: "Admin",
                defaults: new { controller = "Account", action = "CreateAdmin" }
            );
            #endregion

            #region Routes for Home Controller

            routes.MapRoute(
                name: "Index",
                url: "home",
                defaults: new { controller = "Home", action = "Index" }
            );

            //routes.MapRoute(
            //    name: "Help",
            //    url: "help",
            //    defaults: new { controller = MVC.Home.Name, action = MVC.Home.ActionNames.Help }
            //);

            routes.MapRoute(
                name: "About",
                url: "about-job",
                defaults: new { controller = "Home", action = "About" }
            );

            //routes.MapRoute(
            //    name: "TermsOfUse",
            //    url: "terms-of-use",
            //    defaults: new { controller = MVC.Home.Name, action = MVC.Home.ActionNames.TermsOfUse }
            //);

            //routes.MapRoute(
            //    name: "PrivacyPolicy",
            //    url: "privacy-policy",
            //    defaults: new { controller = MVC.Home.Name, action = MVC.Home.ActionNames.PrivacyPolicy }
            //);


            #endregion

            routes.MapRoute(
                name: "Default",
                url: "log-in",
                defaults: new { controller = "Account", action = "SignIn" }
            );
            routes.MapRoute(
                name: "PasswordChange",
                url: "Password-Change",
                defaults: new { controller = "Account", action = "PasswordChange" }
            );

            routes.MapRoute(
               name: "404",
               url: "404",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
