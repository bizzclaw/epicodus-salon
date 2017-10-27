using System;
using System.Collections.Generic;

namespace Salon.Models
{
    public class Stylist
    {
        //NAME

        private int _id;
        public void SetId(int id) {_id = id;}
        public int GetId() {return _id;}

        private string _name;
        public void SetName(string name) {_name = name;}
        public string GetName() {return _name;}

        public List<Client> GetClients()
        {
            clientQuery = new Query("SELECT clients* from stylists JOIN (stylists clients) WHERE stylist_id = @Id");
            clientQuery.AddParameter("Id", _id);
            List<Client> clientList = new List<Client> {};
            var rdr = clientQuery.Read();
            while (rdr.Read())
            {
                int clientId = rdr.ReadInt32(0);
                string clientName = rdr.ReadString(1);
                string clientPhone = rdr.ReadString(2);
                string clientAddress = rdr.ReadString(3);
                string clientNotes = rdr.ReadString(4);

                Client newClient = new Client(clientId, clientName, clientPhone, clientAddress, clientNotes);
                clientList.Add(newClient);
            }
            return clientList;
        }
    }
}
