using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IDbSession
    {
        IUserInfoDAL UserInfoDAL { get; }

        IRoleInfoDAL RoleInfoDAL { get; }

        IOrderInfoDAL OrderInfoDAL { get; }

        int SaveChange();
    }
}
