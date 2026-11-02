
using Microsoft.EntityFrameworkCore;
using todo_api.Data;
using todo_api.Interfaces;
using todo_api.Services;

namespace todo_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registra o seu serviço para injeção de dependência
            builder.Services.AddScoped<ITaskService, TaskService>();

            // Adiciona o DbContext usando o SQL Server e a conexão configurada nos secrets
            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Converte automaticamente qualquer rota para letras minúsculas, poderia também trocar manualmente a rota no Controller
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
