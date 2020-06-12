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

        private IRepository<BodyType> _bodyTypesRepository;
        public IRepository<BodyType> BodyTypesRepository => _bodyTypesRepository ?? new BaseRepository<BodyType>(_dbContext);


        private IRepository<City> _citiesRepository;
        public IRepository<City> CitiesRepository => _citiesRepository ?? new BaseRepository<City>(_dbContext);


        private IRepository<Country> _countiesRepository;
        public IRepository<Country> CountiesRepository => _countiesRepository ?? new BaseRepository<Country>(_dbContext);


        private IRepository<FuelType> _fuelTypesRepository;
        public IRepository<FuelType> FuelTypesRepository => _fuelTypesRepository ?? new BaseRepository<FuelType>(_dbContext);


        private IRepository<Region> _regionsRepository;
        public IRepository<Region> RegionsRepository => _regionsRepository ?? new BaseRepository<Region>(_dbContext);


        private IRepository<TransmissionType> _transmissionTypesRepository;
        public IRepository<TransmissionType> TransmissionTypesRepository => _transmissionTypesRepository ?? new BaseRepository<TransmissionType>(_dbContext);


        private IRepository<TransportBrand> _brandsRepository;
        public IRepository<TransportBrand> BrandsRepository => _brandsRepository ?? new BaseRepository<TransportBrand>(_dbContext);


        private IRepository<TransportCondition> _transportConditionsRepository;
        public IRepository<TransportCondition> TransportConditionsRepository => _transportConditionsRepository ?? new BaseRepository<TransportCondition>(_dbContext);


        private IRepository<TransportConditionInSaleAnnounce> _transportConditionInSaleAnnouncesRepository;
        public IRepository<TransportConditionInSaleAnnounce> TransportConditionInSaleAnnouncesRepository => _transportConditionInSaleAnnouncesRepository ?? new BaseRepository<TransportConditionInSaleAnnounce>(_dbContext);


        private IRepository<TransportModel> _modelsRepository;
        public IRepository<TransportModel> ModelsRepository => _modelsRepository ?? new BaseRepository<TransportModel>(_dbContext);


        private IRepository<TransportSaleAnnounce> _transportSaleAnnouncesRepository;
        public IRepository<TransportSaleAnnounce> TransportSaleAnnouncesRepository => _transportSaleAnnouncesRepository ?? new BaseRepository<TransportSaleAnnounce>(_dbContext);


        private IRepository<TransportSourceProvider> _transportSourceProvidersRepository;
        public IRepository<TransportSourceProvider> TransportSourceProvidersRepository => _transportSourceProvidersRepository ?? new BaseRepository<TransportSourceProvider>(_dbContext);


        private IRepository<TransportSourceProviderUrl> _transportSourceProviderUrlsRepository;
        public IRepository<TransportSourceProviderUrl> TransportSourceProviderUrlsRepository => _transportSourceProviderUrlsRepository ?? new BaseRepository<TransportSourceProviderUrl>(_dbContext);


        private IRepository<VehicleType> _vehicleTypesRepository;
        public IRepository<VehicleType> VehicleTypesRepository => _vehicleTypesRepository ?? new BaseRepository<VehicleType>(_dbContext);

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
