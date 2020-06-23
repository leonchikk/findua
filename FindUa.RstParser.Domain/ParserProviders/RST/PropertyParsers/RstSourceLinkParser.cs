using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstSourceLinkParser : ISourceLinkParser
    {
        public string GetLink(HtmlNode htmlNode, string baseUrl)
        {
            var anchorTag = htmlNode.ChildNodes[0]; //Get first <a> tag
            return $"{baseUrl}{anchorTag.Attributes["href"].Value}";
        }
    }
}
