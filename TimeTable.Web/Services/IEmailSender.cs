///Fájl neve: IEmailSender.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Az IEmailSender interfész
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Az e-mail elküldését megvalósító függvény
        /// </summary>
        /// <param name="email">Az e-mail cím</param>
        /// <param name="subject">A tárgy</param>
        /// <param name="message">Az üzenet</param>
        /// <returns>A Task objektum</returns>
        Task SendEmailAsync(string email, string subject, string message);
    }
}
