using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstYearParser : IYearParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var charactiristicsBlock = htmlNode.ChildNodes[10];
            var charactiristicsList = charactiristicsBlock.ChildNodes[3];
            var yearAndMileageBlock = charactiristicsList.ChildNodes[1];
            var yearAndMileageContent = yearAndMileageBlock.ChildNodes[1];
            var year = yearAndMileageContent.ChildNodes[0];

            var numberString = year.InnerText;

            return int.Parse(numberString);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
