using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServitallersAPI.Models;

namespace ServitallersAPI.Repository.IRepository
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();

        Client GetClient(int ClientId);

        bool ClientExists(string FirstName, string LastName);

        bool ClientExists(int ClientId);
        bool CreateClient(Client client);

        bool UpdateClient(Client client);

        bool DeleteClient(Client client);

        bool Save();
    }
}
