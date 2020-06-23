using HtmlAgilityPack;
using System.Threading.Tasks;

namespace FindUa.Parser.Core
{
    public interface IDataLoader
    {
        Task<HtmlDocument> LoadHtmlDocumentAsync(string url);
    }
}
