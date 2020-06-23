using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.ParserProvider;
using FindUa.RstParser.Domain.ParserProviders.RST;
using FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers;
using FindUa.RstParser.Domain.RST.PropertyParsers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FindUa.RstParser.Domain.Common
{
    public static class ParserProviderFactory
    {
        public static ParserProvider CreateRtsParserProvider(IServiceScope serviceScope)
        {
            var parseProviderLogger = serviceScope.ServiceProvider.GetService<ILogger<RstParserProvider>>();
            var modelParseLogger = serviceScope.ServiceProvider.GetService<ILogger<RstModelParser>>();
            var unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>();
            var memoryStore = serviceScope.ServiceProvider.GetService<IMemoryStore>();
            var dataLoader = serviceScope.ServiceProvider.GetService<IDataLoader>();
            var structureExtractor = new RstStructureExtractor();
            var sourceLinkParser = new RstSourceLinkParser();
            var offerNumberParser = new RstOfferNumberParser();
            var yearParser = new RstYearParser();
            var mileageParser = new RstMileageParser();
            var engineVolumetric = new RstEngineVolumetricParser();
            var regionParser = new RstRegionParser(memoryStore);
            var imageLinkParser = new RstImageLinkParser();
            var descriptionParser = new RstDescriptionParser();
            var priceParser = new RstPriceParser();
            var fuelTypeParser = new RstFuelTypeParser();
            var transmissionTypeParser = new RstTransmissionTypeParser();
            var driveUnitParser = new RstDriveUnitParser();
            var bodyTypeParser = new RstBodyTypeParser(memoryStore);
            var vechicleParser = new RstVehicleTypeParser();
            var publishDateParser = new RstPublishDateParser();
            var modelParser = new RstModelParser(memoryStore, unitOfWork, vechicleParser, modelParseLogger);
            var carConditionParser = new RstCarConditionParser();

            var parser = new RstParserProvider(
                parseProviderLogger,
                unitOfWork,
                memoryStore,
                dataLoader,
                descriptionParser,
                driveUnitParser,
                bodyTypeParser,
                carConditionParser,
                engineVolumetric,
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
                transmissionTypeParser,
                vechicleParser,
                yearParser);

            return parser;
        }
    }
}
