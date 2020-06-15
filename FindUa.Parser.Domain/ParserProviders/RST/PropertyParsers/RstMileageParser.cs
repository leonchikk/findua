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
            var content = htmlNode.SelectNodes("//*[@id=\"rst-page-oldcars-item\"]/div[3]/table/tr[2]/td[2]/span"); //tbody/tr[2]/td[2]/a
            var numberString = content["span"].InnerText;

            return MileageStringToInt(numberString);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
