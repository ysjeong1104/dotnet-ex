using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mvcMovie.Pages
{
    public class CoinTrackerModel : PageModel
    {
        private List<CoinInfo>? CoinList {get; set;}
        private static HttpClient sharedClient = new (){
            BaseAddress = new Uri("https://api.coinpaprika.com"),
        };
        private readonly ILogger<CoinTrackerModel> _logger;

        public CoinTrackerModel(ILogger<CoinTrackerModel> logger)
        {
            _logger = logger;
        }

        public List<CoinInfo>? GetCoinInfos(){
            return CoinList;
        }
        public async Task OnGet()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync("v1/tickers");

            if(response.IsSuccessStatusCode){
                var jsonResponse = await response.Content.ReadAsStringAsync();
                CoinList = JsonConvert.DeserializeObject<List<CoinInfo>>(jsonResponse);
            }
            else
                CoinList = null;

         //   Console.WriteLine(CoinList.ToString());

          //  foreach(CoinInfo coin in CoinList){
           //     Console.WriteLine(coin.id);
          //  }
            

      /*      WebRequest request = WebRequest.Create("https://api.coinpaprika.com/v1/tickers"); // 호출할 url
            request.Method = "GET";
                    
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
     
            string responseFromServer = reader.ReadToEnd();

           var coinList = JsonSerializer.Deserialize<List<CoinInfo>>(responseFromServer);
     
            Console.WriteLine(coinList); // response 출력
     
            reader.Close();
            dataStream.Close();
            response.Close();

            foreach(var coin in coinList){
                Console.WriteLine(coin.id);
            }*/

        }
    }
}