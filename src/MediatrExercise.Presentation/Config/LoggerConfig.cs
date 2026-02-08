using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace MediatrExercise.Presentation.Config;

public static class LoggerConfig
{
    public static Logger CreateLogger()
    {
        var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Server.Kestrel", LogEventLevel.Warning)
            .WriteTo.Async(a =>
                a.Console(
                    outputTemplate:
                    "[{TraceId}]-[{Timestamp:HH:mm:ss}]-[{Level:u3}]-[{SourceContext}]: {Message:lj}{NewLine}{Exception}"))
            .Enrich.FromLogContext()
            .CreateLogger();
        return logger;
    }
}