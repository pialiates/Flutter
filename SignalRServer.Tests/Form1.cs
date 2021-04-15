using Microsoft.AspNetCore.SignalR.Client;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRServer.Tests
{
    public partial class Form1 : Form
    {
        private const String signalRUrl = "https://localhost:44370/deneme";
        private HubConnection connect;

        public Form1()
        {
            InitializeComponent();

            urlTB.Text = signalRUrl;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect = new HubConnectionBuilder().WithUrl(urlTB.Text)
                                                .WithAutomaticReconnect()
                                                .Build();

            connect.On<String>("Hello", hello =>
            {
                MessageBox.Show(hello);
            });

            connect.On<String>("Name", name =>
            {
                MessageBox.Show(name);
            });

            connect.StartAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.InvokeAsync("Hello");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTB.Text))
                return;

            connect.InvokeAsync("Name", nameTB.Text);
        }

        
    }
}
