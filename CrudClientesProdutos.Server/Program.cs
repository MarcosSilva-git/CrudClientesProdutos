using Asp.Versioning.ApiExplorer;
using CrudClientesProdutos.Server.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer(setup =>
    {
        setup.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddInMemoryDbContext(builder.Configuration);

builder.Services.AddRepositories();
builder.Services.AddServices(builder.Configuration);

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<SwaggerConfiguration>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var version = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in version.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.ApiVersion}/swagger.json", $"API V{description.ApiVersion}");
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
