namespace App.Security.Owin.UserNamePwd
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Infrastructure;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Microsoft.Owin;
    using Common;
    using System.Linq;
    using Common.DI;
    using Common.Authorize;

    internal class OwinAuthenticationHandler : AuthenticationHandler<UserNamePwd.UserNamePwdAuthOptions>
    {
        protected async override Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            if (!this.IsAuthorised(Request.Headers))
            {
                return null;
            }
            AuthenticationProperties authProperties = new AuthenticationProperties();
            authProperties.IssuedUtc = DateTime.UtcNow;
            authProperties.ExpiresUtc = DateTime.UtcNow.AddMinutes(3);
            authProperties.AllowRefresh = true;
            authProperties.IsPersistent = true;
            IList<Claim> claimCollection = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Tu Tran")
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection, "Custom");
            AuthenticationTicket ticket = new AuthenticationTicket(claimsIdentity, authProperties);
            return ticket;
        }

        private bool IsAuthorised(IHeaderDictionary headers)
        {
            string[] acceptLanguageValues;
            bool acceptLanguageHeaderPresent = headers.TryGetValue(Constants.AUTHENTICATION_TOKEN, out acceptLanguageValues);
            if (!acceptLanguageHeaderPresent)
            {
                return false;
            }
            string[] elementsInHeader = acceptLanguageValues.ToList()[0].Split(new string[] { Constants.AUTHENTICATION_TOKEN_SEPERATOR }, StringSplitOptions.RemoveEmptyEntries);
            IAuthService authService = IoC.Container.Resolve<IAuthService>();
            return authService.IsAuthorized(elementsInHeader[0], elementsInHeader[1]);
        }
    }
}
