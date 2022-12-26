using System.Collections.Generic;
using SecondService.Models;

namespace SecondService.SyncDataServices.Grpc
{
    public interface ISpecialOfferDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}