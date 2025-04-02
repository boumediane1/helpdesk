namespace helpdesk.Models;

public class ProjectResponse
{
    public string Title { get; set; }
    public List<UserResponse> Users { get; set; }

    public static ProjectResponse From(Project project)
    {
        return new ProjectResponse
        {
            Title = project.Title,
            Users = UserResponse.From(project.Users)
        };
    }
}