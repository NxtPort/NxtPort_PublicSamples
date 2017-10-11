using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace NxtPort.Sample.Winforms.CallApiImplicitFlow
{
    public partial class Form1 : Form
    {
        private string _accessToken;

        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            webBrowser.Visible = true;

            //First make sure the session to STS is ended and that we are logged out.
            webBrowser.Url = new Uri("https://login-dev.nxtport.eu/connect/endsession");
            webBrowser.Url = new Uri("https://login-dev.nxtport.eu/logout");

            //Make the URL based on STS url, clientid, scope and redirecturi.
            //You can change the values in the Config class. Simply copy paste the from the NxtPort MarketPlace portal.
            var template = "{0}/connect/authorize?client_id={1}&response_type=token&scope={2}&redirect_uri={3}";
            var url = string.Format(template, Config.STSURL, Config.CLIENTID, Config.SCOPE, Config.REDIRECTURI);

            //Browse to the URL to start the authentication flow.
            webBrowser.Url = new Uri(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Enter username and password
            if (webBrowser.Document != null)
            {
                webBrowser.Document.InvokeScript("eval",
                    new object[] { "document.getElementById('username').value = '" + Config.DEMOUSER_USERNAME + "';" });
                webBrowser.Document.InvokeScript("eval",
                    new object[] { "document.getElementById('password').value = '" + Config.DEMOUSER_PASSWORD + "';" });
            }
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //After entering correct credentials teh browser redirects.
            if (e.Url.ToString().StartsWith("http://localhost/test.redirect#"))
            {
                var dict = e.Url.ToString().Replace("http://localhost/test.redirect#", "").Replace("?", "").Split('&')
                    .ToDictionary(x => x.Split('=')[0], x => x.Split('=')[1]);
                //You can find the access token as a value in the querystring of this redirect.
                _accessToken = dict["access_token"];
                //We got accesstoken now. Browser session is not needed anymore.
                webBrowser.Visible = false;

                MessageBox.Show(@"We got an accesstoken, now you can call the API." + Environment.NewLine + Environment.NewLine + _accessToken);
            }
        }

        private void btCallAPI_Click(object sender, EventArgs e)
        {
            try
            {
                lbStatus.Text = @"Call in progress...";

                //Create an http Client 
                var client = new HttpClient();
                
                //Add the APIkey as Ocp-Apim-Subscription-Key header
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Config.APIKEY);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                
                //Add the Accesstoken as Authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                
                //Call the Get operation.
                var response = client.GetAsync(Config.APIURL + "/vgm/v1/info?bn=33314669&cn=gesu1070100").Result;
                
                //Ensure success
                response.EnsureSuccessStatusCode();
                
                //read the result
                var result = response.Content.ReadAsStringAsync().Result;
                
                //consume the result
                tbResult.Text = result;

                //Happy
                lbStatus.Text = @"Done!";

            }
            catch (HttpRequestException exception)
            {
                tbResult.Text = exception.ToString();
            }
            catch (Exception exception)
            {
                tbResult.Text = exception.ToString();
            }
        }
    }
}