using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EF_DALFactory
{
    public class DbSessionFactory
    {
        /// <summary>
        /// 线程内实例唯一
        /// </summary>
        /// <returns></returns>
        public static IDbSession GetCurrentDbSession()
        {
            DbSession dbSession = CallContext.GetData("DbSessionFactory") as DbSession;
            if (dbSession==null)
            {
                dbSession = new DbSession();
                CallContext.SetData("DbSessionFactory",dbSession);
            }
            return dbSession;
        }
    }
}
