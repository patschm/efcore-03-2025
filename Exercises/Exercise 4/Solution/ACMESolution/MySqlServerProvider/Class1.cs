using Microsoft.EntityFrameworkCore;

namespace MySqlServerProvider;

public static class MyDatabase
{
    public static DbContextOptionsBuilder UnknownDatabase(this DbContextOptionsBuilder svcs, string consStr)
    {
        svcs.UseSqlServer(consStr);
        return svcs;
    }
}
