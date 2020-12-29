using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using System.Threading.Tasks;
// Visual Studio -> View -> Other Windows -> Package Manager Console -> "Install-Package Newtonsoft.Json"
using Newtonsoft.Json;


namespace WebClient_Forms
{
    public partial class Form1 : Form
    {
        public string URL = ""; // Example: http://xx.xx.xx.xx/info

        public Form1()
        {
            InitializeComponent();
        }

        public static async Task<dynamic> createRequest(string url)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(url);
            dynamic json = JsonConvert.DeserializeObject(result);
            return json;
        }

        private void Form1_Load(object sender, EventArgs e) {}
        private void labelTemperature_Click(object sender, EventArgs e) {}
        private void textBoxTemperature_TextChanged(object sender, EventArgs e) {}
        private void labelHumidity_Click(object sender, EventArgs e) {}
        private void textBoxHumidity_TextChanged(object sender, EventArgs e) {}
        private void textBoxIpAddress_TextChanged(object sender, EventArgs e) {}

        private async void buttonRefresh_Click(object sender, EventArgs e) 
        {

            if(String.IsNullOrEmpty(textBoxIpAddress.Text))
            {
                MessageBox.Show("Invalid Address: is Null or Empty", "Error", MessageBoxButtons.OK);
                return;
            }

            URL = textBoxIpAddress.Text.Trim();

            buttonRefresh.Text = "Refreshing...";
            buttonRefresh.Enabled = false;
            textBoxTemperature.Enabled = false;
            textBoxHumidity.Enabled = false;
            textBoxIpAddress.Enabled = false;

            try
            {
                dynamic response = await createRequest(URL);

                textBoxTemperature.Text = response.temperature;
                textBoxHumidity.Text = response.humidity;
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }

            textBoxTemperature.Enabled = true;
            textBoxHumidity.Enabled = true;
            textBoxIpAddress.Enabled = true;

            buttonRefresh.Enabled = true;
            buttonRefresh.Text = "Refresh";
        }
    }
}
