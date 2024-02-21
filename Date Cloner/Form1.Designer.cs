namespace Date_Cloner
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Copy = new System.Windows.Forms.OpenFileDialog();
            this.Directory = new System.Windows.Forms.Label();
            this.beginButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Instructions = new System.Windows.Forms.Label();
            this.RenameButton = new System.Windows.Forms.Button();
            this.RenameFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Copy
            // 
            this.Copy.Filter = "VLC Converted Files | *-converted.mp4";
            this.Copy.Multiselect = true;
            this.Copy.FileOk += new System.ComponentModel.CancelEventHandler(this.Copy_FileOk);
            // 
            // Directory
            // 
            this.Directory.AutoSize = true;
            this.Directory.Location = new System.Drawing.Point(163, 94);
            this.Directory.Name = "Directory";
            this.Directory.Size = new System.Drawing.Size(0, 13);
            this.Directory.TabIndex = 4;
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(342, 35);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(75, 23);
            this.beginButton.TabIndex = 5;
            this.beginButton.Text = "Begin!";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 123);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(405, 23);
            this.progressBar.TabIndex = 6;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // Instructions
            // 
            this.Instructions.AutoSize = true;
            this.Instructions.Location = new System.Drawing.Point(9, 9);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(406, 13);
            this.Instructions.TabIndex = 7;
            this.Instructions.Text = "Select files you want to copy and paste and make sure they have the same file nam" +
    "e";
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(12, 68);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(405, 23);
            this.RenameButton.TabIndex = 9;
            this.RenameButton.Text = "Remove the \'-converted\' an MP4 file";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // RenameFileDialog
            // 
            this.RenameFileDialog.Filter = "Video | *.mp4";
            this.RenameFileDialog.Multiselect = true;
            this.RenameFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.RenameFileDialog_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Clone/Replace VLC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(429, 158);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.Instructions);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.Directory);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(445, 242);
            this.Name = "Form1";
            this.Text = "Date Cloner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog Copy;
        private System.Windows.Forms.Label Directory;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label Instructions;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.OpenFileDialog RenameFileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

