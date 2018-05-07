using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public abstract class AbstractScheduler
    {
        public abstract void Execute(Guid sessionGuid, Command command);
    }
}
