using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace LinkedInWebAPI.LinkedInWebAPIClasses
{
    /*https://www.linkedin.com/developers/apps/verification/f4f2eb6f-553e-4d13-ba6c-db01b3cd991d*/
    public abstract class BaseWebAPICaller
    {

        protected IConfiguration _configuration;
        public Dictionary<string, string> Params { get; set; }
        protected void PrepareToken()
        {

            Token = _configuration.GetSection("LinkedInCredentials").GetSection("token").Value;

        }
       protected async Task<string> CallGetAction()
        {
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri(_apiUrl);

            HttpResponseMessage response = await client.GetAsync(_apiUrl);

            this.StatusCode = response.StatusCode;

            string responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        protected string _apiUrl = "";
        protected string Token = "";
       


        public abstract Task<string> CallAPI();
        
        public HttpStatusCode StatusCode { get; internal set; }
    }
}
