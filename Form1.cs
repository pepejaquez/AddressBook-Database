using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Community.CsharpSqlite.SQLiteClient;

namespace Address_Book
{
    public partial class Form1 : Form
    {
		SqliteConnection con;
		string DatabaseConnectionString = "uri = Address Book.db";

		/// <summary>
		///  The AddressEntry type for the list is the class with basic address data fields.
		/// </summary>
		List<AddressEntry> addressEntries = new List<AddressEntry>();	


		public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			// Connect to the database and pull all the address info into the addressEntries list.
			DatabaseConnect();

			foreach(AddressEntry addressEntry in addressEntries)
            {
				lstboxCurrentContacts.Items.Add(addressEntry.LastName + ", " + addressEntry.FirstName);
            }

        }

		public void DatabaseConnect()
		{
			con = new SqliteConnection(DatabaseConnectionString);
			con.Open();
			
			string sql = "SELECT * FROM addressentries ORDER BY last_name ASC";

			SqliteCommand cmd = new SqliteCommand(sql, con);
			SqliteDataReader dr = cmd.ExecuteReader();
			

			while (dr.Read())
			{
				AddressEntry addressEntry = new AddressEntry();

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

				addressEntries.Add(addressEntry);
				
			}
			
			dr.Close();
			con.Close();
		}
		

		private void lstboxCurrentContacts_DoubleClick(object sender, EventArgs e)
        {
			string str = lstboxCurrentContacts.SelectedItem.ToString();

			// Use the firstName and lastName from the listbox entries to find and display the correct address information for the entry.
			string firstName = str.Substring(str.IndexOf(' '), str.Length - str.IndexOf(' ') - 1);
			string lastName = str.Substring(0, str.IndexOf(','));


            foreach (AddressEntry addressEntry in addressEntries)
            {
				if (addressEntry.FirstName.Equals(firstName) && addressEntry.LastName.Equals(lastName));
                {
					txtboxFirstName.Text = addressEntry.FirstName;
					txtboxLastName.Text = addressEntry.LastName;
					txtboxAddress.Text = addressEntry.Address;
					txtboxCity.Text = addressEntry.City;
					txtboxState.Text = addressEntry.State;
					txtboxZipcode.Text = addressEntry.Zipcode;
					maskedtxtboxHomePhone.Text = addressEntry.HomePhone;
					maskedtxtboxCellPhone.Text = addressEntry.CellPhone;
					txtboxEmail.Text = addressEntry.Email;
					txtboxComment.Text = addressEntry.Comment;
                }
            }
        }

        private void btnNewUpdateEntry_Click(object sender, EventArgs e)
        {
			// Update changes/add new addresses to address book.

			// Write changes or new addresses to the database.
			if (this.txtboxFirstName.Text != "")
			{
				
				using (con = new SqliteConnection(DatabaseConnectionString))
                {
					SqliteCommand sqlInsert = new SqliteCommand("INSERT INTO addressentries (first_name, last_name, address, city, state, zipcode, home_phone, cell_phone, email, comment) VALUES(@first_name, @last_name, @address, @city, @state, @zipcode, @home_phone, @cell_phone, @email, @comment)", con);

					sqlInsert.Parameters.Add("@first_name", txtboxFirstName.Text);
					sqlInsert.Parameters.Add("@last_name", txtboxLastName.Text);
					sqlInsert.Parameters.Add("@address", txtboxAddress.Text);
					sqlInsert.Parameters.Add("@city", txtboxCity.Text);
					sqlInsert.Parameters.Add("@state", txtboxState.Text);
					sqlInsert.Parameters.Add("@zipcode", txtboxZipcode.Text);
					sqlInsert.Parameters.Add("@home_phone", maskedtxtboxHomePhone.Text);
					sqlInsert.Parameters.Add("@cell_phone", maskedtxtboxCellPhone.Text);
					sqlInsert.Parameters.Add("@email", txtboxEmail.Text);
					sqlInsert.Parameters.Add("@comment", txtboxComment.Text);

					con.Open();
					sqlInsert.ExecuteNonQuery();
				}				
			}
		}

		private void ClearFormControls()
        {
			txtboxFirstName.Text = string.Empty;
			txtboxLastName.Text = string.Empty;
			txtboxAddress.Text = string.Empty;
			txtboxCity.Text = string.Empty;
			txtboxState.Text = string.Empty;
			txtboxZipcode.Text = string.Empty;
			maskedtxtboxHomePhone.Text = string.Empty;
			maskedtxtboxCellPhone.Text = string.Empty;
			txtboxEmail.Text = string.Empty;
			txtboxComment.Text = string.Empty;
		}
    }
}
