using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
namespace Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class LoginController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        public LoginController(IUserLogic IUserLogic) => _userLogic = IUserLogic;

        /// <summary>
        ///  Gets the authentication token
        /// </summary>
        /// <param name="user"> Email and Password</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetToken(UserViewModel user)
        {
            var response = await _userLogic.CreateTokenAsync(user);
            return response.Item1 == null ? BadRequest(response.Item2) : Ok(response.Item1);
        }
    }
}