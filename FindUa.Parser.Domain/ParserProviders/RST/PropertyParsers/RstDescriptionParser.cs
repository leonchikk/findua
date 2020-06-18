using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using FindUa.Parser.Domain.Extensions;
using HtmlAgilityPack;
using System;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstDescriptionParser : IDescriptionParser
    {
        public string ParseForDetailed(HtmlNode htmlNode)
        {
            var content = htmlNode.SelectNodes("//*[@id=\"rst-page-oldcars-item-option-block-container-desc\"]");
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
