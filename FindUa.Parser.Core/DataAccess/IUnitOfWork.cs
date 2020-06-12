using Common.Core.Interfaces;
using FindUa.Parser.Core.Entities;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface IUnitOfWork
    {
        IRepository<BodyType> BodyTypesRepository { get; }
        IRepository<City> CitiesRepository { get; }
        IRepository<Country> CountiesRepository { get; }
        IRepository<FuelType> FuelTypesRepository { get; }
        IRepository<Region> RegionsRepository { get; }
        IRepository<TransmissionType> TransmissionTypesRepository { get; }
        IRepository<TransportBrand> BrandsRepository { get; }
        IRepository<TransportCondition> TransportConditionsRepository { get; }
        IRepository<TransportConditionInSaleAnnounce> TransportConditionInSaleAnnouncesRepository { get; }
        IRepository<TransportModel> ModelsRepository { get; }
        IRepository<TransportSaleAnnounce> TransportSaleAnnouncesRepository { get; }
        IRepository<TransportSourceProvider> TransportSourceProvidersRepository { get; }
        IRepository<TransportSourceProviderUrl> TransportSourceProviderUrlsRepository { get; }
        IRepository<VehicleType> VehicleTypesRepository { get; }

        Task SaveChangesAsync();
    }
}
