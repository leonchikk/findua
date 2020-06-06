using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using System;
using System.Collections.Generic;

namespace FindUa.Parser.Core.ParserProvider
{
    public abstract class ParserProvider
    {
        protected IParserDataLoader DataLoader;
        protected IStructureExtractor StructureExtractor;

        protected IMileageParser MileageParser;
        protected IOfferNumberParser OfferNumberParser;
        protected IPriceParser PriceParser;
        protected IPublishDateParser PublishDateParser;
        protected ISourceLinkParser SourceLinkParser;
        protected IYearParser YearParser;

        public ParserProvider(
            IParserDataLoader dataLoader,
            IStructureExtractor structureExtractor,
            IMileageParser mileageParser,
            IOfferNumberParser offerNumberParser,
            IPriceParser priceParser,
            IPublishDateParser publishDateParser,
            ISourceLinkParser sourceLinkParser,
            IYearParser yearParser
        )
        {
            DataLoader = dataLoader;
            StructureExtractor = structureExtractor;
            MileageParser = mileageParser;
            OfferNumberParser = offerNumberParser;
            PriceParser = priceParser;
            PublishDateParser = publishDateParser;
            SourceLinkParser = sourceLinkParser;
            YearParser = yearParser;
        }

        public abstract IEnumerable<TransportSaleAnnounce> GetFreshData();
    }
}
