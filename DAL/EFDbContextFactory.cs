using EF_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EF_DAL
{
    public class EFDbContextFactory
    {
        public static DbContext GetEFSpringContext()
        {
            DbContext context = CallContext.GetData("EFDbContextFactory") as DataModelContainer; //new OAEntityContainer();
            if (context == null)
            {
                context = new DataModelContainer();
                CallContext.SetData("EFDbContextFactory", context);
            }
            return context;
        }
    }
}
