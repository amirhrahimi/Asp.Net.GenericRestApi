using System.Collections.Generic;

namespace Rahimi.AspNet.GenericRestApi.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Post> Posts { get; set; }

    }
}
