using Common.Core.Models;
using System;

namespace FindUa.Parser.Core.Entities
{
    public class EngineType : BaseEntity
    {
        public double Displacement { get; set; }
        public int Volume { get; set; }
    }
}
