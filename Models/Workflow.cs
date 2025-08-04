namespace WorkflowManagement.Models;

public class Workflow
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
    public List<Role> ReadRoles { get; set; } = new();
    public List<Role> WriteRoles { get; set; } = new();
    public List<WorkflowNode> Nodes { get; set; } = new();
    public List<WorkflowContent> Contents { get; set; } = new();
}
