using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class ConstraintsRepository : IConstraintsRepository
    {
        private OEEContext _context;
        // Constructor
        public ConstraintsRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Constraints
        IEnumerable<Constraints> IConstraintsRepository.GetAll()
        {
            var constraints = _context.Constraints;

            return constraints.AsEnumerable();
        }

        // Get an Constraint
        public Constraints Find(int id)
        {
            var constraint = _context.Constraints.Single(o => o.ConstraintsId == id);

            return constraint;
        }

        // Add an Constraint
        public void Add(Constraints constraint)
        {
            _context.Constraints.Add(constraint);
            _context.SaveChanges();
        }

        // Update an Constraint
        public void Update(Constraints constraint)
        {
            var constraintToUpdate = _context.Constraints.Single(o => o.ConstraintsId == constraint.ConstraintsId);
            if (constraintToUpdate != null)
            {
                constraintToUpdate.NoBarrel = constraint.NoBarrel;
                constraintToUpdate.NoMaterial = constraint.NoMaterial;
                constraintToUpdate.NoOperator = constraint.NoOperator;
                constraintToUpdate.Other = constraint.Other;
                constraintToUpdate.ConstraintsDate = constraint.ConstraintsDate;
                _context.SaveChanges();
            }
        }

        // Remove an Oee
        public void Remove(int id)
        {
            var constraintToRemove = _context.Constraints.Single(o => o.ConstraintsId == id);
            if (constraintToRemove != null)
            {
                _context.Remove(constraintToRemove);
                _context.SaveChanges();
            }
        }

    }
}
