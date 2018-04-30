///Fájl neve: ExternalLoginViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Az ExternalLoginViewModel osztály
    /// </summary>
    public class ExternalLoginViewModel
    {
        /// <summary>
        /// Az "Email" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
