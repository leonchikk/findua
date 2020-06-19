﻿using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    public class FuelTypeRepository : BaseRepository<FuelType>, IFuelTypeRepository
    {
        public FuelTypeRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<FuelType>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
