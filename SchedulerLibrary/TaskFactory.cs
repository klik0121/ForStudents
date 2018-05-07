using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public static class TaskFactory
    {
        public static Command[] Parse(IEnumerable<string> commands)
        {
            return commands.Select(c => new Command(c)).ToArray();
        }

        public static Command[] Parse(string commandSequence)
        {
            return Parse(commandSequence.Split(new []{" "},
                StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
