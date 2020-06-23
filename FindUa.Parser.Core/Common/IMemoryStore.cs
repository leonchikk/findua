using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Core.Entities;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.Common
{
    public interface IMemoryStore
    {
        ConcurrentBag<City> Cities { get; }
        ConcurrentBag<BodyType> BodyTypes { get; }
        ConcurrentBag<FuelType> FuelTypes { get;  }
        ConcurrentBag<TransmissionType> TransmissionTypes { get; }
        ConcurrentBag<TransportCondition> TransportConditions { get;  }
        ConcurrentBag<TransportBrand> TransportBrands { get; }
        ConcurrentBag<TransportModel> TransportModels { get;  }
        ConcurrentBag<VehicleType> VehicleTypes { get; }

        Task LoadDataAsync();
    }
}
