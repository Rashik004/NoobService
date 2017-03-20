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
    public partial class Service1 : ServiceBase
    {
        private Logger _logger;

        public Service1()
        {
            InitializeComponent();
            _logger = new Logger();
        }

        public void OnDebug()
        {
            _logger = new Logger();
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            _logger.Debug("Hello world of Logging!!!!");
            timer.Interval = 30000; // 60 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Onstart.txt");
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            _logger.Debug("service timer logging");
        }

        protected override void OnStop()
        {
            _logger.Fatal("service has been stopped!!!!!!");
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Onstop.txt");
            _logger.Fatal("service has been stopped again!!!!!!");

        }
    }
}
