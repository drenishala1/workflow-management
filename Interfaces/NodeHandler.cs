using WorkflowManagement.Models;

namespace WorkflowManagement.Interfaces;

public class InitNodeHandler : INodeHandler
{
    public NodeType NodeType => NodeType.INIT;

    public void Execute(WorkflowNode node, Trigger trigger, string username)
    {
        node.Status = NodeStatus.Completed;
    }
}

public class ConditionNodeHandler : INodeHandler
{
    public NodeType NodeType => NodeType.CONDITION;

    public void Execute(WorkflowNode node, Trigger trigger, string username)
    {
        if (username != "John")
        {
            node.Status = NodeStatus.Rejected;
            throw new Exception("Condition failed: User is not John");
        }

        node.Status = NodeStatus.Completed;
    }
}

public class ModifyNodeHandler : INodeHandler
{
    public NodeType NodeType => NodeType.MODIFY;

    public void Execute(WorkflowNode node, Trigger trigger, string username)
    {
        trigger.Message += " Hello";
        node.Status = NodeStatus.Completed;
    }
}

public class StoreNodeHandler : INodeHandler
{
    public NodeType NodeType => NodeType.STORE;

    public void Execute(WorkflowNode node, Trigger trigger, string username)
    {
        node.Message =
            $"{{ userId: '{trigger.UserId}', type: '{trigger.Type}', message: '{trigger.Message}' }}";
        node.Status = NodeStatus.Completed;
    }
}
