using FindUa.Parser.Core;
using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.ParserProvider;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using FindUa.RstParser.Domain.Common;
using FindUa.RstParser.Domain.ParserProviders.RST;
using FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers;
using FindUa.RstParser.Domain.RST.PropertyParsers;
using Microsoft.Extensions.DependencyInjection;

namespace FindUa.RstParser.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRstParser(this IServiceCollection services)
        {
            services.AddSingleton<IDataLoader, DataLoader>();
            services.AddTransient<ParserProvider, RstParserProvider>();

            services.AddTransient<IStructureExtractor, RstStructureExtractor>();
            services.AddTransient<ISourceLinkParser, RstSourceLinkParser>();
            services.AddTransient<IOfferNumberParser, RstOfferNumberParser >();
            services.AddTransient<IYearParser, RstYearParser >();
            services.AddTransient<IMileageParser, RstMileageParser>();
            services.AddTransient<IEngineVolumetricParser, RstEngineVolumetricParser >();
            services.AddTransient<IRegionParser, RstRegionParser >();
            services.AddTransient<IImageLinkParser, RstImageLinkParser >();
            services.AddTransient<IDescriptionParser, RstDescriptionParser>();
            services.AddTransient<IPriceParser, RstPriceParser >();
            services.AddTransient<IFuelTypeParser, RstFuelTypeParser >();
            services.AddTransient<ITransmissionTypeParser, RstTransmissionTypeParser>();
            services.AddTransient<IDriveUnitParser, RstDriveUnitParser >();
            services.AddTransient<IBodyTypeParser, RstBodyTypeParser >();
            services.AddTransient<IVehicleTypeParser, RstVehicleTypeParser>();
            services.AddTransient<IPublishDateParser, RstPublishDateParser >();
            services.AddTransient<IBrandModelParser, RstBrandModelParser >();
            services.AddTransient<ICarConditionParser, RstCarConditionParser >();

            return services;
        }
    }
}
