﻿using Microsoft.Extensions.Configuration;

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
            return _configuration.GetValue<string>("ConfigurationSettings:" + keyName);
        }
    }
}