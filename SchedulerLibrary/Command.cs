using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public class Command
    {
        public string Name { get; protected set; }
        public string Message { get; protected set; }
        public CompletionResult Result { get; protected set; }

        public Command(string name)
        {
            Result = CompletionResult.None;
            Name = name;
        }

        public int Execute()
        {
            var rnd = new Random();
            Thread.Sleep(rnd.Next(1000, 2000));
            var exitCode = rnd.NextDouble() > .5 ? 1 : 0;
            Message = string.Format("Command completed with status: {0}.", exitCode == 1 ? "ERROR" : "SUCCESS");
            Result = exitCode == 0 ? CompletionResult.Success : CompletionResult.Error;
            return exitCode;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }


    }
}
