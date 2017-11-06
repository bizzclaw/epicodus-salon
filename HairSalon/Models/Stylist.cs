using System;
using System.Collections.Generic;

namespace HairSalon.Models
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

        public Stylist(string name)
        {
            SetName(name);
        }

        public void Save()
        {
            Query newStylist = new Query("INSERT INTO stylists VALUES (NULL, @Name)");
            newStylist.AddParameter("@Name", GetName());
            newStylist.Execute();
            SetId((int)newStylist.GetCommand().LastInsertedId);
        }

        public void AssignClient(Client client)
        {
            client.Save(GetId());
        }

        public List<Client> GetClients()
        {
            Query clientQuery = new Query("SELECT * from clients WHERE stylist_id = @Id");
            clientQuery.AddParameter("Id", _id.ToString());
            List<Client> clientList = new List<Client> {};
            var rdr = clientQuery.Read();
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                int stylistId = rdr.GetInt32(1);
                string clientName = rdr.GetString(2);
                string clientPhone = rdr.GetString(3);
                string clientAddress = rdr.GetString(4);
                string clientNotes = rdr.GetString(5);

                Client newClient = new Client(clientName, clientPhone, clientAddress, clientNotes);
                newClient.SetId(clientId);
                newClient.SetStylistId(stylistId);
                clientList.Add(newClient);
            }
            return clientList;
        }

        public static Stylist Find(int id)
        {
            Query findStylist = new Query("SELECT (name) FROM stylists WHERE stylist_id = @Id");
            findStylist.AddParameter("@Id", id.ToString());
            var rdr = findStylist.Read();
            string name = "";

            while (rdr.Read())
            {
                name = rdr.GetString(0);
            }
            Stylist found = new Stylist(name);
            found.SetId(id);
            return found;
        }

        public static List<Stylist> GetAll()
        {
            Query getStylists = new Query("SELECT * from stylists");
            List<Stylist> stylistList = new List<Stylist> {};
            var rdr = getStylists.Read();
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);

                Stylist newStylist = new Stylist(stylistName);
                newStylist.SetId(stylistId);
                stylistList.Add(newStylist);
            }
            return stylistList;
        }

        public static void ClearAll()
		{
			Query clearClients = new Query("DELETE FROM stylists");
			clearClients.Execute();
		}

    }
}
