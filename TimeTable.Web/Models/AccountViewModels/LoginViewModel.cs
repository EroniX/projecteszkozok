///Fájl neve: LoginViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A LoginViewModel osztály
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Az "Email" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Az "Password" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        /// <summary>
        /// A "RememberMe" adattag (GETTER, SETTER)
        /// </summary>
        [Display(Name = "Emlékezz rám")]
        public bool RememberMe { get; set; }
    }
}
