using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.CsharpSqlite.SQLiteClient;

namespace Address_Book
{
    class SQLDatabase
    {

		SqliteConnection con;
		string DatabaseConnectionString = "uri = Address Book.db";

		// Used to populate a single address entry.
		AddressEntry addressEntry = new AddressEntry();

		// Holds all the current address entries.
		public List<AddressEntry> addressEntries = new List<AddressEntry>();

		// Temp list for new addresses
		public List<AddressEntry> newEntries = new List<AddressEntry>();

				
		public SQLDatabase(){}


		/// <summary>
		/// Load the addresses from the database to the addressEntries list.
		/// </summary>
		public void DatabaseConnect()
		{
			using (con = new SqliteConnection(DatabaseConnectionString))
			{
				con.Open();

				string sql = "SELECT * FROM addressentries ORDER BY last_name ASC";

				SqliteCommand cmd = new SqliteCommand(sql, con);
				SqliteDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					// Represents a single address entry.
					addressEntry.FirstName = dr["first_name"].ToString();
					addressEntry.LastName = dr["last_name"].ToString();
					addressEntry.Address = dr["address"].ToString();
					addressEntry.City = dr["city"].ToString();
					addressEntry.State = dr["state"].ToString();
					addressEntry.Zipcode = dr["zipcode"].ToString();
					addressEntry.HomePhone = dr["home_phone"].ToString();
					addressEntry.CellPhone = dr["cell_phone"].ToString();
					addressEntry.Email = dr["email"].ToString();
					addressEntry.Comment = dr["comment"].ToString();

					// Add the entry to the list.
					addressEntries.Add(addressEntry);
				}
			}
		}


		/// <summary>
		/// This will run if this is the first time this project was built, which means the database didn't exist till now either.
		/// </summary>
		public void CreateTable()
		{
			using (con = new SqliteConnection(DatabaseConnectionString))
			{
				con.Open();

				try
				{
					SqliteCommand sqlCreateTable = new SqliteCommand("CREATE TABLE addressentries (id INTEGER PRIMARY KEY " + "AUTOINCREMENT NOT NULL, first_name varchar(50) NOT NULL, last_name varchar(50) NOT NULL," +
					  "address varchar(50), city varchar(50), state varchar(50), zipcode varchar(50), home_phone varchar(50)," +
					  "cell_phone varchar(50), email varchar(50), comment varchar(100))", con);

					sqlCreateTable.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					//MessageBox.Show(ex.ToString());
				}
			}
		}
		

		/// <summary>
		/// Add new addresses to the database.
		/// </summary>
		public void AddNewEntry(AddressEntry addressEntry)
        {
			// Write new address to the database.
			using (con = new SqliteConnection(DatabaseConnectionString))
			{
				SqliteCommand sqlInsert = new SqliteCommand("INSERT INTO addressentries (first_name, last_name, address, city, state, zipcode, home_phone, cell_phone, email, comment) VALUES(@first_name, @last_name, @address, @city, @state, @zipcode, @home_phone, @cell_phone, @email, @comment)", con);

				con.Open();
				
				//foreach (AddressEntry addressEntry in newEntries)
				//{
					sqlInsert.Parameters.Add("@first_name", addressEntry.FirstName);
					sqlInsert.Parameters.Add("@last_name", addressEntry.LastName);
					sqlInsert.Parameters.Add("@address", addressEntry.Address);
					sqlInsert.Parameters.Add("@city", addressEntry.City);
					sqlInsert.Parameters.Add("@state", addressEntry.State);
					sqlInsert.Parameters.Add("@zipcode", addressEntry.Zipcode);
					sqlInsert.Parameters.Add("@home_phone", addressEntry.HomePhone);
					sqlInsert.Parameters.Add("@cell_phone", addressEntry.CellPhone);
					sqlInsert.Parameters.Add("@email", addressEntry.Email);
					sqlInsert.Parameters.Add("@comment", addressEntry.Comment);

					sqlInsert.ExecuteNonQuery();
				//}
			}
		}


		/// <summary>
		/// Updates the changes made to an address.
		/// </summary>
		/// <param name="index">The index of the record needed to be updated.</param>
		public void UpdateAddress(int index)
		{

			// Update an existing entry in the address book.
			using (con = new SqliteConnection(DatabaseConnectionString))
			{
                SqliteCommand sqlUpdate = new SqliteCommand("UPDATE addressentries SET first_name='" + addressEntries[index].FirstName + "', last_name='" + addressEntries[index].LastName + "',address='" + addressEntries[index].Address + "',city='" + addressEntries[index].City + "',state='" + addressEntries[index].State + "',zipcode='" + addressEntries[index].Zipcode + "',home_phone='" + addressEntries[index].HomePhone + "',cell_phone='" + addressEntries[index].CellPhone + "',email='" + addressEntries[index].Email + "',comment='" + addressEntries[index].Comment + "' WHERE last_name = '" + addressEntries[index].LastName + "'AND first_name ='" + addressEntries[index].FirstName + "'", con);


				con.Open();
				sqlUpdate.ExecuteNonQuery();
			}
		}
	}
}
