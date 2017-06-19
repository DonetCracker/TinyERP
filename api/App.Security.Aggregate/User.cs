namespace App.Security.Aggregate
{
    using App.Common.Aggregate;
    using Common;
    using Common.Helpers;
    using System;

    public class User : BaseAggregateRoot
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public UserAccountStatus Status { get; set; }
        public string LoginToken { get; set; }
        public DateTime TokenExpiredAfter { get; set; }
        public DateTime LastLogin { get; set; }

        public void GenerateLoginToken()
        {
            AuthenticationToken token = TokenHelper.CreateNewAuthenticationToken(this.LoginToken);
            this.LoginToken = token.Value;
            this.TokenExpiredAfter = token.ExpiredAfter;
        }
    }
}