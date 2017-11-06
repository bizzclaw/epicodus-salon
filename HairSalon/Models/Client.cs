using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
	public class Client
	{
		private int _id;
		public void SetId(int id) {_id = id;}
		public int GetId() {return _id;}

		private int _stylistId;
		public void SetStylistId(int stylistId) {_stylistId = stylistId;}
		public int GetStylistId() {return _stylistId;}

		private string _name;
		public void SetName(string name) {_name = name;}
		public string GetName() {return _name;}

		private string _phone;
		public void SetPhone(string phone) {_phone = phone;}
		public string GetPhone() {return _phone;}

		private string _address;
		public void SetAddress(string address) {_address = address;}
		public string GetAddress() {return _address;}

		private string _notes;
		public void SetNotes(string notes) {_notes = notes;}
		public string GetNotes() {return _notes;}

		public static void ClearAll()
		{
			Query clearClients = new Query("DELETE FROM clients");
			clearClients.Execute();
		}

		public Client(string name, string phone, string address, string notes)
		{
			SetName(name);
			SetPhone(phone);
			SetAddress(address);
			SetNotes(notes);
		}

		public void Save(int stylistId)
		{
			Query newClient = new Query("INSERT INTO clients VALUES(NULL, @StylistId, @Name, @Phone, @Address, @Notes)");
			newClient.AddParameter("@StylistId", stylistId.ToString());
			newClient.AddParameter("@Name", GetName());
			newClient.AddParameter("@Phone", GetPhone());
			newClient.AddParameter("@Address", GetAddress());
			newClient.AddParameter("@Notes", GetNotes());
			newClient.Execute();
			SetId((int)newClient.GetCommand().LastInsertedId);
		}

		public void Update()
		{
			Query updateClient = new Query("UPDATE clients SET name = @Name, phone = @Phone, address = @Address, notes = @Notes WHERE client_id = @ClientId");
			updateClient.AddParameter("@ClientId", GetId().ToString());
			updateClient.AddParameter("@Name", GetName());
			updateClient.AddParameter("@Phone", GetPhone());
			updateClient.AddParameter("@Address", GetAddress());
			updateClient.AddParameter("@Notes", GetNotes());
			updateClient.Execute();
		}

		public void Delete()
		{
			Query deleteClient = new Query("DELETE FROM clients WHERE client_id = @ClientId");
			deleteClient.AddParameter("@ClientId", GetId().ToString());
			deleteClient.Execute();
		}

		public static Client Find(int id)
        {
            Query findClient = new Query("SELECT * FROM clients WHERE client_id = @Id");
            findClient.AddParameter("@Id", id.ToString());
            var rdr = findClient.Read();
			int stylistId = 0;
			string name = "";
			string phone = "";
			string address = "";
			string notes = "";

            while (rdr.Read())
            {
				stylistId = rdr.GetInt32(1);
				name = rdr.GetString(2);
				phone = rdr.GetString(3);
				address = rdr.GetString(4);
				notes = rdr.GetString(5);
            }
            Client found = new Client(name, phone, address, notes);
			found.SetStylistId(stylistId);
            found.SetId(id);
            return found;
        }

		public static List<Client> GetAll()
        {
			List<Client> allClients = new List<Client> {};
			Query getAllClients = new Query("SELECT * FROM clients");
			var rdr = getAllClients.Read();
			while (rdr.Read())
			{
				int stylistId = rdr.GetInt32(1);
				string name = rdr.GetString(2);
				string phone = rdr.GetString(3);
				string address = rdr.GetString(4);
				string notes = rdr.GetString(5);
				Client client = new Client(name, phone, address, notes);
				client.SetId(rdr.GetInt32(0));

				allClients.Add(client);
			}
			return allClients;
		}
	}
}
