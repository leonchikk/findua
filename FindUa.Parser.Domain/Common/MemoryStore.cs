using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FindUa.Parser.Domain.Common
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
        public ConcurrentBag<TransportModel> TransportModels { get; private set; }
        public ConcurrentBag<VehicleType> VehicleTypes { get; private set; }

        public async Task LoadDataAsync()
        {
            Cities = new ConcurrentBag<City>(await _unitOfWork.CitiesRepository.LoadAllAsync());
            BodyTypes = new ConcurrentBag<BodyType>(await _unitOfWork.BodyTypesRepository.LoadAllAsync());
            FuelTypes = new ConcurrentBag<FuelType>(await _unitOfWork.FuelTypesRepository.LoadAllAsync());
            TransmissionTypes = new ConcurrentBag<TransmissionType>(await _unitOfWork.TransmissionTypesRepository.LoadAllAsync());
            TransportConditions = new ConcurrentBag<TransportCondition>(await _unitOfWork.TransportConditionsRepository.LoadAllAsync());
            TransportModels = new ConcurrentBag<TransportModel>(await _unitOfWork.ModelsRepository.LoadAllAsync());
            VehicleTypes = new ConcurrentBag<VehicleType>(await _unitOfWork.VehicleTypesRepository.LoadAllAsync());
        }
    }
}
