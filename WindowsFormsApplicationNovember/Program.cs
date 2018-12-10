using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

using NumberConverter;
using NumberConverter.Models;


namespace WindowsFormsApplicationNovember
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ChannelFactory<INCService> remoteFactory = new ChannelFactory<INCService>("NCConfig");
            INCService remoteProxy = remoteFactory.CreateChannel();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(remoteProxy));
        }
    }
}
