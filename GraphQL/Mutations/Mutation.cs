using System.Threading;
using System.Threading.Tasks;
using DemoGQL.Data;
using DemoGQL.GraphQL.Subscriptions;
using DemoGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace DemoGQL.GraphQL.Mutations
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddUserPayload> AddUserAsync(AddUserInput input, [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Nick = input.Nick
            };

            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnUserAdded), user, cancellationToken);
            return new AddUserPayload(user);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPostPayload> AddPostAsync(AddPostInput input, [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Title = input.Title,
                Description = input.Description,
                UserId = input.UserId
            };

            context.Posts.Add(post);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPostAdded), post, cancellationToken);

            return new AddPostPayload(post);  
        }
    }
}
