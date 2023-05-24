namespace PAW_PAW_PAW
{
    partial class MainForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.createIssueButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.modifyIssueButton = new System.Windows.Forms.Button();
            this.deleteIssueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(27, 79);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1068, 295);
            this.dataGridView.TabIndex = 0;
            // 
            // createIssueButton
            // 
            this.createIssueButton.BackColor = System.Drawing.SystemColors.Info;
            this.createIssueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createIssueButton.Location = new System.Drawing.Point(938, 401);
            this.createIssueButton.Name = "createIssueButton";
            this.createIssueButton.Size = new System.Drawing.Size(157, 37);
            this.createIssueButton.TabIndex = 1;
            this.createIssueButton.Text = "Create Issue";
            this.createIssueButton.UseVisualStyleBackColor = false;
            this.createIssueButton.Click += new System.EventHandler(this.createIssueButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Issues";
            // 
            // modifyIssueButton
            // 
            this.modifyIssueButton.BackColor = System.Drawing.SystemColors.Info;
            this.modifyIssueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyIssueButton.Location = new System.Drawing.Point(754, 401);
            this.modifyIssueButton.Name = "modifyIssueButton";
            this.modifyIssueButton.Size = new System.Drawing.Size(157, 37);
            this.modifyIssueButton.TabIndex = 3;
            this.modifyIssueButton.Text = "Modify Issue";
            this.modifyIssueButton.UseVisualStyleBackColor = false;
            this.modifyIssueButton.Click += new System.EventHandler(this.modifyIssueButton_Click);
            // 
            // deleteIssueButton
            // 
            this.deleteIssueButton.BackColor = System.Drawing.SystemColors.Info;
            this.deleteIssueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteIssueButton.Location = new System.Drawing.Point(27, 401);
            this.deleteIssueButton.Name = "deleteIssueButton";
            this.deleteIssueButton.Size = new System.Drawing.Size(157, 37);
            this.deleteIssueButton.TabIndex = 4;
            this.deleteIssueButton.Text = "Delete Issue";
            this.deleteIssueButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1136, 465);
            this.Controls.Add(this.deleteIssueButton);
            this.Controls.Add(this.modifyIssueButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createIssueButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "MainForm";
            this.Text = "Issue Ticketing System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button createIssueButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button modifyIssueButton;
        private System.Windows.Forms.Button deleteIssueButton;
    }
}

