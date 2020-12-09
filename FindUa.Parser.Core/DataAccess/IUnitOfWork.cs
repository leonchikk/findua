using FindUa.Parser.Core.Entities;
using Services.Shared.DataAccess.UoW.Abstractions;

namespace FindUa.Parser.Core.DataAccess
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IBodyTypeRepository BodyTypesRepository { get; }
        ICityRepository CitiesRepository { get; }
        IBaseRepository<Country> CountiesRepository { get; }
        IFuelTypeRepository FuelTypesRepository { get; }
        IBaseRepository<Region> RegionsRepository { get; }
        ITransmissionTypeRepository TransmissionTypesRepository { get; }
        ITransportBrandRepository BrandsRepository { get; }
        ITransportConditionRepository TransportConditionsRepository { get; }
        IBaseRepository<TransportConditionInSaleAnnounce> TransportConditionInSaleAnnouncesRepository { get; }
        ITransportModelRepository ModelsRepository { get; }
        ITransportSaleAnnounceRepository TransportSaleAnnouncesRepository { get; }
        IVehicleTypeRepository VehicleTypesRepository { get; }
    }
}
