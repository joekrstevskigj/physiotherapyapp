
namespace API
{
    using API.Data;
    using API.Interfaces.Data;
    using API.Interfaces.Repositories;
    using API.Interfaces.Services;
    using API.Repositories;
    using API.Services;

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

            builder.Services.AddSingleton<IApplicationData, ApplicationData>();

            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
            builder.Services.AddScoped<IHeadsetDataRepository, HeadsetDataRepository>();

            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IExercisesService, ExercisesService>();
            builder.Services.AddScoped<IHeadsetService, HeadsetDataService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
