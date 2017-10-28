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
			newClient.AddParameter("@Name", _name);
			newClient.AddParameter("@Phone", _phone);
			newClient.AddParameter("@Address", _address);
			newClient.AddParameter("@Notes", _notes);
			newClient.Execute();
			SetId((int)newClient.GetCommand().LastInsertedId);
		}
	}
}
