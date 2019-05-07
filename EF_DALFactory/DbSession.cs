using EF_DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DALFactory
{
    public class DbSession:IDbSession
    {
        //封装了所有的数据库访问层的DAL：实现了DbSession是整个数据库访问层的统一入口
        private IUserInfoDAL _userInfoDAL;
        public IUserInfoDAL UserInfoDAL
        {
            get {
                if (_userInfoDAL==null)
                {
                    _userInfoDAL = SimpleDALFactory.GetUserInfoDAL();
                }
                return _userInfoDAL;
            }
        }

        private IRoleInfoDAL _roleInfoDAL;
        public IRoleInfoDAL RoleInfoDAL
        {
            get {
                if (_roleInfoDAL==null)
                {
                    _roleInfoDAL = SimpleDALFactory.GetRoleInfoDAL();
                }
                return _roleInfoDAL;
            }
        }

        private IOrderInfoDAL _orderInfoDAL;
        public IOrderInfoDAL OrderInfoDAL
        {
            get {
                if (_orderInfoDAL==null)
                {
                    _orderInfoDAL = SimpleDALFactory.GetOrderInfoDAL();
                }
                return _orderInfoDAL;
            }
        }

        public int SaveChange()
        {
            return EFDbContextFactory.GetEFSpringContext().SaveChanges();
        }
    }
}
