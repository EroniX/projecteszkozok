using System;
using System.Collections.Generic;

namespace EroniX.Core.Audit
{
    public sealed class BusinessAudit
    {
        private readonly ILogger _logger;

        public BusinessAudit(ILogger logger)
        {
            _logger = logger;
        }

        public void Success(int code, string msg, Func<object> getContextObject = null, Func<IDictionary<string, object>> getParams = null, LogLevel logLevel = LogLevel.Information)
        {
            if (_logger == null)
                return;

            try
            {
                _logger.LogBusinessEvent(true, code, msg, getContextObject?.Invoke(), getParams?.Invoke(), logLevel);
            }
            catch(Exception ex)
            {
                new TraceAudit(_logger).PublishException(ex);
            }
        }

        public void Fail(int code, string msg, Func<object> getContextObject = null, Func<IDictionary<string, object>> getParams = null, LogLevel logLevel = LogLevel.Warning)
        {
            if (_logger == null)
                return;

            try
            {
                _logger.LogBusinessEvent(false, code, msg, getContextObject?.Invoke(), getParams?.Invoke(), logLevel);
            }
            catch (Exception ex)
            {
                new TraceAudit(_logger).PublishException(ex);
            }
        }
    }
}
