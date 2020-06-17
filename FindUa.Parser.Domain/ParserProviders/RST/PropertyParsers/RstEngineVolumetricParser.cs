using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstEngineVolumetricParser : IEngineVolumetricParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var charactiristicsBlock = htmlNode.ChildNodes[10];
            var charactiristicsList = charactiristicsBlock.ChildNodes[3];
            var fuelTypeAndEngineVolumetricBlock = charactiristicsList.ChildNodes[2];
            var fuelTypeAndEngineVolumetric = fuelTypeAndEngineVolumetricBlock.ChildNodes[1];
            var engineVolumetricNode = fuelTypeAndEngineVolumetric.ChildNodes[0];

            string numberString = null;
            try
            {
                numberString = engineVolumetricNode.InnerText;
                var engineVolumetric = double.Parse(numberString);
                return (int)Math.Ceiling(engineVolumetric * 1000);
            }
            catch(Exception ex)
            {
                throw new Exception($"RstEngineVolumetricParser {fuelTypeAndEngineVolumetricBlock.InnerHtml}\n Number string: {numberString}");
            }
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
