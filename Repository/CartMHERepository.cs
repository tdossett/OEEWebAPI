using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class CartMHERepository : ICartMHERepository
    {
        private OEEContext _context;

        // Constructor
        public CartMHERepository(OEEContext context)
        {
            _context = context;
        }

        // Get All CartMHE's
        IEnumerable<CartMhe> ICartMHERepository.GetAll()
        {
            var cartmhe = _context.CartMhe;

            return cartmhe.AsEnumerable();
        }

        // Get an CartMHE
        public CartMhe Find(int id)
        {
            var cartmhe = _context.CartMhe.Single(o => o.CartMheid == id);

            return cartmhe;
        }

        // Add an CartMHE
        public void Add(CartMhe cartmhe)
        {
            _context.CartMhe.Add(cartmhe);
            _context.SaveChanges();
        }

        // Update an CartMHE
        public void Update(CartMhe cartmhe)
        {
            var cartmheToUpdate = _context.CartMhe.Single(o => o.CartMheid == cartmhe.CartMheid);
            if (cartmheToUpdate != null)
            {
                cartmheToUpdate.DeadBattery = cartmhe.DeadBattery;
                cartmheToUpdate.BrokenWheels = cartmhe.BrokenWheels;
                cartmheToUpdate.TurntableMalfunction = cartmhe.TurntableMalfunction;
                cartmheToUpdate.Other = cartmhe.Other;
                cartmheToUpdate.CartMhedate = cartmhe.CartMhedate;
                _context.SaveChanges();
            }
        }

        // Remove an CartMHE
        public void Remove(int id)
        {
            var cartmheToRemove = _context.CartMhe.Single(o => o.CartMheid == id);
            if (cartmheToRemove != null)
            {
                _context.Remove(cartmheToRemove);
                _context.SaveChanges();
            }
        }
    }
}
