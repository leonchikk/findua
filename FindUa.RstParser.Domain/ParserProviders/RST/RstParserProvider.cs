using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Domain.ParserProviders.RST
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
            IBrandModelParser brandModelParser,
            IOfferNumberParser offerNumberParser,
            IPriceParser priceParser,
            IPublishDateParser publishDateParser,
            IRegionParser regionParser,
            ISourceLinkParser sourceLinkParser,
            ITransmissionTypeParser transmissionType,
            IVehicleTypeParser vehicleTypeParser,
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
                  brandModelParser,
                  offerNumberParser,
                  priceParser,
                  publishDateParser,
                  regionParser,
                  sourceLinkParser,
                  transmissionType,
                  vehicleTypeParser,
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

                        var (brandId, modelId) = BrandModelParser.ParseForDetailed(detailedOfferNode);

                        var saleAnnounce = new TransportSaleAnnounce()
                        {
                            SourceLink = sourceLink,
                            TransmissionTypeId = TransmissionTypeParser.ParseForDetailed(detailedOfferNode),
                            AdNumber = OfferNumberParser.ParseForDetailed(detailedOfferNode),
                            BodyTypeId = BodyTypeParser.ParseForDetailed(detailedOfferNode),
                            CityId = RegionParser.ParseForDetailed(detailedOfferNode).Id,
                            Description = DescriptionParser.ParseForDetailed(detailedOfferNode),
                            DriveUnitId = DriveUnitParser.ParseForDetailed(detailedOfferNode),
                            EngineVolumetric = EngineVolumetricParser.ParseForDetailed(detailedOfferNode),
                            FuelTypeId = FuelTypeParser.ParseForDetailed(detailedOfferNode),
                            PreviewImageLink = ImageLinkParser.ParseForPreview(previewOfferNode),
                            Mileage = MileageParser.ParseForDetailed(detailedOfferNode),
                            BrandId = brandId,
                            VehicleTypeId = VehicleTypeParser.ParseForDetailed(detailedOfferNode),
                            ModelId = modelId,
                            PriceInDollars = PriceParser.ParseForDetailed(detailedOfferNode),
                            UpdateOfferTime = PublishDateParser.ParseForDetailed(detailedOfferNode),
                            Year = YearParser.ParseForDetailed(detailedOfferNode),
                            CreatedAt = DateTime.Now,
                            SourceProviderId = (int)SourceProviderEnum.RST
                        };

                        var carConditionIds = CarConditionParser.ParseForPreview(previewOfferNode);
                        foreach (var carConditionId in carConditionIds)
                            saleAnnounce.TransportConditions.Add(new TransportConditionInSaleAnnounce()
                            {
                                TransportConditionId = carConditionId
                            });

                        scrapedSaleAnnounces.Add(saleAnnounce);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}\n{ex.StackTrace}");
                }
                finally
                {
                    ScrappingPage++;
                }
            }

            await UnitOfWork.TransportSaleAnnouncesRepository.InsertRangeSaleAnnounces(scrapedSaleAnnounces);
        }
    }
}
