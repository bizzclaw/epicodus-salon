using System;
using System.Collections.Generic;

namespace Salon.Models
{
	public class Client
	{
		private int _id;
		public void SetId(int id) {_id = id;}
		public int GetId() {return _id;}

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

		public Client(string name, string phone, string address, string notes)
		{
			_name = name;
			_phone = phone;
			_address = address;
			_notes = notes;
		}
	}
}
