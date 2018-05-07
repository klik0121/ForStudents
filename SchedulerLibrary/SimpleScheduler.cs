using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public class SimpleScheduler: AbstractScheduler
    {
        public override void Execute(Guid sessionGuid, Command command)
        {
            //meaningfull code here

            command.Execute();
        }
    }
}
