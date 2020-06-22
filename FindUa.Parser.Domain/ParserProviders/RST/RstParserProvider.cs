using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.ParserProvider;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Domain.ParserProviders.RST
{
    public class RstParserProvider : ParserProvider
    {
        private readonly ILogger<RstParserProvider> _logger;

        public RstParserProvider(
            ILogger<RstParserProvider> logger,
            IUnitOfWork unitOfWork,
            IMemoryStore memoryStore,
            IDataLoader dataLoader,
            IDescriptionParser descriptionParser,
            IDriveUnitParser driveUnitParser,
            IBodyTypeParser bodyTypeParser,
            ICarConditionParser carConditionParser,
            IEngineVolumetricParser engineVolumetricParser,
            IFuelTypeParser fuelTypeParser,
            IImageLinkParser imageLinkParser,
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
                  carConditionParser,
                  dataLoader,
                  descriptionParser,
                  driveUnitParser,
                  engineVolumetricParser,
                  fuelTypeParser,
                  imageLinkParser,
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
        {
            _logger = logger;
        }

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

                    foreach (var previewOfferNode in previewOffers)
                    {
                        var sourceLink = SourceLinkParser.GetLink(previewOfferNode, BaseUrl);
                        var detailedHtmlDocument = await DataLoader.LoadHtmlDocumentAsync(sourceLink);
                        var detailedOfferNode = StructureExtractor.GetDetailedOfferStructure(detailedHtmlDocument);

                        var saleAnnounce = new TransportSaleAnnounce()
                        {
                            SourceLink = sourceLink,
                            TransmissionTypeId = TransmissionTypeParser.ParseForDetailed(detailedOfferNode),
                            AdNumber = OfferNumberParser.ParseForDetailed(detailedOfferNode),
                            BodyTypeId = 1,
                            CityId = RegionParser.ParseForDetailed(detailedOfferNode).Id,
                            Description = DescriptionParser.ParseForDetailed(detailedOfferNode),
                            DriveUnitId = DriveUnitParser.ParseForDetailed(detailedOfferNode),
                            EngineVolumetric = EngineVolumetricParser.ParseForDetailed(detailedOfferNode),
                            FuelTypeId = FuelTypeParser.ParseForDetailed(detailedOfferNode),
                            PreviewImageLink = ImageLinkParser.ParseForPreview(previewOfferNode),
                            Mileage = MileageParser.ParseForDetailed(detailedOfferNode),
                            ModelId = ModelParser.ParseForDetailed(detailedOfferNode).Id,
                            PriceInDollars = PriceParser.ParseForDetailed(detailedOfferNode),
                            UpdateOfferTime = DateTime.Now,
                            Year = YearParser.ParseForDetailed(detailedOfferNode),
                            CreatedAt = DateTime.Now
                        };

                        scrapedSaleAnnounces.Add(saleAnnounce);
                    }

                    await UnitOfWork.TransportSaleAnnouncesRepository.InsertBulkAsync(scrapedSaleAnnounces);
                }
                catch(Exception ex)
                {
                    _logger.LogError($"{ex.Message}\n{ex.StackTrace}");
                }
                finally
                {
                    ScrappingPage++;
                }
            }
        }
    }
}
