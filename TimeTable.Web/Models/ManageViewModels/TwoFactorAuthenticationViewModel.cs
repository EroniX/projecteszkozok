///Fájl neve: TwoFactorAuthenticationViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.ManageViewModels
{
    /// <summary>
    /// A TwoFactorAuthenticationViewModel osztály
    /// </summary>
    public class TwoFactorAuthenticationViewModel
    {
        /// <summary>
        /// A "HasAuthenticator" adattag (GETTER, SETTER)
        /// </summary>
        public bool HasAuthenticator { get; set; }

        /// <summary>
        /// A "RecoveryCodesLeft" adattag (GETTER, SETTER)
        /// </summary>
        public int RecoveryCodesLeft { get; set; }

        /// <summary>
        /// Az "Is2faEnabled" adattag (GETTER, SETTER)
        /// </summary>
        public bool Is2faEnabled { get; set; }
    }
}
