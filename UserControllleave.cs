using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SchedCover;

namespace AMSPROJECT
{
    public partial class UserControllleave : UserControl
    {
        public UserControllleave()
        {
            InitializeComponent();
            leavegrid.AutoGenerateColumns = true;
            LoadLeaveData();
        }

        // Load Data into DataGridView
        private void LoadLeaveData()
        {
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                try
                {
                    conn.Open();

                    // Fetch only the records for the logged-in user
                    string query = "SELECT LeaveID, LeaveType, StartDate, EndDate, Status FROM leaved WHERE EmployeeID = @EmployeeID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId); // Filter by logged-in user's ID

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        leavegrid.Columns.Clear();
                        leavegrid.DataSource = dt;

                        if (leavegrid.Columns["LeaveID"] != null)
                        {
                            leavegrid.Columns["LeaveID"].Visible = false; // Hide LeaveID if necessary
                        }

                        foreach (DataGridViewColumn col in leavegrid.Columns)
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Save Leave Record
        private void leavesave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLeaveType.Text))
            {
                MessageBox.Show("Please enter a Leave Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Start Date cannot be after End Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the selected date conflicts with an existing record
            if (IsDateRangeConflict(dtpStartDate.Value, dtpEndDate.Value))
            {
                MessageBox.Show(
                    "The selected date range conflicts with an existing leave. Please choose a different date.",
                    "Date Conflict",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using (MySqlConnection conn = DBConn.Instance.Connection)
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO leaved (EmployeeID, LeaveType, StartDate, EndDate, Status)
                        VALUES (@EmployeeID, @LeaveType, @StartDate, @EndDate, @Status)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId); // Associate with logged-in user
                        cmd.Parameters.AddWithValue("@LeaveType", txtLeaveType.Text);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                        cmd.Parameters.AddWithValue("@Status", "Pending");

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLeaveData();
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Check for conflicting leave records
        private bool IsDateRangeConflict(DateTime startDate, DateTime endDate)
        {
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) 
                        FROM leaved 
                        WHERE EmployeeID = @EmployeeID 
                        AND (
                            (StartDate = @StartDate OR EndDate = @EndDate) 
                            OR 
                            (StartDate <= @EndDate AND EndDate >= @StartDate))";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", UserSession.Instance.UserId); // Filter by logged-in user's ID
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error validating date range: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
        }

        // Clear input fields
        private void ClearInputFields()
        {
            txtLeaveType.Text = string.Empty;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
        }

        private void UserControllleave_Load(object sender, EventArgs e)
        {
            // Optional: Add any load logic here
        }

        private void leavegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Add logic for grid cell clicks here
        }
    }
}
