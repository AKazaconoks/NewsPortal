using System.Xml;
using System.Xml.Linq;
using ForTEsts.Models;

namespace ForTEsts.Services;

public class XmlService
{
    public static async Task<List<FeedItem>> GetXmlContent(string url, int amount)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var settings = new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Ignore
        };
        var xmlReader = XmlReader.Create(url, settings);
        return ParseXmlItems(XDocument.Load(xmlReader, LoadOptions.None), amount, "http://search.yahoo.com/mrss/");
    }

    private static List<FeedItem> ParseXmlItems(XDocument xml, int amount, XNamespace mediaNamespace)
    {
        return xml.Descendants("item")
            .Take(amount)
            .Select(item => new FeedItem()
            {
                Title = item.Element("title").Value,
                Link = item.Element("link").Value,
                Description = item.Element("description").Value,
                PubDate = DateTime.Parse(item.Element("pubDate").Value),
                Category = item.Element("category").Value,
                ImageUrl = item.Element(mediaNamespace + "content").Attribute("url").Value
            })
            .ToList();
    }
}