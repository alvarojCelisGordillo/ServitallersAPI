using ServitallersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServitallersAPI.Repository.IRepository
{
    public interface IVehicleBrandRepository
    {
        ICollection<VehicleBrand> GetVehicleBrands();

        VehicleBrand GetVehicleBrand(int vehicleBrandId);

        bool VehicleExists(string name);
        bool VehicleBrandExists(int id);
        bool CreateVehicleBrand(VehicleBrand vehicleBrand);
        bool UpdateVehicleBrand(VehicleBrand vehicleBrand);
        bool DeleteVehicleBrand(VehicleBrand vehicleBrand);
        bool Save();

    }
}
