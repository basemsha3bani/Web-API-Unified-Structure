using Newtonsoft.Json;

namespace LinkedInWebAPI.LinkedInWebAPIClasses
{
    public class NumberOfFollwersAPIClass : BaseWebAPICaller
    {
        public NumberOfFollwersAPIClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override async Task<string> CallAPI()
        {
            _apiUrl = " https://api.linkedin.com/v2/organizationalEntityFollowerStatistics?q=organizationalEntity&organizationalEntity=90226585";
            
            this.PrepareToken();
            _apiUrl = _apiUrl + "&oauth2_access_token=" + Token;
           return await CallGetAction();
          

          
        }
    }
}
