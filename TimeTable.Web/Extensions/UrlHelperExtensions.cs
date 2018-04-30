///Fájl neve: UrlHelperExtensions.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using TimeTableDesigner.Web.Controllers;

    /// <summary>
    /// Az UrlHelperExtensions statikus osztály
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Az e-mail megerõsítõ linkért felelõs függvény
        /// </summary>
        /// <param name="urlHelper">Az urlHelper</param>
        /// <param name="userId">Az userId</param>
        /// <param name="code">A kód</param>
        /// <param name="scheme">A scheme</param>
        /// <returns>Az e-mail megerõsítõ link</returns>
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        /// <summary>
        /// A jelszó változtatáshoz tartozó callback linkért felelõs függvény
        /// </summary>
        /// <param name="urlHelper">Az urlHelper</param>
        /// <param name="userId">Az userId</param>
        /// <param name="code">A kód</param>
        /// <param name="scheme">A scheme</param>
        /// <returns>A jelszóváltoztató callback link</returns>
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
