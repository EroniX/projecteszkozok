using EroniX.Core.Audit;

namespace EroniX.Core.Services
{
    public abstract class ServiceBase<TAppContextProvider>
        where TAppContextProvider : IAppContextProvider
    {
        protected readonly TAppContextProvider AppContextProvider;
        protected readonly ILogger Logger;

        protected readonly BusinessAudit BusinessAudit;
        protected readonly TraceAudit TraceAudit;


        protected ServiceBase(TAppContextProvider appContextProvider, ILogger logger)
        {
            AppContextProvider = appContextProvider;
            Logger = logger;
            BusinessAudit = new BusinessAudit(logger);
            TraceAudit = new TraceAudit(logger);
        }
    }
}
