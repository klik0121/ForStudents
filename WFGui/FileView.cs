using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerLibrary;

namespace WFGui
{
    public class FileView: IView, IDisposable
    {
        public Guid SessionGuid { get; protected set; }
        protected TextWriter tr;

        public FileView(string fileName)
        {
            tr = new StreamWriter(File.Open(fileName, FileMode.Append, FileAccess.Write)); 
        }

        public event Action<Command> CommandSubmitted;
        public void DisplayCommand(CommandEventArgs args)
        {
            tr.WriteLine(args.ToString());
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            tr.Dispose();
        }
    }
}
