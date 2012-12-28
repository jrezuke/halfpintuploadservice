namespace winFormHttpRequest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnFileDlg = new System.Windows.Forms.Button();
            this.fileDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnSendWebClient = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblRandom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWebClientUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(368, 69);
            this.btnSendRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(101, 19);
            this.btnSendRequest.TabIndex = 0;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(6, 69);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(319, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://halfpintstudy.org/hpTest/FileManager/ChecksUpload";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter a file name (with path):";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(148, 7);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(177, 20);
            this.txtFileName.TabIndex = 4;
            // 
            // btnFileDlg
            // 
            this.btnFileDlg.Location = new System.Drawing.Point(329, 6);
            this.btnFileDlg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFileDlg.Name = "btnFileDlg";
            this.btnFileDlg.Size = new System.Drawing.Size(22, 19);
            this.btnFileDlg.TabIndex = 5;
            this.btnFileDlg.Text = "...";
            this.btnFileDlg.UseVisualStyleBackColor = true;
            this.btnFileDlg.Click += new System.EventHandler(this.btnFileDlg_Click);
            // 
            // btnSendWebClient
            // 
            this.btnSendWebClient.Location = new System.Drawing.Point(368, 119);
            this.btnSendWebClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendWebClient.Name = "btnSendWebClient";
            this.btnSendWebClient.Size = new System.Drawing.Size(110, 19);
            this.btnSendWebClient.TabIndex = 6;
            this.btnSendWebClient.Text = "Send WebClient";
            this.btnSendWebClient.UseVisualStyleBackColor = true;
            this.btnSendWebClient.Click += new System.EventHandler(this.btnSendWebClient_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Generate random number from ";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(171, 170);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(65, 20);
            this.txtFrom.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "to";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(295, 170);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(65, 20);
            this.txtTo.TabIndex = 10;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 206);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblRandom
            // 
            this.lblRandom.AutoSize = true;
            this.lblRandom.Location = new System.Drawing.Point(112, 215);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(35, 13);
            this.lblRandom.TabIndex = 12;
            this.lblRandom.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Enter url:";
            // 
            // txtWebClientUrl
            // 
            this.txtWebClientUrl.Location = new System.Drawing.Point(6, 118);
            this.txtWebClientUrl.Margin = new System.Windows.Forms.Padding(2);
            this.txtWebClientUrl.Name = "txtWebClientUrl";
            this.txtWebClientUrl.Size = new System.Drawing.Size(319, 20);
            this.txtWebClientUrl.TabIndex = 13;
            this.txtWebClientUrl.Text = "http://localhost/hpMvc/FileManager/ChecksWCUpload";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 370);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWebClientUrl);
            this.Controls.Add(this.lblRandom);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSendWebClient);
            this.Controls.Add(this.btnFileDlg);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnSendRequest);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnFileDlg;
        private System.Windows.Forms.OpenFileDialog fileDlg;
        private System.Windows.Forms.Button btnSendWebClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblRandom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWebClientUrl;
    }
}

