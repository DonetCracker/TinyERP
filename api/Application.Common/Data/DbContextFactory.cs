namespace App.Common.Data
{
    using App.Common.DI;
    public class DbContextFactory
    {
        public static IDbContext Create(DbContextOption option)
        {
            IDbContextResolver resolver = IoC.Container.Resolve<IDbContextResolver>();
            return resolver.Resolve(option);
        }
    }
}
