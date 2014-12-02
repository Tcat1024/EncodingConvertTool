using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EncodingConvertTool
{
    public partial class BatProcessForm : Form
    {
        public BatProcessForm(ComboBox.ObjectCollection items, object[] typelist)
        {
            InitializeComponent();
            foreach (var item in items)
                this.comboMode.Items.Add(item);
            this.comboMode.Items.Add("还原模式");
            this.comboMode.SelectedIndex = 0;
            this.comboType.Items.AddRange(typelist);
            this.comboType.SelectedIndex = 0;
        }

        private void checkedListBox1_CustomDrawItem(object sender, CustomDrawCheckListBox.CustomDrawItemEventArgs e)
        {
            if (e.Index == 0)
            {
                e.Font = new Font(e.Font, FontStyle.Bold);
                e.ForeColor = Color.Blue;
            }
        }
        private bool innerInit = false;
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var targetControl = (sender as CheckedListBox);
            if (e.Index == 0)
            {
                if (!innerInit)
                {
                    targetControl.BeginUpdate();
                    for (int i = targetControl.Items.Count - 1; i > 0; i--)
                    {
                        targetControl.SetItemCheckState(i, e.NewValue);
                    }
                    targetControl.EndUpdate();
                }
            }
            else
            {
                int re = targetControl.Items.Count - 1;
                for (int i = targetControl.Items.Count - 1; i > 0; i--)
                {
                    if (targetControl.GetItemChecked(i))
                    {
                        re--;
                    }
                }
                innerInit = true;
                if (re == targetControl.Items.Count - 2 && e.NewValue == CheckState.Unchecked)
                {
                    targetControl.SetItemCheckState(0, CheckState.Unchecked);
                }
                else if (re == 1 && e.NewValue == CheckState.Checked)
                {
                    targetControl.SetItemCheckState(0, CheckState.Checked);
                }
                else
                {
                    targetControl.SetItemCheckState(0, CheckState.Indeterminate);
                }
                innerInit = false;
            }
        }


        private void btnAddNewType_Click(object sender, EventArgs e)
        {
            var target = this.txbNewType.Text.Trim();
            if (target != "")
                clbTypeList.SetItemChecked(clbTypeList.Items.Add("." + target), true);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.txbFolder.Text.Trim() == "")
            {
                MessageBox.Show("未指定路径");
                return;
            } 
            int count = this.clbTypeList.Items.Count;
            List<string> selectedtypes = new List<string>();
            if(this.comboMode.Text!="还原模式")
                for (int i = 1; i < count; i++)
                {
                    if (this.clbTypeList.GetItemChecked(i))
                    {
                        selectedtypes.Add("*" + this.clbTypeList.Items[i].ToString());
                    }
                }
            else
                for (int i = 1; i < count; i++)
                {
                    if (this.clbTypeList.GetItemChecked(i))
                    {
                        selectedtypes.Add("*" + this.clbTypeList.Items[i].ToString()+".bak");
                    }
                }
            if(selectedtypes.Count<1)
            {
                MessageBox.Show("未选择任何文件类型");
                return;
            }
            if (convertThread != null && convertThread.ThreadState != ThreadState.Aborted && convertThread.ThreadState != ThreadState.Stopped)
                abortConvertThread();
            convertThread = new Thread(convertThreadMethod);
            convertThread.IsBackground = true;
            convertThread.Start(new ConvertOption(this.ckbIntelligence.Checked, this.ckbBackUp.Checked, this.comboType.SelectedItem, this.comboMode.SelectedItem, this.txbFolder.Text, selectedtypes));
        }
        private List<string> targetfiles;
        private Thread waitThread;
        private Thread convertThread;
        private object cancelHandle = new object();
        private void convertStartInit()
        {
            this.panel1.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
        }
        private void convertEndInit()
        {
            this.panel1.Enabled = true;
            progressBar1.Visible = false;
            MessageBox.Show("转换了" + currentCount + "个文件");
        }
        private void convertThreadMethod(object option)
        {
            ConvertOption convertoption = option as ConvertOption;
            try
            {
                this.Invoke(new Action(convertStartInit));
                currentCount = 0;
                string result = "";
                string file = "";
                string originname;
                string tempname;
                Action convertmethod;
                targetfiles = convertoption.TypeList.SelectMany(g => Directory.EnumerateFiles(convertoption.RootPath, g, SearchOption.AllDirectories)).ToList();
                if (waitThread != null && waitThread.ThreadState != ThreadState.Aborted)
                    waitThread.Abort();
                (waitThread = new Thread(waitThreadMethod)).Start(targetfiles.Count);
                if (convertoption.EncodeConvertMode.ToString() == "还原模式")
                {
                    if (convertoption.BackUp)
                    {
                        convertmethod = () =>
                        {
                            originname = file.Substring(0, file.Length - 4);
                            if (File.Exists(originname))
                            {
                                tempname = Path.GetTempFileName();
                                FileMethod.RenameFile(originname, tempname);
                                FileMethod.RenameFile(file, originname);
                                FileMethod.RenameFile(tempname, file);
                            }
                            else
                                FileMethod.RenameFile(file, originname);
                        };
                    }
                    else
                    {
                        convertmethod = () =>
                        {
                            originname = file.Substring(0, file.Length - 4);
                            FileMethod.RenameFile(file, originname);
                        };
                    }                
                }
                else
                {
                    if (convertoption.BackUp)
                    {
                        convertmethod = () =>
                        {
                            result = (convertoption.EncodeConvertMode as EncodeConvertMode).Convert(FileMethod.OpenFile(file), convertoption.EncodeType as EncodeType, convertoption.Intelligence);
                            FileMethod.RenameFile(file, file + ".bak");
                            FileMethod.SaveFile(file, result);
                        };
                    }
                    else
                    {
                        convertmethod = () =>
                        {
                            result = (convertoption.EncodeConvertMode as EncodeConvertMode).Convert(FileMethod.OpenFile(file), convertoption.EncodeType as EncodeType, convertoption.Intelligence);
                            FileMethod.SaveFile(file, result);
                        };
                    }
                }
                for (int i = 0; i < targetfiles.Count; )
                {
                    lock (cancelHandle)
                    {
                        try
                        {
                            file = targetfiles[i];
                            convertmethod();
                            currentCount++;
                            i++;
                        }
                        catch (Exception ex)
                        {
                            switch (MessageBox.Show("处理文件\"" + file + "\"时出现异常:\n" + ex.Message, "注意", MessageBoxButtons.AbortRetryIgnore))
                            {
                                case System.Windows.Forms.DialogResult.Ignore: i++; LocalLog.WhriteLog(file + "\r\n\t" + ex.Message + "\r\n\tIgnore;"); continue;
                                case System.Windows.Forms.DialogResult.Retry: continue;
                                case System.Windows.Forms.DialogResult.Abort: LocalLog.WhriteLog(file + "\r\n\t" + ex.Message + "\r\n\tAbort;"); return;
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                waitThread.Abort();
                this.Invoke(new Action(convertEndInit));
            }
        }
        private int currentCount = 0;
        private void waitThreadMethod(object o)
        {
            int count = Convert.ToInt32(o);
            while (true)
            {
                Thread.Sleep(200);
                this.Invoke(new Action(() => { progressBar1.Value = currentCount * 100 / count; }));
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMode.Text == "还原模式")
            {
                this.ckbIntelligence.Enabled = false;
                this.comboType.Enabled = false;
            }
            else
            {
                this.ckbIntelligence.Enabled = true;
                this.comboType.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txbFolder.Text = fbd.SelectedPath;
            }
        }
        private void abortConvertThread()
        {
            lock (cancelHandle)
            {
                convertThread.Abort();
            }
        }
        private void BatProcessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (convertThread != null && convertThread.ThreadState != ThreadState.Aborted && convertThread.ThreadState!= ThreadState.Stopped)
            {
                abortConvertThread();
                e.Cancel = true;
            }
        }
        private class ConvertOption
        {
            public bool Intelligence;
            public bool BackUp;
            public object EncodeType;
            public object EncodeConvertMode;
            public string RootPath;
            public List<string> TypeList;
            public ConvertOption(bool intelligence, bool backup, object encodetype, object encodeconvertmode, string path, List<string> typelist)
            {
                this.Intelligence = intelligence;
                this.BackUp = backup;
                this.EncodeType = encodetype;
                this.EncodeConvertMode = encodeconvertmode;
                this.RootPath = path;
                this.TypeList = typelist;
            }
        }
    }
}
