using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NumberConverter;
using NumberConverter.Models;

namespace WindowsFormsApplicationNovember
{
    public partial class Form3 : Form
    {
        public Form3(INCService rp, User u)
        {
            InitializeComponent();
            this.client = u;
            this.remoteProxy = rp;
        }

        private User client;
        private INCService remoteProxy;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //First we empty the list
            if (tableLayoutPanel1.RowCount > 0)
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowStyles.Clear();
            }

            //Load a new list
            List<Conversion> history = remoteProxy.GetHistory(client.Id);
            tableLayoutPanel1.RowCount = history.Count;
            int row_count = 0;
            foreach (var h in history)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
                var time_label = new Label();
                time_label.Text = h.ConversionTime;
                var og_label = new Label();
                og_label.Text = h.Original;
                var conv_label = new Label();
                conv_label.Text = h.Converted;
                tableLayoutPanel1.Controls.Add(time_label, 0, row_count);
                tableLayoutPanel1.Controls.Add(og_label, 1, row_count);
                tableLayoutPanel1.Controls.Add(conv_label, 2, row_count);
                row_count++;
            }
        }
    }
}
