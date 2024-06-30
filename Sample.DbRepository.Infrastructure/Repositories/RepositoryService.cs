using System;


namespace Sample.DbRepository.Infrastructure.Repositories
{
    internal static class RepositoryService
    {
        public static string CreateDeleteSql(string tableName, string columnName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(tableName, nameof(tableName));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(columnName, nameof(columnName));

            const string parameter = "{0}";
            return $"DELETE FROM {tableName} WHERE {columnName} IN ({parameter})";
        }
    }
}
