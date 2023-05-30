using HtmlAgilityPack;
using System.Net;
using System.Text;

var client = new WebClient();
string url = "https://teksty-pesenok.ru/rus-lyube/";
string html = client.DownloadString(url);

HtmlDocument page = new HtmlDocument();
page.LoadHtml(html);
var links = page.DocumentNode.SelectNodes("//a[@href]");
foreach (var link in links)
{
    var href = link.Attributes["href"].Value;
    if (href.StartsWith("/") && href.Contains("tekst-pesni"))
    {
        href = url + href;
        html = client.DownloadString(href);
        page.LoadHtml(html);
        var divs = page.DocumentNode.SelectNodes("//div").Where(d => d.HasClass("textPesni"));
        foreach (var div in divs)
        {
            Console.WriteLine(div.InnerText);
        }
        href = "";
    }
    
}