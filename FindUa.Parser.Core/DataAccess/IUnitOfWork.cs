using Common.Core.Interfaces;
using FindUa.Parser.Core.Entities;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface IUnitOfWork
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
        IRepository<TransportSaleAnnounce> TransportSaleAnnouncesRepository { get; }
        IVehicleTypeRepository VehicleTypesRepository { get; }

        Task SaveChangesAsync();
    }
}
