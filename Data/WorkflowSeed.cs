using WorkflowManagement.Models;

namespace WorkflowManagement.Data;

public static class WorkflowSeed
{
    public static List<Workflow> GetWorkflows() => new()
    {
        new Workflow
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Finance Workflow",
            Description = "Handles finance approvals",
            CreatedAt = DateTime.UtcNow.ToString(),
            ReadRoles = new List<Role>
            {
                AuthSeed.Roles.First(r => r.Name == "Analyst"), AuthSeed.Roles.First(r => r.Name == "CategoryManager")
            },
            WriteRoles = new List<Role> { AuthSeed.Roles.First(r => r.Name == "Admin") },
            Nodes = new List<WorkflowNode> { new WorkflowNode { Type = NodeType.INIT } }
        },
        new Workflow
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Public Workflow",
            Description = "Open to everyone",
            CreatedAt = DateTime.UtcNow.ToString(),
            ReadRoles = new List<Role> { AuthSeed.Roles.First(r => r.Name == "All") },
            WriteRoles = new List<Role>
                { AuthSeed.Roles.First(r => r.Name == "Public"), AuthSeed.Roles.First(r => r.Name == "Admin") },
            Nodes = new List<WorkflowNode> { new WorkflowNode { Type = NodeType.INIT } }
        }
    };
}