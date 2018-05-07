using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public class ConsoleMessagingScheduler: SimpleScheduler
    {
        public override void Execute(Guid sessionGuid, Command command)
        {
            base.Execute(sessionGuid, command);
            Console.WriteLine("{0}: {1}: {2}", sessionGuid, command.Name, command.Message);
        }
    }
}
