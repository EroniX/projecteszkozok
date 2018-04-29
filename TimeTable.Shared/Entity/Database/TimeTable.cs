namespace TimeTableDesigner.Shared.Entity.Database
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using EroniX.Core.Domain;

    [Table("Semester")]
    public partial class TimeTable : IHaveActive
    {
        public TimeTable()
        {
            Courses = new HashSet<Course>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Semester { get; set; }

        public bool Active { get; set; }

        public string UserId { get; set; }
        
        public virtual ICollection<Course> Courses { get; set; }
    }
}
