using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServitallersAPI.Data;
using ServitallersAPI.Models;
using ServitallersAPI.Repository.IRepository;

namespace ServitallersAPI.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly ApplicationDbContext _db;

        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool ClientExists(string FirstName, string LastName)
        {
            var value = _db.Clients.Any(
                a => a.FirstName.ToLower().Trim() == FirstName.ToLower()
                    .Trim() && a.FirstLastName.ToLower().Trim() == LastName.ToLower().Trim());
            return value;
        }

        public bool ClientExists(int ClientId)
        {
            var value = _db.Clients.Any(a => a.Id == ClientId);
            return value;
        }

        public bool CreateClient(Client client)
        {
            _db.Clients.Add(client);
            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _db.Clients.Remove(client);
            return Save();
        }

        public Client GetClient(int clientId)
        {
            return _db.Clients.FirstOrDefault(a => a.Id == clientId);
        }

        public ICollection<Client> GetClients()
        {
            return _db.Clients.OrderBy(a => a.FirstName).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateClient(Client client)
        {
            _db.Clients.Update(client);
            return Save();
        }
    }
}
