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
    public class RoleInfoBLL:BaseBLL<RoleInfo>
    {
        private IRoleInfoDAL dal = SimpleDALFactory.GetRoleInfoDAL();

        public RoleInfo AddRole(RoleInfo role)
        {
            return dal.Add(role);
        }
    }
}
