namespace DemoGQL.GraphQL.Mutations
{
    public record AddPostInput(string Title, string Description, int UserId);
}