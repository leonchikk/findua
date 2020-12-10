using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using FindUa.Parser.Shared.Extensions;
using HtmlAgilityPack;
using System;

namespace FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstDescriptionParser : IDescriptionParser
    {
        public string ParseForDetailed(HtmlNode htmlNode)
        {
            var content = htmlNode.SelectNodes("//*[@id=\"rst-page-oldcars-item-option-block-container-desc\"]");

            if (content == null)
                return string.Empty;

            var description = content["div"].InnerText
                .RemoveSpecialCharacters()
                .RemoveAllTabulations()
                .TrimStart();

            return description;
        }

        public string ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
