using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.Security.Principal;
using NumberConverter;
using System.Windows.Forms;

namespace NCServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            if (program.IsCurrentlyRunningAsAdmin())
                program.RunServer();
            else
                MessageBox.Show("Administrator priviliges are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RunServer()
        {
            using (ServiceHost host = new ServiceHost(typeof(NCService)))
            {
                host.Open();
                Console.WriteLine("Server started!");

                Console.WriteLine("Press enter to stop the server.");

                Console.ReadLine();
                host.Close();
            }
        }
        private bool IsCurrentlyRunningAsAdmin()
        {
            bool isAdmin = false;
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            if (currentIdentity != null)
            {
                WindowsPrincipal pricipal = new WindowsPrincipal(currentIdentity);
                isAdmin = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
                pricipal = null;
            }
            return isAdmin;
        }
    }
}
