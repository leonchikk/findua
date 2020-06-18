using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstMileageParser : IMileageParser
    {
        private  int MileageStringToInt(string str)
        {
            var resultString = Regex.Match(str, @"\d+").Value;
            return int.Parse(resultString);
        }

        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var millageBlock = htmlNode.Descendants()
                .Where(n => n.InnerText.Contains("Пробег", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var isTableRepresentation = millageBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var mileageInfo = millageBlock.FirstOrDefault(x => x.Name == targetTag).ChildNodes.Last().ChildNodes["span"];

            var numberString = mileageInfo.InnerText;

            return MileageStringToInt(numberString);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
