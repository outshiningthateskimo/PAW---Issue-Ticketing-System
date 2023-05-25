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
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.binarySerializationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deserializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printButton = new System.Windows.Forms.Button();
            this.numerandom = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(29, 110);
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
            this.createIssueButton.Location = new System.Drawing.Point(940, 432);
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
            this.label1.Location = new System.Drawing.Point(25, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Issues";
            // 
            // modifyIssueButton
            // 
            this.modifyIssueButton.BackColor = System.Drawing.SystemColors.Info;
            this.modifyIssueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyIssueButton.Location = new System.Drawing.Point(756, 432);
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
            this.deleteIssueButton.Location = new System.Drawing.Point(29, 432);
            this.deleteIssueButton.Name = "deleteIssueButton";
            this.deleteIssueButton.Size = new System.Drawing.Size(157, 37);
            this.deleteIssueButton.TabIndex = 4;
            this.deleteIssueButton.Text = "Delete Issue";
            this.deleteIssueButton.UseVisualStyleBackColor = false;
            this.deleteIssueButton.Click += new System.EventHandler(this.deleteIssueButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1046, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "(Alt + K)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binarySerializationToolStripMenuItem,
            this.textFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // binarySerializationToolStripMenuItem
            // 
            this.binarySerializationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializeToolStripMenuItem,
            this.deserializeToolStripMenuItem});
            this.binarySerializationToolStripMenuItem.Name = "binarySerializationToolStripMenuItem";
            this.binarySerializationToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.binarySerializationToolStripMenuItem.Text = "Binary Serialization";
            // 
            // serializeToolStripMenuItem
            // 
            this.serializeToolStripMenuItem.Name = "serializeToolStripMenuItem";
            this.serializeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.serializeToolStripMenuItem.Text = "Save";
            this.serializeToolStripMenuItem.Click += new System.EventHandler(this.serializeToolStripMenuItem_Click);
            // 
            // deserializeToolStripMenuItem
            // 
            this.deserializeToolStripMenuItem.Name = "deserializeToolStripMenuItem";
            this.deserializeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.deserializeToolStripMenuItem.Text = "Load";
            this.deserializeToolStripMenuItem.Click += new System.EventHandler(this.deserializeToolStripMenuItem_Click);
            // 
            // textFileToolStripMenuItem
            // 
            this.textFileToolStripMenuItem.Name = "textFileToolStripMenuItem";
            this.textFileToolStripMenuItem.Size = new System.Drawing.Size(77, 26);
            this.textFileToolStripMenuItem.Text = "Text File";
            this.textFileToolStripMenuItem.Click += new System.EventHandler(this.textFileToolStripMenuItem_Click);
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(972, 41);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(125, 40);
            this.printButton.TabIndex = 7;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // numerandom
            // 
            this.numerandom.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.numerandom_PrintPage);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1136, 511);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteIssueButton);
            this.Controls.Add(this.modifyIssueButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createIssueButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Issue Ticketing System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button createIssueButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button modifyIssueButton;
        private System.Windows.Forms.Button deleteIssueButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem binarySerializationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deserializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFileToolStripMenuItem;
        private System.Windows.Forms.Button printButton;
        private System.Drawing.Printing.PrintDocument numerandom;
    }
}

