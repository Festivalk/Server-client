using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
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
            Application.Run(new Form1());
        }
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
        var forms = new List<Form>(){
            new Form1(),
            new Form1(),
            new Form1()
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
