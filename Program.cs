using System.Net.Http.Json;

namespace HttpClient
{
    public class Program
    {
        static async Task Main()
        {
            var client = new System.Net.Http.HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://text-translator2.p.rapidapi.com/translate"),
                Headers =
                {
                    { "X-RapidAPI-Key", "9495ed9410msh7befb35f01562fcp16940cjsnd0f895b9ede1" },
                    { "X-RapidAPI-Host", "text-translator2.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "source_language", "en" },
                    { "target_language", "id" },
                    { "text", "What is your name?" },
                }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}