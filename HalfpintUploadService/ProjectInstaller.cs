using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace HalfpintUploadService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        
        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            var sc = new ServiceController();
            sc.ServiceName = serviceInstaller1.ServiceName;

            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);

                
            }
        }
    }
}
