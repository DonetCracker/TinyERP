namespace App.Api.Features.Common
{
    using System;
    using App.Common;
    using App.Common.Data;
    using Context;

    public class DbContextResolver : IDbContextResolver
    {
        public IDbContext Resolve(DbContextOption option)
        {
            switch (option.RepositoryType) {
                case RepositoryType.MSSQL:
                    return new AppDbContext(option.IOMode);
                case RepositoryType.MongoDb:
                    return new App.Common.Data.MongoDB.MongoDbContext(option.IOMode);
                default:
                    throw new InvalidOperationException("common.errors.unsupportedTyeOdDbContext");
            }
        }
    }
}