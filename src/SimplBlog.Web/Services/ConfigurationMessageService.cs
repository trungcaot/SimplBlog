using SimplBlog.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SimplBlog.Web.Services
{
    public class ConfigurationMessageService : IMessageService
    {
        public IConfiguration _configuration { get; set; }

        public ConfigurationMessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessage()
        {
            return _configuration["Message"];
        }
    }
}
