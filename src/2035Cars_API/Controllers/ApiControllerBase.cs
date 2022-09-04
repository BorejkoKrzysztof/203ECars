using Microsoft.AspNetCore.Mvc;

namespace MyTasks.Api.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        protected Guid accountId => User?.Identity?.IsAuthenticated == true ?
                    Guid.Parse(User.Identity.Name)
                    :
                    Guid.Empty;
    }
}