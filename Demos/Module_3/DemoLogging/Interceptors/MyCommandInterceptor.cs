using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace DemoLogging.Interceptors;

public class MyCommandInterceptor : DbCommandInterceptor
{
    private Stopwatch _stopwatch = new Stopwatch();
    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        _stopwatch.Stop();
        Console.WriteLine($"Elapsed: {_stopwatch.Elapsed}");
        return base.ReaderExecuted(command, eventData, result);
    }
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        _stopwatch.Restart();

        if (command.CommandText.Contains("FROM [Core].[ProductGroups]"))
        {
            command.CommandText += "WHERE Id > 5";
        }
        return base.ReaderExecuting(command, eventData, result);
    }
}
