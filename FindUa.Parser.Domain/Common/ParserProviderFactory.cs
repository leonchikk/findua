using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.ParserProvider;
using FindUa.Parser.Domain.ParserProviders.RST;
using FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FindUa.Parser.Domain.Common
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
            var modelParser = new RstModelParser(memoryStore, unitOfWork, modelParseLogger);

            var parser = new RstParserProvider(
                parseProviderLogger,
                unitOfWork,
                memoryStore,
                dataLoader,
                descriptionParser,
                null,
                null,
                engineVolumetric,
                null,
                imageLinkParser,
                structureExtractor,
                mileageParser,
                modelParser,
                offerNumberParser,
                null,
                null,
                regionParser,
                sourceLinkParser,
                null,
                yearParser);

            return parser;
        }
    }
}
