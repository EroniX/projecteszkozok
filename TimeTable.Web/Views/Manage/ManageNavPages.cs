///Fájl neve: ManageNavPages.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Views.Manage
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using System;

    /// <summary>
    /// A ManageNavPages statikus osztály
    /// </summary>
    public static class ManageNavPages
    {
        /// <summary>
        /// Az "ActivePageKey" metódus
        /// </summary>
        public static string ActivePageKey => "ActivePage";

        /// <summary>
        /// Az "Index" metódus
        /// </summary>
        public static string Index => "Index";

        /// <summary>
        /// A "ChangePassword" metódus
        /// </summary>
        public static string ChangePassword => "ChangePassword";

        /// <summary>
        /// Az "ExternalLogins" metódus
        /// </summary>
        public static string ExternalLogins => "ExternalLogins";

        /// <summary>
        /// A "TwoFactorAuthentication" metódus
        /// </summary>
        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        /// <summary>
        /// Az "IndexNavClass" metódus
        /// </summary>
        /// <param name="viewContext">A ViewContext</param>
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        /// <summary>
        /// A "ChangePasswordNavClass" metódus
        /// </summary>
        /// <param name="viewContext">A ViewContext</param>
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        /// <summary>
        /// Az "ExternalLoginsNavClass" metódus
        /// </summary>
        /// <param name="viewContext">A ViewContext</param>
        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        /// <summary>
        /// A "TwoFactorAuthenticationNavClass" metódus
        /// </summary>
        /// <param name="viewContext">A ViewContext</param>
        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        /// <summary>
        /// A "PageNavClass" metódus
        /// </summary>
        /// <param name="viewContext">A ViewContext</param>
        /// <param name="page">Az oldal</param>
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        /// <summary>
        /// Az "AddActivePage" metódus
        /// </summary>
        /// <param name="viewData">A viewData</param>
        /// <param name="activePage">Az aktív oldal</param>
        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
