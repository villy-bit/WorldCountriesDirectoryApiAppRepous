using Microsoft.AspNetCore.Mvc;
using WorldCountriesDirectoryApiApp.Api.Messages;

namespace WorldCountriesDirectoryApiApp.Api.Controllers
{
    // RootController - 
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet]
        public StringMessage Root()
        {
            return new StringMessage(Message: "server is running");
        }

        [HttpGet("ping")]
        public StringMessage Ping()
        {
            return new StringMessage(Message: "pong");
        }
    }
}
