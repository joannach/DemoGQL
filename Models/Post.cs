using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace DemoGQL.Models
{
    [GraphQLDescription("Represents user name.")]
    public class Post
    {
        [Key]
        [GraphQLDescription("Represents post id.")]
        public int Id { get; set; }

        [Required]
        [GraphQLDescription("Represents post title.")]
        public string Title { get; set; }

        [GraphQLDescription("Represents post description.")]
        public string Description{ get; set; }

        [Required]
        [GraphQLDescription("Represents user id that created this post.")]
        public int UserId { get; set; }

        [GraphQLDescription("Represents user that created this post.")]
        public User User { get; set; }
    }
}
