using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace DemoGQL.Models
{
    [GraphQLDescription("Represents users.")]
    public class User
    {
        [Key]
        [GraphQLDescription("Represents user id.")]
        public int Id { get; set; }

        [GraphQLDescription("Represents user name.")]
        public string Name { get; set; }

        [Required]
        [GraphQLDescription("Represents user nick.")]
        public string Nick { get; set; }

        [GraphQLDescription("Represents users posts.")]
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
