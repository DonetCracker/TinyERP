namespace App.Security.Repository
{
    using App.Common.Data;
    using App.Security.Aggregate;
    public interface IUserRepository : IBaseCommandRepository<User>
    {
        User GetActiveUser(string userName, string password);
    }
}
