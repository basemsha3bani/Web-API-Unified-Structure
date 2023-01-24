using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace LinkedInWebAPI.LinkedInWebAPIClasses
{
    public class GetUserIdWebAPICaller : BaseWebAPICaller
    {
        public GetUserIdWebAPICaller(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override async Task<string> CallAPI()
        {
            _apiUrl = "https://api.linkedin.com/v2/me";
           
            this.PrepareToken();
           _apiUrl = _apiUrl + "?oauth2_access_token=" + Token;
            string responseData = await CallGetAction();

            dynamic rsponseAsDynamic=JsonConvert.DeserializeObject(responseData);
            string localizedLastName = rsponseAsDynamic.localizedLastName;

            return responseData;
        }


    }
}
