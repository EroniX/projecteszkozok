///Fájl neve: ForgotPasswordViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A ForgotPasswordViewModel osztály
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// Az "Email" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
