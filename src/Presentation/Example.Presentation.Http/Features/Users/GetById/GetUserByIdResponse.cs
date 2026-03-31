namespace Example.Presentation.Http.Features.Users.GetById
{
    public sealed class GetUserByIdResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
