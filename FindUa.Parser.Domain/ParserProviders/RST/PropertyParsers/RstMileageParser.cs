using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
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
            var charactiristicsBlock = htmlNode.ChildNodes[10];
            var charactiristicsList = charactiristicsBlock.ChildNodes[3];
            var yearAndMileageBlock = charactiristicsList.ChildNodes[1];
            var yearAndMileageContent = yearAndMileageBlock.ChildNodes[1];
            var mileage = yearAndMileageContent.ChildNodes[2];

            var numberString = mileage.InnerText;

            return MileageStringToInt(numberString);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
