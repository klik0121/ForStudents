using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public abstract class SchedulerDecorator: AbstractScheduler
    {
        protected AbstractScheduler innerScheduler;

        protected SchedulerDecorator(AbstractScheduler innerScheduler)
        {
            this.innerScheduler = innerScheduler;
        }

        public override void Execute(Guid sessionGuid, Command command)
        {
            if (innerScheduler != null)
                innerScheduler.Execute(sessionGuid, command);
            else throw new ArgumentNullException();
        }

        public AbstractScheduler Remove<T>() where T: SchedulerDecorator
        {
            if (this is T)
            {
                var instance = innerScheduler as SchedulerDecorator;
                if (instance == null)
                    return innerScheduler;
                return instance.Remove<T>();
            }
            else
            {
                var instance = innerScheduler as SchedulerDecorator;
                if (instance == null)
                    return this;
                innerScheduler = instance.Remove<T>();
                return innerScheduler;
            }
        }
    }
}
