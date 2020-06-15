using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstYearParser : IYearParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
                                   
            var content = htmlNode.SelectNodes("//*[@id=\"rst-page-oldcars-item\"]/div[3]/table/tr[2]/td[2]/a"); //[3]/table/tbody/tr[2]/td[2]/a");
            var numberString = content["a"].InnerText;

            return int.Parse(numberString);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
