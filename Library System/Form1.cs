using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace Library_System
{
    public partial class frmBook : Form
    {
        private OleDbConnection con;
        public frmBook()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LibSys.mdb;Persist Security Info=False;");
            loadDatagrid();
        }


        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtno.Text = grid1.Rows[e.RowIndex].Cells["Accension Number"].Value.ToString();
            txttitle.Text = grid1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
            txtauthor.Text = grid1.Rows[e.RowIndex].Cells["Author"].Value.ToString();
        }
        private void loadDatagrid()
        {
            con.Open();
            OleDbCommand com = new OleDbCommand("SELECT * FROM book ORDER BY [accession_number] ASC", con);
            com.ExecuteNonQuery();
            OleDbDataAdapter adap = new OleDbDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            grid1.DataSource = tab;

            con.Close();

        }

        private void btnadd_click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand com = new OleDbCommand("Insert into book values ('" + txtno.Text + "', '" + txttitle.Text + "', '" + txtauthor.Text + "')", con);
            com.ExecuteNonQuery();

            MessageBox.Show("Successfully Saved!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            txtno.Clear();
            txttitle.Clear();
            txtauthor.Clear();
            loadDatagrid();
        }



        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grid1.SelectedRows.Count > 0) // Check if a row has been selected
            {
                string accessionNumberInput = ShowInputDialog("Enter the Accession Number to edit:", "Input");

                if (!string.IsNullOrEmpty(accessionNumberInput))
                {
                    if (int.TryParse(accessionNumberInput, out int accessionNumber))
                    {
                        string newTitle = ShowInputDialog("Enter the new Title:", "Input");
                        string newAuthor = ShowInputDialog("Enter the new Author:", "Input");

                        if (!string.IsNullOrEmpty(newTitle) && !string.IsNullOrEmpty(newAuthor))
                        {
                            con.Open();
                            OleDbCommand com = new OleDbCommand("UPDATE book SET title = @title, author = @author WHERE accession_number = @no", con);
                            com.Parameters.AddWithValue("@title", newTitle);
                            com.Parameters.AddWithValue("@author", newAuthor);
                            com.Parameters.AddWithValue("@no", accessionNumber);
                            com.ExecuteNonQuery();
                            con.Close();
                            loadDatagrid();
                            MessageBox.Show("Successfully Edited!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Title and Author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Accession Number. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter an Accession Number to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ShowInputDialog(string prompt, string title)
        {
            Form inputForm = new Form();
            Label promptLabel = new Label();
            TextBox textBox = new TextBox();
            Button okButton = new Button();

            inputForm.Text = title;
            promptLabel.Text = prompt;

            okButton.Text = "OK";
            okButton.DialogResult = DialogResult.OK;

            promptLabel.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            okButton.SetBounds(309, 72, 75, 23);

            promptLabel.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            inputForm.ClientSize = new System.Drawing.Size(396, 107);
            inputForm.Controls.AddRange(new Control[] { promptLabel, textBox, okButton });
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.AcceptButton = okButton;

            return inputForm.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox4.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                con.Open();
                OleDbCommand com = new OleDbCommand("SELECT accession_number, title, author FROM book WHERE accession_number LIKE @searchValue OR title LIKE @searchValue OR author LIKE @searchValue", con);
                com.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                OleDbDataAdapter adap = new OleDbDataAdapter(com);
                DataTable tab = new DataTable();

                adap.Fill(tab);
                grid1.DataSource = tab;

                con.Close();
            }
            else
            {
                loadDatagrid();
            }
        }

        // DataGridView CellClick event handler
        private void grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grid1.Rows[e.RowIndex].Selected = true;
            }
        }

        // Delete Button Click event handler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid1.SelectedRows.Count > 0) // Check if a row has been selected
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = grid1.SelectedRows[0];
                    int accessionNumber = Convert.ToInt32(selectedRow.Cells[0].Value); // Assuming the accession number is in the first column

                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LibSys.mdb;Persist Security Info=False;";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        // Create the DELETE command
                        string deleteQuery = "DELETE FROM book WHERE accession_number = @accessionNumber";
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@accessionNumber", accessionNumber);

                            // Execute the DELETE command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Successfully deleted the row!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadDatagrid();
                            }
                            else
                            {
                                MessageBox.Show("No row was deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("CANCELLED!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtno_TextChanged(object sender, EventArgs e)
        {

        }

        private void grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
