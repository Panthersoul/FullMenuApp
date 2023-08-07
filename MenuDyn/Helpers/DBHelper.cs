using Microsoft.Extensions.Configuration;

namespace MenuDyn.Helpers
{
    public class DBHelper
    {
        public string getDBConn() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:false);
            IConfiguration configuration = builder.Build();
            string connString = configuration.GetValue<string>("ConnectionStrings:DBMenu");
            return connString;
        }
    }
}
