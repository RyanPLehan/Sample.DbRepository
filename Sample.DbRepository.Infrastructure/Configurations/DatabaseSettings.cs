using System;


namespace Sample.DbRepository.Infrastructure.Configurations
{
    public sealed class DatabaseSettings
    {
        public string Path { get; set; } = Directory.GetCurrentDirectory();
        public string DatabaseName { get; set; } = "Chinook.db";
    }
}
