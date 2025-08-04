using WorkflowManagement.Models;

namespace WorkflowManagement.DTOs;

public class WorkflowContentRequest
{
    public ContentType Type { get; set; }

    public string? Title { get; set; }
    public string? AssigneeId { get; set; }
    public string? ReporterId { get; set; }
    public int? Order { get; set; }
    public long? Time { get; set; }
    public Priority? Priority { get; set; }

    public string? Text { get; set; }

    public string? FileName { get; set; }
    public string? FileUrl { get; set; }
}