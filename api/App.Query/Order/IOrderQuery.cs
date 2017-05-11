namespace App.Query.Order
{
    using Common.Mapping;
    using System;
    using System.Collections.Generic;

    public interface IOrderQuery
    {
        void CreateOrder(Guid orderId);
        void AddOrderLineItem(Guid orderId,Guid productId,string productName,int quantity, decimal price);
        void UpdateCustomerDetail(Guid orderId, string customerName);
        void ActivateOrder(Guid orderId);
        IList<TEntity> GetOrders<TEntity>() where TEntity : IMappedFrom<App.Query.Entity.Order.Order>;
        TEntity GetOrder<TEntity>(string id) where TEntity : IMappedFrom<App.Query.Entity.Order.Order>;
    }
}
