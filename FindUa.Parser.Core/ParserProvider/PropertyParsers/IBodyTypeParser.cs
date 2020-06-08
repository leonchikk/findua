﻿using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IBodyTypeParser
    {
        BodyType ParseForPreview(HtmlNode htmlNode);
        BodyType ParseForDetailed(HtmlNode htmlNode);
    }
}
