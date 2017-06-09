namespace App.MessageBus.Aggregate
{
    using App.Common.Aggregate;
    using Common.MessageBus;

    public class BusEventAggregate: BaseAggregateRoot
    {
        public MessageBusEvent Content { get; set; }

    }
}
