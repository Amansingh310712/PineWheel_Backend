using PineWheel_Project.Handlers;
using PineWheel_Project.Repositories;
using PineWheel_Project.Helpers;


namespace Shape
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSingleton<DbHelper>(); // Register DbConnection

            // Register the repository
            builder.Services.AddScoped<IPineWheelRepository, PineWheelRepository>(); // Register IRepository and its implementation

            // Register handlers
            builder.Services.AddScoped<PagesHandler>();
            builder.Services.AddScoped<HighlightsHandler>();
            builder.Services.AddScoped<ReviewsHandler>();
            builder.Services.AddScoped<LabelsHandler>();
            builder.Services.AddScoped<MenuHandler>();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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