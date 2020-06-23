using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstPriceParser : IPriceParser
    {
        public double ParseForDetailed(HtmlNode htmlNode)
        {
            var priceBlock = htmlNode.Descendants()
                .Where(n => n.InnerText.Contains("Цена"))
                .ToList();

            var isTableRepresentation = priceBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var priceString = priceBlock.Where(x => x.Name == targetTag).First().InnerText;

            return ParsePriceString(priceString);
        }

        public double ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private double ParsePriceString(string str)
        {
            var dollarPriceStr = str.Replace("'", "");

            dollarPriceStr = Regex.Match(dollarPriceStr, @"\$\d+")
                                    .Value
                                    .Replace("$", "");

            return double.Parse(dollarPriceStr);
        }
    }
}
