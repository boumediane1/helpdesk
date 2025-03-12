namespace helpdesk.Models;

public class UserResponse
{
    public long Id { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; } 
    public Role Role { get; set; } 
}