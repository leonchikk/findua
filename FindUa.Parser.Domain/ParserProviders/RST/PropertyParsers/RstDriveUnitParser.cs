using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstDriveUnitParser : IDriveUnitParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var transmissionDriveUNitBlock = htmlNode.Descendants()
                  .Where(n => n.InnerText.Contains("КПП"))
                  .ToList();

            var isTableRepresentation = transmissionDriveUNitBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var driveUnitTypeString = transmissionDriveUNitBlock.FirstOrDefault(x => x.Name == targetTag).InnerText;

            return (int)GetTransmissionType(ParseDriveUnitString(driveUnitTypeString));
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private string ParseDriveUnitString(string driveUnitTypeString)
        {
            var driveUnitType = Regex.Match(driveUnitTypeString, @"\((.*?)\)").Value
                                     .Replace("(", "")
                                     .Replace(")", "");
            return driveUnitType;
        }

        private DriveUnitTypeEnum GetTransmissionType(string driveUnitTypeString)
        {
            switch (driveUnitTypeString)
            {
                case "Полный привод":
                    return DriveUnitTypeEnum.AllWheel;

                case "Передний привод":
                    return DriveUnitTypeEnum.FrontWheel;

                case "Задний привод":
                    return DriveUnitTypeEnum.RearWheel;

                default:
                    return DriveUnitTypeEnum.NA;
            }
        }
    }
}
