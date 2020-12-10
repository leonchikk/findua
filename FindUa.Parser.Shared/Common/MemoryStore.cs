using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Core.Entities;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace FindUa.Parser.Shared.Common
{
    public class MemoryStore : IMemoryStore
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemoryStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConcurrentBag<City> Cities { get; private set; }
        public ConcurrentBag<BodyType> BodyTypes { get; private set; }
        public ConcurrentBag<FuelType> FuelTypes { get; private set; }
        public ConcurrentBag<TransmissionType> TransmissionTypes { get; private set; }
        public ConcurrentBag<TransportCondition> TransportConditions { get; private set; }
        public ConcurrentBag<TransportBrand> TransportBrands  { get; private set; }
        public ConcurrentBag<TransportModel> TransportModels { get; private set; }
        public ConcurrentBag<VehicleType> VehicleTypes { get; private set; }

        public async Task LoadDataAsync()
        {
            Cities = new ConcurrentBag<City>(await _unitOfWork.CitiesRepository.LoadAllAsyncAsNoTracking());
            BodyTypes = new ConcurrentBag<BodyType>(await _unitOfWork.BodyTypesRepository.LoadAllAsyncAsNoTracking());
            FuelTypes = new ConcurrentBag<FuelType>(await _unitOfWork.FuelTypesRepository.LoadAllAsyncAsNoTracking());
            TransmissionTypes = new ConcurrentBag<TransmissionType>(await _unitOfWork.TransmissionTypesRepository.LoadAllAsyncAsNoTracking());
            TransportConditions = new ConcurrentBag<TransportCondition>(await _unitOfWork.TransportConditionsRepository.LoadAllAsyncAsNoTracking());
            TransportBrands = new ConcurrentBag<TransportBrand>(await _unitOfWork.BrandsRepository.LoadAllAsyncAsNoTracking());
            TransportModels = new ConcurrentBag<TransportModel>(await _unitOfWork.ModelsRepository.LoadAllAsyncAsNoTracking());
            VehicleTypes = new ConcurrentBag<VehicleType>(await _unitOfWork.VehicleTypesRepository.LoadAllAsyncAsNoTracking());
        }
    }
}
