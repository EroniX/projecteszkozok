///Fájl neve: ChangePasswordViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A ChangePasswordViewModel osztály
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Az "OldPassword" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        /// <summary>
        /// A "NewPassword" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// A "ConfirmPassword" adattag (GETTER, SETTER)
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// A "StatusMessage" adattag (GETTER, SETTER)
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
