using Common.Core.Models;
using System;

namespace FindUa.Parser.Core.Entities
{
    public class TransportSaleAnnounce : BaseEntity
    {
        public long AdNumber { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public double Price { get; set; }
        public string SourceLink { get; set; }
        public string ImageLink { get; set; }
        public DateTime UpdateOfferTime { get; set; }
        public string Description { get; set; }
        public Guid BodyTypeId { get; set; }
        public Guid CarConditionId { get; set; }
        public Guid TranssmisionTypeId { get; set; }
        public Guid EngineTypeId { get; set; }
        public Guid LocalityId { get; set; }

    }
}
