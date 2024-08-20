namespace Defect_Counter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.ListBox lstDefects;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.lstDefects = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();


            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(12, 15);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(29, 15);
            this.lblExtension.TabIndex = 0;
            this.lblExtension.Text = "EXT:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(150, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 15);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "DATE:";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 55);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(39, 15);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "PATH:";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(47, 12);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(97, 23);
            this.txtExtension.TabIndex = 3;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(193, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(104, 23);
            this.dtpDate.TabIndex = 4;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(57, 52);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(494, 23);
            this.txtPath.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(557, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstLogs
            // 
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.ItemHeight = 15;
            this.lstLogs.Location = new System.Drawing.Point(12, 100);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(366, 274);
            this.lstLogs.TabIndex = 7;
            // 
            // lstDefects
            // 
            this.lstDefects.FormattingEnabled = true;
            this.lstDefects.ItemHeight = 15;
            this.lstDefects.Location = new System.Drawing.Point(430, 100);
            this.lstDefects.Name = "lstDefects";
            this.lstDefects.Size = new System.Drawing.Size(366, 274);
            this.lstDefects.TabIndex = 8;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(384, 212);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(40, 50);
            this.btnProcess.TabIndex = 9;
            this.btnProcess.Text = "-> Procesar ->";
            this.btnProcess.UseVisualStyleBackColor = true;
            EventHandler btnProcess_Click = this.btnProcess_Click;
            this.btnProcess.Click += new System.EventHandler(btnProcess_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 390);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(784, 23);
            this.progressBar.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lstDefects);
            this.Controls.Add(this.lstLogs);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblExtension);
            this.Name = "Form1";
            this.Text = "Defect Counter";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

       
    }
}

