using System.Linq;
using DemoGQL.Data;
using DemoGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace DemoGQL.GraphQL
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents users.");

            //descriptor.Field(u => u.Nick).Ignore();
            descriptor
                .Field(u => u.Posts)
                .ResolveWith<Resolvers>(u => u.GetPosts(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of users posts.");
        }
    }

    internal class Resolvers
    {
        public IQueryable<Post> GetPosts([Parent] User user, [ScopedService] AppDbContext context)  //https://chillicream.com/docs/hotchocolate/api-reference/migrate-from-11-to-12#resolvers
        {
            return context.Posts.Where(p => p.UserId == user.Id);
        }
    }
}
