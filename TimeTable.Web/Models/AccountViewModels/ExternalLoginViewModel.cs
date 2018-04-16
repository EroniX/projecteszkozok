using System.ComponentModel.DataAnnotations;

namespace TimeTableDesigner.Web.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
