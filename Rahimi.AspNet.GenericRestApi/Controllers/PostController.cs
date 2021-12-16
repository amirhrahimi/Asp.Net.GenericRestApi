using Microsoft.AspNetCore.Mvc;
using Rahimi.AspNet.GenericRestApi.Core.Domain;
using Rahimi.AspNet.GenericRestApi.Infrastructure.DataAccess;
using Rahimi.AspNet.GenericRestApi.Infrastructure.Generic;

namespace Rahimi.AspNet.GenericRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : GenericRestApi<Post>
    {
        public PostController(IRepository repository) : base(repository)
        {
        }
    }
}
