using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NumberConverter;
using NumberConverter.Models;

namespace WindowsFormsApplicationNovember
{
    public partial class Form1 : Form
    {
        public Form1(INCService rp)
        {
            InitializeComponent();
            this.remoteProxy = rp;
        }
        
        private INCService remoteProxy;

        private void Form1_Load(object sender, EventArgs e)
        {
            string savedToken = File.ReadAllText("Token.txt");

            int userId = remoteProxy.GetUserByToken(savedToken).Result;
            if (userId > -1)
            {
                User u = remoteProxy.GetUserData(userId).Result;
                Hide();
                Form2 LOGIN = new Form2(remoteProxy, u);
                LOGIN.ShowDialog();
                Close();
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            label4.Visible = true;
            label4.Text = "Logging in...";
            progressBar1.Visible = true;

            IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });

            User u = null;
            bool success = false;
            await Task.Run(() =>
            {
                progress.Report(33);
                int userId = remoteProxy.GetUser(username, password).Result;
                progress.Report(66);

                if (userId > -1)
                {
                    progress.Report(99);
                    u = remoteProxy.GetUserData(userId).Result;

                    success = true;
                }
            });

            if (success)
            {
                Hide();
                Form2 LOGIN = new Form2(remoteProxy, u);
                LOGIN.ShowDialog();
                Close();
            }
            else
            {
                //Show error message
                label3.Visible = true;
                progress.Report(0);
            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            label4.Visible = true;
            label4.Text = "Registration...";
            progressBar1.Visible = true;

            IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });

            User u = null;
            bool success = false;
            await Task.Run(() =>
            {
                progress.Report(33);
                int userId = remoteProxy.RegisterUser(username, password).Result;
                progress.Report(66);

                if (userId > -1)
                {
                    progress.Report(99);
                    u = remoteProxy.GetUserData(userId).Result;
                    
                    success = true;
                }
            });

            if (success)
            {
                Hide();
                Form2 LOGIN = new Form2(remoteProxy, u);
                LOGIN.ShowDialog();
                Close();
            }
            else
            {
                //Show error message
                label3.Visible = true;
                progress.Report(0);
            }
        }
    }
}
