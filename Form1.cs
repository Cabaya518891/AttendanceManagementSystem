using System;
using System.Windows.Forms;

namespace AMSPROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowControl(userControlhome1);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ShowControl(userControlhome1);

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ShowControl(userControlprofile1);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            ShowControl(userControl1attendance1);
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            ShowControl(userControllleave1);
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
                userControlhome1,
                userControlprofile1,
                userControl1attendance1,
                userControllleave1
            };

            // Iterate through all controls and adjust visibility
            foreach (var control in controls)
            {
                control.Visible = control == controlToShow;
            }

            // Bring the visible control to the front
            controlToShow.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowControl(userControlsetting1);


        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 loginPage = new Form3();
            loginPage.Show();
this.Close();   
 
        }
    }

}
