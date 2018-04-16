using System;
using System.Collections.Generic;

namespace EroniX.Core.Audit
{
    public interface ILogger
    {
        void LogBusinessEvent(bool success, int code, string msg, object contextObject, IDictionary<string, object> parameters, LogLevel logLevel);

        void LogTraceEvent(TraceType traceType, string message, Exception exception, LogLevel logLevel);
    }
}
