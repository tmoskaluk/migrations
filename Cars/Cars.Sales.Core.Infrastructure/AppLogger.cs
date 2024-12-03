using Cars.SharedKernel;
using System;

namespace Cars.Sales.Core.Infrastructure;

public class AppLogger : IAppLogger
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public void Trace(string message)
    {
        Logger.Trace(message);
    }

    public void Debug(string message)
    {
        Logger.Debug(message);
    }

    public void Info(string message)
    {
        Logger.Info(message);
    }

    public void Warn(string message)
    {
        Logger.Warn(message);
    }

    public void Warn(Exception exception)
    {
        Warn(exception.ToString());
    }

    public void Error(string message)
    {
        Logger.Error(message);
    }

    public void Error(Exception exception)
    {
        Error(exception.ToString());
    }

    public void Fatal(string message)
    {
        Logger.Fatal(message);
    }

    public void Fatal(Exception exception)
    {
        Fatal(exception.ToString());
    }
}