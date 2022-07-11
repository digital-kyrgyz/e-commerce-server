using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    internal static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager _configurationManager = new();
                _configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/API"));
                _configurationManager.AddJsonFile("appsettings.json");
                return _configurationManager.GetConnectionString("AppDbContext");
            }
        }
    }
}
