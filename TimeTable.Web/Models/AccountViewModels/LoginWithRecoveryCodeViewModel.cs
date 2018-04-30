///Fájl neve: LoginWithRecoveryCodeViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A LoginWithRecoveryCodeViewModel osztály
    /// </summary>
    public class LoginWithRecoveryCodeViewModel
    {
        /// <summary>
        /// A "RecoveryCode" adattag (GETTER, SETTER)
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; }
    }
}
