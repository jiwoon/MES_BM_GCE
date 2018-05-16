using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Model
{
    public class TimeAttendance_BasicShiftSchedule
    {
        /// <summary>
        /// 班次编号
        /// </summary>
        public string BasicNo { get; set; }
        /// <summary>
        /// 班次名称
        /// </summary>
        public string BasicName { get; set; }
        /// <summary>
        /// 上班1
        /// </summary>
        public DateTime GoToWork1 { get; set; }
        /// <summary>
        /// 下班1
        /// </summary>
        public DateTime GoFfoWork1 { get; set; }
        /// <summary>
        /// 上班2
        /// </summary>
        public DateTime GoToWork2 { get; set; }
        /// <summary>
        /// 下班2
        /// </summary>
        public DateTime GoFfoWork2 { get; set; }
        /// <summary>
        /// 上班3
        /// </summary>
        public DateTime GoToWork3 { get; set; }
        /// <summary>
        /// 下班3
        /// </summary>
        public DateTime GoFfoWork3 { get; set; }
        /// <summary>
        /// 上班4
        /// </summary>
        public DateTime GoToWork4 { get; set; }
        /// <summary>
        /// 下班4
        /// </summary>
        public DateTime GoFfoWork4 { get; set; }
        /// <summary>
        /// 推后分钟1
        /// </summary>
        public int PushBackMinutes1 { get; set; }
        /// <summary>
        /// 提前分钟1
        /// </summary>
        public int MinutesAheadOfTime1 { get; set; }
        /// <summary>
        /// 推后计加班1
        /// </summary>
        public bool OvertimeAfterPush1 { get; set; }
        /// <summary>
        /// 正班时数1
        /// </summary>
        public int PositiveShiftHours1 { get; set; }
        /// <summary>
        /// 加班时数1
        /// </summary>
        public int OvertimeHours1 { get; set; }
        /// <summary>
        /// 迟到分钟数1
        /// </summary>
        public int MinutesLate1 { get; set; }
        /// <summary>
        /// 早退分钟数1
        /// </summary>
        public int LeaveEarlyMinutes1 { get; set; }
        /// <summary>
        /// 提前加班1
        /// </summary>
        public bool AdvanceOvertime1 { get; set; }
        /// <summary>
        /// 扣除分钟1
        /// </summary>
        public int MinutesDeducted1 { get; set; }
        /// <summary>
        /// 补给分钟1
        /// </summary>
        public int SupplyMinutes1 { get; set; }
        /// <summary>
        /// 推后分钟2
        /// </summary>
        public int PushBackMinutes2 { get; set; }
        /// <summary>
        /// 提前分钟2
        /// </summary>
        public int MinutesAheadOfTime2 { get; set; }
        /// <summary>
        /// 退后加班2
        /// </summary>
        public bool OvertimeAfterPush2 { get; set; }
        /// <summary>
        /// 正班时数2
        /// </summary>
        public int PositiveShiftHours2 { get; set; }
        /// <summary>
        /// 加班时数2
        /// </summary>
        public int OvertimeHours2 { get; set; }
        /// <summary>
        /// 迟到分钟数2
        /// </summary>
        public int MinutesLate2 { get; set; }
        /// <summary>
        /// 早退分钟数2
        /// </summary>
        public int LeaveEarlyMinutes2 { get; set; }
        /// <summary>
        /// 提前加班2
        /// </summary>
        public bool AdvanceOvertime2 { get; set; }
        /// <summary>
        /// 扣除分钟2
        /// </summary>
        public int MinutesDeducted2 { get; set; }
        /// <summary>
        /// 补给分钟2
        /// </summary>
        public int SupplyMinutes2 { get; set; }
        /// <summary>
        /// 推后分钟3
        /// </summary>
        public int PushBackMinutes3 { get; set; }
        /// <summary>
        /// 提前分钟3
        /// </summary>
        public int MinutesAheadOfTime3 { get; set; }
        /// <summary>
        /// 退后加班3
        /// </summary>
        public bool OvertimeAfterPush3 { get; set; }
        /// <summary>
        /// 正班时数3
        /// </summary>
        public int PositiveShiftHours3 { get; set; }
        /// <summary>
        /// 加班时数3
        /// </summary>
        public int OvertimeHours3 { get; set; }
        /// <summary>
        /// 迟到分钟数3
        /// </summary>
        public int MinutesLate3 { get; set; }
        /// <summary>
        /// 早退分钟数3
        /// </summary>
        public int LeaveEarlyMinutes3 { get; set; }
        /// <summary>
        /// 提前加班3
        /// </summary>
        public bool AdvanceOvertime3 { get; set; }
        /// <summary>
        /// 扣除分钟3
        /// </summary>
        public int MinutesDeducted3 { get; set; }
        /// <summary>
        /// 补给分钟3
        /// </summary>
        public int SupplyMinutes3 { get; set; }
        /// <summary>
        /// 推后分钟4
        /// </summary>
        public int PushBackMinutes4 { get; set; }
        /// <summary>
        /// 提前分钟4
        /// </summary>
        public int MinutesAheadOfTime4 { get; set; }
        /// <summary>
        /// 退后加班4
        /// </summary>
        public bool OvertimeAfterPush4 { get; set; }
        /// <summary>
        /// 正班时数4
        /// </summary>
        public int PositiveShiftHours4 { get; set; }
        /// <summary>
        /// 加班时数4
        /// </summary>
        public int OvertimeHours4 { get; set; }
        /// <summary>
        /// 迟到分钟数4
        /// </summary>
        public int MinutesLate4 { get; set; }
        /// <summary>
        /// 早退分钟数4
        /// </summary>
        public int LeaveEarlyMinutes4 { get; set; }
        /// <summary>
        /// 提前加班4
        /// </summary>
        public bool AdvanceOvertime4 { get; set; }
        /// <summary>
        /// 扣除分钟4
        /// </summary>
        public int MinutesDeducted4 { get; set; }
        /// <summary>
        /// 补给分钟4
        /// </summary>
        public int SupplyMinutes4 { get; set; }
        /// <summary>
        /// 正班时数
        /// </summary>
        public int PositiveShiftHours { get; set; }
        /// <summary>
        /// 加班时数
        /// </summary>
        public int OvertimeHours { get; set; }
        /// <summary>
        /// 迟到超过30分钟扣半个小时工时
        /// </summary>
        public int LateDeduction { get; set; }
        /// <summary>
        /// 早退超过30分钟扣半个小时工时
        /// </summary>
        public int LeaveEarlyToDeduct { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// 建档日期
        /// </summary>
        public DateTime createdDate { get; set; }
        /// <summary>
        /// 建档人
        /// </summary>
        public string FilingMan { get; set; }
        /// <summary>
        /// 夜班
        /// </summary>
        public bool NightShift { get; set; }
        /// <summary>
        /// 智能班次
        /// </summary>
        public bool IntelligentShift { get; set; }
        /// <summary>
        /// 自动累计加班
        /// </summary>
        public bool AutomaticOvertime { get; set; }
        /// <summary>
        /// 下班1与上班2最大间隔
        /// </summary>
        public int GoToWork1AndGoFfoWork2 { get; set; }
        /// <summary>
        /// 下班2与上班3最大间隔
        /// </summary>
        public int GoToWork2AndGoFfoWork3 { get; set; }
        /// <summary>
        /// 下班3与上班4最大间隔
        /// </summary>
        public int GoToWork3AndGoFfoWork4 { get; set; }
    }
}
