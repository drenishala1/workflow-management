using WorkflowManagement.Data;
using WorkflowManagement.Models;

namespace WorkflowManagement.Repositories;

public class WorkflowRepository
{
    private readonly List<Workflow> _workflows = WorkflowSeed.GetWorkflows();

    public List<Workflow> GetAll() => _workflows;

    public Workflow? GetById(Guid id) =>
        _workflows.FirstOrDefault(w => w.Id == id);

    public void Add(Workflow workflow) =>
        _workflows.Add(workflow);
}