using Domain.Entities.User;


namespace Application.DTO
{
    public class GenerateTokenDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Roles Role { get; set; }
    }
}
