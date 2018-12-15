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

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            int userId = remoteProxy.GetUser(username, password).Result;

            if (userId > -1)
            {
                User u = remoteProxy.GetUserData(userId).Result;
                Hide();
                Form2 LOGIN = new Form2(remoteProxy, u);
                LOGIN.ShowDialog();
                Close();
            }
            else
            {
                //Show error message
                label3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            int userId = remoteProxy.RegisterUser(username, password).Result;

            if (userId > -1)
            {
                User u = remoteProxy.GetUserData(userId).Result;
                Hide();
                Form2 LOGIN = new Form2(remoteProxy, u);
                LOGIN.ShowDialog();
                Close();
            }
            else
            {
                //Show error message
                label3.Visible = true;
            }
        }
    }
}
