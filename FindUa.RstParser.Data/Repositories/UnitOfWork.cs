using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Data.Contexts;
using Services.Shared.DataAccess.UoW.Abstractions;
using Services.Shared.DataAccess.UoW.Implementations;

namespace FindUa.RstParser.Data.Repositories
{
    public class UnitOfWork : BaseUnitOfWork<TransportParserContext>
    {
        public UnitOfWork(TransportParserContext dbContext) : base(dbContext)
        {
        }

        private IBodyTypeRepository _bodyTypesRepository;
        public IBodyTypeRepository BodyTypesRepository => _bodyTypesRepository ?? (_bodyTypesRepository = new BodyTypeRepository(_dbContext));


        private ICityRepository _citiesRepository;
        public ICityRepository CitiesRepository => _citiesRepository ?? (_citiesRepository = new CityRepository(_dbContext));


        private IBaseRepository<Country> _countiesRepository;
        public IBaseRepository<Country> CountiesRepository => _countiesRepository ?? (_countiesRepository = new BaseRepository<Country>(_dbContext));


        private IFuelTypeRepository _fuelTypesRepository;
        public IFuelTypeRepository FuelTypesRepository => _fuelTypesRepository ?? (_fuelTypesRepository = new FuelTypeRepository(_dbContext));


        private IBaseRepository<Region> _regionsRepository;
        public IBaseRepository<Region> RegionsRepository => _regionsRepository ?? (_regionsRepository = new BaseRepository<Region>(_dbContext));


        private ITransmissionTypeRepository _transmissionTypesRepository;
        public ITransmissionTypeRepository TransmissionTypesRepository => _transmissionTypesRepository ?? (_transmissionTypesRepository = new TransmissionTypeRepository(_dbContext));


        private ITransportBrandRepository _brandsRepository;
        public ITransportBrandRepository BrandsRepository => _brandsRepository ?? (_brandsRepository = new TransportBrandRepository(_dbContext));


        private ITransportConditionRepository _transportConditionsRepository;
        public ITransportConditionRepository TransportConditionsRepository => _transportConditionsRepository ?? (_transportConditionsRepository = new TransportConditionRepository(_dbContext));


        private IBaseRepository<TransportConditionInSaleAnnounce> _transportConditionInSaleAnnouncesRepository;
        public IBaseRepository<TransportConditionInSaleAnnounce> TransportConditionInSaleAnnouncesRepository => _transportConditionInSaleAnnouncesRepository ??
            (_transportConditionInSaleAnnouncesRepository = new BaseRepository<TransportConditionInSaleAnnounce>(_dbContext));


        private ITransportModelRepository _modelsRepository;
        public ITransportModelRepository ModelsRepository => _modelsRepository ?? (_modelsRepository = new TransportModelRepository(_dbContext));


        private ITransportSaleAnnounceRepository _transportSaleAnnouncesRepository;
        public ITransportSaleAnnounceRepository TransportSaleAnnouncesRepository => _transportSaleAnnouncesRepository ??
            (_transportSaleAnnouncesRepository = new TransportSaleAnnounceRepository(_dbContext));


        private IVehicleTypeRepository _vehicleTypesRepository;
        public IVehicleTypeRepository VehicleTypesRepository => _vehicleTypesRepository ?? (_vehicleTypesRepository = new VehicleTypeRepository(_dbContext));
    }
}
