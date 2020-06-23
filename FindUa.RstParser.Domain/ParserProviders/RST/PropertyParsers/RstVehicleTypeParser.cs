using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;

namespace FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstVehicleTypeParser : IVehicleTypeParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            return (int)GetVehicleType(htmlNode);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private VehicleTypeEnum GetVehicleType(HtmlNode htmlNode)
        {
            var offerBlock = htmlNode.OwnerDocument
                .GetElementbyId("rst-page-oldcars-tree-block");

            var bodyTypeBlock = htmlNode.Descendants()
                   .Where(n => n.InnerText.Contains("Тип кузова"))
                   .ToList();

            var isTableRepresentation = bodyTypeBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";
            var bodyTypeString = bodyTypeBlock.FirstOrDefault(x => x.Name == targetTag).ChildNodes.Last().InnerText;

            if (offerBlock.InnerText.Contains("Прицеп", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Trailer;

            if (offerBlock.InnerText.Contains("Мото", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Moto;

            if (offerBlock.InnerText.Contains("Авиатехника", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.AirTransport;

            if (offerBlock.InnerText.Contains("Спецтехника", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.SpecialMachinery;

            if (offerBlock.InnerText.Contains("ВОДНЫЙ ТР.", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.WaterTtransport;

            if (bodyTypeString.Contains("Тягач", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Trucks;

            if (bodyTypeString.Contains("Самосвал", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Trucks;

            if (bodyTypeString.Contains("Шасси", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Trucks;

            if (bodyTypeString.Contains("Микроавтобус грузовой", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Trucks;

            if (bodyTypeString.Contains("Фургон/пикап грузовой", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Trucks;

            if (bodyTypeString.Contains("Автобус", StringComparison.OrdinalIgnoreCase))
                return VehicleTypeEnum.Bus;

            return VehicleTypeEnum.PassengerCar;
        }
    }
}
