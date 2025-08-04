namespace WorkflowManagement.Models;

public abstract class WorkflowContent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ContentType Type { get; set; }
}

public class TaskContent : WorkflowContent
{
    public string Title { get; set; } = string.Empty;
    public string AssigneeId { get; set; } = string.Empty;
    public string ReporterId { get; set; } = string.Empty;
    public int Order { get; set; }
    public long Time { get; set; } // Timestamp
    public Priority Priority { get; set; }
}

public class NoteContent : WorkflowContent
{
    public string Text { get; set; } = string.Empty;
}

public class AttachmentContent : WorkflowContent
{
    public string FileName { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;
}