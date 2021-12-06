using DemoGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace DemoGQL.GraphQL.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public User OnUserAdded([EventMessage] User user) => user;

        [Subscribe]
        [Topic]
        public Post OnPostAdded([EventMessage] Post post) => post;
    }
}
