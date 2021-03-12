using System;
using System.Collections.Generic;
using System.Drawing;
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
			DatabaseConnect();
		}

		/// <summary>
		/// Load the concatenated first and last names of each address entry into the listbox for viewing.
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
					lstboxCurrentContacts.Items.Add(dr["last_name"].ToString() + ", " + dr["first_name"].ToString());
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

		/// <summary>
		/// When the user selects a name from the listbox, retrieve the address information for the name and display it in the corresponding textboxes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void lstboxCurrentContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
			using (con = new SqliteConnection(DatabaseConnectionString))
            {
				con.Open();

				// The name selected in the listbox is parsed for the last name/first name and fed into the query.
				string lName = lstboxCurrentContacts.Text.Substring(0, lstboxCurrentContacts.Text.IndexOf(','));
				string fName = lstboxCurrentContacts.Text.Substring(lstboxCurrentContacts.Text.IndexOf(' ') + 1, lstboxCurrentContacts.Text.Length - lstboxCurrentContacts.Text.IndexOf(' ') - 1);

				string sql = "SELECT * FROM addressentries WHERE last_name = '" + lName + "'AND first_name ='" + fName + "'";


				SqliteCommand cmd = new SqliteCommand(sql, con);
				SqliteDataReader dr = cmd.ExecuteReader();


				while (dr.Read())
				{
					txtboxFirstName.Text = dr["first_name"].ToString();
					txtboxLastName.Text = dr["last_name"].ToString();
					txtboxAddress.Text = dr["address"].ToString();
					txtboxCity.Text = dr["city"].ToString();
					txtboxState.Text = dr["state"].ToString();
					txtboxZipcode.Text = dr["zipcode"].ToString();
					maskedtxtboxHomePhone.Text = dr["home_phone"].ToString();
					maskedtxtboxCellPhone.Text = dr["cell_phone"].ToString();
					txtboxEmail.Text = dr["email"].ToString();
					txtboxComment.Text = dr["comment"].ToString();
				}
			}		
		}
		

        private void btnAddNewEntry_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtboxLastName.Text)) ;
            {
                // Write new address to the database.
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

        private void btnUpdateEntry_Click(object sender, EventArgs e)
        {
			// Update an existing entry in the address book.
			using (con = new SqliteConnection(DatabaseConnectionString))
			{
				// The name selected in the listbox is parsed for the last name/first name and fed into the query.
				string lName = lstboxCurrentContacts.Text.Substring(0, lstboxCurrentContacts.Text.IndexOf(','));
				string fName = lstboxCurrentContacts.Text.Substring(lstboxCurrentContacts.Text.IndexOf(' ') + 1, lstboxCurrentContacts.Text.Length - lstboxCurrentContacts.Text.IndexOf(' ') - 1);

				SqliteCommand sqlUpdate = new SqliteCommand("UPDATE addressentries SET first_name='" + txtboxFirstName.Text + "', last_name='" + txtboxLastName.Text + "',address='" + txtboxAddress.Text + "',city='" + txtboxCity.Text + "',state='" + txtboxState.Text + "',zipcode='" + txtboxZipcode.Text + "',home_phone='" + maskedtxtboxHomePhone.Text + "',cell_phone='" + maskedtxtboxCellPhone.Text + "',email='" + txtboxEmail.Text + "',comment='" + txtboxComment.Text + "' WHERE last_name = '" + lName + "'AND first_name ='" + fName + "'", con);
				
				con.Open();
				sqlUpdate.ExecuteNonQuery();
			}
		}		
    }
}
