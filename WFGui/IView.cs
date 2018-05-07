using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerLibrary;

namespace WFGui
{
    public interface IView
    {
        Guid SessionGuid { get; }


        event Action<Command> CommandSubmitted;
        void DisplayCommand(CommandEventArgs args);
    }
}
