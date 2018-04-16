using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TimeTableDesigner.Shared.Helper.Web
{
    public class WebHtmlReader : IWebHtmlReader, IDisposable
    {
        private HttpClient _httpClient;

        protected HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());

        public async Task<string> GetHtmlByPostAsync(string uri, Dictionary<string, string> postParams)
        {
            var header = new FormUrlEncodedContent(postParams);

            var response = await HttpClient.PostAsync(
                uri,
                header);

            return await response.Content.ReadAsStringAsync();
        }

        public string GetHtmlByPost(string uri, Dictionary<string, string> postParams)
        {
            return GetHtmlByPostAsync(uri, postParams).Result;
        }

        public async Task<string> GetHtmlAsync(string uri)
        {
            return await HttpClient.GetStringAsync(uri);
        }

        public string GetHtml(string uri)
        {
            return GetHtmlAsync(uri).Result;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
