///Fájl neve: IWebHtmlReader.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Helper.Web
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Az IWebHtmlReader interfész
    /// </summary>
    public interface IWebHtmlReader
    {
        /// <summary>
        /// A "GetHtmlByPostAsync" függvény
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <param name="postParams">A POST paraméterek</param>
        /// <returns>A Task objektum</returns>
        Task<string> GetHtmlByPostAsync(string uri, Dictionary<string, string> postParams);

        /// <summary>
        /// A "GetHtmlByPost" függvény
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <param name="postParams">A POST paraméterek</param>
        /// <returns>A string objektum</returns>
        string GetHtmlByPost(string uri, Dictionary<string, string> postParams);

        /// <summary>
        /// A "GetHtmlAsync" függvény
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <returns>A Task objektum</returns>
        Task<string> GetHtmlAsync(string uri);

        /// <summary>
        /// A "GetHtml" függvény
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <returns>A string objektum</returns>
        string GetHtml(string uri);
    }
}
