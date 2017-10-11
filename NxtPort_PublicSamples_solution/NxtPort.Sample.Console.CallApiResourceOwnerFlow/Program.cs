using System.Net.Http;
using System.Net.Http.Headers;
using IdentityModel.Client;

namespace NxtPort.Sample.Console.CallApiResourceOwnerFlow
{
    internal class Program
    {
        private static string _accessToken;

        private static void Main(string[] args)
        {
            //Create TokenClient with URL, ClientID and ClientSecret.
            var tokenClient = new TokenClient(
                Config.STSURL + "/connect/token",
                Config.CLIENTID,
                Config.CLIENTSECRET);

            //Ask response for ResourceOwner Flow with UserName,Password and Scope.
            var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync(
                Config.DEMOUSER_USERNAME, Config.DEMOUSER_PASSWORD, Config.SCOPE).Result;

            //We got the accesstoken.
            _accessToken = tokenResponse.AccessToken;

            System.Console.WriteLine("AccessToken : ");
            System.Console.WriteLine(_accessToken);
            System.Console.WriteLine("");


            //Create an http Client. 
            var client = new HttpClient();

            //Add the APIkey as Ocp-Apim-Subscription-Key header.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Config.APIKEY);

            //Set accept header to receive json.
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            //Add the Accesstoken as Authorization header.
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            //Call the Get operation.
            System.Console.WriteLine("API call busy ...");
            var response = client.GetAsync(Config.APIURL + "/vgm/v1/info?bn=33314669&cn=gesu1070100").Result;

            //Ensure success.
            response.EnsureSuccessStatusCode();

            //Read the result.
            var result = response.Content.ReadAsStringAsync().Result;

            //Consume the result.
            System.Console.WriteLine("");
            System.Console.WriteLine("Result :");
            System.Console.WriteLine(result);

            System.Console.ReadKey();
        }
    }
}