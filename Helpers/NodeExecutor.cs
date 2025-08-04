using WorkflowManagement.Models;

namespace WorkflowManagement.Helpers;

public static class NodeExecutor
{
    public static void ExecuteNode(WorkflowNode node, Trigger trigger, string username)
    {
        switch (node.Type)
        {
            case NodeType.INIT:
                node.Status = NodeStatus.Completed;
                break;

            case NodeType.CONDITION:
                if (username != "John")
                {
                    node.Status = NodeStatus.Rejected;
                    throw new Exception("Condition failed: User is not John");
                }

                node.Status = NodeStatus.Completed;
                break;

            case NodeType.MODIFY:
                trigger.Message += " Hello";
                node.Status = NodeStatus.Completed;
                break;

            case NodeType.STORE:
                node.Message =
                    $"{{ userId: '{trigger.UserId}', type: '{trigger.Type}', message: '{trigger.Message}' }}";
                node.Status = NodeStatus.Completed;
                break;

            default:
                throw new Exception($"Unsupported node type: {node.Type}");
        }
    }
}