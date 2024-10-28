using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


// Load configuration values
string roonCoreAppName = builder.Configuration["AppSettings:coreAppName"];
string roonCoreAppPath = builder.Configuration["AppSettings:coreAppPath"];
int roonCoreRestartDelay = int.Parse(builder.Configuration["AppSettings:coreRestartDelay"]);
string roonServerAppName = builder.Configuration["AppSettings:serverAppName"];
string roonServerAppPath = builder.Configuration["AppSettings:serverAppPath"];
int roonServerRestartDelay = int.Parse(builder.Configuration["AppSettings:serverRestartDelay"]);

// Configure Kestrel to use the port from appsettings.json
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var kestrelConfig = builder.Configuration.GetSection("Kestrel:Endpoints:Http:Url").Value;
    if (!string.IsNullOrEmpty(kestrelConfig))
    {
        serverOptions.ListenAnyIP(new Uri(kestrelConfig).Port);
    }
});

var app = builder.Build();

/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
*/



void StartApplication(string appPath)
{
    // Start the application
    Process.Start(appPath);
}

void StopApplication(string appName)
{
    // Stop the application by killing the process
    foreach (var process in Process.GetProcessesByName(appName))
    {
        process.Kill();
    }
}




// Endpoint to stop the application
app.MapGet("/stopServer", () =>
{
    StopApplication(roonServerAppName);
    //return Results.Ok("Application stopped successfully.");
    return;
});

// Endpoint to start the application
app.MapGet("/startServer", () =>
{
    StartApplication(roonServerAppPath);
    //return Results.Ok("Application started successfully.");
    return;
});

// Endpoint to restart the application
app.MapGet("/restartServer", () =>
{
    StopApplication(roonServerAppName);
    Thread.Sleep(1000 * roonServerRestartDelay);
    StartApplication(roonServerAppPath);
    //return Results.Ok("Application restarted successfully.");
    return;
});


// Endpoint to stop the application
app.MapGet("/stopCore", () =>
{
    StopApplication(roonCoreAppName);
    //return Results.Ok("Application stopped successfully.");
    return;
});

// Endpoint to start the application
app.MapGet("/startCore", () =>
{
    StartApplication(roonCoreAppPath);
    //return Results.Ok("Application started successfully.");
    return;
});

// Endpoint to restart the application
app.MapGet("/restartCore", () =>
{
    StopApplication(roonCoreAppName);
    Thread.Sleep(1000 * roonCoreRestartDelay);
    StartApplication(roonCoreAppPath);
    //return Results.Ok("Application restarted successfully.");
    return;
});



app.Run();






