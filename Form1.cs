using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Community.CsharpSqlite.SQLiteClient;

namespace Address_Book
{
    public partial class Form1 : Form
    {
		SQLDatabase sqlDatabase;
		AddressEntry addressEntry = new AddressEntry();

		public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			sqlDatabase = new SQLDatabase();
			sqlDatabase.CreateTable();
			sqlDatabase.DatabaseConnect();
			PopulateListBox();
		}
		

		/// <summary>
		/// When the user selects a name from the listbox, retrieve the address information for the name and display it in the corresponding textboxes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void lstboxCurrentContacts_SelectedIndexChanged(object sender, EventArgs e)
        {			
			DisplayAddress();
		}


		private void btnClearAddress_Click(object sender, EventArgs e)
		{
			ClearFormControls();
		}


		private void btnAddNewEntry_Click(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(txtboxLastName.Text) || !string.IsNullOrEmpty(txtboxFirstName.Text))
            {
				// Holds a single address.
				SingleAddressEntry();

				// Add the entry to the main list.
				sqlDatabase.addressEntries.Add(addressEntry);

				sqlDatabase.AddNewEntry(addressEntry);

				// Add the entry to the temp list. The temp list holds all the new address entries that will be written to the database upon closure of the program.
				//sqlDatabase.newEntries.Add(addressEntry);
			}

			// Make sure the control is clear BEFORE displaying the names so duplicates are not displayed to the user.
			lstboxCurrentContacts.Items.Clear();
			PopulateListBox();

			ClearFormControls();
        }

        private void btnUpdateEntry_Click(object sender, EventArgs e)
        {
			// Get the index of the entry to update.
			int recordIndex = lstboxCurrentContacts.SelectedIndex;

			// Holds a single address.
			SingleAddressEntry();

			// Get rid of the old record.
			sqlDatabase.addressEntries.RemoveAt(recordIndex);

			// Add the updated record to the list.
			sqlDatabase.addressEntries.Add(addressEntry);			

			// Make sure the control is clear BEFORE displaying the names so duplicates are not displayed to the user.
			lstboxCurrentContacts.Items.Clear();
			PopulateListBox();

			// Update the record in the database.
			sqlDatabase.UpdateAddress(recordIndex);

			ClearFormControls();

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
		/// Add all the addresses to the listbox for viewing.
		/// </summary>
		private void PopulateListBox()
        {
			SortLastNames(sqlDatabase);
			foreach(AddressEntry addressEntry in sqlDatabase.addressEntries)
            {
				lstboxCurrentContacts.Items.Add(addressEntry.LastName + ", " + addressEntry.FirstName);
            }
        }


		/// <summary>
		/// Displays each piece of the address in the proper text box for the selected name in lstboxCurrentContacts.
		/// </summary>
		/// <param name="lastName">Search param to locate the proper record.</param>
		/// <param name="firstName">Search param to locate the proper record.</param>
		private void DisplayAddress()
        {
			// The name selected in the listbox is parsed for the last name/first name and fed into the query.
			string lastName = lstboxCurrentContacts.Text.Substring(0, lstboxCurrentContacts.Text.IndexOf(','));
			string firstName = lstboxCurrentContacts.Text.Substring(lstboxCurrentContacts.Text.IndexOf(' ') + 1, lstboxCurrentContacts.Text.Length - lstboxCurrentContacts.Text.IndexOf(' ') - 1);

			foreach (AddressEntry addressEntry in sqlDatabase.addressEntries)
            {
				if(addressEntry.LastName == lastName && addressEntry.FirstName == firstName)
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

		private void SingleAddressEntry()
        {
			// Represents a single address entry.
			addressEntry.FirstName = txtboxFirstName.Text;
			addressEntry.LastName = txtboxLastName.Text;
			addressEntry.Address = txtboxAddress.Text;
			addressEntry.City = txtboxCity.Text;
			addressEntry.State = txtboxState.Text;
			addressEntry.Zipcode = txtboxZipcode.Text;
			addressEntry.HomePhone = maskedtxtboxHomePhone.Text;
			addressEntry.CellPhone = maskedtxtboxCellPhone.Text;
			addressEntry.Email = txtboxEmail.Text;
			addressEntry.Comment = txtboxComment.Text;
		}

		private void SortLastNames(SQLDatabase sqlDatabase)
		{
			sqlDatabase.addressEntries = sqlDatabase.addressEntries.OrderBy(x => x.LastName).ToList();
		}       
    }
}
