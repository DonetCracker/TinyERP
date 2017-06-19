namespace App.Security.Owin
{
    using App.Common;
    using App.Common.Configurations;
    using App.Common.Extensions;
    using App.Common.Validation;
    using Common.Tasks;
    using global::Owin;
    using Security.Owin.UserNamePwd;

    public class ConfigAuthTask : BaseTask<TaskArgument<IAppBuilder>>, IConfigAppTask<TaskArgument<IAppBuilder>>
    {
        public ConfigAuthTask() : base(App.Common.ApplicationType.All)
        {
        }

        public override void Execute(TaskArgument<IAppBuilder> arg)
        {
            if (!this.IsValid(arg.Type) || !AuthType.Owin.IsIncludedIn(Configuration.Current.Authentication.AuthType)) { return; }
            AuthType authType = Configuration.Current.Authentication.AuthType;
            switch (authType)
            {
                case AuthType.OwinTokenBase:
                    ConfigOwinTokenBase(arg.Data);
                    break;
                case AuthType.OwinBasic:
                    ConfigBasicAuth(arg.Data);
                    break;
                default:
                    throw new ValidationException("common.authentication.invalidAuthType");
            }
        }
        private void ConfigOwinTokenBase(IAppBuilder app)
        {
        }
        private void ConfigBasicAuth(IAppBuilder app)
        {
            app.Use<UserNamePwdAuthMiddleware>(new UserNamePwdAuthOptions());
        }
    }
}