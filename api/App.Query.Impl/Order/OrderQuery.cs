namespace App.Query.Impl.Order
{
    using App.Common.Data;
    using App.Common.Data.MongoDB;
    using App.Query.Order;
    using App.Query.Entity.Order;
    using System.Collections.Generic;
    using Common.Mapping;
    using System;
    using System.Linq;

    public class OrderQuery : BaseQueryRepository<Order>, IOrderQuery
    {
        public OrderQuery() : base(new MongoDbContext()) { }

        public Order GetByOrderId(Guid orderId)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.OrderId == orderId);
        }

        public TEntity GetOrder<TEntity>(string id) where TEntity : IMappedFrom<Order>
        {
            return this.GetById<TEntity>(id);
        }
        public IList<TEntity> GetOrders<TEntity>() where TEntity : IMappedFrom<Order>
        {
            return this.GetItems<TEntity>();
        }
    }
}
