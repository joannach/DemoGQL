using System.Linq;
using DemoGQL.Data;
using DemoGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace DemoGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        // [UseProjection]   //through the children (Startup); since I defined Types it's not need anymore
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context)  // service lifetime once per client request
        {
            return context.Users;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts([ScopedService] AppDbContext context)
        {
            return context.Posts;
        }
    }
}
