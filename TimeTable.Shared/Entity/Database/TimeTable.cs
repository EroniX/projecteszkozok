///Fájl neve: TimeTable.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Database
{
    using EroniX.Core.Domain;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// A TimeTable osztály
    /// </summary>
    [Table("Semester")]
    public partial class TimeTable : IHaveActive
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy TimeTable objektumot
        /// </summary>
        public TimeTable()
        {
            Courses = new HashSet<Course>();
        }

        /// <summary>
        /// Az "Id" adattag (GETTER, SETTER)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Az "Name" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Az "Semester" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Semester { get; set; }

        /// <summary>
        /// Az "Active" adattag (GETTER, SETTER)
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// A "UserId" adattag (GETTER, SETTER)
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// A "Courses" adattag (GETTER, SETTER)
        /// </summary>
        public virtual ICollection<Course> Courses { get; set; }

        /// <summary>
        /// A "User" adattag (GETTER, SETTER)
        /// </summary>
        public virtual User User { get; set; }
    }
}
