using Microsoft.EntityFrameworkCore;
using todo_api.Data;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        // Injetando o AppDbContext para ter acesso ao banco de dados
        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> AddTaskAsync(string title)
        {
            var task = new TaskItem
            {
                Title = title,
                Complete = false
            };

            _context.Tasks.Add(task); // Prepara o objeto em memória (síncrono)

            await _context.SaveChangesAsync(); // Salva no banco de dados de fato (assíncrono)
            return task;
        }

        public async Task<bool> ChangeTaskStatusAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return false;
            }

            task.Complete = !task.Complete; // Inverte o status atual (se era false vira true, se era true vira false)
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return false;
            }

            _context.Tasks.Remove(task);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
