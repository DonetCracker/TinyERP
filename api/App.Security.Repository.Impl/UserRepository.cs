namespace App.Security.Repository.Impl
{
    using App.Common.Data;
    using App.Security.Aggregate;
    using App.Security.Repository;
    using Common;
    using Context;
    using System.Linq;

    internal class UserRepository : BaseCommandRepository<User>, IUserRepository
    {
        public UserRepository() : base(new SecurityDbContext(IOMode.Read)) { }
        public UserRepository(IUnitOfWork uow) : base(uow.Context) { }

        public User GetActiveUser(string userName, string password)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.Status == UserAccountStatus.Active && item.UserName == userName && item.Pwd == password);
        }
    }
}
