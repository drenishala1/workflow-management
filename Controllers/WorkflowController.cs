using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkflowManagement.DTOs;
using WorkflowManagement.Models;
using WorkflowManagement.Services;

namespace WorkflowManagement.Controllers;

[ApiController]
[Route("api/workflows")]
[Authorize]
public class WorkflowController(WorkflowService workflowService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateWorkflow([FromBody] Workflow workflow)
    {
        var created = workflowService.CreateWorkflow(workflow);
        return Ok(created);
    }

    [HttpPost("{id}/execute")]
    public IActionResult ExecuteWorkflow(Guid id, [FromBody] Trigger trigger)
    {
        var username = User.Identity?.Name ?? string.Empty;
        var executed = workflowService.ExecuteWorkflow(id, trigger, username);
        return Ok(executed);
    }

    [HttpPost("{id}/content")]
    public IActionResult AddContent(Guid id, [FromBody] WorkflowContentRequest contentRequest)
    {
        var updated = workflowService.AddContent(id, contentRequest);
        return Ok(updated);
    }

    [HttpGet]
    public IActionResult GetWorkflows()
    {
        var roles = User.FindFirst(ClaimTypes.Role)?.Value.Split(',').ToList() ?? new List<string>();
        var workflows = workflowService.GetWorkflowsForUser(roles);
        return Ok(workflows);
    }

    [HttpGet("{id}/content")]
    public IActionResult GetWorkflowContent(Guid id)
    {
        var roles = User.FindFirst(ClaimTypes.Role)?.Value.Split(',').ToList() ?? new List<string>();
        var content = workflowService.GetWorkflowContent(id, roles);
        return Ok(content);
    }

}