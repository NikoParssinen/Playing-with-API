using System.Text.Json;

var url = $"https://random-data-api.com/api/v2/";
var parameters = "beers?size=20";
HttpClient client = new HttpClient();
client.BaseAddress = new Uri(url);

HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

if (response.IsSuccessStatusCode)
{
    String temp = await response.Content.ReadAsStringAsync();
    string data = @temp;

    using JsonDocument doc = JsonDocument.Parse(data);
    JsonElement root = doc.RootElement;

    Console.WriteLine("| {0,-20} | {1,-42} | {2,-30} | {3,-15} | {4,-35} | {5,-15} | {6,-7} |",
                        "brand", "name", "style", "hop", "yeast", "malts", "alcohol");
    Console.WriteLine("---------------------------------------------------------------------------------------------" +
                      "---------------------------------------------------------------------------------------------");

    int i = 0;
    while (i < root.GetArrayLength())
    {
        var beer = root[i];

        Console.WriteLine("| {0,-20} | {1,-42} | {2,-30} | {3,-15} | {4,-35} | {5,-15} | {6,-7} |",
                        beer.GetProperty("brand"),
                        beer.GetProperty("name"),
                        beer.GetProperty("style"),
                        beer.GetProperty("hop"),
                        beer.GetProperty("yeast"),
                        beer.GetProperty("malts"),
                        beer.GetProperty("alcohol"));
        i++;
    }

}