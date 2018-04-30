///Fájl neve: ApplicationUser.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using TimeTableDesigner.Shared.Entity.Database;

    // Add profile data for application users by adding properties to the ApplicationUser class
    /// <summary>
    /// Az ApplicationUser osztály
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// A "TimeTables" virtuális adattag (GETTER, SETTER)
        /// </summary>
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
