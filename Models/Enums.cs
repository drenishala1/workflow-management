namespace WorkflowManagement.Models;

public enum NodeType
{
    INIT,
    CONDITION,
    MODIFY,
    STORE
}

public enum NodeStatus
{
    Pending,
    InProgress,
    Completed,
    Rejected
}

public enum ContentType
{
    Task,
    Note,
    Attachment
}

public enum Priority
{
    LOW,
    MEDIUM,
    HIGH
}
