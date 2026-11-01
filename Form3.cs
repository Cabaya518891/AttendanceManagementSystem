using MySql.Data.MySqlClient;
using SchedCover;
using System;
using System.IO;
using System.Windows.Forms;

namespace AMSPROJECT
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            txtpassword.PasswordChar = '*'; // Masks the password with '*'
        }

        public static string ValidateUser(string username, string password)
        {
            // Reset session role before validation
            if (UserSession.Instance != null)
            {
                UserSession.Instance.AccessRole = null;
            }

            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                string query = @"
                                SELECT j.access, e.employeeid, e.firstname, e.lastname 
                                FROM employee e
                                JOIN job j
                                ON e.jobid = j.jobid
                                WHERE e.username = @Username AND e.password = @Password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        UserSession.Instance.UserId = reader.GetInt32("employeeid");
                        UserSession.Instance.UserName = reader.GetString("firstname") + " " + reader.GetString("lastname");
                        UserSession.Instance.AccessRole = reader.GetString("access");

                        // Debugging: Print the user and role for validation
                        Console.WriteLine($"User: {UserSession.Instance.UserName}, Role: {UserSession.Instance.AccessRole}");
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    LogError($"SQL Error: {ex.Message}");
                    MessageBox.Show("Database error occurred while logging in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    LogError($"General Error: {ex.Message}");
                    MessageBox.Show("An error occurred during login. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return UserSession.Instance != null ? UserSession.Instance.AccessRole : null;
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            // Validate the user credentials
            ValidateUser(username, password);

            // Ensure the session has a valid role
            if (UserSession.Instance.AccessRole != null)
            {
                // Hide the login form BEFORE showing the new window
                this.Hide();

                if (UserSession.Instance.AccessRole.Equals("staff", StringComparison.OrdinalIgnoreCase))
                {
                    Form1 staffForm = new Form1();
                    staffForm.ShowDialog();
                    this.Close(); // Close login window after staff form closes
                }
                else if (UserSession.Instance.AccessRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    Form2 adminForm = new Form2();
                    adminForm.ShowDialog();
                    this.Close(); // Close login window after admin form closes
                }
                else
                {
                    this.Show(); // Re-show login window if unknown role
                    MessageBox.Show($"Unknown role: {UserSession.Instance.AccessRole}", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Log errors to a file
        private static void LogError(string message)
        {
            string logFilePath = "error_log.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error logging to file: " + ex.Message);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}