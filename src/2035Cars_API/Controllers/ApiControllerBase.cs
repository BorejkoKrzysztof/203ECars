using Microsoft.AspNetCore.Mvc;

namespace MyTasks.Api.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        protected long accountId => User?.Identity?.IsAuthenticated == true ?
                    long.Parse((User.Identity.Name))
                    :
                    0;
    }
}