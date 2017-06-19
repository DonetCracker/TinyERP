namespace App.Security.Owin.Token
{
    using System.Threading.Tasks;
    using Microsoft.Owin.Security.OAuth;
    using App.Common.Helpers;
    using App.Security.Command.UserNameAndPwd;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System;
    using App.Common.Command;
    using App.Security.Aggregate;

    internal class OwinTokenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            string userName = context.UserName;
            string password = context.Password;

            UserNameAndPwdAuthenticationResult authorise = this.Authorise(userName, password);
            if (authorise == null || !authorise.IsValid) { return; }

            IList<Claim> claimCollection = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authorise.FullName),
                    new Claim(ClaimTypes.Email, authorise.Email),
                    new Claim(ClaimTypes.Expired, authorise.ExpiredAfter.ToString()),
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection, context.Options.AuthenticationType);
            context.Validated(claimsIdentity);

        }

        private UserNameAndPwdAuthenticationResult Authorise(string userName, string password)
        {
            ICommandHandlerStrategy commandHandlerStrategy = CommandHandlerStrategyFactory.Create<User>();
            UserNameAndPwdAuthenticationRequest request = new UserNameAndPwdAuthenticationRequest(userName, password);
            commandHandlerStrategy.Execute(request);
            return request.Result;
        }
    }
}
