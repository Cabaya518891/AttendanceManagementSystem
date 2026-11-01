using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SchedCover;

namespace AMSPROJECT
{

    public partial class UserControlemployee : UserControl
    {
        // Declare a variable to hold the profile image in byte array format


        public UserControlemployee()
        {
            InitializeComponent();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            // Check if any required fields are empty
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(lname.Text) ||
                string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(address.Text) ||
                string.IsNullOrWhiteSpace(position.Text) || string.IsNullOrWhiteSpace(Bsalary.Text) ||
                string.IsNullOrWhiteSpace(txtstatus.Text) || string.IsNullOrWhiteSpace(username.Text) ||
                string.IsNullOrWhiteSpace(password.Text))
            {
                // Show a message if any required field is empty
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for user confirmation before adding a new employee
            var confirmResult = MessageBox.Show("Are you sure you want to add this new employee?",
                                                 "Confirm Add", MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string insertEmployeeQuery = @"
            INSERT INTO employee (FirstName, LastName, Email, Address, Position, BasicSalary, Status, Username, Password) 
            VALUES (@fname, @lname, @email, @address, @position, @bsalary, @status, @username, @password);
            SELECT LAST_INSERT_ID();
        ";

                try
                {
                    using (MySqlConnection connection = DBConn.Instance.Connection)
                    {
                        connection.Open();

                        int newEmployeeId;
                        using (MySqlCommand command = new MySqlCommand(insertEmployeeQuery, connection))
                        {
                            // Add parameters for employee data
                            command.Parameters.AddWithValue("@fname", fname.Text);
                            command.Parameters.AddWithValue("@lname", lname.Text);
                            command.Parameters.AddWithValue("@email", email.Text);
                            command.Parameters.AddWithValue("@address", address.Text);
                            command.Parameters.AddWithValue("@position", position.Text);
                            command.Parameters.AddWithValue("@bsalary", Bsalary.Text);
                            command.Parameters.AddWithValue("@status", txtstatus.Text);
                            command.Parameters.AddWithValue("@username", username.Text);
                            command.Parameters.AddWithValue("@password", password.Text);

                            // Execute the query and get the new employee ID
                            object result = command.ExecuteScalar();
                            newEmployeeId = Convert.ToInt32(result);
                        }

                        // Add the corresponding payroll record
                        string insertPayrollQuery = @"
                    INSERT INTO payroll (employeeid, month, year, basicsalary) 
                    VALUES (@empid, @month, @year, @basicSalary);
                ";

                        using (MySqlCommand payrollCommand = new MySqlCommand(insertPayrollQuery, connection))
                        {
                            payrollCommand.Parameters.AddWithValue("@empid", newEmployeeId);
                            payrollCommand.Parameters.AddWithValue("@month", DateTime.Now.Month);
                            payrollCommand.Parameters.AddWithValue("@year", DateTime.Now.Year);
                            payrollCommand.Parameters.AddWithValue("@basicSalary", Bsalary.Text);

                            payrollCommand.ExecuteNonQuery();
                        }
                    }

                    // Success message
                    MessageBox.Show($"{fname.Text} {lname.Text} has been added as {position.Text} in Employee Table, and their payroll record has been created.");

                    // Optionally clear fields
                    fname.Clear();
                    lname.Clear();
                    email.Clear();
                    address.Clear();
                    Bsalary.Clear();
                    username.Clear();
                    password.Clear();
                    txtstatus.SelectedIndex = -1;
                    position.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                // If the user cancels, display a message
                MessageBox.Show("Operation canceled. No employee was added.");
            }
        }

        private void UserControlemployee_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    