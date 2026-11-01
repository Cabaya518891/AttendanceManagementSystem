using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SchedCover;

namespace AMSPROJECT
{
    public partial class UserControllEAVEAPPROVED : UserControl
    {
        public UserControllEAVEAPPROVED()
        {
            InitializeComponent();
            LoadLeaveData();
        }

        // Load leave data with staff full name and user ID
        private void LoadLeaveData()
        {
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                try
                {
                    conn.Open();

                    // Modify SQL to concatenate FirstName and LastName as FullName
                    string query = @"
                        SELECT 
                            leaved.LeaveID AS LeaveID, 
                            employee.EmployeeID AS UserID, 
                            CONCAT(employee.FirstName, ' ', employee.LastName) AS Name, 
                            leaved.LeaveType, 
                            leaved.StartDate, 
                            leaved.EndDate, 
                            leaved.Status 
                        FROM leaved
                        INNER JOIN employee ON leaved.EmployeeID = employee.EmployeeID";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    leavegrid.Columns.Clear();
                    leavegrid.DataSource = dt;

                    if (leavegrid.Columns["LeaveID"] != null)
                    {
                        leavegrid.Columns["LeaveID"].Visible = false; // Hide LeaveID if not needed
                    }

                    foreach (DataGridViewColumn col in leavegrid.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        // Approve a leave request
        private void btnapproved_Click(object sender, EventArgs e)
        {
            if (leavegrid.CurrentRow != null)
            {
                int leaveId = Convert.ToInt32(leavegrid.CurrentRow.Cells["LeaveID"].Value);
                string currentStatus = leavegrid.CurrentRow.Cells["Status"].Value.ToString();

                if (currentStatus == "Approved")
                {
                    MessageBox.Show("This leave request is already approved.");
                }
                else if (currentStatus == "Denied")
                {
                    MessageBox.Show("This leave request is already denied.");
                }
                else
                {
                    UpdateLeaveStatus(leaveId, "Approved");
                    leavegrid.CurrentRow.Cells["Status"].Value = "Approved";
                }
            }
            else
            {
                MessageBox.Show("Please select a leave request to approve.");
            }
        }

        // Deny a leave request
        private void btndeny_Click_1(object sender, EventArgs e)
        {
            if (leavegrid.CurrentRow != null)
            {
                int leaveId = Convert.ToInt32(leavegrid.CurrentRow.Cells["LeaveID"].Value);
                string currentStatus = leavegrid.CurrentRow.Cells["Status"].Value.ToString();

                if (currentStatus == "Denied")
                {
                    MessageBox.Show("This leave request is already denied.");
                }
                else if (currentStatus == "Approved")
                {
                    MessageBox.Show("This leave request is already approved.");
                }
                else
                {
                    try
                    {
                        UpdateLeaveStatus(leaveId, "Denied");
                        leavegrid.CurrentRow.Cells["Status"].Value = "Denied";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while denying the leave request: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a leave request to deny.");
            }
        }

        // Update leave status in the database
        private void UpdateLeaveStatus(int leaveId, string status)
        {
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE leaved SET Status = @status WHERE LeaveID = @leaveid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@leaveid", leaveId);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show($"Leave request {status}.");
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Leave ID not found.");
                        }
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    MessageBox.Show($"Database error: {mysqlEx.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void UserControllEAVEAPPROVED_Load(object sender, EventArgs e)
        {
            LoadLeaveData();
        }

     
    }
}
