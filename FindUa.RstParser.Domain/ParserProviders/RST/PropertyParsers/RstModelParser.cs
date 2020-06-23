using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using FindUa.RstParser.Domain.Extensions;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstModelParser : IBrandModelParser
    {
        private readonly IMemoryStore _memoryStore;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVehicleTypeParser _vehicleTypeParser;
        private readonly ILogger<RstModelParser> _logger;

        public RstModelParser(
            IMemoryStore memoryStore,
            IUnitOfWork unitOfWork,
            IVehicleTypeParser vehicleTypeParser,
            ILogger<RstModelParser> logger)
        {
            _memoryStore = memoryStore;
            _unitOfWork = unitOfWork;
            _vehicleTypeParser = vehicleTypeParser;
            _logger = logger;
        }

        public (int? BrandId, int? ModelId) ParseForDetailed(HtmlNode htmlNode)
        {
            var modelBrandBlock = htmlNode.OwnerDocument
                .GetElementbyId("rst-page-oldcars-tree-block");

            var vehicleTypeId = _vehicleTypeParser.ParseForDetailed(htmlNode);
            var vehicleType = (VehicleTypeEnum)vehicleTypeId;

            var brandBlock = modelBrandBlock.ChildNodes[4];
            var modelBlock = modelBrandBlock.ChildNodes[6];

            var brandName = brandBlock.InnerText.Replace("Купить", "").TrimStart();
            var modelName = modelBlock.InnerText.Replace($"{brandName} ", "")
                                                .RemoveAllDashes();

            if (string.IsNullOrWhiteSpace(brandName) ||
                vehicleType == VehicleTypeEnum.AirTransport ||
                vehicleType == VehicleTypeEnum.Moto ||
                vehicleType == VehicleTypeEnum.WaterTtransport)
                return (BrandId: null, ModelId: null);

            var brand = _memoryStore.TransportBrands
                .Where(x => x.Name.Equals(brandName, StringComparison.OrdinalIgnoreCase) && x.VehicleTypeId == vehicleTypeId)
                .FirstOrDefault();

            if (brand == null)
                brand = _memoryStore.TransportBrands
                    .Where(x => (x.Name.Contains(brandName, StringComparison.OrdinalIgnoreCase) ||
                           brandName.Contains(x.Name, StringComparison.OrdinalIgnoreCase)) &&
                           x.VehicleTypeId == vehicleTypeId)
                    .FirstOrDefault();

            if (brand == null)
                brand = CreateBrand(brandName, vehicleTypeId);

            TransportModel model = null;

            if (!string.IsNullOrWhiteSpace(modelName))
            {
                model = _memoryStore.TransportModels
                   .Where
                   (
                       x => x.BrandId == brand.Id &&
                       (
                           (x.Name
                               .RemoveAllDashes()
                               .RemoveAllWhiteSpaces()
                               .Contains(modelName.RemoveAllWhiteSpaces(), StringComparison.OrdinalIgnoreCase)) ||

                           (modelName.RemoveAllWhiteSpaces()
                               .Contains(x.Name.RemoveAllDashes()
                                               .RemoveAllWhiteSpaces(), StringComparison.OrdinalIgnoreCase))
                       )
                   )
                   .FirstOrDefault();

                if (model == null)
                    model = CreateModel(modelName, brand);
            }

            return (brand?.Id, model?.Id);
        }

        public (int? BrandId, int? ModelId) ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private TransportModel CreateModel(string modelName, TransportBrand brand)
        {
            var model = _unitOfWork.ModelsRepository.Create(modelName, brand.Id);
            _unitOfWork.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            _unitOfWork.ModelsRepository.Detach(model);

            model.Brand = brand;
            _memoryStore.TransportModels.Add(model);

            _logger.LogInformation($"Add new model {modelName} to brand {brand.Name}");

            return model;
        }

        private TransportBrand CreateBrand(string brandName, int vehicleTypeId)
        {
            var brand = _unitOfWork.BrandsRepository.Create(brandName, vehicleTypeId);
            _unitOfWork.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            _unitOfWork.BrandsRepository.Detach(brand);
            _memoryStore.TransportBrands.Add(brand);

            _logger.LogInformation($"Add new brand {brand.Name}");

            return brand;
        }
    }
}
