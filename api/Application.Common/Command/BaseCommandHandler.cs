namespace App.Common.Command
{
    using App.Common.Aggregate;
    using App.Common.Data;
    using Configurations;
    using Configurations.EventHandler;
    using DI;
    using Logging;

    public class BaseCommandHandler
    {
        protected IUnitOfWork CreateUnitOfWork<TAggregate>() where TAggregate : IBaseAggregateRoot
        {
            ILogger logger = IoC.Container.Resolve<ILogger>();
            DbContextOption dbContextOption;
            string aggregateName = typeof(TAggregate).FullName;
            AggregateOption option = Configurations.Configuration.Current.Aggregates[aggregateName];
            if (option == null)
            {
                logger.Info("There is no for {0}, using default setting for UnitOfWork", aggregateName);
                dbContextOption = new DbContextOption(
                    IOMode.Write,
                    Configurations.Configuration.Current.Repository.DefaultRepoType,
                    connectionStringName: Configuration.Current.Repository.DefaultConnectionStringName
                );
            }
            else
            {
                dbContextOption = new DbContextOption(
                    IOMode.Write,
                    option.RepoType,
                    connectionStringName: string.IsNullOrWhiteSpace(option.ConnectionStringName) && option.RepoType == Configuration.Current.Repository.DefaultRepoType ? Configuration.Current.Repository.DefaultConnectionStringName : option.ConnectionStringName
                );
            }
            return new UnitOfWork(dbContextOption);
        }
    }
}
