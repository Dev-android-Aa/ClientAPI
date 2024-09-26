using ClientAPI.Models;

namespace ClientAPI.Service
{
    public class ClientServices
    {

        static List<Client> clients { get; }
        static int nextClientId = 3;

        static ClientServices()
        {
            clients = new List<Client>()
            {
                new Client{Id=1 ,Name ="Adil",Title="developer",Salary=2000},
                new Client{Id=2 ,Name ="Aadjou",Title="Concepteur",Salary=2000},  

            };
        }

        public static List<Client> GetALL() => clients;
        public static Client? GetByID(int id) => clients.FirstOrDefault(c => c.Id == id);

        public static void ADDClient(Client client)
        {
            client.Id = nextClientId++;
            clients.Add(client);
        }
         public static void Update(Client client)
        {
            var index = clients.FindIndex(c => c.Id == client.Id);
            if(index == -1)
            {
                return;
            }
            clients[index] = client;
        }

        public static void Delete(int id)
        {
            var client = GetByID(id);

            if (client is null)
            {
                return;
            }
            clients.Remove(client);
        }

    }
}
