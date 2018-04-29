using EroniX.Core.Domain;

namespace TimeTableDesigner.Shared.Entity.Database
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TimeTable")]
    public partial class TimeTable : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeTable()
        {
            Course = new HashSet<Course>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Semester { get; set; }

        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        public bool Active { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Course { get; set; }
    }
}
