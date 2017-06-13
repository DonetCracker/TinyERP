namespace App.Security.Command.Impl
{
    using System;
    using App.Common.Command;
    using App.Security.Command.UserNameAndPwd;
    using Common.Data;
    using Aggregate;
    using Repository;
    using Common.DI;
    using Common.Helpers;
    using Common.Validation;

    internal class UserNameAndPwdAuthCommandHandler : BaseCommandHandler, IUserNameAndPwdAuthCommandHandler
    {
        public void Handle(UserNameAndPwdAuthenticationRequest command)
        {
            this.ValidateUserNameAndPwdAuthenticationRequest(command);
            using (IUnitOfWork uow = this.CreateUnitOfWork<User>())
            {
                IUserRepository repository = IoC.Container.Resolve<IUserRepository>(uow);
                User user = repository.GetActiveUser(command.UserName, EncodeHelper.EncodePassword(command.Password));
                if (user == null)
                {
                    command.Result = new UserNameAndPwdAuthenticationResult(false);
                    return;
                }
                user.GenerateLoginToken();
                repository.Update(user);
                uow.Commit();
                command.Result = new UserNameAndPwdAuthenticationResult(
                    user.FistName,
                    user.LastName,
                    user.Email,
                    true,
                    user.LoginToken,
                    user.TokenExpiredAfter
                );
            }
        }

        private void ValidateUserNameAndPwdAuthenticationRequest(UserNameAndPwdAuthenticationRequest command)
        {
            IValidationException validationException = ValidationHelper.Validate(command);
            validationException.ThrowIfError();
        }
    }
}
