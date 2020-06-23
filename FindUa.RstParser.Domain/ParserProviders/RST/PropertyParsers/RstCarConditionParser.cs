using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstCarConditionParser : ICarConditionParser
    {
        public IEnumerable<int> ParseForDetailed(HtmlNode htmlNode)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<int> ParseForPreview(HtmlNode htmlNode)
        {
            var conditionIds = new List<int>();

            var conditionBlock = htmlNode.Descendants()
                  .Where(n => n.InnerText.Contains("Состояние"))
                  .ToList();

            var conditionString = conditionBlock.FirstOrDefault(x => x.Name == "li")?
                                                .ChildNodes["span"]
                                                .InnerText;

            var conditionId = (int)GetCarCondition(conditionString);

            conditionIds.Add(conditionId);

            return conditionIds;
        }

        private CarConditionEnum GetCarCondition(string conditionString)
        {
            if (conditionString.Contains("После ДТП", StringComparison.OrdinalIgnoreCase))
                return CarConditionEnum.AfterAccident;

            if (conditionString.Contains("Хорошее", StringComparison.OrdinalIgnoreCase))
                return CarConditionEnum.Good;

            if (conditionString.Contains("Новое авто", StringComparison.OrdinalIgnoreCase))
                return CarConditionEnum.New;

            if (conditionString.Contains("Нормальное", StringComparison.OrdinalIgnoreCase))
                return CarConditionEnum.Good;

            if (conditionString.Contains("По запчастям", StringComparison.OrdinalIgnoreCase))
                return CarConditionEnum.ForParts;

            if (conditionString.Contains("Требует ремонта", StringComparison.OrdinalIgnoreCase))
                return CarConditionEnum.RequiresRepair;

            return CarConditionEnum.NA;
        }
    }
}
