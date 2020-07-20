using System;
using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface IItemsRepository
    {
        Item GetById(Guid itemId);
    }
}
