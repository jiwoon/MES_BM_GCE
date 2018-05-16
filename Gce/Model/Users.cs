using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gce_Model
{
    public class Users
    {
        //用户名
        public string UserName { get; set; }
        //密码
        public string UserPassword { get; set; }
        //系统管理员认证
        public bool systemAdimin { get; set; }
        //权限赋予功能权限
        public bool Limite { get; set; }

        //隶属于的部门名称
        public string Department { get; set; }

        //添加用户权限
        public bool AddUser { get; set; }
    }
}
