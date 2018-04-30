///Fájl neve: ExternalLoginsViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.ManageViewModels
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    /// <summary>
    /// Az ExternalLoginsViewModel osztály
    /// </summary>
    public class ExternalLoginsViewModel
    {
        /// <summary>
        /// A "CurrentLogins" adattag (GETTER, SETTER)
        /// </summary>
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        /// <summary>
        /// Az "OtherLogins" adattag (GETTER, SETTER)
        /// </summary>
        public IList<AuthenticationScheme> OtherLogins { get; set; }

        /// <summary>
        /// A "ShowRemoveButton" adattag (GETTER, SETTER)
        /// </summary>
        public bool ShowRemoveButton { get; set; }

        /// <summary>
        /// A "StatusMessage" adattag (GETTER, SETTER)
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
