using Microsoft.AspNetCore.SignalR.Client;

using SignalRServer.Tests.Models;

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
        private const String urlLogin = "https://aosignalr.aates.site/login";
        private const String urlmessage = "https://aosignalr.aates.site/message";

        //private const String urlmessage = "http://localhost:5000/message";
        //private const String urlLogin = "http://localhost:5000/login";

        private event EventHandler loginEvent;

        private HubConnection connectLogin;
        private HubConnection connectMessage;

        private Token token;

        public Form1()
        {
            InitializeComponent();

            loginEvent += MessageConnectionInit;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectionLoginInit();
        }

        private async void ConnectionLoginInit()
        {


            connectLogin = new HubConnectionBuilder().WithUrl(urlLogin)
                                                .Build();

            connectLogin.On<Boolean>("Create", r =>
            {
                if (r)
                    MessageBox.Show("Kayıt başarılı.");
                else
                    MessageBox.Show("Başarısız!!!");
            });

            connectLogin.On<Token>("Login", token =>
            {
                if(token != null)
                {
                    this.token = token;
                    MessageBox.Show(token.AccessToken);
                    if (token != null)
                        loginEvent?.Invoke(this, null);
                }
            });

            await connectLogin.StartAsync();
        }

        private async void MessageConnectionInit(object sender, EventArgs e)
        {
            connectMessage = new HubConnectionBuilder().WithUrl(urlmessage, options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(this.token.AccessToken);
            }).WithAutomaticReconnect().Build();

            

            connectMessage.On<string>("MessageAll", message =>
            {
                MessageBox.Show(message);
            });

            await connectMessage.StartAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            connectLogin.InvokeAsync("Login", usernameTB.Text, passwordTB.Text);
        }

        private void createButton_Click_1(object sender, EventArgs e)
        {
            connectLogin.InvokeAsync("Create", usernameTB.Text, passwordTB.Text);
        }

        private void senMessageAll_Click(object sender, EventArgs e)
        {
            connectMessage?.InvokeAsync("MessageAll", messageBox.Text);
        }
    }
}
