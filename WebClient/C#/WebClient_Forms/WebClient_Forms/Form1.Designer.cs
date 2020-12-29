
namespace WebClient_Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxTemperature = new System.Windows.Forms.TextBox();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.textBoxHumidity = new System.Windows.Forms.TextBox();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxIpAddress = new System.Windows.Forms.TextBox();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTemperature
            // 
            this.textBoxTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTemperature.Location = new System.Drawing.Point(116, 19);
            this.textBoxTemperature.Name = "textBoxTemperature";
            this.textBoxTemperature.ReadOnly = true;
            this.textBoxTemperature.Size = new System.Drawing.Size(61, 26);
            this.textBoxTemperature.TabIndex = 0;
            this.textBoxTemperature.Text = "-";
            this.textBoxTemperature.TextChanged += new System.EventHandler(this.textBoxTemperature_TextChanged);
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTemperature.Location = new System.Drawing.Point(6, 22);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(104, 20);
            this.labelTemperature.TabIndex = 1;
            this.labelTemperature.Text = "Temperature:";
            this.labelTemperature.Click += new System.EventHandler(this.labelTemperature_Click);
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelHumidity.Location = new System.Drawing.Point(6, 54);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(74, 20);
            this.labelHumidity.TabIndex = 2;
            this.labelHumidity.Text = "Humidity:";
            this.labelHumidity.Click += new System.EventHandler(this.labelHumidity_Click);
            // 
            // textBoxHumidity
            // 
            this.textBoxHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxHumidity.Location = new System.Drawing.Point(116, 51);
            this.textBoxHumidity.Name = "textBoxHumidity";
            this.textBoxHumidity.ReadOnly = true;
            this.textBoxHumidity.Size = new System.Drawing.Size(61, 26);
            this.textBoxHumidity.TabIndex = 3;
            this.textBoxHumidity.Text = "-";
            this.textBoxHumidity.TextChanged += new System.EventHandler(this.textBoxHumidity_TextChanged);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelTemperature);
            this.groupBoxInfo.Controls.Add(this.textBoxHumidity);
            this.groupBoxInfo.Controls.Add(this.textBoxTemperature);
            this.groupBoxInfo.Controls.Add(this.labelHumidity);
            this.groupBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 49);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(196, 91);
            this.groupBoxInfo.TabIndex = 4;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(12, 158);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(196, 50);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxIpAddress
            // 
            this.textBoxIpAddress.Location = new System.Drawing.Point(12, 10);
            this.textBoxIpAddress.Name = "textBoxIpAddress";
            this.textBoxIpAddress.Size = new System.Drawing.Size(196, 26);
            this.textBoxIpAddress.TabIndex = 7;
            this.textBoxIpAddress.Text = "http://xx.xx.xx.xx/info";
            this.textBoxIpAddress.TextChanged += new System.EventHandler(this.textBoxIpAddress_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(224, 225);
            this.Controls.Add(this.textBoxIpAddress);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.groupBoxInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "WebClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTemperature;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.TextBox textBoxHumidity;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxIpAddress;
    }
}

