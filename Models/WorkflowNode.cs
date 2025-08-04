namespace WorkflowManagement.Models;

public class WorkflowNode
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public NodeType Type { get; set; }
    public NodeStatus Status { get; set; } = NodeStatus.Pending;
    public string? Message { get; set; }
}