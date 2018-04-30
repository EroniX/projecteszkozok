///Fájl neve: EnableAuthenticatorViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.ManageViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Az EnableAuthenticatorViewModel osztály
    /// </summary>
    public class EnableAuthenticatorViewModel
    {
        /// <summary>
        /// A "Code" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Verification Code")]
        public string Code { get; set; }

        /// <summary>
        /// A "SharedKey" adattag (GETTER, SETTER)
        /// </summary>
        [ReadOnly(true)]
        public string SharedKey { get; set; }

        /// <summary>
        /// A "AuthenticatorUri" adattag (GETTER, SETTER)
        /// </summary>
        public string AuthenticatorUri { get; set; }
    }
}
