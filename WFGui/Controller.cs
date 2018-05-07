using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerLibrary;

namespace WFGui
{
    public class Controller: AbstractController
    {
        protected List<IView> views;
        protected MessagingScheduler messaging;
        protected BackgroundThreadScheduler background;

        public override List<IView> Views
        {
            get { return views; }
            set { views = value; }
        } 

        public Controller(MessagingScheduler scheduler)
        {
            messaging = scheduler;
            messaging.CommandStatusChanged += Notify;
            background = new BackgroundThreadScheduler(messaging);
            views = new List<IView>();
        }

        public override void Notify(object o, CommandEventArgs e)
        {
            foreach(var view in views)
                view.DisplayCommand(e);
        }

        public override void AddView(IView view)
        {
            view.CommandSubmitted += command =>
                background.Execute(view.SessionGuid, command);
            views.Add(view);
        }
    }
}
