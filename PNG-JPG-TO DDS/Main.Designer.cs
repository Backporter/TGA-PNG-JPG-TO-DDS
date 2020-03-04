namespace PNG_JPG_TO_DDS
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btstart = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btadddir = new System.Windows.Forms.Button();
            this.btadd = new System.Windows.Forms.Button();
            this.lboxFiles = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.credit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PNGTGAJPG = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btstart
            // 
            this.btstart.AutoSize = true;
            this.btstart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btstart.Location = new System.Drawing.Point(658, 119);
            this.btstart.Name = "btstart";
            this.btstart.Size = new System.Drawing.Size(128, 23);
            this.btstart.TabIndex = 93;
            this.btstart.Text = "Start";
            this.btstart.UseVisualStyleBackColor = true;
            this.btstart.Click += new System.EventHandler(this.btstart_Click);
            // 
            // btClear
            // 
            this.btClear.AutoSize = true;
            this.btClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btClear.Location = new System.Drawing.Point(658, 61);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(128, 23);
            this.btClear.TabIndex = 92;
            this.btClear.Text = "Purge list";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btadddir
            // 
            this.btadddir.AutoSize = true;
            this.btadddir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btadddir.Location = new System.Drawing.Point(658, 32);
            this.btadddir.Name = "btadddir";
            this.btadddir.Size = new System.Drawing.Size(128, 23);
            this.btadddir.TabIndex = 91;
            this.btadddir.Text = "Add Directory(s)";
            this.btadddir.UseVisualStyleBackColor = true;
            this.btadddir.Click += new System.EventHandler(this.btadddir_Click);
            // 
            // btadd
            // 
            this.btadd.AutoSize = true;
            this.btadd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btadd.Location = new System.Drawing.Point(658, 3);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(128, 23);
            this.btadd.TabIndex = 90;
            this.btadd.Text = "Add File(s)";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // lboxFiles
            // 
            this.lboxFiles.AllowDrop = true;
            this.lboxFiles.FormattingEnabled = true;
            this.lboxFiles.Location = new System.Drawing.Point(8, 3);
            this.lboxFiles.Name = "lboxFiles";
            this.lboxFiles.Size = new System.Drawing.Size(644, 381);
            this.lboxFiles.TabIndex = 97;
            this.lboxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lboxFiles_DragDrop);
            this.lboxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lboxFiles_DragEnter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // credit
            // 
            this.credit.AutoSize = true;
            this.credit.Location = new System.Drawing.Point(658, 90);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(128, 23);
            this.credit.TabIndex = 95;
            this.credit.Text = "Credits";
            this.credit.UseVisualStyleBackColor = true;
            this.credit.Click += new System.EventHandler(this.credit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(658, 161);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(128, 23);
            this.progressBar1.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "dxt1a",
            "dxt1c",
            "dxt3",
            "dxt5",
            "u1555",
            "u4444",
            "u565",
            "u8888",
            "u555",
            "p8c",
            "p8a",
            "p4c",
            "p4a",
            "a8",
            "cxv8u8",
            "v8u8",
            "v16u16",
            "A8L8",
            "fp32x4",
            "fp32",
            "fp16x4",
            "dxt5nm",
            "3Dc",
            "g16r16",
            "g16r16f"});
            this.comboBox1.Location = new System.Drawing.Point(658, 197);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 100;
            // 
            // PNGTGAJPG
            // 
            this.PNGTGAJPG.AutoSize = true;
            this.PNGTGAJPG.Checked = true;
            this.PNGTGAJPG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PNGTGAJPG.Location = new System.Drawing.Point(658, 224);
            this.PNGTGAJPG.Name = "PNGTGAJPG";
            this.PNGTGAJPG.Size = new System.Drawing.Size(132, 30);
            this.PNGTGAJPG.TabIndex = 101;
            this.PNGTGAJPG.Text = "Delete Orginal Texture\r\n(*.png *.jpg *.tga)";
            this.PNGTGAJPG.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 387);
            this.Controls.Add(this.PNGTGAJPG);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btstart);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btadddir);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.lboxFiles);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "PNG-JPG-TO DDS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btstart;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btadddir;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.ListBox lboxFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button credit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox PNGTGAJPG;
    }
}

