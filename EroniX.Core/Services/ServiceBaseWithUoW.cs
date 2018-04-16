using EroniX.Core.Audit;
using EroniX.Core.DataAccess;

namespace EroniX.Core.Services
{
    public abstract class ServiceBaseWithUoW<TAppContextProvider, TUoW> : ServiceBase<TAppContextProvider>
        where TAppContextProvider: IAppContextProvider
        where TUoW : IUnitOfWork
    {
        protected readonly TUoW UoW;

        protected ServiceBaseWithUoW(TUoW uow, TAppContextProvider appContextProvider, ILogger logger) : base(appContextProvider, logger)
        {
            UoW = uow;
        }
    }
}
