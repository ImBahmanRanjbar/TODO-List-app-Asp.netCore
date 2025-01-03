# TODO-List-app-Asp.netCore
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>About the App</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
</head>
<body>
    <div class="container mt-5">
        <h1>About the App</h1>
        <p>This is a web-based To-Do List application built using ASP.NET Core. The application allows users to manage their tasks efficiently by categorizing them, setting due dates, and updating their status. The interface is user-friendly, providing options to filter tasks based on category, due date, and status. Users can add new tasks, mark tasks as completed, and delete completed tasks.</p>
        
        <h2>Features</h2>
        <ul>
            <li><strong>Task Management</strong>: Add, view, and manage tasks with descriptions, categories, due dates, and statuses.</li>
            <li><strong>Filtering</strong>: Filter tasks by category, due date (future, past, today), and status (open, closed).</li>
            <li><strong>Status Update</strong>: Mark tasks as completed.</li>
            <li><strong>Deletion</strong>: Delete completed tasks.</li>
            <li><strong>User Interface</strong>: Simple and intuitive interface for easy task management.</li>
        </ul>
        
        <h2>How to Use</h2>
        <ol>
            <li><strong>Add a New Task</strong>:
                <ul>
                    <li>Click on the "Add new task" button.</li>
                    <li>Fill in the task description, select a category, set a due date, and choose a status.</li>
                    <li>Click "Add" to save the task.</li>
                </ul>
            </li>
            <li><strong>Filter Tasks</strong>:
                <ul>
                    <li>Use the dropdown menus to filter tasks by category, due date, and status.</li>
                    <li>Click "Filter" to apply the filters or "Clear" to reset them.</li>
                </ul>
            </li>
            <li><strong>Mark Task as Completed</strong>:
                <ul>
                    <li>Click the "Mark Completed" button next to an open task to update its status to closed.</li>
                </ul>
            </li>
            <li><strong>Delete Completed Tasks</strong>:
                <ul>
                    <li>Click the "Delete completed tasks" button to remove all tasks marked as closed.</li>
                </ul>
            </li>
        </ol>
        
        <h2>Code Overview</h2>
        <p><strong>Models</strong></p>
        <ul>
            <li><strong>Filters.cs</strong>: Handles the filtering logic for tasks based on category, due date, and status.</li>
            <li><strong>TODO.cs</strong>: Represents the task entity with properties for description, category, due date, and status.</li>
        </ul>
        
        <p><strong>Controllers</strong></p>
        <ul>
            <li><strong>HomeController.cs</strong>: Manages the main operations of the application, including displaying tasks, adding new tasks, filtering tasks, marking tasks as completed, and deleting completed tasks.</li>
        </ul>
    </div>
</body>
</html>
