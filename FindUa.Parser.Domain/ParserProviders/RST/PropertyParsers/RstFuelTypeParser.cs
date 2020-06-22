using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstFuelTypeParser : IFuelTypeParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var fuelEngineBlock = htmlNode.Descendants()
                 .Where(n => n.InnerText.Contains("Двигатель"))
                 .ToList();

            var isTableRepresentation = fuelEngineBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var fuelTypeString = fuelEngineBlock.FirstOrDefault(x => x.Name == targetTag).InnerText;

            var fuelType = (int)GetFueltType(ParseFuelTypeString(fuelTypeString));
            return fuelType;
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private string ParseFuelTypeString(string fuelTypeString)
        {
            var fuelType = Regex.Match(fuelTypeString, @"\(\w+\)").Value
                             .Replace("(", "")
                             .Replace(")", "");


            return fuelType;
        }

        private FuelTypeEnum GetFueltType(string fuelTypeString)
        {
            switch (fuelTypeString)
            {
                case "Бензин":
                    return FuelTypeEnum.Petrol;

                case "Дизель":
                    return FuelTypeEnum.Diesel;

                case "Газ/Бензин":
                    return FuelTypeEnum.PetrolAndGas;

                case "Газ":
                    return FuelTypeEnum.Gas;

                case "Гибрид":
                    return FuelTypeEnum.Hybrid;

                case "Электро":
                    return FuelTypeEnum.Electric;

                default:
                    return FuelTypeEnum.NA;
            }
        }
    }
}
