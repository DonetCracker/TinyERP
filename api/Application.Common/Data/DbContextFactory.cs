namespace App.Common.Data
{
    using App.Common.DI;
    public class DbContextFactory
    {
        public static IDbContext Create(RepositoryType type)
        {
            IDbContextResolver resolver = IoC.Container.Resolve<IDbContextResolver>();
            return resolver.Resolve(type);
        }
    }
}
