using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SchedCover;

namespace AMSPROJECT
{
    public partial class EditEmployeeForm : Form
    {
        // Declare the event
        public event Action OnEmployeeUpdated;

        public EditEmployeeForm(string employeeID, string firstName, string lastName, string email, string address, string position, string basicSalary, string status, string username)
        {
            InitializeComponent();

            // Populate the fields
            txtEmployeeID.Text = employeeID;
            txtEmployeeID.ReadOnly = true; // Make Employee ID non-editable
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtEmail.Text = email;
            txtAddress.Text = address;
            txtPosition.Text = position;
            txtBasicSalary.Text = basicSalary;
            txtStatus.Text = status;
            txtUsername.Text = username;
        }

            
        private void btnSave_Click_1(object sender, EventArgs e)
        {
                string query = @"UPDATE employee 
                             SET FirstName = @fname, LastName = @lname, Email = @email, Address = @address, 
                                 Position = @position, BasicSalary = @bsalary, Status = @status, Username = @username
                             WHERE EmployeeID = @employeeID";

                try
                {
                    using (MySqlConnection connection = DBConn.Instance.Connection)
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(query, connection);

                        // Add parameters for the update query
                        command.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text);
                        command.Parameters.AddWithValue("@fname", txtFirstName.Text);
                        command.Parameters.AddWithValue("@lname", txtLastName.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@address", txtAddress.Text);
                        command.Parameters.AddWithValue("@position", txtPosition.Text);
                        command.Parameters.AddWithValue("@bsalary", txtBasicSalary.Text);
                        command.Parameters.AddWithValue("@username", txtUsername.Text);
                        command.Parameters.AddWithValue("@status", txtStatus.Text);

                
                    command.ExecuteNonQuery();
                    }

                
                    MessageBox.Show("Employee record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                    OnEmployeeUpdated?.Invoke();

                    // Close the form automatically
                    this.DialogResult = DialogResult.OK; 
                    this.Close(); // Close the form
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
