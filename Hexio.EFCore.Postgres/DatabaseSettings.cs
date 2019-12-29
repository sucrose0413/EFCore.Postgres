using System.Reflection;
using Npgsql;

namespace Hexio.EFCore.Postgres
{
    public class DatabaseSettings
    {
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool DisableSSL { get; set; }
        public int Port { get; set; } = 5432;
        public bool TrustServerCertificate { get; set; } = false;
        
        public string GetConnectionString()
        {
            var applicationName = Assembly.GetEntryAssembly().FullName;

            var connectionBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = Hostname,
                Database = Name,
                Username = Username,
                Password = Password,
                Port = Port,
                MaxPoolSize = 50,
                ApplicationName = applicationName,
                TrustServerCertificate = TrustServerCertificate,
                SslMode = DisableSSL ? SslMode.Disable : SslMode.Require,
            };

            return connectionBuilder.ConnectionString;
        }
    }
}