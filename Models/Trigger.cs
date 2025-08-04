namespace WorkflowManagement.Models;

public class Trigger
{
    public string UserId { get; set; } = string.Empty;
    public string Type { get; set; } = "user-message";
    public string Message { get; set; } = string.Empty;
}