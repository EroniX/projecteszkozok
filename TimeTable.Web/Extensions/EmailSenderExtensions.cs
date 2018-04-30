///Fájl neve: EmailSenderExtensions.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Extensions
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using TimeTableDesigner.Web.Services;

    /// <summary>
    /// Az EmailSenderExtensions statikus osztály
    /// </summary>
    public static class EmailSenderExtensions
    {
        /// <summary>
        /// Az e-mail elküldéséért felelõs statikus függvény
        /// </summary>
        /// <param name="emailSender">Az emailSender</param>
        /// <param name="email">Az email</param>
        /// <param name="link">A link</param>
        /// <returns>A Task objektum</returns>
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
