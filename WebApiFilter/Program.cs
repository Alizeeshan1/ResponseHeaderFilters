
using Microsoft.AspNetCore.Diagnostics;
using WebApiFilter.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IActionResponseTimeStopwatch, ActionResponseTimeStopwatch>();
builder.Services.AddScoped<OtherFilters>();

/*Filter*/
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ResponseTimeFilter());
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*error manage*/
app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
    .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new { details = "An error occurred" };
    await context.Response.WriteAsJsonAsync(response);
}));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
