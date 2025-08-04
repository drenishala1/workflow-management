using WorkflowManagement.Models;

namespace WorkflowManagement.Data;

public static class AuthSeed
{
    public static List<Role> Roles = new()
    {
        new Role { Name = "Admin" },
        new Role { Name = "Analyst" },
        new Role { Name = "CategoryManager" },
        new Role { Name = "Public" },
        new Role { Name = "Basic" },
        new Role { Name = "All" }
    };

    public static List<User> Users = new()
    {
        new User
        {
            Username = "John",
            Email = "john@example.com",
            Password = "12345",
            Roles = new List<Role> { Roles.First(r => r.Name == "Admin") }
        },
        new User
        {
            Username = "Jane",
            Email = "jane@example.com",
            Password = "12345",
            Roles = new List<Role> { Roles.First(r => r.Name == "Analyst") }
        },
        new User
        {
            Username = "Mark",
            Email = "mark@example.com",
            Password = "12345",
            Roles = new List<Role> { Roles.First(r => r.Name == "Basic") }
        }
    };
}