namespace TimeTableDesigner.Shared.Entity.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using EroniX.Core.Domain;

    [Table("User")]
    public partial class User : IHaveActive
    {
        public User()
        {
            TimeTables = new HashSet<TimeTable>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Username { get; set; }

        [Required]
        [StringLength(256)]
        public string Password { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }
        
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
