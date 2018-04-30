///Fájl neve: SecurityContext.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TimeTableDesigner.Web.Models;

    /// <summary>
    /// A SecurityContext osztály
    /// </summary>
    public class SecurityContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy SecurityContext objektumot
        /// </summary>
        /// <param name="options">A beállítások</param>
        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// A kontext inicializálására használt függvény
        /// </summary>
        /// <param name="builder">A builder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
