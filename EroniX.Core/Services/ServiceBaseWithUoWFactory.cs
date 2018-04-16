using EroniX.Core.Audit;
using EroniX.Core.DataAccess;

namespace EroniX.Core.Services
{
    public abstract class ServiceBaseWithUoWFactory<TAppContextProvider, TUoWFactory, TUoW> : ServiceBase<TAppContextProvider>
        where TAppContextProvider: IAppContextProvider
        where TUoWFactory: IUnitOfWorkFactory<TUoW>
        where TUoW : IUnitOfWork
    {
        protected readonly TUoWFactory UoWFactory;

        protected ServiceBaseWithUoWFactory(TUoWFactory uoWFactory, TAppContextProvider appContextProvider, ILogger logger) : base(appContextProvider, logger)
        {
            UoWFactory = uoWFactory;
        }
    }
}
