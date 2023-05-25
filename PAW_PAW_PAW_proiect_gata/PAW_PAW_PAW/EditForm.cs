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

            // Add the developers to the ComboBox ~ ComboBoxes are super cool
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
                // The following can also be used but I prefer to not allow the user to save 
                // unless all fields are completed instead as it would be impractical to have to 
                // exit an error message box every single time you forget to fill a field.

                /* 
                 if (!ValidateChildren())
                  {
                      MessageBox.Show("Empty fields detected. Please fill all the fields before saving the issue.",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);

                      return;
                  }
                */

                // Validate the title and description fields
                if (string.IsNullOrWhiteSpace(titleTextBox.Text))
                {
                    errorProvider.SetError(titleTextBox, "Title is required.");
                    titleTextBox.Focus();
                    return; // Exit the event handler, preventing further execution
                }
                else
                {
                    errorProvider.SetError(titleTextBox, "");
                }

                if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
                {
                    errorProvider.SetError(descriptionTextBox, "Description is required.");
                    descriptionTextBox.Focus();
                    return; 
                }
                else
                {
                    errorProvider.SetError(descriptionTextBox, "");
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

                    issues.Add(newIssue);

                    IssueAdded?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    // Modifying an existing issue
                    selectedIssue.Title = title;
                    selectedIssue.Description = description;
                    selectedIssue.AssignedDeveloper = assignedDeveloper;
                    selectedIssue.IssueResolution = issueResolution;

                    IssueModified?.Invoke(this, EventArgs.Empty);
                }

                // Close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
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
            throw new InvalidOperationException("No resolution selected.");
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
                e.Cancel = true; 
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

        private void titleTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void titleTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string droppedText = (string)e.Data.GetData(DataFormats.Text);
                titleTextBox.Text = droppedText; 
                Console.WriteLine("Dropped Text: " + droppedText);
                MessageBox.Show("Dropped Text: " + droppedText);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            string titleText = titleTextBox.Text;
            if (!string.IsNullOrEmpty(titleText))
            {
                Clipboard.SetText(titleText);
                MessageBox.Show("Title copied to clipboard.", "Copy Successful");
            }
        }
    } 
}

