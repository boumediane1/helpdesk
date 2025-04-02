namespace helpdesk.Models;

public class CreateProjectRequest
{
    public string Title { get; set; }
    public string[] Usernames { get; set; }
}