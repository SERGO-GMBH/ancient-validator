using Me.Kuerschner.AncientValidation;
using Microsoft.AspNetCore.Mvc;

namespace Me.Kuerschner.AncientValidator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Validate]
    public class BaseController : ControllerBase
    {

    }
}