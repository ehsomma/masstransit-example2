using System.Reflection;
using MassTransit;
using WebApplication1.Consumers;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.




        builder.Services.AddMassTransit(busCfg =>
        {
            busCfg.AddConsumer<PersonCreatedConsumer>();
            busCfg.AddConsumer<PersonPositionCreatedConsumer>();

            // Adds all consumers in the specified assemblies.
            //var entryAssembly = Assembly.GetEntryAssembly();
            //Assembly entryAssembly = Assembly.GetAssembly(typeof(PersonCreatedConsumer));
            //busCfg.AddConsumers(entryAssembly);

            busCfg.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });




        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
