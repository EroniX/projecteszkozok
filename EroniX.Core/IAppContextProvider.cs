using System;

namespace EroniX.Core
{
    public interface IAppContextProvider
    {
        string UserName { get; }

        string RequestCorrelationToken { get; }
    }
}
