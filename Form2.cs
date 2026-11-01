using System;
using System.Windows.Forms;

namespace AMSPROJECT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Initialize controls: Show dashboard by default
            ShowControl(userControldashboard11);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Dashboard button clicked
            ShowControl(userControldashboard11);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Add Employee button clicked
            ShowControl(userControlemployee1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Employee List button clicked
            ShowControl(userControlemplist1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Attendance Report button clicked
            ShowControl(userControl1attendance1);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            // Payroll button clicked
            ShowControl(userControlpayroll1);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // Deduction button clicked
            ShowControl(userControldeduct2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ShowControl(userControllEAVEAPPROVED1);
        }

        /// <summary>
        /// Shows the specified UserControl and hides all others.
        /// </summary>
        /// <param name="controlToShow">The UserControl to display.</param>
        private void ShowControl(UserControl controlToShow)
        {
            // List of all UserControls in the form
            UserControl[] controls =
            {
                userControldashboard11,
                userControlemployee1,
                userControlemplist1,
                userControl1attendance1,
                userControldeduct2,
                userControllEAVEAPPROVED1,
                userControlpayroll1
            };

            // Iterate through all controls and adjust visibility
            foreach (var control in controls)
            {
                control.Visible = control == controlToShow;
            }

            // Bring the visible control to the front
            controlToShow.BringToFront();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (UserSession.Instance != null)
            {
                UserSession.Instance.UserId = 0;
                UserSession.Instance.UserName = null;
                UserSession.Instance.AccessRole = null;
            }
            Form3 loginPage = new Form3();
            loginPage.Show();

            this.Close();
        }

    }
}

