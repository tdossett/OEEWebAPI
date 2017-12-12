using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private OEEContext _context;

        // Constructor
        public MaterialRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Material's
        IEnumerable<Material> IMaterialRepository.GetAll()
        {
            var material = _context.Material;

            return material.AsEnumerable();
        }

        // Get an Material
        public Material Find(int id)
        {
            var material = _context.Material.Single(o => o.MaterialId == id);

            return material;
        }

        // Add an Material
        public void Add(Material material)
        {
            _context.Material.Add(material);
            _context.SaveChanges();
        }

        // Update an Material
        public void Update(Material material)
        {
            var materialToUpdate = _context.Material.Single(o => o.MaterialId == material.MaterialId);
            if (materialToUpdate != null)
            {
                materialToUpdate.PolyWrap = material.PolyWrap;
                materialToUpdate.NotStickingIml = material.NotStickingIml;
                materialToUpdate.CompactionRollerIssue = material.CompactionRollerIssue;
                materialToUpdate.CrossedTow = material.CrossedTow;
                materialToUpdate.SpliceBreak = material.SpliceBreak;
                materialToUpdate.TowJumpOffRoller = material.TowJumpOffRoller;
                materialToUpdate.LostTow = material.LostTow;
                materialToUpdate.TowShredding = material.TowShredding;
                materialToUpdate.SpoolChanges = material.SpoolChanges;
                materialToUpdate.CleanOutFod = material.CleanOutFod;
                materialToUpdate.TowWrapOnqRoller = material.TowWrapOnqRoller;
                materialToUpdate.MaterialDate = material.MaterialDate;
                _context.SaveChanges();
            }
        }

        // Remove an Material
        public void Remove(int id)
        {
            var materialToRemove = _context.Material.Single(o => o.MaterialId == id);
            if (materialToRemove != null)
            {
                _context.Remove(materialToRemove);
                _context.SaveChanges();
            }
        }
    }
}
