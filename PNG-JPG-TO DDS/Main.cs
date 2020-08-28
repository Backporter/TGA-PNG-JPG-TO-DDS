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

namespace PNG_JPG_TO_DDS
{
    public partial class Main : Form
    {
        private List<string> filePaths = new List<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "dxt1a";
            Directory.CreateDirectory("temp");
            toolTip1.SetToolTip(this.btadd, "This is to add them one by one");
            toolTip1.SetToolTip(this.btadddir, "This is for adding a dirtory");
            toolTip1.SetToolTip(this.btClear, "this will purge the list");
            toolTip1.SetToolTip(this.credit, "This will open the credit");
            toolTip1.SetToolTip(this.btstart, "this will start the ");
            if (File.Exists("Data\\nvdxt.exe") == false)
            {
               MessageBox.Show("data\\nvdxt.exe is missing please put it in the data folder", ("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            MessageBox.Show("if any other required tools are missing this will not work right", ("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("Due to legail reasons i can't include the required tools you will need to find them yourself", ("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            label1.Text = "Add Textures to begin";
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

        private void btstart_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("temp");
            DirectoryInfo info = new DirectoryInfo(Application.StartupPath + "\\temp\\");
            FileInfo[] files = info.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            for (int i = 0; i < filePaths.Count; i++)
            {
                if (comboBox1.Text == ("dxt1a"))
                {
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        System.GC.Collect();
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        System.GC.Collect();
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        System.GC.Collect();
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        System.GC.Collect();
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        System.GC.Collect();
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        System.GC.Collect();
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("dxt1c"))
                {
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1c\"";
                        process.Start();
                        process.WaitForExit();

                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1c\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1c\"";
                        process.Start();
                        process.WaitForExit();

                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1c\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt1a\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("dxt3"))
                {
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt3\"";
                        process.Start();
                        process.WaitForExit();

                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt3\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt3\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt3\"";
                        process.Start();
                        process.WaitForExit();

                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt3\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt3\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("dxt5"))
                {
                    ///dxt5
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5\"";
                        process.Start();
                        process.WaitForExit();

                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5\"";
                        process.Start();
                        process.WaitForExit();

                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5\"";
                        process.Start();
                        process.WaitForExit();
                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("u1555"))
                {
                    ///u1555
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u1555\"";
                        process.Start();
                        process.WaitForExit();

                        
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u1555\"";
                        process.Start();
                        process.WaitForExit();

                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u1555\"";
                        process.Start();
                        process.WaitForExit();

                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u1555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u1555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u1555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("u4444"))
                {
                    //u4444
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u4444\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u4444\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u4444\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u4444\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u4444\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u4444\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("u565"))
                {
                    ///u565
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u565\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u565\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u565\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u565\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u565\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u565\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("u8888"))
                {
                    ///u8888
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u8888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u8888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u8888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u8888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u8888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u8888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("u888"))
                {
                    //u888
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u888\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("u555"))
                {
                    //u555
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    //
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -u555\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("p8c"))
                {
                    ///p8c
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("p8a"))
                {
                    ////p8a
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p8a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("p4c"))
                {
                    //p4c
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4c\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("p4a"))
                {
                    //p4a
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -p4a\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("a8"))
                {
                    //a8
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -a8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -a8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -a8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -a8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -a8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -a8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("cxv8u8"))
                {
                    //cxv8u8
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -cxv8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -cxv8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -cxv8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -cxv8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -cxv8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -cxv8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("v8u8"))
                {
                    //v8u8
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v8u8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("v16u16"))
                {
                    //v16u16
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v16u16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v16u16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v16u16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v16u16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v16u16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -v16u16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("A8L8"))
                {
                    //A8L8
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -A8L8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -A8L8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -A8L8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if(filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -A8L8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -A8L8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -A8L8\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("fp32x4"))
                {
                    //fp32x4
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("fp32"))
                {
                    //fp32
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp32\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("fp16x4"))
                {
                    //fp16x4
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp16x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp16x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp16x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp16x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp16x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -fp16x4\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("dxt5nm"))
                {
                    //dxt5nm
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5nm\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5nm\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5nm\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5nm\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5nm\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -dxt5nm\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("3Dc"))
                {
                    //3Dc
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -3Dc\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -3Dc\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -3Dc\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -3Dc\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -3Dc\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -3Dc\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("g16r16"))
                {
                    //g16r16
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                else if (comboBox1.Text == ("g16r16f"))
                {
                    //g16r16f
                    if (filePaths[i].Contains(".png"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".png", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16f\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".jpg"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".jpg", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16f\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".tga"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".tga", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16f\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    ///
                    else if (filePaths[i].Contains(".PNG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".PNG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16f\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;

                    }
                    else if (filePaths[i].Contains(".JPG"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".JPG", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16f\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".TGA"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.Arguments = "/c Data\\nvdxt.exe -file \"" + filePaths[i] + "\" -output \"" + filePaths[i].ToString().Replace(".TGA", ".dds") + "\" -rel_scale 1.0, 1.0 -nomipmap -g16r16f\"";
                        process.Start();
                        process.WaitForExit();
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }
                if (PNGTGAJPG.Checked == true)
                {
                    System.IO.File.Delete(filePaths[i]);
                }

                /// this checks to see if they are all done converting
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    /// this is going to show the messege box
                    MessageBox.Show("Your Textures are converted!", "Finished!");
                    label1.Text = "Finished";
                    filePaths.Clear();
                    lboxFiles.Items.Clear();
                    progressBar1.Value = 0;
                }
            }
        }

        private void lboxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string all in array)
            {
                if ((Path.GetExtension(all) == ".png" || Path.GetExtension(all) == ".PNG" || Path.GetExtension(all) == ".jpg" || Path.GetExtension(all) == ".JPG" || Path.GetExtension(all) == ".tga" || Path.GetExtension(all) == ".TGA") && !filePaths.Contains(all))
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
            Directory.Delete("temp");
        }
    }
}
