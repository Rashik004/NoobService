using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CodeLibrary.Logger;

namespace NoobService
{
    public partial class Service1:ServiceBase
    {
        private Logger _logger;
        public Service1()
        {
            InitializeComponent();
            _logger = new Logger();
            //eventLog1 = new EventLog();
            //if (!EventLog.SourceExists("MySource"))
            //{
            //    EventLog.CreateEventSource(
            //        "MySource", "MyNewLog");
            //}
            //eventLog1.Source = "MySource";
            //eventLog1.Log = "MyNewLog";
        }

        public void OnDebug()
        {
            _logger = new Logger();
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            //eventLog1.WriteEntry("In OnStart");
            System.Timers.Timer timer = new System.Timers.Timer();
            _logger.Debug("Hello world of Logging!!!!");
            timer.Interval = 10000; // 60 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            //Logger loging = new Logger();
            timer.Start();
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Onstart.txt");
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            eventLog1.WriteEntry("Monitoring the System",EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Onstop.txt");

        }
    }
}
