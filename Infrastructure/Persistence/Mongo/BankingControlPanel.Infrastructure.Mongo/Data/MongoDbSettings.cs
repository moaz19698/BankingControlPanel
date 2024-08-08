using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Infrastructure.Persistence.Mongo.Data
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
