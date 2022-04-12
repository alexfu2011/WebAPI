using Microsoft.AspNetCore.Mvc;
using Models;
using BLL;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public ActionResult<User> Index()
        {
            UserBLL userBLL = new UserBLL();
            var users = userBLL.GetList();
            return Content(JsonConvert.SerializeObject(users));
        }
    }
}
