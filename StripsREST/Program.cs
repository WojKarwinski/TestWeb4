using StripsBL.Interfaces;
using StripsBL.Managers;
using StripsDL.Repositories;

namespace StripsREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\SQLExpress;Initial Catalog=Strips;Integrated Security=True ;Integrated Security=True"; ;
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IStripsRepository, StripsRepository>(provider => new StripsRepository(connectionString));
            builder.Services.AddScoped<StripsManager>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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