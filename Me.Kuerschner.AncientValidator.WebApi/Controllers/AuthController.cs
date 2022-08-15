using Me.Kuerschner.AncientValidator.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Me.Kuerschner.AncientValidator.WebApi.Controllers
{

    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public Task<ActionResult> Auth(LoginCredentialsDto _)
        {
            return Task.FromResult<ActionResult>(Ok());
        }
    }
}