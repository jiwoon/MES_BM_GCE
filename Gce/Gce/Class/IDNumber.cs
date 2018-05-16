using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Gce.Class
{
    public class IDNumber
    {
        private Dictionary<int,string> dicSheng=new Dictionary<int,string>(){
            {11,"北京市"},{12,"天津市"},{13,"河北省"},{14,"山西省"},{15,"内蒙古自治区"}
            ,{21,"辽宁省"},{22,"吉林省"},{23,"黑龙江省"},{31,"上海市"},{32,"江苏省"}
            ,{33,"浙江省"},{34,"安徽省"},{35,"福建省"},{36,"江西省"},{37,"山东省"}
            ,{41,"河南省"},{42,"湖北省"},{43,"湖南省"},{44,"广东省"},{45,"广西壮族自治区"}
            ,{46,"海南省"},{50,"重庆市"},{51,"四川省"},{52,"贵州省"},{53,"云南省"}
            ,{54,"西藏自治区"},{61,"陕西省"},{62,"甘肃省"},{63,"青海省"},{64,"宁夏回族自治区"}
            ,{65,"新疆维吾尔族自治区"},{71,"台湾省"},{81,"香港特别行政区"},{82,"澳门特别行政区"}
        };


        string GetGender(int Number)
        {
            if (Number % 2 == 0)
            {
                return "女";
            }
            else
            {
                return "男";
            }
        }

        public DataTable GetIDNumberText(string IDNumber)
        {
            DataTable dt = new DataTable();
            DateTime dtime;
            dt.Columns.Add("省份", typeof(string));
            dt.Columns.Add("出生日期", typeof(string));
            dt.Columns.Add("性别", typeof(string));
            try
            {
                DataRow dr = dt.NewRow();
                dr["省份"] = dicSheng[Convert.ToInt32(IDNumber.Substring(0, 2))];
                dr["出生日期"] = dtime = DateTime.ParseExact(IDNumber.Substring(6, 8), "yyyyMMdd",System.Globalization.CultureInfo.CurrentCulture);
                dr["性别"] = GetGender(Convert.ToInt32(IDNumber.Substring(IDNumber.Length - 2, 1)));

                dt.Rows.Add(dr);
            }
            catch
            {
                throw;
            }
            return dt;
        }

        string Getnumber(string IDNumber,int Begin,int count)
        {
            return IDNumber.Substring(Begin, count);
        }

    }
}
