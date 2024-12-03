using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Sales.Core.Infrastructure;

public static class MigrationExtensions
{
    /// <summary>
    /// Builds an Microsoft.EntityFrameworkCore.Migrations.Operations.SqlOperation to execute SQL from embedded resource script file
    /// with the same name as the migration with added _Up.sql or _Down.sql postfix
    /// </summary>
    public static void ExecuteSqlEmbeddedResourceScript<T>(this MigrationBuilder migrationBuilder, MigrationType type) where T : Migration
    {
        var migrationId = typeof(T).GetCustomAttribute<MigrationAttribute>()?.Id;
        var embeddedResourcePath = $"{typeof(T).Namespace}.{migrationId}_{type}.sql";

        string sql;
        var stream = typeof(T).Assembly.GetManifestResourceStream(embeddedResourcePath);
        using (var reader = new StreamReader(stream, Encoding.UTF8)) sql = reader.ReadToEnd();

        migrationBuilder.Sql(sql);
    }
}

public enum MigrationType
{
    Up,
    Down
}