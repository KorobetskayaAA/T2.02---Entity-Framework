using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MurrrcatConsoleCodeFirst
{
    class ConnectionStringManager
    {
        public string ConnectionString { get; }

        public ConnectionStringManager(string connectionStringName = "DefaultConnection",
            string environmentVariableName = "DefaultConnection")
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();
            string userId = "", password = "";
            config.Providers.Any(p => p.TryGet("MurrrcatDb:UserId", out userId));
            config.Providers.Any(p => p.TryGet("MurrrcatDb:Password", out password));
            ConnectionString = string.Format(
                config.GetConnectionString(connectionStringName),
                userId, password
            ) ?? Environment.GetEnvironmentVariable(environmentVariableName);
        }
    }
}
