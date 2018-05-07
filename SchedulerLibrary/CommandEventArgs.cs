using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
    public class CommandEventArgs: EventArgs
    {
        public Guid SessionGuid { get; protected set; }
        public Command Command { get; protected set; }
        public CommandStatus Status { get; protected set; }

        public CompletionResult Result
        {
            get { return Command.Result; }
        }
        public string Message
        {
            get { return Command.Message; }
        }

        public CommandEventArgs(Guid sessionGuid, Command cmd,
            CommandStatus status)
        {
            SessionGuid = sessionGuid;
            Command = cmd;
            Status = status;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}: {2}: {3}: {4}",
                SessionGuid, Command.Name, Status, Command.Result, Command.Message);
        }

        protected bool Equals(CommandEventArgs other)
        {
            return SessionGuid.Equals(other.SessionGuid) && Equals(Command, other.Command);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CommandEventArgs) obj);
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (SessionGuid.GetHashCode()*397) ^ (Command != null ? Command.GetHashCode() : 0);
            }
        }
    }
}
