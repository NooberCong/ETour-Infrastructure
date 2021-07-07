using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InfrasUtils
{
    public static class HostHelper
    {
        public static string ClientHostUrl()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                return "etour-client.azurewebsites.net";
            } else
            {
                return "localhost:44323";
            }
        }

        public static string CompanyHostUrl()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                return "etour-company.azurewebsites.net";
            }
            else
            {
                return "localhost:44360";
            }
        }
    }
}
