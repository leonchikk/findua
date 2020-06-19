using FindUa.Parser.Core.ParserProvider;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindUa.Parser.Domain.ParserProviders.RST
{
    public class RstStructureExtractor : IStructureExtractor
    {
        public HtmlNode GetDetailedOfferStructure(HtmlDocument htmlDocument)
        {
            var structure = htmlDocument.GetElementbyId($"rst-page-left-column");

            var adviceFromRstNode = structure.SelectSingleNode("//span[@class='rst-uix-billet']");

            if (adviceFromRstNode != null)
            {
                var tableDataNode = adviceFromRstNode.ParentNode;
                var tableRowNode = tableDataNode.ParentNode;
                tableRowNode.Remove();
            }

            structure.Descendants()
                .Where(n => n.Name == "script" || n.Name == "style")
                .ToList()
                .ForEach(n => n.Remove());

            return structure;
        }


        public IEnumerable<HtmlNode> GetPreviewOfferStructure(HtmlDocument htmlDocument, int page)
        {
            var pageDocument = htmlDocument.GetElementbyId($"rst-page-{page}");
            return pageDocument.ChildNodes.Where(x => x.Id.Contains("rst-ocid-"));
        }
    }
}
