using HtmlAgilityPack;
using System;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IPublishDateParser
    {
        DateTime ParseForPreview(HtmlNode htmlNode);
        DateTime ParseForDetailed(HtmlNode htmlNode);
    }
}
