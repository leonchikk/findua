using Common.Core.Interfaces;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using System;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransportParserContext _dbContext;

        public UnitOfWork
        (
            TransportParserContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        private IBodyTypeRepository _bodyTypesRepository;
        public IBodyTypeRepository BodyTypesRepository => _bodyTypesRepository ?? new BodyTypeRepository(_dbContext);


        private ICityRepository _citiesRepository;
        public ICityRepository CitiesRepository => _citiesRepository ?? new CityRepository(_dbContext);


        private IRepository<Country> _countiesRepository;
        public IRepository<Country> CountiesRepository => _countiesRepository ?? (_countiesRepository = new BaseRepository<Country>(_dbContext));


        private IFuelTypeRepository _fuelTypesRepository;
        public IFuelTypeRepository FuelTypesRepository => _fuelTypesRepository ?? new FuelTypeRepository(_dbContext);


        private IRepository<Region> _regionsRepository;
        public IRepository<Region> RegionsRepository => _regionsRepository ?? (_regionsRepository = new BaseRepository<Region>(_dbContext));


        private ITransmissionTypeRepository _transmissionTypesRepository;
        public ITransmissionTypeRepository TransmissionTypesRepository => _transmissionTypesRepository ?? new TransmissionTypeRepository(_dbContext);


        private ITransportBrandRepository _brandsRepository;
        public ITransportBrandRepository BrandsRepository => _brandsRepository ?? (_brandsRepository = new TransportBrandRepository(_dbContext));


        private ITransportConditionRepository _transportConditionsRepository;
        public ITransportConditionRepository TransportConditionsRepository => _transportConditionsRepository ?? new TransportConditionRepository(_dbContext);


        private IRepository<TransportConditionInSaleAnnounce> _transportConditionInSaleAnnouncesRepository;
        public IRepository<TransportConditionInSaleAnnounce> TransportConditionInSaleAnnouncesRepository => _transportConditionInSaleAnnouncesRepository ?? 
            (_transportConditionInSaleAnnouncesRepository = new BaseRepository<TransportConditionInSaleAnnounce>(_dbContext));


        private ITransportModelRepository _modelsRepository;
        public ITransportModelRepository ModelsRepository => _modelsRepository ?? new TransportModelRepository(_dbContext);


        private IRepository<TransportSaleAnnounce> _transportSaleAnnouncesRepository;
        public IRepository<TransportSaleAnnounce> TransportSaleAnnouncesRepository => _transportSaleAnnouncesRepository ?? 
            (_transportSaleAnnouncesRepository = new BaseRepository<TransportSaleAnnounce>(_dbContext));


        private IVehicleTypeRepository _vehicleTypesRepository;
        public IVehicleTypeRepository VehicleTypesRepository => _vehicleTypesRepository ?? new VehicleTypeRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
