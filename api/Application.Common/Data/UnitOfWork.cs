namespace App.Common.Data
{
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        public RepositoryType RepositoryType { get; protected set; }
        public IDbContext Context { get; private set; }
        protected UnitOfWork(DbContextOption option) : this(DbContextFactory.Create(option))
        {
            this.RepositoryType = option.RepositoryType;
        }
        public UnitOfWork(RepositoryType repoType) : this(new DbContextOption(IOMode.Write,repoType)){}
        
        protected UnitOfWork(IDbContext context)
        {
            this.Context = context;
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}