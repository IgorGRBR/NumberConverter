using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NumberConverter;
using NumberConverter.Models;

namespace WindowsFormsApplicationNovember
{
    public partial class Form2 : Form
    {
        public Form2(INCService rp, User u)
        {
            InitializeComponent();
            this.client = u;
            this.remoteProxy = rp;
        }

        private User client;
        private INCService remoteProxy;

        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = client.Name;

            //Save user token to a file
            using (StreamWriter writer = new StreamWriter("Token.txt"))
            {
                writer.Write(client.CurrentToken);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 HISTORY = new Form3(remoteProxy, client);
            HISTORY.ShowDialog();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (input != String.Empty)
            {
                int num = Int32.Parse(input);
                if (input == num.ToString()) //Check if it is a number
                {
                    Conversion result = null; 
                    IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });
                    await Task.Run(() =>
                    {
                        progress.Report(33);
                        int convId = remoteProxy.ConvertNumber(num, client.Id).Result;
                        progress.Report(66);
                        result = remoteProxy.GetConversion(convId).Result;
                        progress.Report(100);
                    });
                    textBox2.Text = result.Converted;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            this.client = null;

            //Remove access token from file
            using (StreamWriter writer = new StreamWriter("Token.txt"))
            {
                writer.Write(String.Empty);
            }

            Form1 LOGIN = new Form1(remoteProxy);
            LOGIN.ShowDialog();
            Close();
        }
    }
}
