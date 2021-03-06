﻿using FindUa.Parser.Core.DataAccess;
using FindUa.RstParser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Shared.DataAccess.UoW.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class TransportConditionRepository : BaseRepository<TransportCondition>, ITransportConditionRepository
    {
        public TransportConditionRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<TransportCondition>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet.AsNoTracking()
                              .ToListAsync();
        }
    }
}
