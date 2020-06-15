using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.ParserProvider;
using FindUa.Parser.Domain.ParserProviders.RST;
using FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers;
using Microsoft.Extensions.DependencyInjection;

namespace FindUa.Parser.Domain.Common
{
    public static class ParserProviderFactory
    {
        public static ParserProvider CreateRtsParserProvider(IServiceScope serviceScope)
        {
            var unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>();
            var memoryStore = serviceScope.ServiceProvider.GetService<IMemoryStore>();
            var dataLoader = serviceScope.ServiceProvider.GetService<IDataLoader>();
            var structureExtractor = new RstStructureExtractor();
            var sourceLinkParser = new RstSourceLinkParser();
            var offerNumberParser = new RstOfferNumberParser();
            var yearParser = new RstYearParser();
            var mileageParser = new RstMileageParser();

            var parser = new RstParserProvider(
                unitOfWork,
                memoryStore,
                dataLoader,
                null,
                null,
                null,
                null,
                null,
                structureExtractor,
                mileageParser,
                null,
                offerNumberParser,
                null,
                null,
                null,
                sourceLinkParser,
                null,
                yearParser);

            return parser;
        }
    }
}
