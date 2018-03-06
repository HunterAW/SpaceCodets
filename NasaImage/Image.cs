using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace NasaImage
{
    public class Image
    {
        private const string Address = "https://api.nasa.gov/planetary/apod?api_key=jJSnOuXvEk2vL2QFgxcuqVgWSgmtopRCJ48Av4JC";

        public string Title { get; set; }
        public string Url { get; set; }
        public string Copyright { get; set; }
        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        public static Task<Image> RequestApod()
        {
            var client = new RestClient(Address);
            var request = new RestRequest(Method.GET);
            var taskCompletionSource = new TaskCompletionSource<Image>();
            var asyncHandle = client.ExecuteAsync<Image>(request, response =>
            {
                taskCompletionSource.SetResult(response.Data);
            });

            return taskCompletionSource.Task;
        }
    }
}
