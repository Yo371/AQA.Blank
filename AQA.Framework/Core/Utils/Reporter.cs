using AQA.Blank.Core.Configuration;
using Serilog;
using Serilog.Events;

namespace AQA.Blank.Core.Utils;

public static class Reporter
{
    private static readonly ILogger _logger;

    static Reporter()
    {
        _logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .ReadFrom
            .Configuration(ConfigurationManager.Configuration)
            .CreateLogger();
    }

    public static void Info(string message)
    {
        _logger.Write(LogEventLevel.Information, message);
    }

    public static void Error(string message)
    {
        _logger.Write(LogEventLevel.Error, message);
    }

    public static void Warning(string message)
    {
        _logger.Write(LogEventLevel.Warning, message);
    }
}