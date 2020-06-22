﻿using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    class TransportBrandRepository : BaseRepository<TransportBrand>, ITransportBrandRepository
    {
        public TransportBrandRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public TransportBrand Create(string brandName, int vehicleTypeId)
        {
            var brand = new TransportBrand()
            {
                VehicleTypeId = vehicleTypeId,
                Name = brandName
            };

            DbSet.Add(brand);

            return brand;
        }

        public async Task<IList<TransportBrand>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet.Include(brand => brand.VehicleType)
                              .AsNoTracking()
                              .ToListAsync();
        }
    }
}