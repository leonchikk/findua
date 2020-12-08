﻿using System.Threading.Tasks;

namespace Common.Core.Interfaces
{
    public interface IBaseUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
