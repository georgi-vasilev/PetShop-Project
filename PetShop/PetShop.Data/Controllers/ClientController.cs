using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    class ClientController
    {
        private PetShopContext petShopContext;
        public void AddClient(Models.Client client)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Clients.Add(client);
                petShopContext.SaveChanges();
            }
        }

        public void UpdateClient(Models.Client client)
        {
            using (petShopContext = new PetShopContext())
            {
                var update = petShopContext.Clients.Find(client.Id);
                if (update != null)
                {
                    petShopContext.Entry(update).CurrentValues.SetValues(client);
                    petShopContext.SaveChanges();
                }
            }
        }

        public void RemoveClient(Models.Client client /*int id*/)
        {
            using (petShopContext = new PetShopContext())
            {
                var delClient = petShopContext.Clients.Find(client.Id);
                if (delClient != null)
                {
                    petShopContext.Clients.Remove(delClient);
                    petShopContext.SaveChanges();
                }
            }
        }

        public List<Client> SearchByTagsClient(string clientName, string sSN)
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Clients.Where(x => x.ClientName == clientName && x.Ssn == sSN).ToList();
            }
        }

        public List<Client> GetAllClients()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Clients.ToList();
            }
        }
    }
}
