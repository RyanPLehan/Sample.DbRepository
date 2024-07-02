using System;
using System.Reflection;


namespace Sample.DbRepository.Infrastructure.Configurations
{
    public sealed class DatabaseSettings
    {
        public static string CONFIGURATION_SECTION = "Database";
        public string Path { get; set; } = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public string DatabaseName { get; set; } = "Chinook.db";
    }
}
