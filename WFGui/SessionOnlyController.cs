using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerLibrary;

namespace WFGui
{
    public class SessionOnlyController: Controller
    {
        public SessionOnlyController(MessagingScheduler scheduler): base(scheduler)
        {

        }

        public override void Notify(object o, CommandEventArgs e)
        {
            foreach(var view in Views)
                if(view.SessionGuid.Equals(e.SessionGuid))
                    view.DisplayCommand(e);
        }
    }
}
