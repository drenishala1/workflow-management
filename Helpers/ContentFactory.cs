using WorkflowManagement.DTOs;
using WorkflowManagement.Models;

namespace WorkflowManagement.Helpers;

public static class ContentFactory
{
    public static WorkflowContent CreateContent(WorkflowContentRequest req)
    {
        return req.Type switch
        {
            ContentType.Task => CreateTask(req),
            ContentType.Note => CreateNote(req),
            ContentType.Attachment => CreateAttachment(req),
            _ => throw new Exception("Unsupported content type")
        };
    }

    private static TaskContent CreateTask(WorkflowContentRequest req)
    {
        if (string.IsNullOrEmpty(req.Title) ||
            string.IsNullOrEmpty(req.AssigneeId) ||
            string.IsNullOrEmpty(req.ReporterId) ||
            !req.Order.HasValue ||
            !req.Time.HasValue ||
            !req.Priority.HasValue)
            throw new Exception("Invalid Task fields");

        return new TaskContent
        {
            Type = ContentType.Task,
            Title = req.Title!,
            AssigneeId = req.AssigneeId!,
            ReporterId = req.ReporterId!,
            Order = req.Order.Value,
            Time = req.Time.Value,
            Priority = req.Priority.Value
        };
    }

    private static NoteContent CreateNote(WorkflowContentRequest req)
    {
        if (string.IsNullOrEmpty(req.Text))
            throw new Exception("Note text is required");

        return new NoteContent
        {
            Type = ContentType.Note,
            Text = req.Text!
        };
    }

    private static AttachmentContent CreateAttachment(WorkflowContentRequest req)
    {
        if (string.IsNullOrEmpty(req.FileName) || string.IsNullOrEmpty(req.FileUrl))
            throw new Exception("Attachment file name and URL required");

        return new AttachmentContent
        {
            Type = ContentType.Attachment,
            FileName = req.FileName!,
            FileUrl = req.FileUrl!
        };
    }
}