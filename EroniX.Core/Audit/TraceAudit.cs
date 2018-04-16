using System;
using System.Runtime.CompilerServices;

namespace EroniX.Core.Audit
{
    public sealed class TraceAudit
    {
        private readonly ILogger _logger;

        public TraceAudit(ILogger logger)
        {
            _logger = logger;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PublishException(Exception exception, LogLevel logLevel = LogLevel.Error)
        {
            if (_logger == null)
                return;

            try
            {
                _logger.LogTraceEvent(TraceType.Exception, exception?.Message, exception, logLevel);
            }
            catch
            {
                // TODO
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Enter(LogLevel logLevel = LogLevel.Trace)
        {
            if (_logger == null)
                return;

            try
            {
                _logger.LogTraceEvent(TraceType.Enter, "Enter", null, logLevel);
            }
            catch(Exception ex)
            {
                PublishException(ex);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Leave(LogLevel logLevel = LogLevel.Trace)
        {
            if (_logger == null)
                return;

            try
            {
                _logger.LogTraceEvent(TraceType.Leave, "Leave", null, logLevel);
            }
            catch(Exception ex)
            {
                PublishException(ex);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void UserMessage(string message, LogLevel logLevel = LogLevel.Information)
        {
            if (_logger == null)
                return;

            try
            {
                _logger.LogTraceEvent(TraceType.Message, message, null, logLevel);
            }
            catch (Exception ex)
            {
                PublishException(ex);
            }
        }
    }
}
