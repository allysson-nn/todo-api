using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using todo_api.DTOs;
using todo_api.Interfaces;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();

            return Ok(tasks); // Retorna 200 OK com a lista de tarefas
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound(); // Retorna 404 Not Found se não existir
            }

            return Ok(task); // Retorna 200 OK com a tarefa encontrada
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                return BadRequest(new { message = "O título da tarefa não pode ser vazio." });
            }

            await _taskService.AddTaskAsync(dto.Title);

            return Ok(new { message = "Tarefa criada com sucesso!" });
        }

        [HttpPatch("{id}/status")] 
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var success = await _taskService.ChangeTaskStatusAsync(id);

            if (!success)
            {
                return NotFound(); // Retorna 404 se o ID não existir
            }

            return NoContent(); // Retorna 204 No Content (sucesso sem corpo de retorno)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _taskService.DeleteTaskAsync(id);

            if (!success)
            {
                return NotFound(); // Retorna 404 se o ID não existir
            }

            return NoContent(); // Retorna 204 No Content (sucesso ao deletar)

        }
    }
}
