using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.Threading;

namespace HalfpintUploadService
{
    public partial class HalfpintUploadService : ServiceBase
    {
        private System.Timers.Timer _timer = null;
        private EventLog _logger = null;

        public HalfpintUploadService()
        {
            InitializeComponent();
            if (!EventLog.SourceExists("Halfpint"))
            {
                EventLog.CreateEventSource(
                        "Halfpint", "Application");
            }
            _logger = new EventLog("Application");
            _logger.Source = "Halfpint";
        }

        protected override void OnStart(string[] args)
        {
            _logger.WriteEntry("OnStart", EventLogEntryType.Information);
            _timer = new System.Timers.Timer();
            _timer.Interval = 30000; //3600000;  //every hour
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Start();
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _logger.WriteEntry("Timer started", EventLogEntryType.Information);
        }
        
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _logger.WriteEntry("Timer event", EventLogEntryType.Information);
            DirectoryInfo di = new DirectoryInfo(@"C:\Halfpint\Copy");
            if (!di.Exists)
            {
                _logger.WriteEntry("The Halfpint\\Copy folder does not exist", EventLogEntryType.Information);
                return;
            }

            //FileInfo fi;
            FileInfo[] fis = di.GetFiles();
            foreach (var fi in fis)
            //if(fis.Length >0)
            {
                //fi = fis[0];
                if (fi.Name.IndexOf("copy") > -1)
                {
                    string institID = fi.Name.Substring(0, 2);

                    //formulate key
                    //add all the numbers in the file name

                    int key = 0;
                    foreach (var c in fi.Name)
                    {
                        if (char.IsNumber(c))
                            key += int.Parse(c.ToString());
                    }

                    key *= key;

                    int iInstitID = int.Parse(institID);


                    key = key * iInstitID;
                    Random rnd = new Random();
                    int iRnd = rnd.Next(100000, 999999);

                    string sKey = iRnd.ToString() + key.ToString();

                    NameValueCollection nvc = new NameValueCollection();
                    nvc.Add("institID", institID);
                    nvc.Add("key", sKey);

                    HttpUploadFile("https://halfpintstudy.org/hpProd/FileManager/ChecksUpload",
                         fi.FullName, "file", "application/msexcel", nvc);
                    

                }

            }

        }

        protected override void OnStop()
        {
            _logger.WriteEntry("OnStop", EventLogEntryType.Information);
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            _logger.WriteEntry("OnPowerEvent", EventLogEntryType.Information);
            return base.OnPowerEvent(powerStatus);
        }

        protected override void OnContinue()
        {
            _logger.WriteEntry("OnContinue", EventLogEntryType.Information);
            base.OnContinue();
        }

        protected override void OnPause()
        {
            _logger.WriteEntry("OnPause", EventLogEntryType.Information);
            base.OnPause();
        }

        protected override void OnShutdown()
        {
            _logger.WriteEntry("OnShutdown", EventLogEntryType.Information);
            base.OnShutdown();
        }

        private void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            //Console.WriteLine(string.Format("Uploading {0} to {1}", file, url));

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            //trying this
            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; }; 
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.AllowWriteStreamBuffering = true;
            wr.Method = "POST";
            //wr.KeepAlive = true;
            //wr.SendChunked = true;
            //wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            _logger.WriteEntry("HttpUploadFile fileName: " + file, EventLogEntryType.Information);

            try
            {
                _logger.WriteEntry("HttpUploadFile before GetRequestStream", EventLogEntryType.Information);
                Stream rs = wr.GetRequestStream();
                //Thread.Sleep(2000);
                _logger.WriteEntry("HttpUploadFile after GetRequestStream", EventLogEntryType.Information);
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (string key in nvc.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, nvc[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                _logger.WriteEntry("HttpUploadFile after nvc.Keys", EventLogEntryType.Information);
                
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, paramName, file, contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);

                FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();

                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();
            }
            catch (Exception e)
            {
                _logger.WriteEntry("HttpUploadFile exception: " + e.Message, EventLogEntryType.Information);
            }

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                _logger.WriteEntry("HttpUploadFile after GetResponse", EventLogEntryType.Information);
                //Console.WriteLine(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
                wresp.Close();
                wresp = null;
            }
            catch (Exception ex)
            {
                _logger.WriteEntry("HttpUploadFile error: " + ex.Message, EventLogEntryType.Information);
                //Console.WriteLine("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                throw ex;
            }
            finally
            {
                wr = null;
            }
        }
        
    }
}
