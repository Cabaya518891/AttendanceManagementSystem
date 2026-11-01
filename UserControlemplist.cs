using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SchedCover;

namespace AMSPROJECT
{
    public partial class UserControlemplist : UserControl
    {
        public UserControlemplist()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void UserControlemplist_Load(object sender, EventArgs e)
        {
           
            LoadEmployeeData("Active");
        }

        private void InitializeDataGridView()
        {
       
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn ArchiveColumn = new DataGridViewButtonColumn
            {
                Name = "Archive",
                Text = "Archive",
                UseColumnTextForButtonValue = true
            };

          
        }

        private void LoadEmployeeData(string statusFilter = "Active")
        {
            string query = "SELECT EmployeeID, FirstName, LastName, Username, Position, Email, Address, BasicSalary, Status FROM employee";

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                query += " WHERE Status = @statusFilter";
            }

            try
            {
                using (MySqlConnection connection = DBConn.Instance.Connection)
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                    {
                        command.Parameters.AddWithValue("@statusFilter", statusFilter);
                    }

                    MySqlDataReader reader = command.ExecuteReader();
                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["EmployeeID"].ToString(),
                            reader["FirstName"].ToString(),
                            reader["LastName"].ToString(),
                            reader["Username"].ToString(),
                            reader["Position"].ToString(),
                            reader["Email"].ToString(),
                            reader["Address"].ToString(),
                            reader["BasicSalary"].ToString(),
                            reader["Status"].ToString()
                        );
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void ArchiveEmployee(string employeeID)
        {
            string query = "UPDATE employee SET Status = 'Archived' WHERE EmployeeID = @employeeID";

            try
            {
                using (MySqlConnection connection = DBConn.Instance.Connection)
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@employeeID", employeeID);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Employee archived successfully.");
                LoadEmployeeData("Active");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error archiving employee: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                        string employeeID = selectedRow.Cells["EmployeeID"].Value?.ToString();

                        if (columnName == "Edit")
                        {
                            string firstName = selectedRow.Cells["FirstName"].Value?.ToString();
                            string lastName = selectedRow.Cells["LastName"].Value?.ToString();
                            string username = selectedRow.Cells["Username"].Value?.ToString();
                            string position = selectedRow.Cells["Position"].Value?.ToString();
                            string email = selectedRow.Cells["Email"].Value?.ToString();
                            string address = selectedRow.Cells["Address"].Value?.ToString();
                            string basicSalary = selectedRow.Cells["BasicSalary"].Value?.ToString();
                            string status = selectedRow.Cells["Status"].Value?.ToString();

                            // Validate critical fields
                            if (string.IsNullOrEmpty(employeeID))
                            {
                                throw new Exception("Employee ID is missing. Unable to edit the employee.");
                            }

                            if (MessageBox.Show("Are you sure you want to update this employee's information?",
                                "Confirm Update",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var editForm = new EditEmployeeForm(employeeID, firstName, lastName, email, address, position, basicSalary, status, username);

                                if (editForm.ShowDialog() == DialogResult.OK)
                                {
                                    MessageBox.Show("Employee information updated successfully.",
                                        "Update Successful",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                    LoadEmployeeData("Active"); // Reload data
                                }
                            }
                        }
                        else if (columnName == "Archive")
                        {
                            if (MessageBox.Show("Are you sure you want to archive this employee?",
                                "Confirm Archive",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                ArchiveEmployee(employeeID);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while processing the request: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

            private void empfilter_Click(object sender, EventArgs e)
        {
            string[] options = { "All", "Active", "Inactive" };
            string selectedStatus = ShowStatusSelectionDialog(options);

            if (!string.IsNullOrEmpty(selectedStatus))
            {
                if (selectedStatus == "All")
                {
                    LoadEmployeeData();
                }
                else
                {
                    LoadEmployeeData(selectedStatus);
                }
            }
        }

        private string ShowStatusSelectionDialog(string[] options)
        {
            using (Form dialog = new Form())
            {
                dialog.Text = "Select Status";
                dialog.Width = 250;
                dialog.Height = 150;
                dialog.StartPosition = FormStartPosition.CenterScreen;

                ComboBox comboBox = new ComboBox { Left = 20, Top = 20, Width = 200 };
                comboBox.Items.AddRange(options);
                comboBox.SelectedIndex = 0;

                Button confirmButton = new Button { Text = "OK", Left = 75, Top = 70, Width = 75 };
                confirmButton.DialogResult = DialogResult.OK;
                dialog.Controls.Add(comboBox);
                dialog.Controls.Add(confirmButton);
                dialog.AcceptButton = confirmButton;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return comboBox.SelectedItem.ToString();
                }
            }
            return null;
        }

        private void btnarchive_Click(object sender, EventArgs e)
        {
            string statusFilter = empfilter.Text == "Show Archived" ? "Archived" : "Active";
            empfilter.Text = statusFilter == "Archived" ? "Show Active" : "Show Archived";
            LoadEmployeeData(statusFilter);
        }

        private void empsearch_TextChanged(object sender, EventArgs e)
        {
            LoadEmployeeData(empsearch.Text.Trim());
        }

        private void empexport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    Title = "Save Employee Data As CSV",
                    FileName = "EmployeeData.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        string header = string.Join(",", dataGridView1.Columns.Cast<DataGridViewColumn>()
                                                            .Select(col => col.HeaderText));
                        sw.WriteLine(header);

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string rowData = string.Join(",", row.Cells.Cast<DataGridViewCell>()
                                                            .Select(cell => cell.Value?.ToString().Replace(",", " ") ?? ""));
                                sw.WriteLine(rowData);
                            }
                        }
                    }

                    MessageBox.Show("Employee data has been successfully exported.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
