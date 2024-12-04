using Microsoft.Extensions.Configuration;
using System;

namespace MembershipLookup.API.Services
{
    public class ConfigReaderService : IConfigReaderService
    {
        private readonly IConfiguration _configuration;

        public ConfigReaderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConfigValue(string keyName)
        {
            return Environment.GetEnvironmentVariable(keyName); //_configuration.GetValue<string>("ConfigurationSettings:" + keyName);
        }

        private string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("FunctionalDatabaseConn", EnvironmentVariableTarget.Process);
        }
    }
}
