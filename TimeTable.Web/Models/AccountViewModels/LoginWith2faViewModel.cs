///Fájl neve: LoginWith2faViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A LoginWith2faViewModel osztály
    /// </summary>
    public class LoginWith2faViewModel
    {
        /// <summary>
        /// Az "TwoFactorCode" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator code")]
        public string TwoFactorCode { get; set; }

        /// <summary>
        /// Az "RememberMachine" adattag (GETTER, SETTER)
        /// </summary>
        [Display(Name = "Remember this machine")]
        public bool RememberMachine { get; set; }

        /// <summary>
        /// Az "RememberMe" adattag (GETTER, SETTER)
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
