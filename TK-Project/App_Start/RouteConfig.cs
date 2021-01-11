using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TK_Project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("NotConfirmAccount",
            "waiting-confirmation",
            new { controller = "Account", action = "NotConfirm", permalink = UrlParameter.Optional, page = UrlParameter.Optional });

            routes.MapRoute("NotRegister",
            "not-register-user",
            new { controller = "Account", action = "NotRegister", permalink = UrlParameter.Optional, page = UrlParameter.Optional });

            routes.MapRoute("WaitingApprovment",
            "waiting-approvment",
            new { controller = "Administrator", action = "WaitingApprovment", permalink = UrlParameter.Optional, page = UrlParameter.Optional });

            routes.MapRoute("MyStudent",
            "students",
            new { controller = "Administrator", action = "MyStudent", permalink = UrlParameter.Optional, page = UrlParameter.Optional });

            routes.MapRoute("DetailsStudent",
            "details/{id}",
            new { controller = "Administrator", action = "DetailsStudent", permalink = UrlParameter.Optional, page = UrlParameter.Optional });

            routes.MapRoute("Dashboard",
            "dashboard",
            new { controller = "Administrator", action = "Dashboard", permalink = UrlParameter.Optional, page = UrlParameter.Optional });

            routes.MapRoute("RegisterAdmin",
            "register-admin",
            new { controller = "Account", action = "RegisterAdmin", permalink = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute("RegisteredUser",
            "registered-user",
            new { controller = "Account", action = "RegisteredUser", permalink = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute("Login",
            "login",
            new { controller = "Account", action = "Login", permalink = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute("Registration",
                "register",
                new { controller = "Account", action = "Register", permalink = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute("RejectedStudents",
                "rejected-students",
                new { controller = "Administrator", action = "RejectedStudents", permalink = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute("LogOut",
                "logout",
                new { controller = "Account", action = "LogOff", permalink = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
