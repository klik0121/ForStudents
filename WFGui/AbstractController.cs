using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerLibrary;

namespace WFGui
{
    public abstract class AbstractController
    {
        public abstract List<IView> Views { get; set; } 

        public abstract void Notify(object o, CommandEventArgs e);
        public abstract void AddView(IView view);
    }
}
