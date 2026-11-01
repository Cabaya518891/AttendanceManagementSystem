using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AMSPROJECT; 
using SchedCover;

namespace AMSPROJECT
{
    public partial class UserControldashboard1 : UserControl
    {
        public UserControldashboard1()
        {
            InitializeComponent();
        }

        private void UserControldashboard1_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            
            using (MySqlConnection conn = DBConn.Instance.Connection)
            {
                conn.Open();

              
                MySqlCommand employeeCommand = new MySqlCommand("SELECT COUNT(*) FROM Employee", conn);
                int totalEmployees = Convert.ToInt32(employeeCommand.ExecuteScalar());
                numemployee.Text = totalEmployees.ToString(); 

                MySqlCommand attendanceCommand = new MySqlCommand("SELECT COUNT(*) FROM Attendance WHERE AttendanceDate BETWEEN '2024-12-01' AND '2024-12-31'", conn);
                int totalAttendance = Convert.ToInt32(attendanceCommand.ExecuteScalar());
                numattend.Text = totalAttendance.ToString(); 

                MySqlCommand leaveCommand = new MySqlCommand("SELECT COUNT(*) FROM Leaved WHERE Status = 'Pending'", conn);
                int totalPendingLeaveRequests = Convert.ToInt32(leaveCommand.ExecuteScalar());
                numrequest.Text = totalPendingLeaveRequests.ToString();

                conn.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numrequest_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
           
        }
    }
}
