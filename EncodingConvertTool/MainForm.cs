﻿using System;
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
            var templist = EncodeType.GetKnownTypeList();
            ToolStripItem tempItem;
            foreach(var item in templist)
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
                InitTextBoard(openFile(filenames.GetValue(0).ToString()));
            }
        }
        private string openFile(string filepath)
        {
            currentfilpath = filepath;
            using (StreamReader sr = new StreamReader(filepath, Encoding.Default))
            {
                string temp = sr.ReadToEnd();
                sr.Close();
                return temp;
            }
        }
        private bool initing = false;
        private void InitTextBoard(string target)
        {
            initing = true;
            this.mainTextBoard.Text = target;
            currentchanged = false;
        }
        private void saveFile(string filepath, string source)
        {
            if (filepath.Trim() == "")
                throw new Exception("并未打开任何文件");
            using (StreamWriter wr = new StreamWriter(filepath, false, Encoding.Default))
            {
                wr.Write(source);
                wr.Close();
                currentchanged = false;
            }
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
                    saveFile(sfd.FileName, this.mainTextBoard.Text);
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
            btnIntelligence.Checked = !btnIntelligence.Checked;
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
                    InitTextBoard(openFile(opd.FileName));
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
                saveFile(currentfilpath, this.mainTextBoard.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAllowQOpen_Click(object sender, EventArgs e)
        {
            btnAllowQOpen.Checked = !btnAllowQOpen.Checked;
            menuConfig.DropDown.AutoClose = true;
        }

        private void btnEncodeConvert_Click(object sender, EventArgs e)
        {
            string source = this.mainTextBoard.Text;
            if (source.Trim() == "")
                return;
            string result = (this.comboMode.SelectedItem as EncodeConvertMode).Convert(source, (sender as ToolStripItem).Tag as EncodeType);
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
                                saveFile(currentfilpath, this.mainTextBoard.Text);
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
    }
    public abstract class EncodeConvertMode
    {
        private string _Name;
        public string Name { get { return this._Name; } }
        public override string ToString()
        {
            return this.Name;
        }
        public abstract string Convert(string source, EncodeType encode);
        public static string[] GetKnownModeNameList()
        {
            List<string> result = new List<string>();
            foreach (var info in typeof(EncodeConvertMode).GetProperties())
            {
                if (info.PropertyType == typeof(EncodeConvertMode))
                    result.Add(info.Name);
            }
            return result.ToArray();
        }
        public static string[] GetKnownModeCNNameList()
        {
            List<string> result = new List<string>();
            string temp;
            foreach (var info in typeof(EncodeConvertMode).GetProperties())
            {
                if (info.PropertyType == typeof(EncodeConvertMode))
                {
                    var attr = info.GetCustomAttributes(typeof(CNNameAttribute), false);
                    if (attr != null && !result.Contains(temp = (attr[0] as CNNameAttribute).Name))
                        result.Add(temp);
                }
            }
            return result.ToArray();
        }
        public static EncodeConvertMode[] GetKnownModeList()
        {
            List<EncodeConvertMode> result = new List<EncodeConvertMode>();
            foreach (var info in typeof(EncodeConvertMode).GetProperties())
            {
                if (info.PropertyType == typeof(EncodeConvertMode))
                    result.Add(info.GetValue(null, null) as EncodeConvertMode);
            }
            return result.ToArray();
        }
        public static EncodeConvertMode GetModeFromName(string name)
        {
            var info = typeof(EncodeConvertMode).GetProperty(name);
            if (info == null)
                throw new Exception("属性不存在");
            if (info.PropertyType != typeof(EncodeConvertMode))
                throw new Exception("属性类型错误");
            return (EncodeConvertMode)info.GetValue(null, null);
        }
        public static EncodeConvertMode GetModeFromCNName(string name)
        {
            var infos = typeof(EncodeConvertMode).GetProperties();
            foreach (var info in infos)
            {
                if (info.PropertyType != typeof(EncodeConvertMode))
                    continue;
                var attr = info.GetCustomAttributes(typeof(CNNameAttribute), false);
                if (attr != null && (attr[0] as CNNameAttribute).Name == name)
                {
                    return ((EncodeConvertMode)info.GetValue(null, null));
                }
            }
            throw new Exception("属性不存在");
        }



        [CNName("cue")]
        public static EncodeConvertMode Cue { get { return _Cue != null ? _Cue : _Cue = new CueEncodeConvertMode() { _Name = "cue" }; } }
        private static EncodeConvertMode _Cue;
        private class CueEncodeConvertMode : EncodeConvertMode
        {
            public override string Convert(string source, EncodeType encode)
            {
                int i, count;
                string result = "";
                string cod;
                var ps = source.Split('"');
                count = ps.Length;
                for (i = 0; i < count - 1; i++)
                {
                    if (encode.Check(ps[i]))
                    {
                        cod = encode.Encode.GetString(Encoding.Default.GetBytes(ps[i]));
                        ps[i] = cod;
                    }
                    result += ps[i] + "\"";
                }
                if (encode.Check(ps[i]))
                {
                    cod = encode.Encode.GetString(Encoding.Default.GetBytes(ps[i]));
                    ps[i] = cod;
                }
                result += ps[i];
                return result;
            }
        }
        [CNName("默认")]
        public static EncodeConvertMode Default { get { return _Default != null ? _Default : _Default = new DefaultEncodeConvertMode() { _Name = "默认" }; } }
        private static EncodeConvertMode _Default;
        private class DefaultEncodeConvertMode : EncodeConvertMode
        {
            public override string Convert(string source, EncodeType encode)
            {
                int i, count;
                string result = "";
                string cod;
                count = source.Length;
                for (i = 0; i < count; i++)
                {
                    if (encode.Check(source[i]))
                    {
                        cod = encode.Encode.GetString(Encoding.Default.GetBytes(new char[] { source[i] }));
                        result += cod;
                    }
                    else
                        result += source[i];
                }
                return result;
            }
        }

    }
    public abstract class EncodeType
    {
        private string _Name;
        public string Name { get { return this._Name; } }
        private string _EncodeName;
        public string EncodeName
        {
            get
            {
                return this._EncodeName;
            }
            private set
            {
                this._EncodeName = value;
                this._Encode = Encoding.GetEncoding(value);
            }
        }
        private Encoding _Encode;
        public Encoding Encode { get { return this._Encode; } }
        public abstract bool Check(string target);
        public abstract bool Check(char target);
        public override string ToString()
        {
            return this.Name;
        }
        public static string[] GetKnownTypeNameList()
        {
            List<string> result = new List<string>();
            foreach (var info in typeof(EncodeType).GetProperties())
            {
                if (info.PropertyType == typeof(EncodeType))
                    result.Add(info.Name);
            }
            return result.ToArray();
        }
        public static string[] GetKnownTypeCNNameList()
        {
            List<string> result = new List<string>();
            string temp;
            foreach (var info in typeof(EncodeType).GetProperties())
            {
                if (info.PropertyType == typeof(EncodeType))
                {
                    var attr = info.GetCustomAttributes(typeof(CNNameAttribute), false);
                    if (attr != null && !result.Contains(temp = (attr[0] as CNNameAttribute).Name))
                        result.Add(temp);
                }
            }
            return result.ToArray();
        }
        public static EncodeType[] GetKnownTypeList()
        {
            List<EncodeType> result = new List<EncodeType>();
            foreach (var info in typeof(EncodeType).GetProperties())
            {
                if (info.PropertyType == typeof(EncodeType))
                    result.Add(info.GetValue(null, null) as EncodeType);  
            }
            return result.ToArray();
        }
        public static EncodeType GetEncodeFromName(string name)
        {
            var info = typeof(EncodeType).GetProperty(name);
            if (info == null)
                throw new Exception("属性不存在");
            if (info.PropertyType != typeof(EncodeType))
                throw new Exception("属性类型错误");
            return (EncodeType)info.GetValue(null, null);
        }
        public static EncodeType GetEncodesFromCNName(string name)
        {
            var infos = typeof(EncodeType).GetProperties();
            foreach (var info in infos)
            {
                if (info.PropertyType != typeof(EncodeType))
                    continue;
                var attr = info.GetCustomAttributes(typeof(CNNameAttribute), false);
                if (attr != null && (attr[0] as CNNameAttribute).Name == name)
                {
                    return ((EncodeType)info.GetValue(null, null));
                }
            }
            throw new Exception("属性不存在");
        }


        [CNName("日文")]
        public static EncodeType JN { get { return _JN != null ? _JN : _JN = new JNEncodeType() { _Name = "日文", EncodeName = "Shift-JIS" }; } }
        private static EncodeType _JN;
        private class JNEncodeType : EncodeType
        {
            public override bool Check(string targets)
            {
                if (null == targets)
                {
                    return false;
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    char c = targets[i];

                    var b = Encoding.Default.GetBytes(new char[] { c });


                    // Shift-JISの1バイトコード（半角文字）のエリア
                    if (b.Length == 1)
                    {
                        int firstByte = b[0];
                        if (firstByte < 0)
                        {
                            firstByte += 256;
                        }

                        // 0x00～0x1F、0x7F は制御コードです
                        if ((0x00 <= firstByte && firstByte <= 0x1F) || firstByte == 0x7F)
                        {
                            return false;
                        }
                        // 0x20～0x7E はASCII文字です
                        else if (0x20 <= firstByte && firstByte <= 0x7E)
                        {
                            //Unicode -> Shift-Jisの場合、非Shift-JIS文字が[?]に変化
                            if (firstByte != c)
                            {
                                return false;
                            }
                            continue;
                        }
                        // 0xA1～0xDF は半角カタカナです
                        else if (0xA1 <= firstByte && firstByte <= 0xDF)
                        {
                            continue;
                        }
                        // Shift-JIS以下の文字
                        else
                        {
                            return false;
                        }
                    }
                    // シフトJISの2バイトコード（全角文字）のエリア（JIS X 0208の漢字エリア）
                    else if (b.Length == 2)
                    {
                        int firstByte = b[0];
                        int secondByte = b[1];

                        if (firstByte < 0)
                        {
                            firstByte += 256;
                        }

                        if (secondByte < 0)
                        {
                            secondByte += 256;
                        }

                        // 上位1バイト0x81～0x9F、 0xE0～0xEF
                        // 下位1バイト0x40～0x7E、 0x80～0xFC
                        if ((0x81 <= firstByte && firstByte <= 0x9F || 0xE0 <= firstByte && firstByte <= 0xEF)
                                && (0x40 <= secondByte && secondByte <= 0x7E || 0x80 <= secondByte && secondByte <= 0xFC))
                        {
                            String sHex = firstByte.ToString("x") + secondByte.ToString("x");
                            int code = Convert.ToInt32(sHex, 16);
                            if (0x81AD <= code && code <= 0x81B7
                                    || 0x81C0 <= code && code <= 0x81C7
                                    || 0x81CF <= code && code <= 0x81D9
                                    || 0x81E9 <= code && code <= 0x81EF
                                    || 0x81F8 <= code && code <= 0x81FC
                                    || 0x8240 <= code && code <= 0x824e
                                    || 0x8259 <= code && code <= 0x825f
                                    || 0x827A <= code && code <= 0x8280
                                    || 0x829B <= code && code <= 0x829E
                                    || 0x82F2 <= code && code <= 0x82FC
                                    || 0x8397 <= code && code <= 0x839E
                                    || 0x83B7 <= code && code <= 0x83BE
                                    || 0x83D7 <= code && code <= 0x83FC
                                    || 0x8461 <= code && code <= 0x846F
                                    || 0x8492 <= code && code <= 0x849E
                                    || 0x84BF <= code && code <= 0x84FC
                                    || 0x8540 <= code && code <= 0x889E
                                    || 0x9873 <= code && code <= 0x989E
                                    || 0xEBA5 <= code && code <= 0xEBFC
                                    || 0xEB40 <= code && code <= 0xEFFC)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            public override bool Check(char targetc)
            {
                var b = Encoding.Default.GetBytes(new char[] { targetc });
                // Shift-JISの1バイトコード（半角文字）のエリア
                if (b.Length == 1)
                {
                    int firstByte = b[0];
                    if (firstByte < 0)
                    {
                        firstByte += 256;
                    }

                    // 0x00～0x1F、0x7F は制御コードです
                    if ((0x00 <= firstByte && firstByte <= 0x1F) || firstByte == 0x7F)
                    {
                        return false;
                    }
                    // 0x20～0x7E はASCII文字です
                    else if (0x20 <= firstByte && firstByte <= 0x7E)
                    {
                        //Unicode -> Shift-Jisの場合、非Shift-JIS文字が[?]に変化
                        if (firstByte != targetc)
                        {
                            return false;
                        }
                        return true;
                    }
                    // 0xA1～0xDF は半角カタカナです
                    else if (0xA1 <= firstByte && firstByte <= 0xDF)
                    {
                        return true;
                    }
                    // Shift-JIS以下の文字
                    else
                    {
                        return false;
                    }
                }
                // シフトJISの2バイトコード（全角文字）のエリア（JIS X 0208の漢字エリア）
                else if (b.Length == 2)
                {
                    int firstByte = b[0];
                    int secondByte = b[1];

                    if (firstByte < 0)
                    {
                        firstByte += 256;
                    }

                    if (secondByte < 0)
                    {
                        secondByte += 256;
                    }

                    // 上位1バイト0x81～0x9F、 0xE0～0xEF
                    // 下位1バイト0x40～0x7E、 0x80～0xFC
                    if ((0x81 <= firstByte && firstByte <= 0x9F || 0xE0 <= firstByte && firstByte <= 0xEF)
                            && (0x40 <= secondByte && secondByte <= 0x7E || 0x80 <= secondByte && secondByte <= 0xFC))
                    {
                        String sHex = firstByte.ToString("x") + secondByte.ToString("x");
                        int code = Convert.ToInt32(sHex, 16);
                        if (0x81AD <= code && code <= 0x81B7
                                || 0x81C0 <= code && code <= 0x81C7
                                || 0x81CF <= code && code <= 0x81D9
                                || 0x81E9 <= code && code <= 0x81EF
                                || 0x81F8 <= code && code <= 0x81FC
                                || 0x8240 <= code && code <= 0x824e
                                || 0x8259 <= code && code <= 0x825f
                                || 0x827A <= code && code <= 0x8280
                                || 0x829B <= code && code <= 0x829E
                                || 0x82F2 <= code && code <= 0x82FC
                                || 0x8397 <= code && code <= 0x839E
                                || 0x83B7 <= code && code <= 0x83BE
                                || 0x83D7 <= code && code <= 0x83FC
                                || 0x8461 <= code && code <= 0x846F
                                || 0x8492 <= code && code <= 0x849E
                                || 0x84BF <= code && code <= 0x84FC
                                || 0x8540 <= code && code <= 0x889E
                                || 0x9873 <= code && code <= 0x989E
                                || 0xEBA5 <= code && code <= 0xEBFC
                                || 0xEB40 <= code && code <= 0xEFFC)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class CNNameAttribute : Attribute
    {
        public string Name;
        public CNNameAttribute(string name)
        {
            Name = name;
        }
    }
}