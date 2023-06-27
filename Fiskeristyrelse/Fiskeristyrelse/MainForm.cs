using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Fiskeristyrelse
{
    public partial class MainForm : Form
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        private string csvFolderPath = "C:\\Users\\andre\\Desktop\\Fiskeridata";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Configure DataGridView
            dataGridView.AutoGenerateColumns = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Start FileSystemWatcher to monitor CSV folder
            var watcher = new FileSystemWatcher(csvFolderPath, "*.csv");
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;
        }

        private void LoadCSVButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.InitialDirectory = csvFolderPath;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string csvFilePath = openFileDialog.FileName;
                LoadCSVData(csvFilePath);
            }
        }

        private void SaveToDatabaseButton_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();
        }

        private void LoadCSVData(string csvFilePath)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Read CSV file into DataTable
                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string[] headers = reader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }

                    while (!reader.EndOfStream)
                    {
                        string[] rows = reader.ReadLine().Split(',');
                        dataTable.Rows.Add(rows);
                    }
                }

                // Display DataTable in DataGridView
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDataToDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create a new table in the database (if it doesn't exist)
                    SqlCommand createTableCmd = new SqlCommand("CREATE TABLE IF NOT EXISTS FollowUpData (Column1 VARCHAR(100), Column2 VARCHAR(100), Column3 VARCHAR(100))", connection);
                    createTableCmd.ExecuteNonQuery();

                    // Clear existing data from the table
                    SqlCommand clearDataCmd = new SqlCommand("DELETE FROM FollowUpData", connection);
                    clearDataCmd.ExecuteNonQuery();

                    // Insert data from DataGridView into the database table
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            SqlCommand insertDataCmd = new SqlCommand("INSERT INTO FollowUpData (Column1, Column2, Column3) VALUES (@Column1, @Column2, @Column3)", connection);
                            insertDataCmd.Parameters.AddWithValue("@Column1", row.Cells[0].Value.ToString());
                            insertDataCmd.Parameters.AddWithValue("@Column2", row.Cells[1].Value.ToString());
                            insertDataCmd.Parameters.AddWithValue("@Column3", row.Cells[2].Value.ToString());
                            insertDataCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data saved to the database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string csvFilePath = e.FullPath;
            LoadCSVData(csvFilePath);
        }
    }
}

