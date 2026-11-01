using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AMSPROJECT
{
    public partial class UserControlsetting : UserControl
    {
        // MySQL connection string
        string connectionString = "Server=localhost;Database=ams_database;User ID=root;Password=;";

        public UserControlsetting()
        {
            InitializeComponent();
            textpassword.PasswordChar = '*';
            textnewpassword.PasswordChar = '*';
            textconfirmpass.PasswordChar = '*';

        }

        private void submit_Click(object sender, EventArgs e)
        {
            string username = textusername.Text.Trim();
            string oldPassword = textpassword.Text;
            string newPassword = textnewpassword.Text;
            string confirmPassword = textconfirmpass.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Username, old password, and new password cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the old and new passwords
            string hashedOldPassword = HashPassword(oldPassword);
            string hashedNewPassword = HashPassword(newPassword);

            // Verify old password and update to the new password
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query to check the old password
                    string selectQuery = "SELECT COUNT(*) FROM employee WHERE LOWER(username) = LOWER(@username) AND password = @oldPassword";

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@username", username);
                        selectCmd.Parameters.AddWithValue("@oldPassword", oldPassword); // Plain text comparison for now

                        int userExists = Convert.ToInt32(selectCmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                            // Update the password if the old password matches
                            string updateQuery = "UPDATE employee SET password = @newPassword WHERE LOWER(username) = LOWER(@username)";

                            using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@username", username);
                                updateCmd.Parameters.AddWithValue("@newPassword", newPassword); // Plain text comparison for now

                                updateCmd.ExecuteNonQuery();
                                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Clear input fields after successful update
                                ClearFields();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Old password is incorrect or username not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Function to hash a password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Function to clear all input fields
        private void ClearFields()
        {
            textusername.Text = string.Empty;
            textpassword.Text = string.Empty;
            textnewpassword.Text = string.Empty;
            textconfirmpass.Text = string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textusername_TextChanged(object sender, EventArgs e)
        {
        }


    }
}


