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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            titleTextBox.Validating += titleTextBox_Validating;
            descriptionTextBox.Validating += descriptionTextBox_Validating;

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
            try
            {
                // Validate the title and description fields
                if (string.IsNullOrWhiteSpace(titleTextBox.Text))
                {
                    errorProvider.SetError(titleTextBox, "Title is required.");
                    titleTextBox.Focus();
                    return; // Exit the event handler, preventing further execution
                }
                else
                {
                    errorProvider.SetError(titleTextBox, ""); // Clear error message
                }

                if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
                {
                    errorProvider.SetError(descriptionTextBox, "Description is required.");
                    descriptionTextBox.Focus();
                    return; // Exit the event handler, preventing further execution
                }
                else
                {
                    errorProvider.SetError(descriptionTextBox, ""); // Clear error message
                }


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
            catch (ArgumentException ex)
            {
                // Handle the exception
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!IsTitleValid())
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Title is required.");
            }
        }

        private void titleTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private bool IsTitleValid()
        {
            return !string.IsNullOrWhiteSpace(titleTextBox.Text.Trim());
        }

        private void descriptionTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                errorProvider.SetError(descriptionTextBox, "Description is required.");
                e.Cancel = true; // Prevent focus change if validation fails
            }
            else
            {
                errorProvider.SetError(descriptionTextBox, ""); // Clear error message
            }
        }

        private void descriptionTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }
    }
}

