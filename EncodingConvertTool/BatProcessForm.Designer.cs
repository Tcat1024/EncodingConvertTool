namespace EncodingConvertTool
{
    partial class BatProcessForm
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
            this.txbFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.comboMode = new System.Windows.Forms.ComboBox();
            this.ckbChildFolder = new System.Windows.Forms.CheckBox();
            this.ckbIntelligence = new System.Windows.Forms.CheckBox();
            this.ckbBackUp = new System.Windows.Forms.CheckBox();
            this.txbNewType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewType = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clbTypeList = new EncodingConvertTool.CustomDrawCheckListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbFolder
            // 
            this.txbFolder.Location = new System.Drawing.Point(11, 7);
            this.txbFolder.Name = "txbFolder";
            this.txbFolder.ReadOnly = true;
            this.txbFolder.Size = new System.Drawing.Size(184, 22);
            this.txbFolder.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(201, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // comboMode
            // 
            this.comboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMode.FormattingEnabled = true;
            this.comboMode.Location = new System.Drawing.Point(171, 145);
            this.comboMode.Name = "comboMode";
            this.comboMode.Size = new System.Drawing.Size(104, 21);
            this.comboMode.TabIndex = 3;
            this.comboMode.SelectedIndexChanged += new System.EventHandler(this.comboMode_SelectedIndexChanged);
            // 
            // ckbChildFolder
            // 
            this.ckbChildFolder.AutoSize = true;
            this.ckbChildFolder.Checked = true;
            this.ckbChildFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbChildFolder.Location = new System.Drawing.Point(166, 62);
            this.ckbChildFolder.Name = "ckbChildFolder";
            this.ckbChildFolder.Size = new System.Drawing.Size(110, 18);
            this.ckbChildFolder.TabIndex = 4;
            this.ckbChildFolder.Text = "包含子文件夹";
            this.ckbChildFolder.UseVisualStyleBackColor = true;
            // 
            // ckbIntelligence
            // 
            this.ckbIntelligence.AutoSize = true;
            this.ckbIntelligence.Checked = true;
            this.ckbIntelligence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIntelligence.Location = new System.Drawing.Point(166, 38);
            this.ckbIntelligence.Name = "ckbIntelligence";
            this.ckbIntelligence.Size = new System.Drawing.Size(110, 18);
            this.ckbIntelligence.TabIndex = 5;
            this.ckbIntelligence.Text = "智能识别语种";
            this.ckbIntelligence.UseVisualStyleBackColor = true;
            // 
            // ckbBackUp
            // 
            this.ckbBackUp.AutoSize = true;
            this.ckbBackUp.Checked = true;
            this.ckbBackUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbBackUp.Location = new System.Drawing.Point(166, 86);
            this.ckbBackUp.Name = "ckbBackUp";
            this.ckbBackUp.Size = new System.Drawing.Size(96, 18);
            this.ckbBackUp.TabIndex = 6;
            this.ckbBackUp.Text = "备份源文件";
            this.ckbBackUp.UseVisualStyleBackColor = true;
            // 
            // txbNewType
            // 
            this.txbNewType.Location = new System.Drawing.Point(21, 202);
            this.txbNewType.Name = "txbNewType";
            this.txbNewType.Size = new System.Drawing.Size(84, 22);
            this.txbNewType.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(11, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "目标文件类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddNewType
            // 
            this.btnAddNewType.Location = new System.Drawing.Point(108, 202);
            this.btnAddNewType.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddNewType.Name = "btnAddNewType";
            this.btnAddNewType.Size = new System.Drawing.Size(45, 23);
            this.btnAddNewType.TabIndex = 12;
            this.btnAddNewType.Text = "添加";
            this.btnAddNewType.UseVisualStyleBackColor = true;
            this.btnAddNewType.Click += new System.EventHandler(this.btnAddNewType_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(201, 172);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(201, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = ".";
            // 
            // comboType
            // 
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(171, 118);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(105, 21);
            this.comboType.TabIndex = 17;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 229);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(282, 10);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbFolder);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.comboType);
            this.panel1.Controls.Add(this.comboMode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ckbChildFolder);
            this.panel1.Controls.Add(this.ckbIntelligence);
            this.panel1.Controls.Add(this.ckbBackUp);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.txbNewType);
            this.panel1.Controls.Add(this.btnAddNewType);
            this.panel1.Controls.Add(this.clbTypeList);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 229);
            this.panel1.TabIndex = 19;
            // 
            // clbTypeList
            // 
            this.clbTypeList.CheckOnClick = true;
            this.clbTypeList.FormattingEnabled = true;
            this.clbTypeList.Items.AddRange(new object[] {
            "全选",
            ".txt",
            ".cue",
            ".log",
            ".c",
            ".cs",
            ".cpp"});
            this.clbTypeList.Location = new System.Drawing.Point(11, 62);
            this.clbTypeList.Name = "clbTypeList";
            this.clbTypeList.Size = new System.Drawing.Size(142, 140);
            this.clbTypeList.TabIndex = 10;
            this.clbTypeList.CustomDrawItem += new System.EventHandler<EncodingConvertTool.CustomDrawCheckListBox.CustomDrawItemEventArgs>(this.checkedListBox1_CustomDrawItem);
            this.clbTypeList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // BatProcessForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(282, 239);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(287, 226);
            this.Name = "BatProcessForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批处理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatProcessForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox comboMode;
        private System.Windows.Forms.CheckBox ckbChildFolder;
        private System.Windows.Forms.CheckBox ckbIntelligence;
        private System.Windows.Forms.CheckBox ckbBackUp;
        private System.Windows.Forms.TextBox txbNewType;
        private CustomDrawCheckListBox clbTypeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNewType;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
    }
}