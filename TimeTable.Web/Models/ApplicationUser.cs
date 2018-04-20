using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
