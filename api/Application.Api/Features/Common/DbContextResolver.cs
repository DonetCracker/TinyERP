namespace App.Api.Features.Common
{
    using System;
    using App.Common;
    using App.Common.Data;
    using Context;

    public class DbContextResolver : IDbContextResolver
    {
        public IDbContext Resolve(RepositoryType type)
        {
            switch (type) {
                case RepositoryType.MSSQL:
                    return new AppDbContext();
                case RepositoryType.MongoDb:
                    return new App.Common.Data.MongoDB.MongoDbContext();
                default:
                    throw new InvalidOperationException("common.errors.unsupportedTyeOdDbContext");
            }
        }
    }
}