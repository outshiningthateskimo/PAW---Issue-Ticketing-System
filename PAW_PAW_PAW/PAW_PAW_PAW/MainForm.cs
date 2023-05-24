using PAW_PAW_PAW.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAW_PAW_PAW
{
    public partial class MainForm : Form
    {
        private List<Issue> issues = new List<Issue>();

        public MainForm()
        {
            InitializeComponent();
            InitIssues();
            dataGridView.DataError += DataGridView_DataError;
            dataGridView.CellFormatting += DataGridView_CellFormatting;


        }

        private void InitIssues()
        {
            issues = new List<Issue>();

            // Create instances of Developer and Resolution
            Developer developer1 = new Developer("Johnny Test", new List<Issue>());
            Developer developer2 = new Developer("Gerald McBoing-Boing", new List<Issue>());

            Resolution resolution1 = new Resolution(ResolutionType.Fixed);
            Resolution resolution2 = new Resolution(ResolutionType.InProgress);

            // Create instances of Issue and assign values
            Issue issue1 = new Issue()
            {
                IssueId = 1,
                Title = "UI Bug",
                Description = "The login button is not aligned properly",
                CreatedDate = DateTime.Now,
                AssignedDeveloper = developer1,
                IssueResolution = resolution1
            };

            Issue issue2 = new Issue()
            {
                IssueId = 2,
                Title = "Database Error",
                Description = "Data not found",
                CreatedDate = DateTime.Now,
                AssignedDeveloper = developer2,
                IssueResolution = resolution2
            };

            // Add the issues to the list
            issues.Add(issue1);
            issues.Add(issue2);

            // Bind the list to the DataGridView
            dataGridView.DataSource = issues;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public List<Issue> GetIssues()
        {
            return issues;
        }

        private void createIssueButton_Click(object sender, EventArgs e)
        {
            List<Developer> developers = GetDevelopers();

            EditForm editForm = new EditForm(dataGridView, issues, developers);
            editForm.IssueAdded += EditForm_IssueAdded; // Subscribe to the IssueAdded event                                                  // Subscribe to the IssueModified event
            editForm.IssueModified += EditForm_IssueModified;


            editForm.ShowDialog();



        }


        private List<Developer> GetDevelopers()
        {
            // Retrieve the developers from a database, file, or any other source
            List<Developer> developers = new List<Developer>();
            developers.Add(new Developer("Developer 1", new List<Issue>()));
            developers.Add(new Developer("Developer 2", new List<Issue>()));
            developers.Add(new Developer("Developer 3", new List<Issue>()));

            return developers;
        }

        private void EditForm_IssueAdded(object sender, EventArgs e)
        {
            // Refresh the DataGridView with the updated list of issues
            dataGridView.DataSource = null;
            dataGridView.DataSource = issues;
        }

        private void EditForm_IssueModified(object sender, EventArgs e)
        {
            // Refresh the DataGridView with the updated list of issues
            dataGridView.DataSource = null;
            dataGridView.DataSource = issues;
        }


        private int GetSelectedRowIndex()
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedCellIndex = dataGridView.SelectedCells[0].RowIndex;
                return selectedCellIndex;
            }
            return -1;
        }



        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Display a custom error message
            MessageBox.Show("An error occurred while editing the data. Please try again.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cancel the error to prevent the default error dialog from showing
            e.Cancel = true;
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current column is the AssignedDeveloper column
            if (dataGridView.Columns[e.ColumnIndex].Name == "AssignedDeveloper")
            {
                // Get the underlying Developer object
                Developer developer = (Developer)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Set the display value to the developer's name
                e.Value = developer.Name;
            }
            // Check if the current column is the IssueResolution column
            else if (dataGridView.Columns[e.ColumnIndex].Name == "IssueResolution")
            {
                // Get the underlying Resolution object
                Resolution resolution = (Resolution)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Set the display value to the resolution's type
                e.Value = resolution.Description;
            }
        }

        private void modifyIssueButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                // Get the index of the selected row
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;

                // Retrieve the selected issue based on the row index
                Issue selectedIssue = issues[selectedRowIndex];

                // Get the list of developers
                List<Developer> developers = GetDevelopers();

                // Create an instance of the AddEditForm for modification
                EditForm editForm = new EditForm(dataGridView, issues, developers, selectedIssue);

                // Subscribe to the IssueModified event
                editForm.IssueModified += EditForm_IssueModified;

                // Show the form
                DialogResult result = editForm.ShowDialog();

                // Check if the form was closed with the OK result
                if (result == DialogResult.OK)
                {
                    // Refresh the DataGridView with the updated list of issues
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = issues;
                }

            }
            else
            {
                MessageBox.Show("Please select an issue to modify.", "No Issue Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteIssueButton_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedIndex = dataGridView.SelectedRows[0].Index;

                // Retrieve the selected issue from the dataGridView's DataSource
                Issue selectedIssue = dataGridView.Rows[selectedIndex].DataBoundItem as Issue;

                // Display a confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to delete this issue?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Check if the user confirmed the deletion
                if (result == DialogResult.Yes)
                {
                    // Remove the selected issue from the list
                    issues.Remove(selectedIssue);

                    // Update the dataGridView
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = issues;
                }
            }
            else
            {
                // If no row is selected, display a message to the user
                MessageBox.Show("Please select an issue to delete.", "Delete Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}