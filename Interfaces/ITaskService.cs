using todo_api.Models;

namespace todo_api.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<TaskItem> AddTaskAsync(string title);
        Task<bool> ChangeTaskStatusAsync(int id);
        Task<bool> DeleteTaskAsync(int id);
    }
}
