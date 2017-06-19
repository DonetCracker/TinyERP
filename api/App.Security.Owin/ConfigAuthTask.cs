namespace App.Security.Owin
{
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
            if (!this.IsValid(arg.Type)) { return; }

            arg.Data.Use<UserNamePwdAuthMiddleware>(new UserNamePwdAuthOptions());
        }
    }
}