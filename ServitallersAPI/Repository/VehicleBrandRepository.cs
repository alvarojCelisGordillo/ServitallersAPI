using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServitallersAPI.Data;
using ServitallersAPI.Models;
using ServitallersAPI.Repository.IRepository;

namespace ServitallersAPI.Repository
{
    public class VehicleBrandRepository : IVehicleBrandRepository
    {
        private readonly ApplicationDbContext _db;

        public VehicleBrandRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<VehicleBrand> GetVehicleBrands()
        {
            return _db.VehicleBrands.OrderBy(a => a.Make).ToList();
        }

        public VehicleBrand GetVehicleBrand(int vehicleBrandId)
        {
            return _db.VehicleBrands.FirstOrDefault(a => a.Id == vehicleBrandId);
        }

        public bool VehicleExists(string name)
        {
            bool value = _db.VehicleBrands.Any(a => a.Model.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool VehicleBrandExists(int id)
        {
            return _db.VehicleBrands.Any(a => a.Id == id);
        }

        public bool CreateVehicleBrand(VehicleBrand vehicleBrand)
        {
            _db.VehicleBrands.Add(vehicleBrand);
            return Save();
        }

        public bool UpdateVehicleBrand(VehicleBrand vehicleBrand)
        {
            _db.VehicleBrands.Update(vehicleBrand);
            return Save();
        }

        public bool DeleteVehicleBrand(VehicleBrand vehicleBrand)
        {
            _db.VehicleBrands.Remove(vehicleBrand);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
