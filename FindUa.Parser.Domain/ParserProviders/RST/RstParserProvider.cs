using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
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
            IMemoryStore memoryStore,
            IDataLoader dataLoader,
            IBodyTypeParser bodyTypeParser,
            IBrandParser brandParser,
            ICarConditionParser carConditionParser,
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
                  memoryStore,
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

            while (ItemsCountForStep > scrapedSaleAnnounces.Count)
            {
                try
                {
                    UrlForScrapping += $"&start={ScrappingPage}";
                    var htmlDocument = await DataLoader.LoadHtmlDocumentAsync(UrlForScrapping);
                    var previewOffers = StructureExtractor.GetPreviewOfferStructure(htmlDocument, ScrappingPage);

                    foreach (var previewOffer in previewOffers)
                    {
                        var sourceLink = SourceLinkParser.GetLink(previewOffer, BaseUrl);
                        var detailedHtmlDocument = await DataLoader.LoadHtmlDocumentAsync(sourceLink);
                        var detailedOfferNode = StructureExtractor.GetDetailedOfferStructure(detailedHtmlDocument);

                        var saleAnnounce = new TransportSaleAnnounce()
                        {
                            SourceLink = sourceLink,
                            TransmissionTypeId = 1,
                            AdNumber = OfferNumberParser.ParseForDetailed(detailedOfferNode),
                            BodyTypeId = 1,
                            CityId = 2480119,
                            Description = "bla bla bla",
                            EngineVolumetric = 1600,
                            FuelTypeId = 1,
                            ImageLink = "https://empty.com/image",
                            Mileage = MileageParser.ParseForDetailed(detailedOfferNode),
                            ModelId = 1666,
                            Price = 20,
                            UpdateOfferTime = DateTime.Now,
                            Year = YearParser.ParseForDetailed(detailedOfferNode)
                        };

                        scrapedSaleAnnounces.Add(saleAnnounce);
                    }
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    ScrappingPage++;
                }
            }

            await UnitOfWork.TransportSaleAnnouncesRepository.InsertBulkAsync(scrapedSaleAnnounces);
        }
    }
}
