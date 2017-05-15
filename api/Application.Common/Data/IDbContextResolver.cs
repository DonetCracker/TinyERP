namespace App.Common.Data
{
    public interface IDbContextResolver
    {
        IDbContext Resolve(RepositoryType type);
    }
}
