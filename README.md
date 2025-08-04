# 🚀 Workflow Management Tool (ASP.NET Core)

A backend application built with **ASP.NET Core** that implements:

- **JWT Authentication** with Role-based Access Control
- **Workflow Execution Engine** with Node Types (`INIT`, `CONDITION`, `MODIFY`, `STORE`)
- **Content Management** for Tasks, Notes, and Attachments
- **Pre-seeded Users, Roles, and Workflows**
- **Role-based Permissions** for Read/Write access

---

## 📂 **Project Structure**

- **Controllers/ → API endpoints**
- **Services/ → Business logic (Auth, Workflow execution)**
- **Repositories/ → In-memory storage**
- **Data/ → Seed data (Users, Roles, Workflows)**
- **Models/ → Entities (Workflow, User, Node, Content, Role)**
- **Helpers/ → Node execution & content creation helpers**
- **Program.cs → App entry point (JWT, Swagger, etc.)**

---

## 🛠 **Implementation Details**

### **Authentication**

- Uses JWT tokens with role claims
- Login with `/api/authenticate` using username/email + password
- Token includes roles for role-based access control

### **Workflow Engine**

- Workflows contain sequential **Nodes**
- Node Types:
    - `INIT` → Marks start of workflow
    - `CONDITION` → Checks if user is `"John"`
    - `MODIFY` → Appends `"Hello"` to the incoming message
    - `STORE` → Stores final user message
- Node Status transitions: `Pending → InProgress → Completed/Rejected`

### **Content**

- Workflows can have:
    - `Task` → Title, Assignee, Reporter, Priority
    - `Note` → Text
    - `Attachment` → File URL
- All validated before adding

### **Roles & Access**

- Predefined Roles: `Admin`, `Analyst`, `CategoryManager`, `Public`, `Basic`, `All`
- Read/Write permissions defined at Workflow level
- Write includes implicit read permission

---

