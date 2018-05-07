using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedulerLibrary;

namespace WFGui
{
    public partial class ClientGui : Form, IView
    {
        public Guid SessionGuid { get; protected set; }
        protected int commandCounter;
        protected BindingList<CommandEventArgs> list; 

        public ClientGui()
        {
            InitializeComponent();
            SessionGuid = Guid.NewGuid();
            commandCounter = 0;
            list = new BindingList<CommandEventArgs>();
            commands.DataSource = list;
        }

        public event Action<Command> CommandSubmitted;
        public void DisplayCommand(CommandEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if (!list.Contains(args))
                        list.Add(args);
                    else
                        list[list.IndexOf(args)] = args;
                }));
            }
            else
            {
                if (!list.Contains(args))
                    list.Add(args);
                else
                    list[list.IndexOf(args)] = args;
            }
        }
        private void CreateNewCommand(object sender, EventArgs e)
        {
            commandCounter++;
            var handler = CommandSubmitted;
            if(handler != null)
                handler(new Command(string.Format("Cmd{0}", commandCounter)));
        }
    }
}
