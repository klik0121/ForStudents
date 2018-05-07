using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public class BackgroundThreadScheduler: SchedulerDecorator
    {
        protected Queue<KeyValuePair<Guid, Command>> queue;
        protected Task worker;

        public BackgroundThreadScheduler(AbstractScheduler innerScheduler): base(innerScheduler)
        {
            queue = new Queue<KeyValuePair<Guid, Command>>();
        }
        public override void Execute(Guid sessionGuid, Command command)
        {
            lock (queue)
                queue.Enqueue(new KeyValuePair<Guid, Command>(sessionGuid, command));
            if (worker == null || (worker.IsCompleted || worker.IsCanceled || worker.IsFaulted))
            {
                worker = new Task(() =>
                {
                    while (queue.Count > 0)
                    {
                        KeyValuePair<Guid, Command> item;
                        lock (queue)
                            item = queue.Dequeue();
                        innerScheduler.Execute(item.Key, item.Value);
                    }
                });
                worker.Start();
            }
        }
    }
}
