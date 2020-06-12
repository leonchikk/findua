﻿using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.ParserProvider;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Domain.ParserProviders.RST
{
    public class RstParserProvider : ParserProvider
    {
        public RstParserProvider(
            IUnitOfWork unitOfWork,
            IBodyTypeParser bodyTypeParser,
            IBrandParser brandParser,
            ICarConditionParser carConditionParser,
            IParserDataLoader dataLoader,
            IEngineVolumetricParser engineVolumetricParser,
            IFuelTypeParser fuelTypeParser,
            IStructureExtractor structureExtractor,
            IMileageParser mileageParser,
            IModelParser modelParser,
            IOfferNumberParser offerNumberParser,
            IPriceParser priceParser,
            IPublishDateParser publishDateParser,
            IRegionParser regionParser,
            ISourceLinkParser sourceLinkParser,
            ITransmissionTypeParser transmissionType,
            IYearParser yearParser)
            : base(unitOfWork,
                  bodyTypeParser, 
                  brandParser, 
                  carConditionParser, 
                  dataLoader, 
                  engineVolumetricParser, 
                  fuelTypeParser, 
                  structureExtractor, 
                  mileageParser, 
                  modelParser, 
                  offerNumberParser, 
                  priceParser, 
                  publishDateParser, 
                  regionParser, 
                  sourceLinkParser, 
                  transmissionType, 
                  yearParser)
        { }

        public override async Task ProcessDataAsync()
        {
            var scrapedSaleAnnounces = new List<TransportSaleAnnounce>();

            var htmlDocument = await DataLoader.LoadHtmlDocumentAsync();

            var previewOffers = StructureExtractor.GetPreviewOfferStructure(htmlDocument);

            foreach (var previewOffer in previewOffers)
            {
                var sourceLink = SourceLinkParser.GetLink(previewOffer);
                var detailedHtmlDocument = await DataLoader.LoadHtmlDocumentAsync(sourceLink);

                var detailedOffer = StructureExtractor.GetDetailedOfferStructure(detailedHtmlDocument);
            }
        }
    }
}
