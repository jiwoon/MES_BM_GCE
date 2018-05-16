using Gce_Model;
using Gce_Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Gce_Bll
{
    public class UsersBll
    {
        UsersDal ud = new UsersDal();
        public List<Users> UsersLoginBll(string username, string password, string SQLCommand)
        {
            return ud.UsersLoginDal(username, password, SQLCommand);
        }
        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="str">需要转换MD5的字符串</param>
        /// <returns>string</returns>
        public string GetMd5(string str)
        {
            StringBuilder sb = new StringBuilder();
            //创建一个计算MD5值对象
            using (MD5 md = MD5.Create())
            {
                //把字符串转成字节数组
                byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
                //调用该对象的方法进行MD5计算
                byte[] md5bytes = md.ComputeHash(bytes);

                for (int i = 0; i < md5bytes.Length; i++)
                {
                    sb.Append(md5bytes[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="SQLCommand">SQL命令</param>
        /// <returns>bool</returns>
        public bool checkUserNemeBll(string UserName, string SQLCommand)
        {
            if (ud.checkUserNemeDal(UserName, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool insertUsersBll(List<Users> list, string SQLCommand)
        {
            if (ud.insertUsersDal(list, SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Userpassword">密码</param>
        /// <param name="SQLCommand">SQL命令</param>
        /// <returns>bool</returns>
        public bool UpdatePasswordBll(string UserName, string Userpassword, string SQLCommand)
        {
            if (ud.UpdatePasswordDal(UserName, GetMd5(Userpassword), SQLCommand) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> selectDistinctPUsersBll(string SQLCommand)
        {
            return ud.selectDistinctPUsersDal(SQLCommand);
        }

        public List<Users> selectPUsersBll(string SQLCommand)
        {
            return ud.selectPUsersDal(SQLCommand);
        }
        /// <summary>
        /// 修改用户表权限
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Limite"></param>
        /// <param name="SQLComman"></param>
        /// <returns></returns>
        public bool updatePUsersBll(string UserName, bool Limite, string SQLComman)
        {
            if (ud.updatePUsersDal(UserName, Limite, SQLComman) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
    