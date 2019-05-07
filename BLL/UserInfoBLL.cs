using EF_DALFactory;
using EF_Model;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserInfoBLL:BaseBLL<UserInfo>
    {
        //private IUserInfoDAL dal = SimpleDALFactory.GetUserInfoDAL();

        //private DbSession dbSession = new DbSession();
        private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();
        private IUserInfoDAL dal;
        public UserInfoBLL()
        {
            dal = dbSession.UserInfoDAL;
        }

        public UserInfo AddUser(UserInfo user)
        {
            UserInfo userR = new UserInfo();
            userR=dal.Add(user);
            userR=dal.Update(user);
            dbSession.SaveChange();
            return userR;
        }
    }
}
