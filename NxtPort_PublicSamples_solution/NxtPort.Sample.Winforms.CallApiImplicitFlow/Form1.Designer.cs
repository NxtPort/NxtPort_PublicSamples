namespace NxtPort.Sample.Winforms.CallApiImplicitFlow
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.btStart = new System.Windows.Forms.Button();
            this.btEnterCredentials = new System.Windows.Forms.Button();
            this.btCallAPI = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(29, 27);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(942, 1574);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btStart.Location = new System.Drawing.Point(994, 27);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(805, 113);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btEnterCredentials
            // 
            this.btEnterCredentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btEnterCredentials.Location = new System.Drawing.Point(994, 156);
            this.btEnterCredentials.Name = "btEnterCredentials";
            this.btEnterCredentials.Size = new System.Drawing.Size(805, 109);
            this.btEnterCredentials.TabIndex = 2;
            this.btEnterCredentials.Text = "Enter Credentials";
            this.btEnterCredentials.UseVisualStyleBackColor = true;
            this.btEnterCredentials.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCallAPI
            // 
            this.btCallAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btCallAPI.Location = new System.Drawing.Point(994, 280);
            this.btCallAPI.Name = "btCallAPI";
            this.btCallAPI.Size = new System.Drawing.Size(805, 109);
            this.btCallAPI.TabIndex = 3;
            this.btCallAPI.Text = "Call API";
            this.btCallAPI.UseVisualStyleBackColor = true;
            this.btCallAPI.Click += new System.EventHandler(this.btCallAPI_Click);
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResult.Location = new System.Drawing.Point(994, 468);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(805, 1133);
            this.tbResult.TabIndex = 4;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(994, 406);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 25);
            this.lbStatus.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1826, 1626);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btCallAPI);
            this.Controls.Add(this.btEnterCredentials);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.webBrowser);
            this.Name = "Form1";
            this.Text = "NxtPort Sample : ImplicitFlow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btEnterCredentials;
        private System.Windows.Forms.Button btCallAPI;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lbStatus;
    }
}

