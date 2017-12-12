using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IEquipmentFailureRepository
    {
        IEnumerable<EquipmentFailure> GetAll();
        EquipmentFailure Find(int id);
        void Add(EquipmentFailure equipmentfailure);
        void Update(EquipmentFailure equipmentfailure);
        void Remove(int id);
    }
}
