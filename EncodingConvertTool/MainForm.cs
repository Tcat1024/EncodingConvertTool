using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EncodingConvertTool
{
    public partial class MainForm : Form
    {
        string currentfilpath = "";
        bool currentchanged = false;
        EncodeType[] typelist;
        public MainForm()
        {
            InitializeComponent();
            this.mainTextBoard.AllowDrop = true;
            this.mainTextBoard.DragDrop += mainTextBoard_DragDrop;
            this.mainTextBoard.DragEnter += mainTextBoard_DragEnter;
            initMenu();
        }
        private void initMenu()
        {
            typelist = EncodeType.GetKnownTypeList();
            ToolStripItem tempItem;
            foreach (var item in typelist)
            {
                tempItem = new ToolStripMenuItem(item.Name + "->" + "中文");
                tempItem.Tag = item;
                tempItem.Click += this.btnEncodeConvert_Click;
                menuTool.DropDownItems.Insert(0, tempItem);
            }
            this.comboMode.Items.AddRange(EncodeConvertMode.GetKnownModeList());
            this.comboMode.SelectedIndex = 0;
        }
        void mainTextBoard_DragEnter(object sender, DragEventArgs e)
        {
            if (this.btnAllowQOpen.Checked)
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        void mainTextBoard_DragDrop(object sender, DragEventArgs e)
        {
            if (checkChanged())
            {
                var filenames = (Array)e.Data.GetData(DataFormats.FileDrop);
                InitTextBoard(FileMethod.OpenFile(currentfilpath = filenames.GetValue(0).ToString()));
            }
        }

        private bool initing = false;
        private void InitTextBoard(string target)
        {
            initing = true;
            this.mainTextBoard.Text = target;
            currentchanged = false;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.GetDirectoryName(currentfilpath);
            sfd.Filter = "所有文件(*)|*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = false;
            sfd.FileName = Path.GetFileName(currentfilpath);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileMethod.SaveFile(sfd.FileName, this.mainTextBoard.Text);
                    currentchanged = false;
                    currentfilpath = sfd.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnIntelligence_Click(object sender, EventArgs e)
        {
            menuConfig.DropDown.AutoClose = true;
        }
        private void menuConfig_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            menuConfig.DropDown.AutoClose = false;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (currentfilpath.Trim() == "")
                opd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            else
                opd.InitialDirectory = Path.GetDirectoryName(currentfilpath);
            opd.Filter = "所有文件(*)|*";
            opd.FilterIndex = 1;
            opd.RestoreDirectory = false;
            if (opd.ShowDialog() == DialogResult.OK&&checkChanged())
            {
                try
                {
                    InitTextBoard(FileMethod.OpenFile(currentfilpath = opd.FileName));
                    currentfilpath = opd.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FileMethod.SaveFile(currentfilpath, this.mainTextBoard.Text);

                currentchanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAllowQOpen_Click(object sender, EventArgs e)
        {
            menuConfig.DropDown.AutoClose = true;
        }
        private void btnEncodeConvert_Click(object sender, EventArgs e)
        {
            string source = this.mainTextBoard.Text;
            if (source.Trim() == "")
                return;
            string result = (this.comboMode.SelectedItem as EncodeConvertMode).Convert(source, (sender as ToolStripItem).Tag as EncodeType,this.btnIntelligence.Checked);
            this.mainTextBoard.Text = result;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!checkChanged())
                e.Cancel = true;
        }
        private bool checkChanged()
        {
            if (this.currentchanged)
            {
                var result = new SaveMessageBox() { MessageText = "当前文件已修改，是否将更改保存到\"" + Path.GetFileName(currentfilpath) + "\"中?" }.ShowDialog();
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        {
                            try
                            {
                                FileMethod.SaveFile(currentfilpath, this.mainTextBoard.Text);
                                currentchanged = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return false;
                            }
                            return true;
                        }
                    case System.Windows.Forms.DialogResult.No: return true;
                    default: return false;
                }
            }
            else
                return true;
        }
        private void mainTextBoard_TextChanged(object sender, EventArgs e)
        {
            if (!initing)
                currentchanged = true;
            else
                initing = false;
        }

        private void btnBatPro_Click(object sender, EventArgs e)
        {
            BatProcessForm configForm = new BatProcessForm(this.comboMode.Items,this.typelist);
            configForm.ShowDialog();
        }
    }
}
