using System;

namespace Address_Book
{
	/// <summary>
	/// Used as a single address entry.
	/// </summary>
	public struct AddressEntry
	{		
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zipcode { get; set; }
		public string Email { get; set; }		
		public string HomePhone { get; set; }
		public string CellPhone { get; set; }
		public string Comment { get; set; }		
	}
}
