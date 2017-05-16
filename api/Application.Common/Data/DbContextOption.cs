namespace App.Common.Data
{
    public class DbContextOption
    {
        public RepositoryType RepositoryType { get; set; }
        public IOMode IOMode { get; set; }
        public IDbContext DbContext { get; protected set; }
        public string ConnectionStringName { get; protected set; }
        public DbContextOption(IOMode mode, RepositoryType type, string connectionStringName = "", IDbContext context = null)
        {
            this.ConnectionStringName = connectionStringName;
            this.DbContext = context;
            this.IOMode = mode;
            this.RepositoryType = type;
        }
    }
}
