using CMS.BLL.Abstract;
using CMS.DAL.Abstract;
using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Concrete
{
    public class VehicleFleetService : IVehicleFleetService
    {
        IVehicleFleetDAL _vehicleFleetDAL;
        public VehicleFleetService(IVehicleFleetDAL vehicleFleetDAL)
        {
            _vehicleFleetDAL = vehicleFleetDAL;
        }
        public void Delete(VehicleFleet entity)
        {
            _vehicleFleetDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public VehicleFleet Get(int entityID)
        {
            return _vehicleFleetDAL.Get(a => a.Id == entityID);
        }

        public ICollection<VehicleFleet> GetAll()
        {
            return _vehicleFleetDAL.GetAll();
        }

        public void Insert(VehicleFleet entity)
        {
            _vehicleFleetDAL.Add(entity);
        }

        public void Update(VehicleFleet entity)
        {
            _vehicleFleetDAL.Update(entity);
        }
    }
}
