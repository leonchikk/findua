using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using System.Collections.Generic;

namespace FindUa.Parser.Core.ParserProvider
{
    public abstract class ParserProvider
    {
        protected IParserDataLoader DataLoader;
        protected IStructureExtractor StructureExtractor;

        protected IBodyTypeParser BodyTypeParser;
        protected IBrandParser BrandParser;
        protected ICarConditionParser CarConditionParser;
        protected IEngineTypeParser EngineTypeParser;
        protected IMileageParser MileageParser;
        protected IModelParser ModelParser;
        protected IOfferNumberParser OfferNumberParser;
        protected IPriceParser PriceParser;
        protected IPublishDateParser PublishDateParser;
        protected IRegionParser RegionParser;
        protected ISourceLinkParser SourceLinkParser;
        protected ITransmissionTypeParser TransmissionType;
        protected IYearParser YearParser;

        public ParserProvider(
            IBodyTypeParser bodyTypeParser,
            IBrandParser brandParser,
            ICarConditionParser carConditionParser,
            IParserDataLoader dataLoader,
            IEngineTypeParser engineTypeParser,
            IStructureExtractor structureExtractor,
            IMileageParser mileageParser,
            IModelParser modelParser,
            IOfferNumberParser offerNumberParser,
            IPriceParser priceParser,
            IPublishDateParser publishDateParser,
            IRegionParser regionParser,
            ISourceLinkParser sourceLinkParser,
            ITransmissionTypeParser transmissionType,
            IYearParser yearParser
        )
        {
            BodyTypeParser = bodyTypeParser;
            BrandParser = brandParser;
            CarConditionParser = carConditionParser;
            DataLoader = dataLoader;
            EngineTypeParser = engineTypeParser;
            StructureExtractor = structureExtractor;
            MileageParser = mileageParser;
            ModelParser = modelParser;
            OfferNumberParser = offerNumberParser;
            PriceParser = priceParser;
            PublishDateParser = publishDateParser;
            RegionParser = regionParser;
            SourceLinkParser = sourceLinkParser;
            TransmissionType = transmissionType;
            YearParser = yearParser;
        }

        public abstract IEnumerable<TransportSaleAnnounce> GetFreshData();
    }
}
