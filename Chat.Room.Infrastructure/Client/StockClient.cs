using System.Net;
using Chat.Room.Domain.Model;
using Chat.Room.Infrastructure.Client.Interfaces;
using Chat.Room.Infrastructure.Configuration.Interfaces;
using Chat.Room.Shared.FlowControl.Enum;
using Chat.Room.Shared.FlowControl.Model;
using Newtonsoft.Json;

namespace Chat.Room.Infrastructure.Client
{
    public class StockClient : IStockClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILoginSession _loginSession;

        public StockClient(IHttpClientFactory httpClientFactory,
                           ILoginSession loginSession)
        {
            _httpClient = httpClientFactory.CreateClient("StockBotClient");
            _loginSession = loginSession;
        }

        public async Task<Result<Stock>> GetStockAsync(string stockCode)
        {
            // var resource = $"/api/Stock?{stockCode.Replace("/stock", "code")}";
            //
            // _httpClient.DefaultRequestHeaders.Add("Authorization", _loginSession.Token);
            //
            // using var httpclient = await _httpClient.GetAsync(resource);
            //
            // var response = httpclient.Content.ReadAsStringAsync();
            // if (!httpclient.IsSuccessStatusCode)
            //     return Result.Fail<Stock>(new Error(ErrorType.Business, response.Result));
            //
            // var stock = JsonConvert.DeserializeObject<Stock>(response.Result);
            
            return Result.Ok(new Stock());
        }
    }
}