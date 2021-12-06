using System.Linq;
using DemoGQL.Data;
using DemoGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace DemoGQL.GraphQL
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Description("Represents post");

            descriptor
                .Field(p => p.User)
                .ResolveWith<Resolvers>(p => p.GetUser(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the user to whom the post belong");
        }

        private class Resolvers
        {
            public User GetUser([Parent] Post post, [ScopedService] AppDbContext context)
            {
                return context.Users.FirstOrDefault(u => u.Id == post.UserId);
            }
        }
    }
}
