namespace App.Common.Data
{
    public class DbContextOption
    {
        public RepositoryType RepositoryType { get; set; }
        public IOMode IOMode { get; set; }
        public IDbContext DbContext { get; protected set; }
        public DbContextOption(IOMode mode, RepositoryType type, IDbContext context = null)
        {
            this.DbContext = context;
            this.IOMode = mode;
            this.RepositoryType = type;
        }
    }
}
