using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.AppSettings
{
    public class DatabaseOptions
    {
        public string MongoDBConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DebugCollection { get; set; }
        public string QueueCollection { get; set; }
        public string RegressionCollection { get; set; }
    }
}
