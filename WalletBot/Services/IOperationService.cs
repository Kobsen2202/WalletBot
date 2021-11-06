using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WalletBot.Entities;

namespace WalletBot.Services
{
    public interface IOperationService
    {
        Task<Operation> GetLast(long userId);
        Task<List<Operation>> GetOperations(long userId, DateTime byDate);
    }
}