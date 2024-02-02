
namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var AllowOrigins = "_allowOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();            

            builder.Services.AddSingleton<IList<Todo>>(sp => new List<Todo>()
            {
                new Todo(1, "Exécuter le déboguage"),
                new Todo(2, "Test Cloture Todo")
            });
            builder.Services.AddScoped<ITodoRepository, FakeTodoService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(AllowOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}
