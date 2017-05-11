namespace App.EventHandler.Impl.Order
{
    using Event.Order;
    using App.EventHandler.Order;
    using Common.Logging;
    using Common.DI;
    using Query.Order;

    public class OrderEventHandler : IOrderEventHandler
    {
        private ILogger logger;
        public OrderEventHandler()
        {
            this.logger = IoC.Container.Resolve<ILogger>();
        }

        public void Execute(OnOrderActivated ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            query.ActivateOrder(ev.OrderId);
            this.logger.Info("OnOrderActivated:{0}", ev.OrderId);
        }

        public void Execute(OnOrderCreated ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            query.CreateOrder(ev.OrderId);
            this.logger.Info("OnOrderCreated:{0}", ev.OrderId);
        }

        public void Execute(OnOrderLineItemAdded ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            query.AddOrderLineItem(ev.OrderId,ev.ProductId, ev.ProductName,ev.Quantity, ev.Price);
            this.logger.Info("OnOrderLineItemAdded:{0}", ev.Price);
        }

        public void Execute(OnCustomerDetailChanged ev)
        {
            IOrderQuery query = IoC.Container.Resolve<IOrderQuery>();
            query.UpdateCustomerDetail(ev.OrderId, ev.CustomerName);
            this.logger.Info("OnCustomerDetailChanged:{0}", ev.CustomerName);
        }
    }
}
