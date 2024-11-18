using Microsoft.AspNetCore.Mvc;
using TestProject.Model;
using TestProject.Repository;
using TestProject.Repository.Interface;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("/test/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<User> users = userRepository.Get();
            return Ok(users);
        }
    }
}
