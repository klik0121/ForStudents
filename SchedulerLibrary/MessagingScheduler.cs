using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public class MessagingScheduler: SchedulerDecorator
    {
        public event EventHandler<CommandEventArgs> CommandStatusChanged;
        

        public MessagingScheduler(AbstractScheduler innerScheduler): base(innerScheduler)
        {

        }

        public override void Execute(Guid sessionGuid, Command command)
        {
            OnCommandStatusChanged(sessionGuid, command, CommandStatus.Executing);
            base.Execute(sessionGuid, command);
            OnCommandStatusChanged(sessionGuid, command, CommandStatus.Completed);
        }

        protected virtual void OnCommandStatusChanged(Guid sessionGuid, Command cmd, 
            CommandStatus status)
        {
            var e = new CommandEventArgs(sessionGuid, cmd, status);
            var handler = CommandStatusChanged;
            if (handler != null) 
                handler(this, e);
        }
    }
}
