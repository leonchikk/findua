﻿using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IFuelTypeParser
    {
        FuelType ParseForPreview(HtmlNode htmlNode);
        FuelType ParseForDetailed(HtmlNode htmlNode);
    }
}