using Microsoft.AspNetCore.Components;

namespace CarPricePredictor.Classes
{

    public class Client: ComponentBase
    {
        private HttpClient _httpClient;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task CallML()
        {

        }
    }
}
