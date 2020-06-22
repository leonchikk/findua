using FindUa.Parser.Domain.Enumerations;
using HtmlAgilityPack;
using System;

namespace FindUa.Parser.Domain.ParserProviders.RST.Helpers
{
    public static class RstPropertyHelper
    {
        public static VehicleTypeEnum GetVehicleType(HtmlNode offerBlock)
        {
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

            return VehicleTypeEnum.PassengerCar;
        }
    }
}
