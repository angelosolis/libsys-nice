using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System
{
    public partial class frmBorrow : Form
    {
        public frmBorrow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Connection string
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LibSys.mdb;Persist Security Info=False;";

            // Create OleDbConnection object
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                // Create the SQL query
                string query = "INSERT INTO borrower (borrower_fname, borrower_lname, borrower_phone, borrower_email) " +
                               "VALUES (@fname, @lname, @phone, @email)";
                OleDbCommand command = new OleDbCommand(query, connection);

                // Set parameter values
                command.Parameters.AddWithValue("@fname", borrow_Fname.Text);
                command.Parameters.AddWithValue("@lname", borrow_Lname.Text);
                command.Parameters.AddWithValue("@phone", borrow_phoneNum.Text);
                command.Parameters.AddWithValue("@email", borrow_emailAdd.Text);

                // Open the database connection and execute the query
                connection.Open();
                command.ExecuteNonQuery();

                // Show a success message or perform any additional actions
                MessageBox.Show("Data saved successfully!");

                borrow_emailAdd.Clear();
                borrow_Fname.Clear();
                borrow_Lname.Clear();
                borrow_phoneNum.Clear();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                connection.Close();
            }
        }
    }
}
