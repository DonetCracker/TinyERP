namespace App.Security.EventHandler.Impl
{
    using App.Common.DI;
    using App.Common.Tasks;
    using Common.Event;
    using Event.Authentication;

    public class Bootstrap : BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap() : base(App.Common.ApplicationType.All){}

        public override void Execute(IBaseContainer context)
        {
            context.RegisterTransient<IEventHandler<OnAuthenticationFailed>, App.Security.EventHandler.Impl.AuthenticationEventHandler>("OnAuthenticationFail");
            context.RegisterTransient<IEventHandler<OnAuthenticationSuccess>, App.Security.EventHandler.Impl.AuthenticationEventHandler>("OnAuthenticationSuccess");
        }
    }
}