using System.Net.Http.Headers;
using System.Text.Json;

namespace CarPricePredictor.Classes
{
    public class API
    {
        public async Task InvokeRequestResponseService(CarInfo info)
        {
            var client = new HttpClient();

            const string apiKey = "Ifehu7PxMAeu4qB8mnkG7bLlGyEzFNWb";
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("A key should be provided to invoke the endpoint");
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            client.BaseAddress = new Uri("http://8429f526-e1c1-4fa9-a371-49e66a1a023e.westeurope.azurecontainer.io/score");

            var json = JsonSerializer.Serialize(info);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync("", content);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Result: {0}", result);
            }
            else
            {
                Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                // Print the headers - they include the requert ID and the timestamp,
                // which are useful for debugging the failure
                Console.WriteLine(response.Headers.ToString());

                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
        }
    }
}
