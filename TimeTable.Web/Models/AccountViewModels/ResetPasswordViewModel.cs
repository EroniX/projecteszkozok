///Fájl neve: ResetPasswordViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A ResetPasswordViewModel osztály
    /// </summary>
    public class ResetPasswordViewModel
    {
        /// <summary>
        /// Az "Email" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// A "Password" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// A "ConfirmPassword" adattag (GETTER, SETTER)
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// A "Code" adattag (GETTER, SETTER)
        /// </summary>
        public string Code { get; set; }
    }
}
