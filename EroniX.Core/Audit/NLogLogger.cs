using System;
using System.Collections.Generic;
using System.Diagnostics;
using NLog;

namespace EroniX.Core.Audit
{
    public sealed class NLogLogger : Logger
    {
        public NLogLogger(IAppContextProvider contextProvider) : base(contextProvider)
        {
        }

        public override void LogBusinessEvent(bool success, int code, string msg, object contextObject, IDictionary<string, object> parameters, LogLevel logLevel)
        {
            var stackTrace = new StackTrace(2);
            var loggerCallSite = GetCallingMethod(stackTrace);
            var nlogLogLevel = ToNLogLoglevel(logLevel);

            var logger = LogManager.GetLogger("[business]" + loggerCallSite.ClassName);

            LogEventInfo logEvent = new LogEventInfo(nlogLogLevel, "[business]" + loggerCallSite.ClassName, msg);
            logEvent.Properties["business_Code"] = code;
            logEvent.Properties["business_AppUser"] = ContextProvider.UserName;
            logEvent.Properties["business_ContextObject"] = contextObject;
            logEvent.Properties["business_Success"] = success;
            logEvent.Properties["business_Class"] = loggerCallSite.ClassName;
            logEvent.Properties["business_Method"] = loggerCallSite.MethodName;
            logEvent.Properties["business_Details"] = ToXml(contextObject);
            logEvent.Properties["business_CorrelationToken"] = ContextProvider.RequestCorrelationToken;

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    logEvent.Properties[param.Key] = param.Value;
                }
            }

            logger.Log(logEvent);
        }

        public override void LogTraceEvent(TraceType traceType, string message, Exception exception, LogLevel logLevel)
        {
            var stackTrace = new StackTrace(2);
            var loggerCallSite = GetCallingMethod(stackTrace);
            var nlogLogLevel = ToNLogLoglevel(logLevel);

            var logger = LogManager.GetLogger("[diagnostic]" + loggerCallSite.ClassName);

            LogEventInfo logEvent = new LogEventInfo(nlogLogLevel, "[diagnostic]" + loggerCallSite.ClassName, message);
            logEvent.Properties["diagnostic_AppUser"] = ContextProvider.UserName;
            logEvent.Properties["diagnostic_EventType"] = traceType.ToString();
            logEvent.Properties["diagnostic_Class"] = loggerCallSite.ClassName;
            logEvent.Properties["diagnostic_Method"] = loggerCallSite.MethodName;
            logEvent.Properties["diagnostic_ExceptionType"] = exception?.GetType()?.FullName;
            logEvent.Properties["diagnostic_StackTrace"] = exception?.ToString() ?? stackTrace.ToString();
            logEvent.Properties["diagnostic_CorrelationToken"] = ContextProvider.RequestCorrelationToken;

            logger.Log(logEvent);
        }

        private NLog.LogLevel ToNLogLoglevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Fatal:return NLog.LogLevel.Fatal;
                case LogLevel.Error:return NLog.LogLevel.Error;
                case LogLevel.Warning:return NLog.LogLevel.Warn;
                case LogLevel.Information:return NLog.LogLevel.Info;
                case LogLevel.Debug:return NLog.LogLevel.Debug;
                case LogLevel.Trace:return NLog.LogLevel.Trace;
            }
            return NLog.LogLevel.Off;
        }
    }
}
