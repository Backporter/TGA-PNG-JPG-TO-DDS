using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PNG_JPG_TO_DDS.Properties;
using System.Threading;

namespace PNG_JPG_TO_DDS
{
    public partial class Main : Form
    {
        public BackgroundWorker bw = new BackgroundWorker();
        public string format = "dxt1a";
        public bool clean = false;
        public List<string> filePaths = new List<string>();
        public bool T1_Done = false;
        public bool log = false;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "dxt1a";
            if (!File.Exists("Data\\nvdxt.exe") )
            {
               MessageBox.Show("data\\nvdxt.exe is missing please put it in the data folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            label1.Text = "Add Imanges To Begin";
            if (Properties.Settings.Default.warned == "false")
            {
                MessageBox.Show("if any other required tools are missing this will not work right", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MessageBox.Show("Due to legail reasons i can't include the required tools you will need to find them yourself", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Properties.Settings.Default.warned = "true";
                Properties.Settings.Default.Save();
            }
            var message = MessageBox.Show("Do you want to log the output of nvdxt on each imange?", "Log?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (message == DialogResult.Yes)
            {
                log = true;
            }
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = true;
            OFD.ShowDialog();
            filePaths.AddRange(OFD.FileNames);
            for (int i = 0; i < filePaths.Count; i++)
            {
                lboxFiles.Items.Add(OFD.SafeFileNames[i]);
            }
            label1.Text = lboxFiles.Items.Count + " To be converted ";
        }

        private void btadddir_Click(object sender, EventArgs e)
        {
            /// this is going to add all files via the add dir to the listbox
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Select the texture Folder";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(FBD.SelectedPath, "*.png", SearchOption.AllDirectories);
                foreach (string dds in files)
                {
                    if (!filePaths.Contains(dds))
                    {
                        lboxFiles.Items.Add(Path.GetFileName(dds));
                        filePaths.Add(dds);
                        label1.Text = lboxFiles.Items.Count + " To be converted ";
                    }
                }
                files = Directory.GetFiles(FBD.SelectedPath, "*.jpg", SearchOption.AllDirectories);
                foreach (string tgafiles in files)
                {
                    if (!filePaths.Contains(tgafiles))
                    {
                        lboxFiles.Items.Add(Path.GetFileName(tgafiles));
                        filePaths.Add(tgafiles);
                        label1.Text = lboxFiles.Items.Count + " To be converted ";
                    }
                }
                files = Directory.GetFiles(FBD.SelectedPath, "*.tga", SearchOption.AllDirectories);
                foreach (string tgafiles in files)
                {
                    if (!filePaths.Contains(tgafiles))
                    {
                        lboxFiles.Items.Add(Path.GetFileName(tgafiles));
                        filePaths.Add(tgafiles);
                        label1.Text = lboxFiles.Items.Count + " To be converted ";
                    }
                }
            }
            label1.Text = lboxFiles.Items.Count + " To be converted ";
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            lboxFiles.Items.Clear();
            lboxFiles.Refresh();
            filePaths.Clear();
            progressBar1.Maximum = lboxFiles.Items.Count;
            label1.Text = lboxFiles.Items.Count + " To be converted ";
        }

        private void credit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Credits"] == null)
            {
                Credits form = new Credits();
                form.Show();
            }
        }

        public void UpdateProgress()
        {
            Invoke(new Action(() =>
            {
                progressBar1.Value++;
            }));
        }

        public void Finished()
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show("Your Imanges are converted!", "Finished!");
                label1.Text = "Finished";
                filePaths.Clear();
                lboxFiles.Items.Clear();
                progressBar1.Value = 0;
            }));
            return;
        }

        public void Work()
        {
            foreach (var file in filePaths)
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + file + "\" -output \"" + file.Replace(Path.GetExtension(file), ".dds") + $"\" -rel_scale 1.0, 1.0 -nomipmap -{format}\"";                
                if (log)
                {
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                }
                process.Start();
                process.WaitForExit();
                if (log)
                {
                    string logname = "logs\\" + Path.GetFileNameWithoutExtension(file) + "_1.log";
                    File.WriteAllText(logname, process.StandardOutput.ReadToEnd());
                }
                if (clean)
                {
                    File.Delete(file);
                }
                UpdateProgress();
            }
            T1_Done = true;
        }

        public void ClearLogs()
        {
            string[] logs = Directory.EnumerateFiles("logs", "*.log", SearchOption.AllDirectories).ToArray();
            foreach (string log in logs)
            {
                File.Delete(log);
            }
        }

        private void btstart_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("logs"))
            {
                ClearLogs();
            }
            else
            {
                Directory.CreateDirectory("logs");
            }
            clean = RCClean.Checked;
            format = comboBox1.Text;
            progressBar1.Maximum = filePaths.Count;
            ThreadStart Createthread2 = new ThreadStart(Work);
            Thread thread2 = new Thread(Createthread2);
            thread2.Start();
            backgroundWorker1.RunWorkerAsync();
        }

        private void lboxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string all in array)
            {
                if ((Path.GetExtension(all.ToLower()) == ".png" || Path.GetExtension(all.ToLower()) == ".jpg" || Path.GetExtension(all.ToLower()) == ".tga") && !filePaths.Contains(all))
                {
                    lboxFiles.Items.Add(Path.GetFileName(all));
                    filePaths.Add(all);
                    label1.Text = lboxFiles.Items.Count + " To be converted ";
                }
                if (Directory.Exists(all))
                {
                    string[] files = Directory.GetFiles(all, "*.png", SearchOption.AllDirectories);
                    foreach (string dds in files)
                    {
                        if (!filePaths.Contains(dds))
                        {
                            lboxFiles.Items.Add(Path.GetFileName(dds));
                            filePaths.Add(dds);
                            label1.Text = lboxFiles.Items.Count + " To be converted ";
                        }
                    }
                    files = Directory.GetFiles(all, "*.jpg", SearchOption.AllDirectories);
                    foreach (string tga in files)
                    {
                        if (!filePaths.Contains(tga))
                        {
                            lboxFiles.Items.Add(Path.GetFileName(tga));
                            filePaths.Add(tga);
                            label1.Text = lboxFiles.Items.Count + " To be converted ";
                        }
                    }
                    files = Directory.GetFiles(all, "*.tga", SearchOption.AllDirectories);
                    foreach (string tga in files)
                    {
                        if (!filePaths.Contains(tga))
                        {
                            lboxFiles.Items.Add(Path.GetFileName(tga));
                            filePaths.Add(tga);
                            label1.Text = lboxFiles.Items.Count + " To be converted ";
                        }
                    }
                }
            }
        }

        private void lboxFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    if (T1_Done == true)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("Your Imanges are converted!", "Finished!");
                            filePaths.Clear();
                            lboxFiles.Items.Clear();
                            label1.Text = "Finished Converting! ";
                            progressBar1.Value = 0;
                        }));
                        break;
                    }
                }
            }
        }
    }
}