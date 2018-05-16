using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class TimeAttendance_Employee_File
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string ChineseName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// 员工类别
        /// </summary>
        public string EmployeeCategory { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        public string EntryDate { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DepartmentNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 组别编号
        /// </summary>
        public string GroupNo { get; set; }
        /// <summary>
        /// 组别名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 线别编号
        /// </summary>
        public string Line_No { get; set; }
        /// <summary>
        /// 线别名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNumber { get; set; }
        /// <summary>
        /// 发证机关
        /// </summary>
        public string IssuingAuthority { get; set; }
        /// <summary>
        /// 发证日期
        /// </summary>
        public string DateOfIssue { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public string IDTermOfValidity { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string BirthDay { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string PlaceOrigin { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string HomeAddress { get; set; }
        /// <summary>
        /// 考勤日期
        /// </summary>
        public string AttendanceData { get; set; }
        /// <summary>
        /// 考勤规则
        /// </summary>
        public string AttendanceRegulations { get; set; }
        /// <summary>
        /// 转正日期
        /// </summary>
        public string CompletionData { get; set; }
        /// <summary>
        /// 试用期 
        /// </summary>
        public bool ProbationPeriod { get; set; }
        /// <summary>
        /// 薪资类别
        /// </summary>
        public string SalaryCategory { get; set; }
        /// <summary>
        /// 介绍人
        /// </summary>
        public string Introducer { get; set; }
        /// <summary>
        /// 职等
        /// </summary>
        public string PositionsGrade { get; set; }
        /// <summary>
        /// 职级
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// 逻辑卡号
        /// </summary>
        public string LogicalCardNumber { get; set; }
        /// <summary>
        /// 物理卡号
        /// </summary>
        public string PhysicalCardNumber { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 紧急联系人
        /// </summary>
        public string EmergencyContact { get; set; }
        /// <summary>
        /// 紧急联系电话
        /// </summary>
        public string EmergencyContactPhone { get; set; }
        /// <summary>
        /// 紧急联系地址
        /// </summary>
        public string EmErgencyContactAddress { get; set; }
        /// <summary>
        /// 计薪方式
        /// </summary>
        public string PaymentMode { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// 左眼视力
        /// </summary>
        public string LeftEyeVision { get; set; }
        /// <summary>
        /// 右眼视力
        /// </summary>
        public string RightEyeVision { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }
        /// <summary>
        /// 合同签订
        /// </summary>
        public string ContractSigning { get; set; }
        /// <summary>
        /// 合同到期
        /// </summary>
        public string ExpirationContract { get; set; }
        /// <summary>
        /// 身份证期限
        /// </summary>
        public string IDCardPeriod { get; set; }
        /// <summary>
        /// 在职
        /// </summary>
        public bool Job { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        public string leaveDate { get; set; }
        /// <summary>
        /// 离职类别
        /// </summary>
        public string TurnoverType { get; set; }
        /// <summary>
        /// 离职原因
        /// </summary>
        public string ReasonsForLeaving { get; set; }
        /// <summary>
        /// 黑名单
        /// </summary>
        public bool Blacklist { get; set; }
        /// <summary>
        /// 已婚
        /// </summary>
        public bool married { get; set; }
        /// <summary>
        /// 免卡
        /// </summary>
        public bool FreeCard { get; set; }
        /// <summary>
        /// 加班需申请
        /// </summary>
        public bool OvertimeApplication { get; set; }
        /// <summary>
        /// 建档日期
        /// </summary>
        public string createddate { get; set; }
        /// <summary>
        /// 建档人
        /// </summary>
        public string FilingMan { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public string modificationDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string Modifier { get; set; }
        /// <summary>
        /// 工种
        /// </summary>
        public string workType { get; set; }
        /// <summary>
        /// 工种等级
        /// </summary>
        public string workGrade { get; set; }
        /// <summary>
        /// 是否上传照片
        /// </summary>
        public bool Photo { get; set; }
        /// <summary>
        /// 最小部门
        /// </summary>
        public string MinimalSector { get; set; }

    }
}
