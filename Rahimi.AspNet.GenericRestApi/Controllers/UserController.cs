using Microsoft.AspNetCore.Mvc;
using Rahimi.AspNet.GenericRestApi.Core.Domain;
using Rahimi.AspNet.GenericRestApi.Infrastructure.DataAccess;
using Rahimi.AspNet.GenericRestApi.Infrastructure.Generic;

namespace Rahimi.AspNet.GenericRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericRestApi<User>
    {
        public UserController(IRepository repository) : base(repository)
        {
        }
    }
}
