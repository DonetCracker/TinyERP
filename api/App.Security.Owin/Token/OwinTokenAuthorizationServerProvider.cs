namespace App.Security.Owin.Token
{
    using System.Threading.Tasks;
    using Microsoft.Owin.Security.OAuth;
    using App.Security.Command;
    using System.Collections.Generic;
    using System.Security.Claims;
    using App.Common.Command;
    using App.Security.Aggregate;
    using Common.Configurations;
    using App.Security.Command.UserNameAndPwd;

    internal class OwinTokenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //ntext.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { Configuration.Current.Authentication.AllowOrigins });
            string userName = context.UserName;
            string password = context.Password;

            AuthenticationResult authorise = this.Authorise(userName, password);
            if (authorise == null || !authorise.IsValid) { return; }

            IList<Claim> claimCollection = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authorise.FullName),
                    new Claim(ClaimTypes.Email, authorise.Email),
                    new Claim(ClaimTypes.Expired, authorise.TokenExpiredAfter.ToString()),
                    new Claim(ClaimTypes.Role, "admin")
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection, context.Options.AuthenticationType);
            context.Validated(claimsIdentity);

        }

        private AuthenticationResult Authorise(string userName, string password)
        {
            ICommandHandlerStrategy commandHandlerStrategy = CommandHandlerStrategyFactory.Create<User>();
            UserNameAndPwdAuthenticationRequest request = new UserNameAndPwdAuthenticationRequest(userName, password);
            commandHandlerStrategy.Execute(request);
            return request.Result;
        }
    }
}
