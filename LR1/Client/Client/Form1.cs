using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("x", textBox1.Text),
                new KeyValuePair<string, string>("y", textBox2.Text),
            });
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44304/");
            HttpResponseMessage response = await client.PostAsync("ADD4", stringContent);
            textBox3.Text = await response.Content.ReadAsStringAsync();
        }
    }
}
