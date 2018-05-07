using System;
using System.CodeDom;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchedulerLibrary;
using TaskFactory = SchedulerLibrary.TaskFactory;

namespace Tests
{
    [TestClass]
    public class SchedulerTests
    {
        [TestMethod]
        public void TestSimpleScheduler()
        {
            var scheduler = new SimpleScheduler();
            var guid = Guid.NewGuid();
            foreach (var command in TaskFactory.Parse("Cmd1 Cmd2 Cmd3"))
                scheduler.Execute(guid, command);
        }

        [TestMethod]
        public void TestConsoleMessagingScheduler()
        {
            var scheduler = new ConsoleMessagingScheduler();
            var guid = Guid.NewGuid();
            foreach (var command in TaskFactory.Parse("Cmd1 Cmd2 Cmd3"))
                scheduler.Execute(guid, command);
        }

        [TestMethod]
        public void TestMessagingScheduler()
        {
            AbstractScheduler scheduler = new SimpleScheduler();
            var messagingScheduler = new MessagingScheduler(scheduler);
            messagingScheduler.CommandStatusChanged += (sender, args) => Console.WriteLine(args);
            var guid = Guid.NewGuid();
            foreach (var command in TaskFactory.Parse("Cmd1 Cmd2 Cmd3"))
                messagingScheduler.Execute(guid, command);
            scheduler = messagingScheduler.Remove<MessagingScheduler>();
            foreach (var command in TaskFactory.Parse("Cmd1 Cmd2 Cmd3"))
                scheduler.Execute(guid, command);
        }

        [TestMethod]
        public void TestBackgroundScheduler()
        {
            var scheduler = new SimpleScheduler();
            var messagingScheduler =  new MessagingScheduler(scheduler);
            messagingScheduler.CommandStatusChanged += (sender, args) => 
                Console.WriteLine(args);
            var backgroundScheduler = new BackgroundThreadScheduler(messagingScheduler);
            var thread1 = new Task(() =>
            {
                var guid = Guid.NewGuid();
                foreach (var command in TaskFactory.Parse("Cmd1 Cmd2 Cmd3"))
                    backgroundScheduler.Execute(guid, command);
            });
            var thread2 = new Task(() =>
            {
                var guid = Guid.NewGuid();
                foreach (var command in TaskFactory.Parse("Cmd4 Cmd5 Cmd6"))
                    backgroundScheduler.Execute(guid, command);
            });
            thread1.Start();
            thread2.Start();
            thread1.Wait();
            thread2.Wait();
            Thread.Sleep(10000);
        }
    }
}
