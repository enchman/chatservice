using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistModule.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controllers
{
    public enum SessionType
    {
        AccountId,
        Token,
        OnSince
    }

    static class CookieOption
    {
        private static string tokenName = "c_t";
        private static string clientKeyName = "c_k";
        private static string rememberMeName = "c_r";

        public static string TokenName { get { return tokenName; } }
        public static string ClientKey { get { return clientKeyName; } }
        public static string RememberMe { get { return rememberMeName; } }
    }

    static class UserAction
    {
        public static bool ValidateToken(Controller control)
        {
            if (
                control.HttpContext.Items.ContainsKey(SessionType.AccountId) &&
                control.HttpContext.Items.ContainsKey(SessionType.Token) &&
                control.Request.Cookies.ContainsKey(CookieOption.TokenName)
                )
            {
                try
                {
                    string tokenText = control.Request.Cookies[CookieOption.TokenName];
                    byte[] token = Convert.FromBase64String(tokenText);
                    byte[] data = (byte[])control.HttpContext.Items[SessionType.Token];

                    return token.VerifyToken(data);
                }
                catch { }
            }

            return false;
        }
    }
}
