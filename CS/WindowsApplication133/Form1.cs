using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication133
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            for (int i = 0; i < 50; i++)
            {
                const string c = "caption";
                StringBuilder sb = new StringBuilder();
                int n = i+1;
                while(n>0){
                    sb.Append(c[n%c.Length]);
                    n /= c.Length;
                }
                dt.Columns.Add(sb.ToString());
                cGridView1.Columns.AddField(sb.ToString()).Visible = false;
            }
            cGridControl1.DataSource = dt;
            cGridView1.ColumnsCustomization();
        }
    }
}