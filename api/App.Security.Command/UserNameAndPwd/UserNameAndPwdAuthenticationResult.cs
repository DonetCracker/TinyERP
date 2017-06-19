namespace App.Security.Command.UserNameAndPwd
{
    using System;
    public class UserNameAndPwdAuthenticationResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return String.Format("{0} {1}", this.FirstName, this.LastName); } }
        public string Email { get; set; }
        public bool IsValid { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredAfter { get; set; }
        public UserNameAndPwdAuthenticationResult(bool isValid = false)
        {
            this.IsValid = isValid;
            this.Token = string.Empty;
            this.ExpiredAfter = DateTime.UtcNow;
        }

        public UserNameAndPwdAuthenticationResult(
            string firstName,
            string lastName,
            string email,
            bool isValid,
            string loginToken,
            DateTime tokenExpiredAfter
        ) : this(isValid)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Token = loginToken;
            this.ExpiredAfter = tokenExpiredAfter;
        }
    }
}
