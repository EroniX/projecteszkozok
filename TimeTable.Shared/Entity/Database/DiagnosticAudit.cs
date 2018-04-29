using EroniX.Core.Domain;

namespace TimeTableDesigner.Shared.Entity.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DiagnosticAudit")]
    public partial class DiagnosticAudit : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime When { get; set; }

        [Required]
        [StringLength(50)]
        public string User { get; set; }

        [Required]
        [StringLength(10)]
        public string EventType { get; set; }

        [Required]
        [StringLength(10)]
        public string Level { get; set; }

        [Required]
        [StringLength(16)]
        public string Machine { get; set; }

        [Required]
        [StringLength(100)]
        public string Class { get; set; }

        [Required]
        [StringLength(50)]
        public string Method { get; set; }

        [StringLength(100)]
        public string ExceptionType { get; set; }

        [Required]
        [StringLength(2048)]
        public string Message { get; set; }

        [Required]
        public string StackTrace { get; set; }

        public Guid CorrelationToken { get; set; }
    }
}
