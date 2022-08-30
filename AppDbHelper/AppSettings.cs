using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextHelper
{
    public interface IAppSettings
    {
        public string GetConnectstring();
    }

    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectstring()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
