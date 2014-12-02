namespace EncodingConvertTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTextBoard = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重做ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBatPro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIntelligence = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAllowQOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.comboMode = new System.Windows.Forms.ToolStripComboBox();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTextBoard
            // 
            this.mainTextBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTextBoard.Location = new System.Drawing.Point(0, 28);
            this.mainTextBoard.Name = "mainTextBoard";
            this.mainTextBoard.Size = new System.Drawing.Size(581, 397);
            this.mainTextBoard.TabIndex = 0;
            this.mainTextBoard.Text = "";
            this.mainTextBoard.TextChanged += new System.EventHandler(this.mainTextBoard_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.编辑ToolStripMenuItem,
            this.menuTool,
            this.menuConfig,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnClose});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(49, 24);
            this.menuFile.Text = "文件";
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(120, 24);
            this.btnOpen.Text = "打开";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 24);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(120, 24);
            this.btnSaveAs.Text = "另存为";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 24);
            this.btnClose.Text = "退出";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤销ToolStripMenuItem,
            this.重做ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            this.撤销ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.撤销ToolStripMenuItem.Text = "撤销";
            // 
            // 重做ToolStripMenuItem
            // 
            this.重做ToolStripMenuItem.Name = "重做ToolStripMenuItem";
            this.重做ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.重做ToolStripMenuItem.Text = "重做";
            // 
            // menuTool
            // 
            this.menuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBatPro});
            this.menuTool.Name = "menuTool";
            this.menuTool.Size = new System.Drawing.Size(49, 24);
            this.menuTool.Text = "工具";
            // 
            // btnBatPro
            // 
            this.btnBatPro.Name = "btnBatPro";
            this.btnBatPro.Size = new System.Drawing.Size(162, 24);
            this.btnBatPro.Text = "批处理";
            this.btnBatPro.Click += new System.EventHandler(this.btnBatPro_Click);
            // 
            // menuConfig
            // 
            this.menuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIntelligence,
            this.btnAllowQOpen,
            this.toolStripSeparator1,
            this.comboMode});
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.Size = new System.Drawing.Size(49, 24);
            this.menuConfig.Text = "设置";
            this.menuConfig.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuConfig_DropDownItemClicked);
            // 
            // btnIntelligence
            // 
            this.btnIntelligence.Checked = true;
            this.btnIntelligence.CheckOnClick = true;
            this.btnIntelligence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnIntelligence.Name = "btnIntelligence";
            this.btnIntelligence.Size = new System.Drawing.Size(181, 24);
            this.btnIntelligence.Text = "智能识别语种";
            this.btnIntelligence.Click += new System.EventHandler(this.btnIntelligence_Click);
            // 
            // btnAllowQOpen
            // 
            this.btnAllowQOpen.Checked = true;
            this.btnAllowQOpen.CheckOnClick = true;
            this.btnAllowQOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAllowQOpen.Name = "btnAllowQOpen";
            this.btnAllowQOpen.Size = new System.Drawing.Size(181, 24);
            this.btnAllowQOpen.Text = "快捷打开";
            this.btnAllowQOpen.Click += new System.EventHandler(this.btnAllowQOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // comboMode
            // 
            this.comboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMode.Name = "comboMode";
            this.comboMode.Size = new System.Drawing.Size(121, 28);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.说明ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 说明ToolStripMenuItem
            // 
            this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
            this.说明ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.说明ToolStripMenuItem.Text = "说明";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 425);
            this.Controls.Add(this.mainTextBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "日文编码转换";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox mainTextBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem btnSaveAs;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem menuConfig;
        private System.Windows.Forms.ToolStripMenuItem btnIntelligence;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重做ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTool;
        private System.Windows.Forms.ToolStripMenuItem btnBatPro;
        private System.Windows.Forms.ToolStripMenuItem btnAllowQOpen;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox comboMode;
        private System.Windows.Forms.ToolStripMenuItem btnClose;

    }
}

