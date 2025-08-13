using WorkflowManagement.Interfaces;
using WorkflowManagement.Models;

namespace WorkflowManagement.Helpers;

public class NodeExecutor
{
    private readonly Dictionary<NodeType, INodeHandler> _handlers;

    public NodeExecutor(IEnumerable<INodeHandler> handlers)
    {
        _handlers = handlers.ToDictionary(h => h.NodeType, h => h);
    }

    public void ExecuteNode(WorkflowNode node, Trigger trigger, string username)
    {
        if (_handlers.TryGetValue(node.Type, out var handler))
        {
            handler.Execute(node, trigger, username);
        }
        else
        {
            throw new Exception($"No handler registered for node type: {node.Type}");
        }
    }
}
