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
        protected IBrandParser BrandParser;
        protected ICarConditionParser CarConditionParser;
        protected IDescriptionParser DescriptionParser;
        protected IEngineVolumetricParser EngineVolumetricParser;
        protected IFuelTypeParser FuelTypeParser;
        protected IImageLinkParser ImageLinkParser;
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
            IUnitOfWork unitOfWork,
            IMemoryStore memoryStore,
            IBodyTypeParser bodyTypeParser,
            IBrandParser brandParser,
            ICarConditionParser carConditionParser,
            IDataLoader dataLoader,
            IDescriptionParser descriptionParser,
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
            IYearParser yearParser
        )
        {
            UnitOfWork = unitOfWork;
            MemoryStore = memoryStore;
            BodyTypeParser = bodyTypeParser;
            BrandParser = brandParser;
            CarConditionParser = carConditionParser;
            DescriptionParser = descriptionParser;
            DataLoader = dataLoader;
            EngineVolumetricParser = engineVolumetricParser;
            FuelTypeParser = fuelTypeParser;
            ImageLinkParser = imageLinkParser;
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
