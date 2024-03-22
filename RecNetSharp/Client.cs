using RecNetSharp.Controllers;
using RecNetSharp.Models.RecNetSharp;
using System.Text.Json;

namespace RecNetSharp
{
    public class RecNetClient
    {
        // the key used to authorize API requests
        string Key;

        // the HttpClient used to make API requests
        HttpClient RequestClient;

        // the version of the api in use
        ApiVersion Version;

        // the base url for the public RecNet API
        string ApiBaseUrl = "https://apim.rec.net/public/";

        // the accounts manager
        public AccountController Accounts;

        // the images manager
        public ImagesController Images;

        // the rooms manager
        public RoomsController Rooms;

        // this stores the auth key (might not really be useful) and sets up the HttpClient
        public RecNetClient(string? AuthKey = "", ApiVersion UseVersion = ApiVersion.v1)
        {
            // store the auth key
            Key = AuthKey;

            // store the version
            Version = UseVersion;

            // create the HttpClient
            RequestClient = new HttpClient();

            // set the header for cache control
            RequestClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            // set the header for api version
            RequestClient.DefaultRequestHeaders.Add("Api-Version", UseVersion.ToString());

            // set authorization if provided
            if(!string.IsNullOrEmpty(AuthKey))
            {
                RequestClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AuthKey);
            }

            // set up accounts
            Accounts = new AccountController(this);

            // set up images
            Images = new ImagesController(this);

            // set up rooms
            Rooms = new RoomsController(this);
        }

        public async Task<T> Get<T>(string Route)
        {
            string Result = await RequestClient.GetStringAsync(ApiBaseUrl + Route);
            if (string.IsNullOrEmpty(Result))
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(Result);
        }

        public async Task<T> Post<T>(string Route, string Content)
        {
            HttpResponseMessage Response = await RequestClient.PostAsync(ApiBaseUrl + Route, new StringContent(Content));
            string Result = await Response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(Result))
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(Result);
        }

        public async Task<T> Post<T>(string Route, MultipartFormDataContent Content)
        {
            HttpResponseMessage Response = await RequestClient.PostAsync(ApiBaseUrl + Route, Content);
            string Result = await Response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(Result))
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(Result);
        }
    }
}
