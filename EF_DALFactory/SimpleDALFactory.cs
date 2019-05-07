using DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EF_DALFactory
{
    public class SimpleDALFactory
    {
        public static IUserInfoDAL GetUserInfoDAL()
        {
            string classFulleName = ConfigurationManager.AppSettings["DALNameSpace"] + ".UserInfoDAL";

            
            var obj = GetInstance(ConfigurationManager.AppSettings["DalAssembly"], classFulleName);


            return obj as IUserInfoDAL;
        }

        public static IRoleInfoDAL GetRoleInfoDAL()
        {
            string classFulleName = ConfigurationManager.AppSettings["DALNameSpace"] + ".RoleInfoDAL";

             

            var obj = GetInstance(ConfigurationManager.AppSettings["DalAssembly"], classFulleName);

            return obj as IRoleInfoDAL;
        }

        public static IOrderInfoDAL GetOrderInfoDAL()
        {
            string classFulleName = ConfigurationManager.AppSettings["DALNameSpace"] + ".RoleInfoDAL";



            var obj = GetInstance(ConfigurationManager.AppSettings["DalAssembly"], classFulleName);

            return obj as IOrderInfoDAL;
        }

        public static object GetInstance(string assembly, string className)
        {
            //用缓存优化
            Object obj = HttpRuntime.Cache[className + assembly];

            if (obj == null)
            {
                obj = Assembly.Load(assembly).CreateInstance(className, true);
                HttpRuntime.Cache[className + assembly] = obj;
            }

            return obj;
        }
    }
}
