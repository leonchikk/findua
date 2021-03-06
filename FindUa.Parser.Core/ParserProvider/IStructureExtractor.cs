﻿using HtmlAgilityPack;
using System.Collections.Generic;

namespace FindUa.Parser.Core.ParserProvider
{
    public interface IStructureExtractor
    {
        IEnumerable<HtmlNode> GetPreviewOfferStructure(HtmlDocument htmlDocument, int page);
        HtmlNode GetDetailedOfferStructure(HtmlDocument htmlDocument);
    }
}
