namespace App.Common.Data
{
    using global::MongoDB.Bson;
    public abstract class BaseQueryRepository<TEntity> : BaseRepository<TEntity, ObjectId>, IBaseQueryRepository<TEntity> 
        where TEntity : class, IBaseEntity<ObjectId>
    {
        public BaseQueryRepository(App.Common.Data.MongoDB.IMongoDbContext context) : base(context)
        {
            this.DbSet = context.GetDbSet<TEntity, ObjectId>();
        }

        public BaseQueryRepository(RepositoryType type) : base(type){}
    }
}
