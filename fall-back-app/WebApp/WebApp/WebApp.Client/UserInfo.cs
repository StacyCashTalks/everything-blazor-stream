namespace WebApp.Client;

public class UserInfo
{
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public required string[] Roles { get; set; }
}