using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Public
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyapplicationContext());
        }
    }
    class MyapplicationContext : ApplicationContext
    {
        private void onFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }
        public MyapplicationContext()
        {
            for (int i = 1; i <= 5; i++)
            {
                new Server().auto_run(i);
            }
            var forms = new List<Form>(){
            new Clients(),
            //new Clients(),
            new Server(),
            //new Form1()
        };
            foreach (var form in forms)
            {
                form.FormClosed += onFormClosed;
            }
            foreach (var form in forms)
            {
                form.Show();
            }
        }
    }
}
