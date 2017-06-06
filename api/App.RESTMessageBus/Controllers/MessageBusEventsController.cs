namespace App.RESTMessageBus.Controllers
{
    using App.Common.MVC;
    using MessageBus.Service;
    using Common.DI;
    using Common.MessageBus;
    using Common.MVC.Attributes;
    using System.Web.Http;

    [RoutePrefix("api/messageBus")]
    public class MessageBusEventsController : BaseApiController
    {
        [HttpPost]
        [Route("")]
        [ResponseWrapper()]
        public CreateMessageBusEventResponse CreateMessage(MessageBusEvent ev)
        {
            IMessageBusEventService service = IoC.Container.Resolve<IMessageBusEventService>();
            return service.Create(ev);
        }
    }
}