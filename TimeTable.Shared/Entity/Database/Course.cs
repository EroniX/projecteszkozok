///Fájl neve: Course.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Database
{
    using EroniX.Core.Domain;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// A Course osztály
    /// </summary>
    [Table("Course")]
    public partial class Course : IHaveActive
    {
        /// <summary>
        /// Az "Id" adattag (GETTER, SETTER)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// A "TimeTableId" adattag (GETTER, SETTER)
        /// </summary>
        public int TimeTableId { get; set; }

        /// <summary>
        /// A "CourseId" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(128)]
        public string CourseId { get; set; }

        /// <summary>
        /// A "CourseNumber" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(128)]
        public string CourseNumber { get; set; }

        /// <summary>
        ///  A "Active" adattag (GETTER, SETTER)
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///  A "TimeTable" virtuális adattag (GETTER, SETTER)
        /// </summary>
        public virtual TimeTable TimeTable { get; set; }
    }
}
