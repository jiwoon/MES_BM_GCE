using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class PAbnormalInput
    {
         
        //订单号 
        public string ZhiDan { get; set; }
        //录入人员
        public string SchoolPersonnel { get; set; }
        //公司名称
        public string CompanyName { get; set; }
        //产线名称
        public string LineOf { get; set; }
        //工站
        public string WorkStation { get; set; }

        //异常类型
        public string ExceptionTypes { get; set; }

        //问题描述
        public string ProblemDescription { get; set; }

        //备注
        public string Node1 { get; set; }

        //id
        public int ID { get; set; }
    }
}
