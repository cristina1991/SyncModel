using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using FileMVC.Models;

namespace FileMVC
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "000000004C10C01A",
                clientSecret: "NQRkZAtTHwjbsIeESF6exh02XPwshsrz");

            //OAuthWebSecurity.RegisterTwitterClient(
            //   consumerKey: "BH2aXJW3LXxdaYpBdGzQ",
            //   consumerSecret: "q5fZyWwOEW9mIXVAxRd1VygY0pqUR9HiaA7cQIKZQ");
            //OAuthWebSecurity.RegisterFacebookClient(
            //   appId: "187654464761762",
            //   appSecret: "62cfd93111645f7a956a0625adc3d2c5");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
