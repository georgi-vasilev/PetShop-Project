using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for client table.
    /// </summary>
    class ClientController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Function that add information to the database about a client
        /// </summary>
        /// <param name="client">Argumet based on model used to add information in the database.</param>
        public void AddClient(Models.Client client)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Clients.Add(client);
                petShopContext.SaveChanges();
            }
        }

        /// <summary>
        /// Function to update information about the client.
        /// </summary>
        /// <param name="client">Argumet based on model used to update information in the database.</param>
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


        /// <summary>
        /// Function to delete information about a client.
        /// </summary>
        /// <param name="client">Argumet based on model used to delete information in the database.</param>
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

        /// <summary>
        /// Function to return all clients which you search by the given client name and SSN 
        /// </summary>
        /// <param name="clientName">Argumet that reads from the console the client name.</param>
        /// <param name="SSN">Argument that reads from the console the client SSN</param>
        /// <returns></returns>
        public List<Client> SearchByTagsClient(string clientName, string SSN)
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Clients.Where(x => x.ClientName == clientName && x.Ssn == SSN).ToList();
            }
        }

        /// <summary>
        /// Function to display all information about the clients in the database.
        /// </summary>
        /// <returns>Returns all information about the clients converted to list.</returns>
        public List<Client> GetAllClients()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Clients.ToList();
            }
        }
    }
}
