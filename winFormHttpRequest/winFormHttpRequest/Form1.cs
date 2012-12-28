using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;
using System.Collections.Specialized;


namespace winFormHttpRequest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Halfpint");
            if(! di.Exists)
                di = new DirectoryInfo(@"D:\Halfpint"); 
            
            //FileInfo fi = null;
            FileInfo[] fis = di.GetFiles();

            foreach (var fi in fis)
            {

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

                    HttpUploadFile(txtUrl.Text,
                         fi.FullName, "file", "application/msexcel", nvc);

                }

            }

        }

        private void btnFileDlg_Click(object sender, EventArgs e)
        {
            fileDlg.ShowDialog();
            txtFileName.Text = fileDlg.FileName;
        }

        private void btnSendWebClient_Click(object sender, EventArgs e)
        {
            //look for file in specified folder            
            DirectoryInfo di = new DirectoryInfo(@"C:\Halfpint");

            FileInfo fi = null;
            FileInfo[] fis = di.GetFiles();
            if (fis.Length > 0)
            {
                fi = fis[0];
                string institID = fi.Name.Substring(0, 2);
                int key = 0;
                foreach (var c in fi.Name)
                {
                    if (char.IsNumber(c))
                        key += int.Parse(c.ToString());
                }

                key *= key;
                Random rnd = new Random();
                int iRnd = rnd.Next(100000, 999999);

                string sKey = iRnd.ToString() + key.ToString();
                
                WebClient wc = new WebClient();

                wc.QueryString.Add("key", sKey);
                wc.QueryString.Add("institID", institID);
                wc.UploadFile(txtWebClientUrl.Text, "POST", fi.FullName);
                wc.Dispose();
    
            }
        }

        public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
           
            Console.WriteLine(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain,
 sslPolicyErrors) => true);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.AllowWriteStreamBuffering = true;

            wr.Method = "POST";
            //wr.KeepAlive = true;
            //wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //wr.SendChunked = true;
            //wr.ContentLength = -1;
            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

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

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                Console.WriteLine(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int rndID = rnd.Next(int.Parse(txtFrom.Text), int.Parse(txtTo.Text));
            lblRandom.Text = rndID.ToString();
        }
        
    }

}
