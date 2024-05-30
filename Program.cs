using Newtonsoft.Json;
using SystemNet;
using Week16BitCoinApp;


BitCoinRate bitcoin = GetRates()

Console.WriteLine($"Current BitCoin rate is: {bitcoin.bpi.EUR.rate_float} {bitcoin.bpi.EUR.code}");

static BitCoinRate GetRates()
{
    string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

    HttpsWebRequest request = (HttpsWebRequest)WebRequest.Create(url);
    request.Method = "GET";

    var WebResponse = request.GetResponse();
    var webStream = WebResponse.GetResponseStream();

    BitCoinRate bitcoinRate;

    using (var responseReader = new StreamReader(webStream))
    {
        var response = responseReader.ReadToEnd();
        bitcoinRate = JsonConvert.DeserializeObject<bitcoinRate>(response);
    }


    return bitcoinRate;
}


