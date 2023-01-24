using LinkedInWebAPI.LinkedInWebAPIClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LinkedInWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;


        public HomeController(IConfiguration config)
        {
            _config = config;


        }


        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        [Route("GetUserInformation")]
        public async Task<IActionResult> GetUserInformation(
            //[FromBody] AuthenticationInfo authenticationInfo
            )
        {
            APIFactory _userIdWebAPIFactory;
            _userIdWebAPIFactory = this.apiFactory(APITypeEnum.LoginAPIF);
            IServiceProvider serviceProvider = _userIdWebAPIFactory.CreateServices();
            using (var scope = serviceProvider.CreateScope())
            {
                GetUserIdWebAPICaller userIdWebAPICaller = scope.ServiceProvider.GetService<GetUserIdWebAPICaller>();
                
                return await this.ReturnAPIResults(userIdWebAPICaller);
            }
        }


        [HttpPost]
        [Route("OrganizationFollowerCount")]
        public async Task<IActionResult> OrganizationFollowerCount(
          //[FromBody] AuthenticationInfo authenticationInfo
          )
        {

            APIFactory _numberOfFollwersAPIFactory;
            _numberOfFollwersAPIFactory = this.apiFactory(APITypeEnum.NumberOfFollwersAPI);
           
            IServiceProvider serviceProvider = _numberOfFollwersAPIFactory.CreateServices();
            using (var scope = serviceProvider.CreateScope())
            {
                NumberOfFollwersAPIClass NumberOfFollwersAPICaller = scope.ServiceProvider.GetService<NumberOfFollwersAPIClass>();
                return await this.ReturnAPIResults(NumberOfFollwersAPICaller);
            }

        }
        private APIFactory apiFactory(APITypeEnum aPITypeEnum)
        {
            switch (aPITypeEnum)
            {
                case APITypeEnum.LoginAPIF:

                return new LoginAPIFactory();
                    

                case APITypeEnum.NumberOfFollwersAPI:

                    return new NumberOfFollwersAPIFactory();
                default:
                    return new LoginAPIFactory();
            }
        }

        async Task<IActionResult> ReturnAPIResults(BaseWebAPICaller APICaller)
        {
            string result = await APICaller.CallAPI();
            if (APICaller.StatusCode != System.Net.HttpStatusCode.OK)
                return new ContentResult { StatusCode = (int)APICaller.StatusCode };


            return Ok(result);
        }

    }
 
}
