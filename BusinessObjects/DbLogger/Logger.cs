using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DbLogger
{
    public class Logger : System.Data.Entity.DbConfiguration
    {
        public Logger()
        {
            this.AddInterceptor(new DbInterceptor());
        }
    }
}
