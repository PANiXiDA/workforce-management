using System;
using System.Web;
using System.Web.Http;

namespace WorkforceManagement.Presentation.Http
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            var applicationPath = Request.ApplicationPath?.TrimEnd('/') ?? string.Empty;
            var currentPath = Request.Url?.AbsolutePath?.TrimEnd('/');

            if (string.Equals(currentPath, applicationPath, StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect($"{applicationPath}/swagger", endResponse: true);
            }
        }
    }
}
