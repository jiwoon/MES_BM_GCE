using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class TimeAttendance_Department
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DepartmentNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 上级部门编号
        /// </summary>
        public string ParentDepartmentNo { get; set; }
        /// <summary>
        /// 上级部门名称
        /// </summary>
        public string ParentDepartmentName { get; set; }
        /// <summary>
        /// 编制人数
        /// </summary>
        public int NumberOfStaff { get; set; }
        /// <summary>
        /// 在编人数
        /// </summary>
        public int InTheNumberOfStaff { get; set; }
        /// <summary>
        /// 超编人数
        /// </summary>
        public int ExceedNumberOfStaff { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
