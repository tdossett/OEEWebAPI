using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface ICartMHERepository
    {
        IEnumerable<CartMhe> GetAll();
        CartMhe Find(int id);
        void Add(CartMhe cartmhe);
        void Update(CartMhe cartmhe);
        void Remove(int id);
    }
}
