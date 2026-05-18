using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;


[assembly: OwinStartup(
    typeof(task.App_Start.Startup))]
namespace task.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            CookieAuthenticationOptions cookie = new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString(
                            "/login/index"),
                ExpireTimeSpan = TimeSpan.FromMinutes(60),
                SlidingExpiration = true
            };
            app.UseCookieAuthentication(cookie);
        }
    }
}