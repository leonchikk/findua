using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface ICarConditionParser
    {
        IEnumerable<TransportCondition> ParseForPreview(HtmlNode htmlNode);
        IEnumerable<TransportCondition> ParseForDetailed(HtmlNode htmlNode);
    }
}
