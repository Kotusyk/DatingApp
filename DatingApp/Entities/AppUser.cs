namespace DatingApp.Entities;

public record AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
}
