using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace InsurancePolicyManagementDBA.Utility
{
    static class DbConnUtil
    {
        static IConfiguration _iConfiguration;
        static DbConnUtil()
        {
            GetAppSettingFile();
        }

        private static void GetAppSettingFile()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");
            _iConfiguration = builder.Build();

        }
        public static string GetConnectionString()
        {
            return _iConfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
