using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedulerLibrary;

namespace WFGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new ClientGui();
            var view2 = new ClientGui();
            var view3 = new FileView("output.txt");
            var scheduler = new MessagingScheduler(new SimpleScheduler());
            var controller = new SessionOnlyController(scheduler);
            var controller2 = new Controller(scheduler);
            controller.AddView(view);
            controller2.AddView(view2);
            controller2.AddView(view3);
            view2.Show();
            Application.Run(view);
            view3.Dispose();
        }
    }
}
