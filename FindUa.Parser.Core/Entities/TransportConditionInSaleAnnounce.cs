﻿using Common.Core.Models;

namespace FindUa.Parser.Core.Entities
{
    public class TransportConditionInSaleAnnounce : BaseEntity
    {
        public int SaleAnnounceId { get; set; }
        public int TransportConditionId { get; set; }

        public TransportSaleAnnounce SaleAnnounce { get; set; }
        public TransportCondition TransportCondition { get; set; }
    }
}