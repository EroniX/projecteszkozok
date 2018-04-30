///Fájl neve: User.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Database
{
    using EroniX.Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// A User osztály
    /// </summary>
    [Table("User")]
    public partial class User : IHaveActive
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy User objektumot
        /// </summary>
        public User()
        {
            TimeTables = new HashSet<TimeTable>();
        }

        /// <summary>
        /// Az "Id" adattag (GETTER, SETTER)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// A "Username" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Username { get; set; }

        /// <summary>
        /// A "Password" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Password { get; set; }

        /// <summary>
        /// Az "Email" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        /// <summary>
        /// A "LastLoginDate" adattag (GETTER, SETTER)
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// A "RegistrationDate" adattag (GETTER, SETTER)
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Az "Active" adattag (GETTER, SETTER)
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// A "TimeTables" adattag (GETTER, SETTER)
        /// </summary>
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
