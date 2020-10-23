using System.IO;
using Microsoft.Extensions.Configuration;

namespace Persistence.DatabaseContext
{
    public partial class ConnectionStrings
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
        public string GetSpecificContextConnection() => Configuration.GetConnectionString("SpecificContext");
    }
}