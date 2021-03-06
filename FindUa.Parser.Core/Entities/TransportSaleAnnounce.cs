﻿using Common.Core.Models;
using System;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class TransportSaleAnnounce : BaseEntity<int>
    {
        public TransportSaleAnnounce()
        {
            TransportConditions = new HashSet<TransportConditionInSaleAnnounce>();
        }

        public long AdNumber { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public double PriceInDollars { get; set; }
        public string SourceLink { get; set; }
        public string PreviewImageLink { get; set; }
        public DateTime UpdateOfferTime { get; set; }
        public string Description { get; set; }
        public int EngineVolumetric { get; set; }
        public int? BodyTypeId { get; set; }
        public int TransmissionTypeId { get; set; }
        public int CityId { get; set; }
        public int FuelTypeId { get; set; }
        public int? ModelId { get; set; }
        public int? BrandId { get; set; }
        public int VehicleTypeId { get; set; }
        public int SourceProviderId { get; set; }
        public int DriveUnitId { get; set; }

        public BodyType BodyType { get; set; }
        public DriveUnit DriveUnit { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public City City { get; set; }
        public FuelType FuelType { get; set; }
        public TransportModel Model { get; set; }
        public TransportBrand Brand { get; set; }
        public VehicleType VehicleType { get; set; }
        public SourceProvider SourceProvider { get; set; }

        public ICollection<TransportConditionInSaleAnnounce> TransportConditions { get; set; }
    }
}
