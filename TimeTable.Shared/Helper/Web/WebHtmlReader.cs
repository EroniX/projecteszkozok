///Fájl neve: WebHtmlReader.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Helper.Web
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// A WebHtmlReader osztály
    /// </summary>
    public class WebHtmlReader : IWebHtmlReader, IDisposable
    {
        /// <summary>
        /// A HttpClient adattag
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// _httpClient inicializálása
        /// </summary>
        protected HttpClient HttpClient=> _httpClient ?? (_httpClient = new HttpClient());

        /// <summary>
        /// Aszinkron POST kérés
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <param name="postParams">A POST paraméterek</param>
        /// <returns>A POST kérésre kapott válasz</returns>
        public async Task<string> GetHtmlByPostAsync(string uri, Dictionary<string, string> postParams)
        {
            var header = new FormUrlEncodedContent(postParams);

            var response = await HttpClient.PostAsync(
                uri,
                header);

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// POST kérés
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <param name="postParams">A POST paraméterek</param>
        /// <returns>A POST kérésre kapott válasz</returns>
        public string GetHtmlByPost(string uri, Dictionary<string, string> postParams)
        {
            return GetHtmlByPostAsync(uri, postParams).Result;
        }

        /// <summary>
        /// Aszinkron GET kérés
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <returns>A GET kérésre kapott válasz</returns>
        public async Task<string> GetHtmlAsync(string uri)
        {
            return await HttpClient.GetStringAsync(uri);
        }

        /// <summary>
        /// GET kérés
        /// </summary>
        /// <param name="uri">Az URI</param>
        /// <returns>A GET kérésre kapott válasz</returns>
        public string GetHtml(string uri)
        {
            return GetHtmlAsync(uri).Result;
        }

        /// <summary>
        /// HttpClient erőforrás elengedését megvalósító függvény
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
