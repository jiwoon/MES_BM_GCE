using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gce_Common
{
    public static class AttendanceMachineHelp
    {
        //public static List<TimeAttendance_AttendanceSchedule> GetUserData(zkemkeeper.CZKEMClass axCZKEM1,string txtiMachineNumber, bool bIsConnected, string txtIP, string MachinePosition)
        //{            
        //    List<TimeAttendance_AttendanceSchedule> DataList = new List<TimeAttendance_AttendanceSchedule>();

        //    string sdwEnrollNumber = "";
        //    int idwTMachineNumber = 0;
        //    int idwEMachineNumber = 0;
        //    int idwVerifyMode = 0;
        //    int idwInOutMode = 0;
        //    int idwYear = 0;
        //    int idwMonth = 0;
        //    int idwDay = 0;
        //    int idwHour = 0;
        //    int idwMinute = 0;
        //    int idwSecond = 0;
        //    int idwWorkcode = 0;
        //    int idwErrorCode = 0;
        //    int iGLCount = 0;
        //    int iIndex = 0;
        //    string name = "";
        //    string password = "";
        //    int privilege = 0;
        //    bool enble = true;
        //    int iMachineNumber = int.Parse(txtiMachineNumber);
        //    if (bIsConnected == true)
        //    {
        //        axCZKEM1.EnableDevice(iMachineNumber, false);//设置为工作模式
        //        if (axCZKEM1.ReadGeneralLogData(Convert.ToInt32(iMachineNumber)) && axCZKEM1.ReadAllUserID(Convert.ToInt32(iMachineNumber)))//read all the attendance records to the memory
        //        {
        //            //int i = 0;
        //            while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
        //                       out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
        //            {
        //                string UserID = sdwEnrollNumber;
        //                iMachineNumber = int.Parse(txtiMachineNumber);
        //                string IPAdd = txtIP;
        //                string workDates = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString();
        //                DateTime workDate = DateTime.Parse(workDates);
        //                DateTime InputDate = DateTime.Now;
        //                //Hashtable data1 = new Hashtable();

        //                string username = "";
        //                //获取用户信息
        //                while (axCZKEM1.SSR_GetUserInfo(iMachineNumber, UserID, out name, out password, out privilege, out enble))
        //                {
        //                    username = name;
        //                    break;
        //                }

        //                DataList.Add(new TimeAttendance_AttendanceSchedule()
        //                {
        //                    JobNumber = UserID,
        //                    Name = username,
        //                    MachineID = iMachineNumber.ToString(),
        //                    UpdateTime = InputDate,
        //                    AttendanceTime = workDate,
        //                    MachinePosition=MachinePosition
        //                });
        //            }


        //        }
        //    }

        //    return DataList;
        //}

        //public static bool Connect(zkemkeeper.CZKEMClass axCZKEM1,string txt_IPAddress, int portNumber)
        //{
        //    if (axCZKEM1.Connect_Net(txt_IPAddress, portNumber))
        //    {
        //        return true;
        //    }
        //    else return false;
        //}

       
    }
}
