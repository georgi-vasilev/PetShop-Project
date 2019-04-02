using System.Collections.Generic;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for client table.
    /// </summary>
    public class ClientController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Empty constructor of this class which create new PetShopContext.
        /// </summary>
        public ClientController()
        {
            this.petShopContext = new PetShopContext();
        }


        public ClientController(PetShopContext context)
        {
            this.petShopContext = context;
        }


        /// <summary>
        /// Function that add information to the database about a client
        /// </summary>
        /// <param name="client">Argumet based on model used to add information in the database.</param>
        public void AddClient(Models.Client client)
        {
            using (petShopContext)
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
            using (petShopContext)
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
            using (petShopContext)
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
            using (petShopContext)
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
            using (petShopContext)
            {
                return petShopContext.Clients.ToList();
            }
        }



        /// <summary>
        /// Method to show all clients with same name
        /// </summary>
        /// <param name="clientName">Argument that read from the console</param>
        /// <returns>Found the same client name</returns>
        public List<Client> GetAllTheSameClientName(string clientName)
        {
            List<Client> result = new List<Client>();
            using (petShopContext)
            {
                result = petShopContext.Clients.Where(n => n.ClientName == clientName).ToList();
                return result;
            }
        }

    }
}
