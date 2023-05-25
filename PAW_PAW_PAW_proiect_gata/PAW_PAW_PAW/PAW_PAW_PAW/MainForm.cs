using PAW_PAW_PAW.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }


        private void createIssueButton_Click(object sender, EventArgs e)
        {
            List<Developer> developers = GetDevelopers();

            EditForm editForm = new EditForm(dataGridView, issues, developers);
            editForm.IssueAdded += EditForm_IssueAdded; // Subscribe to the IssueAdded event                                                  // Subscribe to the IssueModified event
            editForm.IssueModified += EditForm_IssueModified;

            editForm.ShowDialog();
        }

        private void Display()
        {
            dataGridView.DataSource = issues;
        } 


        private List<Developer> GetDevelopers()
        {
            List<Developer> developers = new List<Developer>();
            developers.Add(new Developer("Developer 1", new List<Issue>()));
            developers.Add(new Developer("Developer 2", new List<Issue>()));
            developers.Add(new Developer("Developer 3", new List<Issue>()));

            return developers;
        }

        private void EditForm_IssueAdded(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = issues;
        }

        private void EditForm_IssueModified(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = issues;
        }


        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("An error occurred while editing the data. Please try again.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "AssignedDeveloper")
            {
                // Get the underlying Developer object (so that it won't show PAW_PAW_PAW.Classes.Developer anymore smh)
                Developer developer = (Developer)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                e.Value = developer.Name;
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "IssueResolution")
            {
                // Get the underlying Resolution object
                Resolution resolution = (Resolution)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                e.Value = resolution.Description;
            }
        }

        private void modifyIssueButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                Issue selectedIssue = issues[selectedRowIndex];
                List<Developer> developers = GetDevelopers();

                EditForm editForm = new EditForm(dataGridView, issues, developers, selectedIssue);
                editForm.IssueModified += EditForm_IssueModified;

                DialogResult result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
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
            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView.SelectedRows[0].Index;
                Issue selectedIssue = dataGridView.Rows[selectedIndex].DataBoundItem as Issue;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this issue?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    issues.Remove(selectedIssue);

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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.K)
            {
                createIssueButton.PerformClick();
                e.Handled = true;
            }
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = File.Create("serializattt.bin"))
            {
                binaryFormatter.Serialize(fileStream, issues);
            }
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = File.OpenRead("serializattt.bin"))
            {
                issues = (List<Issue>) binaryFormatter.Deserialize(fileStream);
                Display();
            }
        }

        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Export report";
                saveFileDialog.Filter = "Text file | *.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = saveFileDialog.FileName;
                    using (StreamWriter streamWriter = File.CreateText(FilePath))
                    {
                        streamWriter.WriteLine();
                        foreach (Issue issue in issues) 
                        {
                            string developerName = issue.AssignedDeveloper.Name;
                            string resolutionDescription = issue.IssueResolution.Description.ToString();

                            streamWriter.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n\n\n", 
                                issue.IssueId,
                                issue.Title,
                                issue.Description,
                                issue.CreatedDate,
                                developerName,
                                resolutionDescription
                        );
                        } // end foreach
                    } // end using
                } // end if
            }
        }// END textFileToolStripMenuItem_Click

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = numerandom;
            printPreviewDialog.ShowDialog();
        }

        private void numerandom_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Times New Roman", 12);
            Brush brush = Brushes.BlueViolet;
            string pageContent = "Issue ID, Title, Description, Created Date, Assigned Developer, Issue Resolution\n\n";

            foreach (Issue issue in issues)
            {
                string developerName = issue.AssignedDeveloper.Name;
                string resolutionDescription = issue.IssueResolution.Description.ToString();

                pageContent += string.Format("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n\n\n",
                    issue.IssueId,
                    issue.Title,
                    issue.Description,
                    issue.CreatedDate,
                                developerName,
                                resolutionDescription
                    );
            }
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            graphics.DrawString(pageContent, font, brush, x, y);
            e.HasMorePages = false;
        }
    }
}