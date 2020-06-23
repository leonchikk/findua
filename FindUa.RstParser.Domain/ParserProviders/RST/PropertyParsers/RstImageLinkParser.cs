using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;

namespace FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstImageLinkParser : IImageLinkParser
    {
        public string ParseForDetailed(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        public string ParseForPreview(HtmlNode htmlNode)
        {
            var imageBlock = htmlNode.Descendants()
                .Where(n => n.Name == "img")
                .FirstOrDefault();

            return imageBlock.Attributes["src"].Value;
        }
    }
}
