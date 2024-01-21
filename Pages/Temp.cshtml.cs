using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace mvcMovie.Pages{
    public class TempModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TempModel(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

        public IEnumerable<CoinInfo>? Coins {get; set;}

        public async Task OnGet()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,"https://api.coinpaprika.com/v1/tickers");
            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if(httpResponseMessage.IsSuccessStatusCode){
                
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                Coins = await JsonSerializer.DeserializeAsync<IEnumerable<CoinInfo>>(contentStream);
            }

        }
    }

    public record class CoinInfo
    {
        public record class Quotes{

            public record class USD{
                public float? price = null;
            }
            public USD? usd= null;
        }
        public string? id = null;
        public string? name= null;
        public string? symbol= null;   

        public Quotes? quotes = null;     
    }
}