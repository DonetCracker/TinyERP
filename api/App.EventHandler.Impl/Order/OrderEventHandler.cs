namespace App.EventHandler.Impl.Order
{
    using Event.Order;
    using App.EventHandler.Order;
    using Common.DI;
    using Query.Order;
    using ValueObject.Order;

    public class OrderEventHandler : IOrderEventHandler
    {
        public void Execute(OnOrderActivated ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            App.Query.Entity.Order.Order order = query.GetByOrderId(ev.OrderId);
            order.IsActivated = true;
            query.Update(order);
        }

        public void Execute(OnOrderCreated ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            query.Add(new App.Query.Entity.Order.Order(ev.OrderId));
        }

        public void Execute(OnOrderLineItemAdded ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            App.Query.Entity.Order.Order order = query.GetByOrderId(ev.OrderId);
            order.OrderLines.Add(new OrderLine(ev.ProductId, ev.ProductName, ev.Quantity, ev.Price));
            order.TotalItems += ev.Quantity;
            order.TotalPrice += ev.Price * (decimal)ev.Quantity;
            query.Update(order);
        }

        public void Execute(OnCustomerDetailChanged ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            App.Query.Entity.Order.Order order = query.GetByOrderId(ev.OrderId);
            order.Name = ev.CustomerName;
            query.Update(order);
        }
    }
}
