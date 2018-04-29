using EroniX.Core.Domain;

namespace TimeTableDesigner.Shared.Entity.Database
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Course")]
    public partial class Course : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int TimeTableId { get; set; }

        [Required]
        [StringLength(128)]
        public string CourseId { get; set; }

        [Required]
        [StringLength(128)]
        public string CourseNumber { get; set; }

        public bool Active { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}
