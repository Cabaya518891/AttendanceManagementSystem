using MySql.Data.MySqlClient;
using SchedCover;
using System;
using System.ComponentModel; // Required for LicenseManager design-time guard
using System.Data;
using System.Windows.Forms;

namespace AMSPROJECT
{
    public partial class UserControlpayroll : UserControl
    {
        public UserControlpayroll()
        {
            InitializeComponent();
            this.Load += new EventHandler(UserControlpayroll_Load);
        }

        private void UserControlpayroll_Load(object sender, EventArgs e)
        {
            // Prevents Visual Studio Designer from executing database code in design view
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            LoadPayrollData();
        }

        /// <summary>
        /// Loads payroll data from the database and displays it in the DataGridView.
        /// Includes a JOIN on the employee table so we can see the employee’s name.
        /// </summary>
        private void LoadPayrollData(string searchKeyword = "")
        {
            string query = @"
            SELECT 
                p.payrollid,
                p.employeeid,
                CONCAT(e.firstname, ' ', e.lastname) AS EmployeeName,
                p.basicsalary,
                p.totalsalary,
                (SELECT IFNULL(SUM(TIMESTAMPDIFF(MINUTE, a.time_in, a.time_out)), 0) / 60.0
                 FROM attendance a
                 WHERE a.employeeid = p.employeeid AND a.time_in IS NOT NULL AND a.time_out IS NOT NULL) AS TotalHoursWorked
            FROM payroll p
            JOIN employee e ON p.employeeid = e.employeeid
            WHERE 
                CONCAT(e.firstname, ' ', e.lastname) LIKE @searchKeyword
                OR p.payrollid LIKE @searchKeyword
                OR p.employeeid LIKE @searchKeyword";

            try
            {
                using (MySqlConnection connection = DBConn.Instance.Connection)
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Add additional columns if not already present
                    if (!table.Columns.Contains("GrossPay"))
                        table.Columns.Add("GrossPay", typeof(decimal));
                    if (!table.Columns.Contains("Tax"))
                        table.Columns.Add("Tax", typeof(decimal));
                    if (!table.Columns.Contains("PagIBIG"))
                        table.Columns.Add("PagIBIG", typeof(decimal));
                    if (!table.Columns.Contains("SSS"))
                        table.Columns.Add("SSS", typeof(decimal));
                    if (!table.Columns.Contains("PhilHealth"))
                        table.Columns.Add("PhilHealth", typeof(decimal));
                    if (!table.Columns.Contains("Deductions"))
                        table.Columns.Add("Deductions", typeof(decimal));

                    // Perform calculations for each row
                    foreach (DataRow row in table.Rows)
                    {
                        decimal basicSalary = Convert.ToDecimal(row["basicsalary"]);
                        object totalHoursObj = row["TotalHoursWorked"];
                        decimal totalHoursWorked = totalHoursObj != DBNull.Value ? Convert.ToDecimal(totalHoursObj) : 0;

                        // Calculate hourly rate and gross pay
                        decimal hourlyRate = basicSalary / 160; // Example: 160 hours per month
                        decimal grossPay = hourlyRate * totalHoursWorked;

                        // Deductions calculation
                        decimal tax = basicSalary * 0.10m; // Example: 10% tax
                        decimal pagibig = 100; // Fixed Pag-IBIG contribution
                        decimal sss = 500; // Fixed SSS contribution
                        decimal philhealth = basicSalary * 0.04m; // Example: 4% PhilHealth contribution

                        decimal totalDeductions = tax + pagibig + sss + philhealth;

                        // Add calculated values to the row
                        row["GrossPay"] = grossPay;
                        row["Tax"] = tax;
                        row["PagIBIG"] = pagibig;
                        row["SSS"] = sss;
                        row["PhilHealth"] = philhealth;
                        row["Deductions"] = totalDeductions;

                        // Recalculate net salary after deductions
                        row["totalsalary"] = grossPay - totalDeductions;
                    }

                    // Bind updated table to DataGridView
                    paygrid.DataSource = table;

                    // Formatting columns
                    paygrid.Columns["basicsalary"].DefaultCellStyle.Format = "N2";
                    paygrid.Columns["GrossPay"].DefaultCellStyle.Format = "N2";
                    paygrid.Columns["Tax"].DefaultCellStyle.Format = "N2";
                    paygrid.Columns["PagIBIG"].DefaultCellStyle.Format = "N2";
                    paygrid.Columns["SSS"].DefaultCellStyle.Format = "N2";
                    paygrid.Columns["PhilHealth"].DefaultCellStyle.Format = "N2";
                    paygrid.Columns["Deductions"].DefaultCellStyle.Format = "N2";
                    paygrid.Columns["totalsalary"].DefaultCellStyle.Format = "N2";

                    // Setting column headers
                    paygrid.Columns["payrollid"].HeaderText = "Payroll ID";
                    paygrid.Columns["employeeid"].HeaderText = "Employee ID";
                    paygrid.Columns["EmployeeName"].HeaderText = "Employee Name";
                    paygrid.Columns["basicsalary"].HeaderText = "Basic Salary";
                    paygrid.Columns["GrossPay"].HeaderText = "Gross Pay";
                    paygrid.Columns["Tax"].HeaderText = "Tax (10%)";
                    paygrid.Columns["PagIBIG"].HeaderText = "Pag-IBIG (2%)";
                    paygrid.Columns["SSS"].HeaderText = "SSS (11%)";
                    paygrid.Columns["PhilHealth"].HeaderText = "PhilHealth (4%)";
                    paygrid.Columns["Deductions"].HeaderText = "Total Deductions";
                    paygrid.Columns["totalsalary"].HeaderText = "Net Salary";

                    // Move the 'Net Salary' column to the end
                    paygrid.Columns["totalsalary"].DisplayIndex = paygrid.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payroll data: " + ex.Message);
            }
        }

        private void payfilter_Click(object sender, EventArgs e)
        {
            LoadPayrollData(paysearch.Text.Trim());
        }

        private void payexport_Click(object sender, EventArgs e)
        {
            if (paygrid.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV file (*.csv)|*.csv",
                    Title = "Export Payroll Data",
                    FileName = "PayrollData.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog.FileName))
                        {
                            // Write the header row
                            for (int i = 0; i < paygrid.Columns.Count; i++)
                            {
                                writer.Write(paygrid.Columns[i].HeaderText);
                                if (i < paygrid.Columns.Count - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();

                            // Write each row
                            foreach (DataGridViewRow row in paygrid.Rows)
                            {
                                if (!row.IsNewRow) // Exclude the new row placeholder
                                {
                                    for (int i = 0; i < paygrid.Columns.Count; i++)
                                    {
                                        writer.Write(row.Cells[i].Value?.ToString());
                                        if (i < paygrid.Columns.Count - 1)
                                            writer.Write(",");
                                    }
                                    writer.WriteLine();
                                }
                            }
                        }

                        MessageBox.Show("Payroll data exported successfully!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data available to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}