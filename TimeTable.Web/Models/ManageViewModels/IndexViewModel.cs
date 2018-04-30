///Fájl neve: IndexViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Az IndexViewModel osztály
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Az "Username" adattag (GETTER, SETTER)
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Az "IsEmailConfirmed" adattag (GETTER, SETTER)
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Az "Email" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// A "PhoneNumber" adattag (GETTER, SETTER)
        /// </summary>
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// A "StatusMessage" adattag (GETTER, SETTER)
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
