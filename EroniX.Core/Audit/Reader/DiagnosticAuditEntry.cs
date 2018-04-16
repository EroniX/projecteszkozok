using System;
using EroniX.Core.Domain;

namespace EroniX.Core.Audit.Reader
{
    public class DiagnosticAuditEntry : Entity
    {
        public DateTime When { get; set; }

        public string User { get; set; }

        public string EventType { get; set; }

        public string Level { get; set; }

        public string Machine { get; set; }

        public string Class { get; set; }

        public string Method { get; set; }

        public string ExceptionType { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public Guid CorrelationToken { get; set; }
    }
}
