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
    public partial class EditForm : Form
    {
        private List<Developer> developers;
        private List<Issue> issues;
        private DataGridView dataGridView;
        private Issue selectedIssue = null ;
        


        public event EventHandler IssueAdded;
        public event EventHandler IssueModified;



        public EditForm()
        {
            InitializeComponent();
            developers = new List<Developer>();
            issues = new List<Issue>();
        }



        public EditForm(DataGridView dataGridView, List<Issue> issues, List<Developer> availableDevelopers)
        {
            InitializeComponent();
            this.issues = issues;
            this.dataGridView = dataGridView;
            developers = availableDevelopers;
        }

        public EditForm(DataGridView dataGridView, List<Issue> issues, List<Developer> availableDevelopers, Issue selectedIssue)
        {
            InitializeComponent();
            this.dataGridView = dataGridView;
            this.issues = issues;
            developers = availableDevelopers;
            this.selectedIssue = selectedIssue;

            // Set the selected issue for modification
            // Update the form controls with the selected issue's details
            titleTextBox.Text = selectedIssue.Title;
            descriptionTextBox.Text = selectedIssue.Description;
            assignedDeveloperComboBox.SelectedItem = selectedIssue.AssignedDeveloper.Name;
            resolutionComboBox.SelectedItem = selectedIssue.IssueResolution.Description;
        }


        private void EditForm_Load(object sender, EventArgs e)
        {
            // Predefined developer instances
            Developer developer1 = new Developer("Developer 1", new List<Issue>());
            Developer developer2 = new Developer("Developer 2", new List<Issue>());
            Developer developer3 = new Developer("Developer 3", new List<Issue>());

            // Add the developers to the ComboBox
            assignedDeveloperComboBox.Items.Add(developer1.Name);
            assignedDeveloperComboBox.Items.Add(developer2.Name);
            assignedDeveloperComboBox.Items.Add(developer3.Name);

            resolutionComboBox.Items.Add(ResolutionType.Fixed);
            resolutionComboBox.Items.Add(ResolutionType.Pending);
            resolutionComboBox.Items.Add(ResolutionType.InProgress);
            resolutionComboBox.Items.Add(ResolutionType.NotApplicable);
        }


        public void saveIssueButton_Click(object sender, EventArgs e)
        {
            // Retrieve the values entered by the user
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            Developer assignedDeveloper = GetAssignedDeveloper();
            Resolution issueResolution = GetIssueResolution();

            if (selectedIssue == null)
            {
                // Creating a new issue
                Issue newIssue = new Issue()
                {
                    IssueId = Issue.GenerateUniqueIssueId(issues),
                    Title = title,
                    Description = description,
                    CreatedDate = DateTime.Now,
                    AssignedDeveloper = assignedDeveloper,
                    IssueResolution = issueResolution
                };

                // Add the new issue to the list
                issues.Add(newIssue);

                // Raise the IssueAdded event
                IssueAdded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Modifying an existing issue
                selectedIssue.Title = title;
                selectedIssue.Description = description;
                selectedIssue.AssignedDeveloper = assignedDeveloper;
                selectedIssue.IssueResolution = issueResolution;

                // Raise the IssueModified event
                IssueModified?.Invoke(this, EventArgs.Empty);
            }

            // Close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        //private Developer GetAssignedDeveloper()
        //{
        //    // Retrieve the selected developer name from the ComboBox
        //    string developerName = assignedDeveloperComboBox.SelectedItem.ToString();

        //    // Find the Developer object with the matching name
        //    Developer assignedDeveloper = developers.FirstOrDefault(dev => dev.Name == developerName);

        //    return assignedDeveloper;
        //}

        private Developer GetAssignedDeveloper()
        {
            string selectedDeveloperName = assignedDeveloperComboBox.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedDeveloperName))
            {
                Developer assignedDeveloper = developers.FirstOrDefault(d => d.Name == selectedDeveloperName);
                if (assignedDeveloper != null)
                {
                    return assignedDeveloper;
                }
                else
                {
                    // Handle the case when the selected developer is not found in the collection
                    MessageBox.Show("Selected developer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Handle the case when no developer is selected
                MessageBox.Show("Please select a developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }



        private Resolution GetIssueResolution()
        {
            if (resolutionComboBox.SelectedItem != null)
            {
                ResolutionType resolutionType = (ResolutionType)resolutionComboBox.SelectedItem;
                Resolution issueResolution = new Resolution(resolutionType);
                return issueResolution;
            }

            // Handle the case when no resolution is selected
            // You can return a default resolution or throw an exception, depending on your requirements.
            throw new InvalidOperationException("No resolution selected.");
        }

        private int GetSelectedRowIndex(DataGridViewSelectedCellCollection selectedCells)
        {
            if (selectedCells.Count > 0)
            {
                int selectedCellIndex = selectedCells[0].RowIndex;
                return selectedCellIndex;
            }
            return -1;
        }


        private void modifyIssueButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Get the Issue object associated with the selected row
                Issue selectedIssue = (Issue)selectedRow.DataBoundItem;

                // Create an instance of the EditForm
                EditForm editForm = new EditForm(dataGridView, issues, developers);

                // Set the values of the EditForm based on the selected issue
                editForm.titleTextBox.Text = selectedIssue.Title;
                editForm.descriptionTextBox.Text = selectedIssue.Description;
                // Set the selected developer in the assignedDeveloperComboBox
                editForm.assignedDeveloperComboBox.SelectedItem = selectedIssue.AssignedDeveloper.Name;
                // Set the selected resolution in the resolutionComboBox
                editForm.resolutionComboBox.SelectedItem = selectedIssue.IssueResolution.Description;

                // Handle the ModifyIssueButtonClicked event in the EditForm
                editForm.IssueModified += (s, args) =>
                {
                    // Update the issue in the list
                    selectedIssue.Title = editForm.titleTextBox.Text;
                    selectedIssue.Description = editForm.descriptionTextBox.Text;
                    selectedIssue.AssignedDeveloper = editForm.GetAssignedDeveloper();
                    selectedIssue.IssueResolution = editForm.GetIssueResolution();

                    // Refresh the DataGridView
                    RefreshDataGridView();
                };

                // Show the EditForm as a dialog
                editForm.ShowDialog();
            }
            else
            {
                // No row selected, display an error message or take appropriate action
                MessageBox.Show("Please select a row to modify.");
            }
        }


        public void deleteIssueButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Get the Issue object associated with the selected row
                Issue selectedIssue = (Issue)selectedRow.DataBoundItem;

                // Confirm the delete operation with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this issue?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the issue from the list
                    issues.Remove(selectedIssue);

                    // Refresh the DataGridView
                    RefreshDataGridView();
                }
            }
            else
            {
                // No row selected, display an error message or take appropriate action
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void RefreshDataGridView()
        {
            // Clear the existing rows
            dataGridView.Rows.Clear();

            // Add the updated issues to the DataGridView
            foreach (Issue issue in issues)
            {
                // Add a new row with the issue data
                int rowIndex = dataGridView.Rows.Add();
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                row.Cells["TitleColumn"].Value = issue.Title;
                row.Cells["DescriptionColumn"].Value = issue.Description;
                row.Cells["AssignedDeveloperColumn"].Value = issue.AssignedDeveloper.Name;
                row.Cells["ResolutionColumn"].Value = issue.IssueResolution.Description;
            }
        }
    }
}

