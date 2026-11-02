namespace todo_api.DTOs
{
    // Data Transfer Object (DTO): Um DTO serve para transportar dados entre diferentes partes de um sistema de forma leve e segura, isolando a estrutura interna do banco de dados daquilo que é enviado para o cliente ou tela.
    public class TaskDto
    {
        public string Title { get; set; } = string.Empty;
    }
}
