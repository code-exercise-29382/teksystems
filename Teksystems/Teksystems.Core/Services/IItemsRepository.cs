using System;
using System.Threading.Tasks;
using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface IItemsRepository
    {
        Task<Item> GetByIdAsync(Guid itemId);
    }
}
