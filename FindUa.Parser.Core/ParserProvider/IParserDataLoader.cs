using HtmlAgilityPack;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.ParserProvider
{
    public interface IParserDataLoader
    {
        Task<HtmlDocument> LoadHtmlDocumentAsync();
    }
}
