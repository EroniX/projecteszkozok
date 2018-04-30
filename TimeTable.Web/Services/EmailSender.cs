///Fájl neve: EmailSender.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Services
{
    using System.Threading.Tasks;

    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    /// <summary>
    /// Az EmailSender osztály
    /// </summary>
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// Az e-mail elküldését megvalósító függvény
        /// </summary>
        /// <param name="email">Az e-mail cím</param>
        /// <param name="subject">A tárgy</param>
        /// <param name="message">Az üzenet</param>
        /// <returns>A Task objektum</returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
