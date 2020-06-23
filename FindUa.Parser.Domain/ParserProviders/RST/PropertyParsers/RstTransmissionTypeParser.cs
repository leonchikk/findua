using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstTransmissionTypeParser : ITransmissionTypeParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var transmissionBlock = htmlNode.Descendants()
                 .Where(n => n.InnerText.Contains("КПП"))
                 .ToList();

            var isTableRepresentation = transmissionBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var transmissionTypeString = transmissionBlock.FirstOrDefault(x => x.Name == targetTag).ChildNodes.Last().InnerText;

            var transmissionType = (int)GetTransmissionType(ParseTransmissionTypeString(transmissionTypeString));
            return transmissionType;
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new System.NotImplementedException();
        }

        private string ParseTransmissionTypeString(string transmissionTypeString)
        {
            var transmissionType = Regex.Replace(transmissionTypeString, @" \(\w+\)", "");
            return transmissionType;
        }

        private TransmissionTypeEnum GetTransmissionType(string transmissionTypeString)
        {
            if (transmissionTypeString.Contains("Механика"))
                return TransmissionTypeEnum.Mechanical;

            if (transmissionTypeString.Contains("Автомат"))
                return TransmissionTypeEnum.Automatic;

            if (transmissionTypeString.Contains("Типтроник"))
                return TransmissionTypeEnum.Tiptronic;

            return TransmissionTypeEnum.NA;
        }
    }
}
