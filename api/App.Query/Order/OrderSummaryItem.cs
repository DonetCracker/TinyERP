namespace App.Query.Order
{
    using App.Common.Mapping;
    using Common.Data.MongoDB;
    using Common.DI;
    using System;
    using System.Linq;

    public class OrderSummaryItem :
        BaseMongoDbEntity,
        IMappedFrom<App.Query.Entity.Order.Order>,
        ICustomMap<App.Query.Entity.Order.Order>
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalPrice { get; set; }
        public void MapFrom(App.Query.Entity.Order.Order order)
        {
            this.TotalItems = order.OrderLines != null ? order.OrderLines.Count : 0;
            this.TotalPrice = order.OrderLines == null ? 0: order.OrderLines.Sum(item => item.Price);
        }
    }
}
