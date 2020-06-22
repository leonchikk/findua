using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.ParserProvider
{
    public abstract class ParserProvider
    {
        protected string BaseUrl;
        protected string UrlForScrapping;
        protected int ScrappingPage;

        protected int DaysCountForProcessing;
        protected int DelayBetweenStepsInMilliseconds;
        protected int ItemsCountForStep;

        protected IUnitOfWork UnitOfWork;
        protected IMemoryStore MemoryStore;

        protected IDataLoader DataLoader;
        protected IStructureExtractor StructureExtractor;

        protected IBodyTypeParser BodyTypeParser;
        protected ICarConditionParser CarConditionParser;
        protected IDescriptionParser DescriptionParser;
        protected IDriveUnitParser DriveUnitParser;
        protected IEngineVolumetricParser EngineVolumetricParser;
        protected IFuelTypeParser FuelTypeParser;
        protected IImageLinkParser ImageLinkParser;
        protected IMileageParser MileageParser;
        protected IBrandModelParser BrandModelParser;
        protected IOfferNumberParser OfferNumberParser;
        protected IPriceParser PriceParser;
        protected IPublishDateParser PublishDateParser;
        protected IRegionParser RegionParser;
        protected ISourceLinkParser SourceLinkParser;
        protected ITransmissionTypeParser TransmissionTypeParser;
        protected IVehicleTypeParser VehicleTypeParser;
        protected IYearParser YearParser;

        public ParserProvider(
            IUnitOfWork unitOfWork,
            IMemoryStore memoryStore,
            IBodyTypeParser bodyTypeParser,
            ICarConditionParser carConditionParser,
            IDataLoader dataLoader,
            IDescriptionParser descriptionParser,
            IDriveUnitParser driveUnitParser,
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
            IYearParser yearParser
        )
        {
            UnitOfWork = unitOfWork;
            MemoryStore = memoryStore;
            BodyTypeParser = bodyTypeParser;
            CarConditionParser = carConditionParser;
            DescriptionParser = descriptionParser;
            DriveUnitParser = driveUnitParser;
            DataLoader = dataLoader;
            EngineVolumetricParser = engineVolumetricParser;
            FuelTypeParser = fuelTypeParser;
            ImageLinkParser = imageLinkParser;
            StructureExtractor = structureExtractor;
            MileageParser = mileageParser;
            BrandModelParser = brandModelParser;
            OfferNumberParser = offerNumberParser;
            PriceParser = priceParser;
            PublishDateParser = publishDateParser;
            RegionParser = regionParser;
            SourceLinkParser = sourceLinkParser;
            TransmissionTypeParser = transmissionType;
            VehicleTypeParser = vehicleTypeParser;
            YearParser = yearParser;

            ScrappingPage = 1;
        }

        public abstract Task ProcessDataAsync();

        public ParserProvider SetDaysCountForProcessing(int daysCount)
        {
            DaysCountForProcessing = daysCount;

            return this;
        }

        public ParserProvider SetItemsCountForStep(int itemsCount)
        {
            ItemsCountForStep = itemsCount;

            return this;
        }

        public ParserProvider SetBaseUrl(string url)
        {
            BaseUrl = url;

            return this;
        }

        public ParserProvider SetUrlForScrapping(string url)
        {
            UrlForScrapping = url;

            return this;
        }
    }
}
