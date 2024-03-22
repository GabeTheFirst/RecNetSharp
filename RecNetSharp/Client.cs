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
            if (!string.IsNullOrEmpty(AuthKey))
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

        // gets data from rec.net as a get request and deserialize it
        public async Task<T> Get<T>(string Route)
        {
            // Get the string response from the requested route
            string Result = await RequestClient.GetStringAsync(ApiBaseUrl + Route);

            // if there's no result, return a default value
            if (string.IsNullOrEmpty(Result))
            {
                // return a default value
                return default(T);
            }
            // deserialize the response as the requested type and return it
            return JsonSerializer.Deserialize<T>(Result);
        }

        // post data to rec.net with a string as the content
        public async Task<T> Post<T>(string Route, string Content)
        {
            // gets an HttpResponseMessage variable by posting the data of the string 'Content' as StringContent
            HttpResponseMessage Response = await RequestClient.PostAsync(ApiBaseUrl + Route, new StringContent(Content));
            // read the content of the response as a string
            string Result = await Response.Content.ReadAsStringAsync();

            // if there's no result, return a default value
            if (string.IsNullOrEmpty(Result))
            {
                // return a default value
                return default(T);
            }
            // deserialize the response as the requested type and return it
            return JsonSerializer.Deserialize<T>(Result);
        }

        // post data to rec.net with a form data as the content
        public async Task<T> Post<T>(string Route, MultipartFormDataContent Content)
        {
            // gets an HttpResponseMessage variable by posting the data of the form data variable 'Content' 
            HttpResponseMessage Response = await RequestClient.PostAsync(ApiBaseUrl + Route, Content);
            // read the content of the response as a string
            string Result = await Response.Content.ReadAsStringAsync();

            // if there's no result, return a default value
            if (string.IsNullOrEmpty(Result))
            {
                // return a default value
                return default(T);
            }
            // deserialize the response as the requested type and return it
            return JsonSerializer.Deserialize<T>(Result);
        }
    }
}
