using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gce_Dal;

namespace Gce_Bll
{
    public class LOrderMessageBll
    {
        LOrderMessageDal lomd = new LOrderMessageDal();
        public int selectSumZhiDanNumberBll(string strOrder, string SQLCommand)
        {
            string str = lomd.selectSumZhiDanNumberDal(strOrder, SQLCommand);
            if (str != "")
            {
                int i = str.IndexOf("@@");
                int j = str.IndexOf("}}");

                return Convert.ToInt32(str.Substring(i + 2, j - i - 2));
            }
            else
            {
                return 0;
            }
        }
    }
}
