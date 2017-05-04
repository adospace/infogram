using infogram_net.Elements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace infogram_net
{
    public class InfogramClient
    {
        public readonly string ApiKey;
        public readonly string ApiSecret;

        private const string BASE_URL = "https://infogr.am/service/v1/";

        public InfogramClient(string apiKey, string apiSecret)
        {
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (apiSecret == null) throw new ArgumentNullException(nameof(apiSecret));

            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        private string EncodeParamatersAsString(string target, string method, Parameter[] parameters)
        {
            var paramsList = new List<Parameter>(parameters);

            paramsList.Add(new Parameter("api_key", ApiKey));
            var signature = Helpers.ComputeSignature(string.Concat(BASE_URL, target), method, paramsList, ApiSecret);
            paramsList.Add(new Parameter("api_sig", signature));

            return Helpers.EncodedParameterStringFromList(paramsList);
        }

        public async Task<string> GetAsync(string target, params Parameter[] parameters)
        {
            var client = new HttpClient() { BaseAddress = new Uri(BASE_URL, UriKind.Absolute) };

            var query = EncodeParamatersAsString(target, "GET", parameters);

            var response = await client.GetAsync(new Uri(string.Concat(target, "?", query), UriKind.Relative));

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<string> PutAsync(string target, params Parameter[] parameters)
        {
            var client = new HttpClient() { BaseAddress = new Uri(BASE_URL, UriKind.Absolute) };
            var postData = EncodeParamatersAsString(target, "PUT", parameters);

            var response = await client.PutAsync(new Uri(target, UriKind.Relative), new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"));

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<string> PostAsync(string target, params Parameter[] parameters)
        {
            var client = new HttpClient() { BaseAddress = new Uri(BASE_URL, UriKind.Absolute) };
            var postData = EncodeParamatersAsString(target, "POST", parameters);

            var response = await client.PostAsync(new Uri(target, UriKind.Relative), new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"));

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<string> DeleteAsync(string target, params Parameter[] parameters)
        {
            var client = new HttpClient() { BaseAddress = new Uri(BASE_URL, UriKind.Absolute) };

            var query = EncodeParamatersAsString(target, "DELETE", parameters);

            var response = await client.DeleteAsync(new Uri(string.Concat(target, "?", query), UriKind.Relative));

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<Infographic[]> GetInfographicsAsync()
        {
            var res = await GetAsync("infographics");

            return JsonConvert.DeserializeObject<Infographic[]>(res);
        }

        public async Task<Infographic[]> GetInfographicsAsync(string userProfile)
        {
            var res = await GetAsync($"users/{userProfile}/infographics");

            return JsonConvert.DeserializeObject<Infographic[]>(res);
        }

        public async Task<Infographic> GetInfographicAsync(Guid id)
        {
            var res = await GetAsync($"infographics/{id}");

            return JsonConvert.DeserializeObject<Infographic>(res);
        }

        public async Task UpdateInfographicAsync(Guid id, int themeId,
            string content = null,
            bool? publish = null,
            string publishMode = null,
            string password = null,
            string title = null,
            int? width = null,
            string copyright = null)
        {
            if (id == Guid.Empty) throw new ArgumentException("id empty", nameof(id));
            if (themeId <= 0) throw new ArgumentException("invalid theme_id", nameof(content));

            var listofParameters = new List<Parameter>();

            listofParameters.Add(new Parameter("theme_id", themeId.ToString()));

            if (content != null)
                listofParameters.Add(new Parameter("content", content));
            if (publish != null)
                listofParameters.Add(new Parameter("publish", publish.Value.ToString()));
            if (publishMode != null)
                listofParameters.Add(new Parameter("publishMode", publishMode));
            if (password != null)
                listofParameters.Add(new Parameter("password", password));
            if (title != null)
                listofParameters.Add(new Parameter("title", title));
            if (width != null)
                listofParameters.Add(new Parameter("width", width.ToString()));
            if (copyright != null)
                listofParameters.Add(new Parameter("copyright", copyright));

            await PutAsync($"infographics/{id}", listofParameters.ToArray());
        }

        public async Task UpdateInfographicAsync(Infographic infographic,
            string content = null,
            bool? publish = null,
            string publishMode = null,
            string password = null,
            string title = null,
            int? width = null,
            string copyright = null)
        {
            await UpdateInfographicAsync(infographic.Id, infographic.ThemeId, content, publish, publishMode, password, title, width, copyright);
        }

        public async Task UpdateInfographicAsync(Infographic infographic,
            Element[] content,
            bool? publish = null,
            string publishMode = null,
            string password = null,
            string title = null,
            int? width = null,
            string copyright = null)
        {
            await UpdateInfographicAsync(infographic.Id, infographic.ThemeId, content != null ? JsonConvert.SerializeObject(content) : null, publish, publishMode, password, title, width, copyright);
        }

        public async Task UpdateInfographicAsync(Guid id, int themeId,
            Element[] content,
            bool? publish = null,
            string publishMode = null,
            string password = null,
            string title = null,
            int? width = null,
            string copyright = null)
        {
            await UpdateInfographicAsync(id, themeId, content != null ? JsonConvert.SerializeObject(content) : null, publish, publishMode, password, title, width, copyright);
        }

        public async Task<Infographic> CreateInfographic(int themeId, string content,
            bool? publish = null,
            string publishMode = null,
            string password = null,
            string title = null,
            int? width = null,
            string copyright = null)
        {
            if (themeId <= 0) throw new ArgumentException("invalid theme_id", nameof(content));
            if (content == null) throw new ArgumentNullException(nameof(content));

            var listofParameters = new List<Parameter>();

            listofParameters.Add(new Parameter("theme_id", themeId.ToString()));
            listofParameters.Add(new Parameter("content", content));

            if (publish != null)
                listofParameters.Add(new Parameter("publish", publish.Value.ToString()));
            if (publishMode != null)
                listofParameters.Add(new Parameter("publishMode", publishMode));
            if (password != null)
                listofParameters.Add(new Parameter("password", password));
            if (title != null)
                listofParameters.Add(new Parameter("title", title));
            if (width != null)
                listofParameters.Add(new Parameter("width", width.ToString()));
            if (copyright != null)
                listofParameters.Add(new Parameter("copyright", copyright));

            string res = await PostAsync($"infographics", listofParameters.ToArray());

            return JsonConvert.DeserializeObject<Infographic>(res);
        }

        public async Task<Infographic> CreateInfographic(int themeId, Element[] content,
            bool? publish = null,
            string publishMode = null,
            string password = null,
            string title = null,
            int? width = null,
            string copyright = null)
        {
            return await CreateInfographic(themeId, JsonConvert.SerializeObject(content),
                publish,
                publishMode,
                password,
                title,
                width,
                copyright);
        }

        public async Task DeleteInfographic(Guid id)
        {
            await DeleteAsync($"infographics/{id}");
        }

        public async Task<Theme[]> GetThemesAsync()
        {
            var res = await GetAsync("themes");

            return JsonConvert.DeserializeObject<Theme[]>(res);
        }
    }
}
