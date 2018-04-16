using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTableDesigner.Shared.Helper.Web
{
    public interface IWebHtmlReader
    {
        Task<string> GetHtmlByPostAsync(string uri, Dictionary<string, string> postParams);
        string GetHtmlByPost(string uri, Dictionary<string, string> postParams);
        Task<string> GetHtmlAsync(string uri);
        string GetHtml(string uri);
    }
}
