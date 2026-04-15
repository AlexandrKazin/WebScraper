using HtmlAgilityPack;

try
{
string url = args.Length > 0 ? args[0] : "https://example.com/news";
using HttpClient client = new HttpClient();
string html = await client.GetStringAsync(url);

HtmlDocument doc = new HtmlDocument();
doc.LoadHtml(html);

var titles = doc.DocumentNode.SelectNodes("//h2[@class='title']");
if (titles != null)
{
    foreach (var node in titles)
        Console.WriteLine(node.InnerText.Trim());
}
else
{
    Console.WriteLine("No titles found.");
}
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
