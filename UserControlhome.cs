using MySql.Data.MySqlClient;
using SchedCover;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AMSPROJECT
{
    public partial class UserControlhome : UserControl
    {
        public UserControlhome()
        {
            InitializeComponent();
        }

        private void UserControlhome_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            RefreshAttendanceDisplay();
        }

        // Event Handler for Time-In Button
        private void hometimein_Click(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                if (UserSession.Instance == null || UserSession.Instance.UserId == null)
                {
                    MessageBox.Show("User session is not set. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (HasTimeInAlready(currentDate))
                {
                    MessageBox.Show("You have already timed in today.", "Duplicate Time-In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (MySqlConnection conn = DBConn.Instance.Connection)
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Database connection is not initialized.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    string query = "INSERT INTO attendance (employeeid, AttendanceDate, status, `time_in`) " +
                                   "VALUES (@EmployeeID, @Date, @Status, @TimeIn)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId);
                        cmd.Parameters.AddWithValue("@Date", currentDate);
                        cmd.Parameters.AddWithValue("@Status", "Present");
                        cmd.Parameters.AddWithValue("@TimeIn", currentTime);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Time-In successfully recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshAttendanceDisplay();
                        }
                        else
                        {
                            MessageBox.Show("Failed to record Time-In.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasTimeInAlready(string currentDate)
        {
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                string query = "SELECT COUNT(*) FROM attendance WHERE employeeid = @EmployeeID AND DATE(AttendanceDate) = @Date";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId);
                    cmd.Parameters.AddWithValue("@Date", currentDate);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void hometimeout_Click(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                if (UserSession.Instance == null || UserSession.Instance.UserId == null)
                {
                    MessageBox.Show("User session is invalid. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (HasTimeOutAlready(currentDate))
                {
                    MessageBox.Show("You have already timed out today.", "Duplicate Time-Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (MySqlConnection conn = DBConn.Instance.Connection)
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Database connection is not initialized.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    string query = "UPDATE attendance SET `time_out` = @TimeOut " +
                                   "WHERE employeeid = @EmployeeID AND DATE(AttendanceDate) = @Date AND `time_out` IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId);
                        cmd.Parameters.AddWithValue("@Date", currentDate);
                        cmd.Parameters.AddWithValue("@TimeOut", currentTime);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Time-Out successfully recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshAttendanceDisplay();
                        }
                        else
                        {
                            MessageBox.Show("No matching Time-In record found for today or already timed out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasTimeOutAlready(string currentDate)
        {
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                string query = "SELECT COUNT(*) FROM attendance WHERE employeeid = @EmployeeID AND DATE(AttendanceDate) = @Date AND `time_out` IS NOT NULL";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId);
                    cmd.Parameters.AddWithValue("@Date", currentDate);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void RefreshAttendanceDisplay()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                using (MySqlConnection conn = DBConn.Instance.Connection)
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Database connection is not initialized.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    string query = "SELECT time_in, time_out, status FROM attendance " +
                                   "WHERE employeeid = @EmployeeID AND DATE(AttendanceDate) = @Date";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId);
                        cmd.Parameters.AddWithValue("@Date", currentDate);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Fetch today's record values
                                string timeIn = reader["time_in"] != DBNull.Value ? reader["time_in"].ToString() : "";
                                string timeOut = reader["time_out"] != DBNull.Value ? reader["time_out"].ToString() : "";
                                string status = reader["status"] != DBNull.Value ? reader["status"].ToString() : "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing attendance: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}