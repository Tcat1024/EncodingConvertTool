using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncodingConvertTool
{
    public partial class CustomDrawCheckListBox : CheckedListBox
    {
        public CustomDrawCheckListBox()
        {
            InitializeComponent();
        }
        public event EventHandler<CustomDrawItemEventArgs> CustomDrawItem;
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if(CustomDrawItem!=null)
            {
                var temp = new CustomDrawItemEventArgs(e);
                CustomDrawItem(this,temp);
                base.OnDrawItem(new DrawItemEventArgs(temp.Graphics, temp.Font, temp.Bounds, temp.Index, temp.State,temp.ForeColor,temp.BackColor));
            }
            else
                base.OnDrawItem(e);
        }
        public class CustomDrawItemEventArgs:EventArgs
        {
            public Graphics Graphics { get; set; }
            public Font Font { get; set; }
            public Rectangle Bounds { get; set; }
            public int Index { get; set; }
            public DrawItemState State { get; set; }
            public Color ForeColor { get; set; }
            public Color BackColor { get; set; }
            public CustomDrawItemEventArgs(DrawItemEventArgs e)
            {
                this.Graphics = e.Graphics;
                this.Font = e.Font;
                this.Bounds = e.Bounds;
                this.Index = e.Index;
                this.State = e.State;
                this.ForeColor = e.ForeColor;
                this.BackColor = e.BackColor;
            }
        }
    }
}
