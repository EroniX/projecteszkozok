///F�jl neve: UrlHelperExtensions.cs
///D�tum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using TimeTableDesigner.Web.Controllers;

    /// <summary>
    /// Az UrlHelperExtensions statikus oszt�ly
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Az e-mail meger�s�t� link�rt felel�s f�ggv�ny
        /// </summary>
        /// <param name="urlHelper">Az urlHelper</param>
        /// <param name="userId">Az userId</param>
        /// <param name="code">A k�d</param>
        /// <param name="scheme">A scheme</param>
        /// <returns>Az e-mail meger�s�t� link</returns>
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        /// <summary>
        /// A jelsz� v�ltoztat�shoz tartoz� callback link�rt felel�s f�ggv�ny
        /// </summary>
        /// <param name="urlHelper">Az urlHelper</param>
        /// <param name="userId">Az userId</param>
        /// <param name="code">A k�d</param>
        /// <param name="scheme">A scheme</param>
        /// <returns>A jelsz�v�ltoztat� callback link</returns>
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
