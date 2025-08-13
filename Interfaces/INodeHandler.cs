using WorkflowManagement.Models;

namespace WorkflowManagement.Interfaces;

public interface INodeHandler
{
    NodeType NodeType { get; }
    void Execute(WorkflowNode node, Trigger trigger, string username); 
}