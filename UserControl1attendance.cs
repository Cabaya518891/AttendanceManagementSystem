using MySql.Data.MySqlClient;
using SchedCover;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMSPROJECT
{
    public partial class UserControl1attendance : UserControl
    {
        public UserControl1attendance()
        {
            InitializeComponent();
        }

        private void UserControl1attendance_Load(object sender, EventArgs e)
        {
            // Initial data load
            initializeListView();
        }

        // Initial loading of attendance data
        private void initializeListView()
        {
            string query = @"SELECT a.*,
                                    CONCAT(e.firstname, ' ', e.lastname) AS Name
                             FROM attendance a
                             JOIN employee e
                             ON a.employeeid = e.employeeid";

            if (UserSession.Instance.AccessRole == "staff")
                query += " WHERE e.employeeid = @EmpID";

            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                if (UserSession.Instance.AccessRole == "staff")
                    cmd.Parameters.AddWithValue("@EmpID", UserSession.Instance.UserId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                atdatagrid.DataSource = dataTable;
                atdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // Event when filter button is clicked
        private void atbtnfilter_Click(object sender, EventArgs e)
        {
            DateTime fromDate = atfromdate.Value.Date;
            DateTime toDate = atttodate.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show("The 'From Date' cannot be later than the 'To Date'.", "Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT a.*,
                                    CONCAT(e.firstname, ' ', e.lastname) AS Name
                             FROM attendance a
                             JOIN employee e
                             ON a.employeeid = e.employeeid
                             WHERE a.attendancedate BETWEEN @FromDate AND @ToDate";

            if (UserSession.Instance.AccessRole == "staff")
            {
                query += " AND e.employeeid = @EmpID";
            }

            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    if (UserSession.Instance.AccessRole == "staff")
                    {
                        cmd.Parameters.AddWithValue("@EmpID", UserSession.Instance.UserId);
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    atdatagrid.DataSource = dataTable;
                    MessageBox.Show("Filter applied successfully.", "Filter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event to handle time-in and time-out
        private void RecordAttendance(string action)
        {
            // Get current date and time
            DateTime currentDateTime = DateTime.Now;

            string query = @"INSERT INTO attendance (employeeid, attendancedate, action)
                             VALUES (@EmpID, @AttendDate, @Action)";

            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@EmpID", UserSession.Instance.UserId);
                    cmd.Parameters.AddWithValue("@AttendDate", currentDateTime);
                    cmd.Parameters.AddWithValue("@Action", action); // "TimeIn" or "TimeOut"

                    cmd.ExecuteNonQuery();

                    // Reload the attendance list after recording
                    initializeListView();

                    MessageBox.Show($"{action} recorded successfully.", $"{action} Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Handle Time-In button click
        private void timeInButton_Click(object sender, EventArgs e)
        {
            RecordAttendance("TimeIn");
        }

        // Handle Time-Out button click
        private void timeOutButton_Click(object sender, EventArgs e)
        {
            RecordAttendance("TimeOut");
        }
    }
}
