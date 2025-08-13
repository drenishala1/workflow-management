using WorkflowManagement.Data;
using WorkflowManagement.DTOs;
using WorkflowManagement.Helpers;
using WorkflowManagement.Models;
using WorkflowManagement.Repositories;

namespace WorkflowManagement.Services;

public class WorkflowService(WorkflowRepository repository, NodeExecutor executor)
{
    public Workflow CreateWorkflow(Workflow workflow)
    {
        if (workflow.Nodes.Count == 0 || workflow.Nodes[0].Type != NodeType.INIT)
            throw new Exception("Workflow must start with INIT node");

        if (!workflow.ReadRoles.Any())
            workflow.ReadRoles = new List<Role> { AuthSeed.Roles.First(r => r.Name == "All") };

        if (!workflow.WriteRoles.Any())
            workflow.WriteRoles = new List<Role> { AuthSeed.Roles.First(r => r.Name == "Admin") };

        repository.Add(workflow);
        return workflow;
    }

    public Workflow ExecuteWorkflow(Guid workflowId, Trigger trigger, string username)
    {
        var workflow = repository.GetById(workflowId) ?? throw new Exception("Workflow not found");

        foreach (var node in workflow.Nodes.Where(n => n.Status != NodeStatus.Completed))
        {
            node.Status = NodeStatus.InProgress;
            executor.ExecuteNode(node, trigger, username);
        }

        return workflow;
    }

    public Workflow AddContent(Guid workflowId, WorkflowContentRequest contentRequest)
    {
        var workflow = repository.GetById(workflowId) ?? throw new Exception("Workflow not found");
        var content = ContentFactory.CreateContent(contentRequest);
        workflow.Contents.Add(content);
        return workflow;
    }

    public List<Workflow> GetWorkflowsForUser(List<string> userRoles) =>
        repository.GetAll()
            .Where(w =>
                w.ReadRoles.Any(rr => rr.Name == "All" || userRoles.Contains(rr.Name)) ||
                w.WriteRoles.Any(wr => userRoles.Contains(wr.Name)))
            .ToList();

    public List<WorkflowContent> GetWorkflowContent(Guid workflowId, List<string> userRoles)
    {
        var workflow = repository.GetById(workflowId) ?? throw new Exception("Workflow not found");

        var hasReadAccess = workflow.ReadRoles.Any(rr => rr.Name == "All" || userRoles.Contains(rr.Name)) ||
                            workflow.WriteRoles.Any(wr => userRoles.Contains(wr.Name));

        if (!hasReadAccess) throw new UnauthorizedAccessException("You do not have read access");

        return workflow.Contents;
    }
}
