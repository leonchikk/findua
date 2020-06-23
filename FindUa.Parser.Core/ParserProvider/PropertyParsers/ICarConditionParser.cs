using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface ICarConditionParser
    {
        IEnumerable<int> ParseForPreview(HtmlNode htmlNode);
        IEnumerable<int> ParseForDetailed(HtmlNode htmlNode);
    }
}
