using Common.Core.Interfaces;
using FindUa.Parser.Core.Entities;

namespace FindUa.Parser.Core.DataAccess
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IBodyTypeRepository BodyTypesRepository { get; }
        ICityRepository CitiesRepository { get; }
        IRepository<Country> CountiesRepository { get; }
        IFuelTypeRepository FuelTypesRepository { get; }
        IRepository<Region> RegionsRepository { get; }
        ITransmissionTypeRepository TransmissionTypesRepository { get; }
        ITransportBrandRepository BrandsRepository { get; }
        ITransportConditionRepository TransportConditionsRepository { get; }
        IRepository<TransportConditionInSaleAnnounce> TransportConditionInSaleAnnouncesRepository { get; }
        ITransportModelRepository ModelsRepository { get; }
        ITransportSaleAnnounceRepository TransportSaleAnnouncesRepository { get; }
        IVehicleTypeRepository VehicleTypesRepository { get; }
    }
}
