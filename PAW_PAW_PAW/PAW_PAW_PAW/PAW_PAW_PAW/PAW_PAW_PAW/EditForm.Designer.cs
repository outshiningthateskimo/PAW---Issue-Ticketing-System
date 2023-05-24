namespace PAW_PAW_PAW
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveIssueButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.title_label = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.assignedDeveloperComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resolution_label = new System.Windows.Forms.Label();
            this.resolutionComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // saveIssueButton
            // 
            this.saveIssueButton.BackColor = System.Drawing.SystemColors.Info;
            this.saveIssueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveIssueButton.Location = new System.Drawing.Point(569, 362);
            this.saveIssueButton.Name = "saveIssueButton";
            this.saveIssueButton.Size = new System.Drawing.Size(157, 37);
            this.saveIssueButton.TabIndex = 2;
            this.saveIssueButton.Text = "Save";
            this.saveIssueButton.UseVisualStyleBackColor = false;
            this.saveIssueButton.Click += new System.EventHandler(this.saveIssueButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(57, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Location = new System.Drawing.Point(54, 99);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(36, 16);
            this.title_label.TabIndex = 4;
            this.title_label.Text = "Title:";
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Location = new System.Drawing.Point(54, 140);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(78, 16);
            this.description_label.TabIndex = 6;
            this.description_label.Text = "Description:";
            // 
            // titleTextBox
            // 
            this.errorProvider.SetError(this.titleTextBox, "errorProvider");
            this.titleTextBox.Location = new System.Drawing.Point(203, 95);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(160, 22);
            this.titleTextBox.TabIndex = 7;
            this.titleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.titleTextBox_Validating);
            this.titleTextBox.Validated += new System.EventHandler(this.titleTextBox_Validated);
            // 
            // descriptionTextBox
            // 
            this.errorProvider.SetError(this.descriptionTextBox, "errorProvider");
            this.descriptionTextBox.Location = new System.Drawing.Point(203, 130);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(160, 22);
            this.descriptionTextBox.TabIndex = 8;
            this.descriptionTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.descriptionTextBox_Validating);
            this.descriptionTextBox.Validated += new System.EventHandler(this.descriptionTextBox_Validated);
            // 
            // assignedDeveloperComboBox
            // 
            this.assignedDeveloperComboBox.FormattingEnabled = true;
            this.assignedDeveloperComboBox.Location = new System.Drawing.Point(203, 180);
            this.assignedDeveloperComboBox.Name = "assignedDeveloperComboBox";
            this.assignedDeveloperComboBox.Size = new System.Drawing.Size(160, 24);
            this.assignedDeveloperComboBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Assigned Developer:";
            // 
            // resolution_label
            // 
            this.resolution_label.AutoSize = true;
            this.resolution_label.Location = new System.Drawing.Point(54, 233);
            this.resolution_label.Name = "resolution_label";
            this.resolution_label.Size = new System.Drawing.Size(74, 16);
            this.resolution_label.TabIndex = 13;
            this.resolution_label.Text = "Resolution:";
            // 
            // resolutionComboBox
            // 
            this.resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionComboBox.FormattingEnabled = true;
            this.resolutionComboBox.Location = new System.Drawing.Point(203, 230);
            this.resolutionComboBox.Name = "resolutionComboBox";
            this.resolutionComboBox.Size = new System.Drawing.Size(160, 24);
            this.resolutionComboBox.TabIndex = 12;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resolution_label);
            this.Controls.Add(this.resolutionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assignedDeveloperComboBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveIssueButton);
            this.Name = "EditForm";
            this.Text = "AddEditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveIssueButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox assignedDeveloperComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label resolution_label;
        private System.Windows.Forms.ComboBox resolutionComboBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}