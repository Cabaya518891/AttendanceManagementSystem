using MySql.Data.MySqlClient;
using SchedCover;
using System;
using System.Windows.Forms;

namespace AMSPROJECT
{
    public partial class UserControlprofile : UserControl
    {
        public UserControlprofile()
        {
            InitializeComponent();
        }

        public void LoadEmployeeData(int employeeID)
        {
            // Query to fetch employee data by EmployeeID
            string query = "SELECT EmployeeID,Username, FirstName, LastName, Email, Address FROM employee WHERE EmployeeID = @EmployeeID";

            // Using MySQL connection from your DBConn singleton
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        // Add parameter to prevent SQL injection and fetch specific employee data
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate TextBoxes with the retrieved data
                                username.Text = reader["FirstName"].ToString();
                                fname.Text = reader["FirstName"].ToString();
                                lname.Text = reader["LastName"].ToString();
                                email.Text = reader["Email"].ToString();
                                address.Text= reader["Address"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No data found for the given Employee ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Display the error message
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UserControlprofile_Load(object sender, EventArgs e)
        {
            // Assuming you want to load the profile of the currently logged-in user:
            int currentEmployeeID = UserSession.Instance.UserId;  // Get the current logged-in user's EmployeeID
            LoadEmployeeData(currentEmployeeID);
        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
