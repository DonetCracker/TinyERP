namespace App.Common.Authorize
{
    public interface IAuthService
    {
        bool IsAuthorized(string userName, string pwd);
    }
}
