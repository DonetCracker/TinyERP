namespace App.Api.Features.Common
{
    using System;
    using App.Common;
    using App.Common.Data;
    using Context;
    using App.Common.Helpers;
    using System.Linq;

    public class DbContextResolver : IDbContextResolver
    {
        public IDbContext Resolve(DbContextOption option)
        {
            switch (option.RepositoryType)
            {
                case RepositoryType.MSSQL:
                    //IDbContext context = ObjectHelper.CreateInstance<IDbContext<TAggegate>>(option);
                    //if (context == null)
                    //{
                    //    context = ObjectHelper.CreateInstance<IDbContext>(option);
                    //}
                    //return context;
                return new AppDbContext(option.IOMode, connectionName: option.ConnectionStringName);
                case RepositoryType.MongoDb:
                    return new App.Common.Data.MongoDB.MongoDbContext(option.IOMode, connectionName: option.ConnectionStringName);
                default:
                    throw new InvalidOperationException("common.errors.unsupportedTyeOdDbContext");
            }
        }
    }
}