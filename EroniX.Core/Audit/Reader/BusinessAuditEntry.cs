using System;
using EroniX.Core.Domain;

namespace EroniX.Core.Audit.Reader
{
    public class BusinessAuditEntry : Entity
    {
        public DateTime When { get; set; }

        public string User { get; set; }

        public int EventId { get; set; }

        public string EventDesc { get; set; }

        public string Level { get; set; }

        public bool Success { get; set; }

        public string Machine { get; set; }

        public string Class { get; set; }

        public string Method { get; set; }

        public string Details { get; set; }

        public Guid CorrelationToken { get; set; }
    }
}
