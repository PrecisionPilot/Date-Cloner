using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Date_Cloner
{
    public partial class Form1 : Form
    {
        string exception = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Copy_FileOk(object sender, CancelEventArgs e)
        {
            label1.Text = Copy.FileNames.Length + " files selected";
        }

        private async void beginButton_Click(object sender, EventArgs e)
        {
            if (Copy.FileName == "")// if no files were selected
            {
                MessageBox.Show("You have not made a selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                button1.Enabled = false;
                beginButton.Enabled = false;
                RenameButton.Enabled = false;

                var progress = new Progress<int>(v =>
                {
                    progressBar.Value = v;
                });


                Task t = Task.Run(() => Clone(progress));
                await Task.WhenAll(t);
            }
            catch (Exception exception)//show an error message box, incase if somthing goes wrong for good measure
            {
                MessageBox.Show(exception.ToString(), "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Copy.FileName = "";//clear the OpenFileDialog for 'Copy'
            label1.Text = "";
            progressBar.Value = 0;

            button1.Enabled = true;
            beginButton.Enabled = true;
            RenameButton.Enabled = true;
        }

        public void Clone(IProgress<int> progress)//executed in another thread
        {
            int copiedFiles = 0;
            List<string> toCopyFiles = new List<string>();

            for (int I = 0; I < Copy.FileNames.Length; I++)//for each files to copy
            {
                for (int i = 0; i < Copy.FileNames.Length; i++)//find a matching file name from the files to paste
                {
                    string toCopyFile = Copy.FileNames[I].Substring(0, Copy.FileNames[I].Length - 14) +".mp4";//store the file that are to be copied as a variable

                    if (Path.GetFileNameWithoutExtension(toCopyFile) + "-converted.mp4" == Path.GetFileName(Copy.FileNames[i]))
                    {
                        try
                        {
                            File.SetCreationTime(Copy.FileNames[i], File.GetCreationTime(toCopyFile));
                            File.SetLastWriteTime(Copy.FileNames[i], File.GetLastWriteTime(toCopyFile));
                            toCopyFiles.Add(toCopyFile);//add the file to the list
                            copiedFiles++;
                            break;
                        }
                        catch(Exception e)
                        {
                            exception = "\n\n" + e.ToString();
                        }
                    }
                }
                progress.Report(copiedFiles * 80 / Copy.FileNames.Length);
            }
            string[] toCopyFilesArray = toCopyFiles.ToArray();
            
            foreach (string file in toCopyFilesArray)//Delete original files
            {
                Console.WriteLine(file);
                File.Delete(file);
            }

            //to rename the converted files
            bool success = true;
            string unsuccessfulFilenames = "";
            int unsuccessfulFiles = 0;
            int renamedFiles = 0;
            foreach (string fileName in Copy.FileNames)
            {
                try
                {
                    File.Move(fileName, fileName.Substring(0, fileName.Length - 14) + ".mp4");
                    renamedFiles++;
                    progress.Report(80 + (renamedFiles * 20 / Copy.FileNames.Length));
                }
                catch
                {
                    success = false;
                    unsuccessfulFilenames += Path.GetFileName(fileName) + "\n";
                    unsuccessfulFiles++;
                }
            }

            if (copiedFiles > 0)
            {
                if (success)
                    MessageBox.Show("Successfully copied/pasted date from " + copiedFiles + " file(s)", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Successfully copied/pasted date from " + copiedFiles + " file(s)\n\n" +
                        "Failed to rename:\n" + unsuccessfulFilenames + exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else//if no file dates were copied/pasted
                MessageBox.Show("No action has been done" + exception, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            exception = "";
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Copy.ShowDialog();
        }

        private void Paste_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            RenameFileDialog.ShowDialog();
        }
        private void RenameFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you remove the '-converted' from " + RenameFileDialog.FileNames.Length +
                " file(s)\nthis action cannot be undone with this software", "Conformation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                bool success = true;
                string unsuccessfulFiles = "";
                int renamedFiles = 0;
                foreach (string fileName in RenameFileDialog.FileNames)
                {
                    try
                    {
                        File.Move(fileName, fileName.Substring(0, fileName.Length - 14) + ".mp4");
                        renamedFiles++;
                        progressBar.Value = renamedFiles * 100 / RenameFileDialog.FileNames.Length;
                    }
                    catch
                    {
                        success = false;
                        unsuccessfulFiles += Path.GetFileName(fileName) + "\n";
                    }
                }
                RenameFileDialog.FileName = "";
                if (success)
                    MessageBox.Show("Successfully renamed " + renamedFiles + " file(s)", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Successfully renamed " + renamedFiles + " file(s)\n\nFailed to rename:\n" + unsuccessfulFiles,
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                progressBar.Value = 0;
            }
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
