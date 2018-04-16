using System.Threading.Tasks;

namespace TimeTableDesigner.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
