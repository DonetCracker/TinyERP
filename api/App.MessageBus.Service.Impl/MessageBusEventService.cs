namespace App.MessageBus.Service.Impl
{
    using System;
    using Common.MessageBus;
    using App.MessageBus.Service;
    internal class MessageBusEventService : IMessageBusEventService
    {
        public CreateMessageBusEventResponse Create(MessageBusEvent ev)
        {
            this.ValidateCreateMessageBusEventRequest(ev);
            using (IUnitOfWork uow = Unit)
        }
    }
}
