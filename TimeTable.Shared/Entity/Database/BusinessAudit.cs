using EroniX.Core.Domain;

namespace TimeTableDesigner.Shared.Entity.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BusinessAudit")]
    public partial class BusinessAudit : IEntity
    {
        public int Id { get; set; }

        public DateTime When { get; set; }

        [Required]
        [StringLength(50)]
        public string User { get; set; }

        public int EventId { get; set; }

        [Required]
        [StringLength(256)]
        public string EventDesc { get; set; }

        [Required]
        [StringLength(10)]
        public string Level { get; set; }

        public bool Success { get; set; }

        [Required]
        [StringLength(16)]
        public string Machine { get; set; }

        [Required]
        [StringLength(100)]
        public string Class { get; set; }

        [Required]
        [StringLength(50)]
        public string Method { get; set; }

        [Column(TypeName = "xml")]
        public string Details { get; set; }

        public Guid CorrelationToken { get; set; }

        public int? TestIntValue { get; set; }

        [StringLength(50)]
        public string TestStringValue { get; set; }
    }
}
