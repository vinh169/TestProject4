using Microsoft.AspNetCore.Mvc;
using TestProject.Repository;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("/api/testConnect")]
    public class TestConnectController : ControllerBase
    {
        public TestConnectionRepository connectionRepository;

        public TestConnectController(TestConnectionRepository connectionRepository)
        {
            this.connectionRepository = connectionRepository;
            //a
        }

        [HttpGet]
        public ActionResult testConnect()
        {
            return Ok(connectionRepository.TestConnection());
        }
    }
}
