using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gce_Model;

namespace Gce_Dal
{
    public class TimeAttendance_Employee_FileDal
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="DepartmentNo"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<TimeAttendance_Employee_File> selectTimeAttendance_Employee_FileDepartmentNoDal(string MinimalSector, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<TimeAttendance_Employee_File> list = new List<TimeAttendance_Employee_File>();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MinimalSector",SqlDbType.VarChar,50){Value=MinimalSector}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimeAttendance_Employee_File()
                            {
                                JobNumber=reader.GetString(0),
                                ChineseName=reader.IsDBNull(1)?"":reader.GetString(1),
                                Gender=reader.IsDBNull(2)?"":reader.GetString(2),
                                Education=reader.IsDBNull(3)?"":reader.GetString(3),
                                Post=reader.IsDBNull(4)?"":reader.GetString(4),
                                EmployeeCategory=reader.IsDBNull(5)?"":reader.GetString(5),
                                EntryDate = reader.IsDBNull(6) ? "":reader.GetDateTime(6).ToString(),
                                DepartmentNo=reader.IsDBNull(7)?"":reader.GetString(7),
                                DepartmentName=reader.IsDBNull(8)?"":reader.GetString(8),
                                GroupNo=reader.IsDBNull(9)?"":reader.GetString(9),
                                GroupName=reader.IsDBNull(10)?"":reader.GetString(10),
                                Line_No=reader.IsDBNull(11)?"":reader.GetString(11),
                                LineName=reader.IsDBNull(12)?"":reader.GetString(12),
                                IDNumber=reader.IsDBNull(13)?"":reader.GetString(13),
                                IssuingAuthority=reader.IsDBNull(14)?"":reader.GetString(14),
                                DateOfIssue = reader.IsDBNull(15) ? "" : reader.GetDateTime(15).ToString(),
                                IDTermOfValidity=reader.IsDBNull(16)?"":reader.GetString(16),
                                BirthDay = reader.IsDBNull(17) ? "" : reader.GetDateTime(17).ToString(),
                                PlaceOrigin=reader.IsDBNull(18)?"":reader.GetString(18),
                                Nation=reader.IsDBNull(19)?"":reader.GetString(19),
                                HomeAddress=reader.IsDBNull(20)?"":reader.GetString(20),
                                AttendanceData = reader.IsDBNull(21) ? "" : reader.GetDateTime(21).ToString(),
                                AttendanceRegulations=reader.IsDBNull(22)?"":reader.GetString(22),
                                CompletionData = reader.IsDBNull(23) ? "" : reader.GetDateTime(23).ToString(),
                                ProbationPeriod=reader.IsDBNull(24)?false:reader.GetBoolean(24),
                                SalaryCategory=reader.IsDBNull(25)?"":reader.GetString(25),
                                Introducer=reader.IsDBNull(26)?"":reader.GetString(26),
                                PositionsGrade=reader.IsDBNull(27)?"":reader.GetString(27),
                                Rank=reader.IsDBNull(28)?"":reader.GetString(28),
                                LogicalCardNumber=reader.IsDBNull(29)?"":reader.GetString(29),
                                PhysicalCardNumber = reader.IsDBNull(30) ? "" : reader.GetString(30),
                                PhoneNumber = reader.IsDBNull(31) ? "" : reader.GetString(31),
                                EmergencyContact = reader.IsDBNull(32) ? "" : reader.GetString(32),
                                EmergencyContactPhone = reader.IsDBNull(33) ? "" : reader.GetString(33),
                                EmErgencyContactAddress = reader.IsDBNull(34) ? "" : reader.GetString(34),
                                PaymentMode = reader.IsDBNull(35) ? "" : reader.GetString(35),
                                Height = reader.IsDBNull(36) ? "" : reader.GetString(36),
                                Weight = reader.IsDBNull(37) ? "" : reader.GetString(37),
                                LeftEyeVision = reader.IsDBNull(38) ? "" : reader.GetString(38),
                                RightEyeVision = reader.IsDBNull(39) ? "" : reader.GetString(39),
                                note = reader.IsDBNull(40) ? "" : reader.GetString(40),
                                ContractNumber = reader.IsDBNull(41) ? "" : reader.GetString(41),
                                ContractSigning = reader.IsDBNull(42) ? "" : reader.GetDateTime(42).ToString(),
                                ExpirationContract = reader.IsDBNull(43) ? "" : reader.GetDateTime(43).ToString(),
                                IDCardPeriod = reader.IsDBNull(44) ? "" : reader.GetDateTime(44).ToString(),
                                Job=reader.IsDBNull(45)?false:reader.GetBoolean(45),
                                leaveDate = reader.IsDBNull(46) ? "" : reader.GetDateTime(46).ToString(),
                                TurnoverType=reader.IsDBNull(47)?"":reader.GetString(47),
                                ReasonsForLeaving=reader.IsDBNull(48)?"":reader.GetString(48),
                                Blacklist=reader.IsDBNull(49)?false:reader.GetBoolean(49),
                                married=reader.IsDBNull(50)?false:reader.GetBoolean(50),
                                FreeCard = reader.IsDBNull(51) ? false : reader.GetBoolean(51),
                                OvertimeApplication = reader.IsDBNull(52) ? false : reader.GetBoolean(52),
                                createddate = reader.IsDBNull(53) ? "" : reader.GetDateTime(53).ToString(),
                                FilingMan=reader.IsDBNull(54)?"":reader.GetString(54),
                                modificationDate = reader.IsDBNull(55) ? "": reader.GetDateTime(55).ToString(),
                                Modifier = reader.IsDBNull(56) ? "" : reader.GetString(56),
                                workType = reader.IsDBNull(57) ? "" : reader.GetString(57),
                                workGrade = reader.IsDBNull(58) ? "" : reader.GetString(58),
                                Photo = reader.IsDBNull(59) ? false : reader.GetBoolean(59),
                                MinimalSector = reader.IsDBNull(60) ? "" : reader.GetString(60),
                            });
                        }
                    }
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<TimeAttendance_Employee_File> selectAllTimeAttendance_Employee_File1Dal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<TimeAttendance_Employee_File> list = new List<TimeAttendance_Employee_File>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimeAttendance_Employee_File()
                            {
                                JobNumber = reader.GetString(0),
                                ChineseName = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Gender = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Education = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Post = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                EmployeeCategory = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                EntryDate = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToString(),
                                DepartmentNo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                DepartmentName = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                GroupNo = reader.IsDBNull(9) ? "" : reader.GetString(9),
                                GroupName = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                Line_No = reader.IsDBNull(11) ? "" : reader.GetString(11),
                                LineName = reader.IsDBNull(12) ? "" : reader.GetString(12),
                                IDNumber = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                IssuingAuthority = reader.IsDBNull(14) ? "" : reader.GetString(14),
                                DateOfIssue = reader.IsDBNull(15) ? "" : reader.GetDateTime(15).ToString(),
                                IDTermOfValidity = reader.IsDBNull(16) ? "" : reader.GetString(16),
                                BirthDay = reader.IsDBNull(17) ? "" : reader.GetDateTime(17).ToString(),
                                PlaceOrigin = reader.IsDBNull(18) ? "" : reader.GetString(18),
                                Nation = reader.IsDBNull(19) ? "" : reader.GetString(19),
                                HomeAddress = reader.IsDBNull(20) ? "" : reader.GetString(20),
                                AttendanceData = reader.IsDBNull(21) ? "" : reader.GetDateTime(21).ToString(),
                                AttendanceRegulations = reader.IsDBNull(22) ? "" : reader.GetString(22),
                                CompletionData = reader.IsDBNull(23) ? "" : reader.GetDateTime(23).ToString(),
                                ProbationPeriod = reader.IsDBNull(24) ? false : reader.GetBoolean(24),
                                SalaryCategory = reader.IsDBNull(25) ? "" : reader.GetString(25),
                                Introducer = reader.IsDBNull(26) ? "" : reader.GetString(26),
                                PositionsGrade = reader.IsDBNull(27) ? "" : reader.GetString(27),
                                Rank = reader.IsDBNull(28) ? "" : reader.GetString(28),
                                LogicalCardNumber = reader.IsDBNull(29) ? "" : reader.GetString(29),
                                PhysicalCardNumber = reader.IsDBNull(30) ? "" : reader.GetString(30),
                                PhoneNumber = reader.IsDBNull(31) ? "" : reader.GetString(31),
                                EmergencyContact = reader.IsDBNull(32) ? "" : reader.GetString(32),
                                EmergencyContactPhone = reader.IsDBNull(33) ? "" : reader.GetString(33),
                                EmErgencyContactAddress = reader.IsDBNull(34) ? "" : reader.GetString(34),
                                PaymentMode = reader.IsDBNull(35) ? "" : reader.GetString(35),
                                Height = reader.IsDBNull(36) ? "" : reader.GetString(36),
                                Weight = reader.IsDBNull(37) ? "" : reader.GetString(37),
                                LeftEyeVision = reader.IsDBNull(38) ? "" : reader.GetString(38),
                                RightEyeVision = reader.IsDBNull(39) ? "" : reader.GetString(39),
                                note = reader.IsDBNull(40) ? "" : reader.GetString(40),
                                ContractNumber = reader.IsDBNull(41) ? "" : reader.GetString(41),
                                ContractSigning = reader.IsDBNull(42) ? "" : reader.GetDateTime(42).ToString(),
                                ExpirationContract = reader.IsDBNull(43) ? "" : reader.GetDateTime(43).ToString(),
                                IDCardPeriod = reader.IsDBNull(44) ? "" : reader.GetDateTime(44).ToString(),
                                Job = reader.IsDBNull(45) ? false : reader.GetBoolean(45),
                                leaveDate = reader.IsDBNull(46) ? "" : reader.GetDateTime(46).ToString(),
                                TurnoverType = reader.IsDBNull(47) ? "" : reader.GetString(47),
                                ReasonsForLeaving = reader.IsDBNull(48) ? "" : reader.GetString(48),
                                Blacklist = reader.IsDBNull(49) ? false : reader.GetBoolean(49),
                                married = reader.IsDBNull(50) ? false : reader.GetBoolean(50),
                                FreeCard = reader.IsDBNull(51) ? false : reader.GetBoolean(51),
                                OvertimeApplication = reader.IsDBNull(52) ? false : reader.GetBoolean(52),
                                createddate = reader.IsDBNull(53) ? "" : reader.GetDateTime(53).ToString(),
                                FilingMan = reader.IsDBNull(54) ? "" : reader.GetString(54),
                                modificationDate = reader.IsDBNull(55) ? "" : reader.GetDateTime(55).ToString(),
                                Modifier = reader.IsDBNull(56) ? "" : reader.GetString(56),
                                workType = reader.IsDBNull(57) ? "" : reader.GetString(57),
                                workGrade = reader.IsDBNull(58) ? "" : reader.GetString(58),
                                Photo = reader.IsDBNull(59) ? false : reader.GetBoolean(59),
                                MinimalSector = reader.IsDBNull(60) ? "" : reader.GetString(60),
                            });
                        }
                    }
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 插入员工档案表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int  insertTimeAttendance_Employee_FileDal(TimeAttendance_Employee_File data,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@JobNumber",SqlDbType.VarChar,50){Value=data.JobNumber},
                new SqlParameter("@ChineseName",SqlDbType.VarChar,80){Value=data.ChineseName},
                new SqlParameter("@Gender",SqlDbType.VarChar,50){Value=data.Gender},
                new SqlParameter("@Education",SqlDbType.VarChar,50){Value=data.Education},
                new SqlParameter("@Post",SqlDbType.VarChar,50){Value=data.Post},
                new SqlParameter("@EmployeeCategory",SqlDbType.VarChar,50){Value=data.EmployeeCategory},
                new SqlParameter("@EntryDate",SqlDbType.DateTime){Value=data.EntryDate==""?DBNull.Value:(object)data.EntryDate},
                new SqlParameter("@DepartmentNo",SqlDbType.VarChar,50){Value=data.DepartmentNo},
                new SqlParameter("@DepartmentName",SqlDbType.VarChar,80){Value=data.DepartmentName},
                new SqlParameter("@GroupNo",SqlDbType.VarChar,50){Value=data.GroupNo},
                new SqlParameter("@GroupName",SqlDbType.VarChar,80){Value=data.GroupName},
                new SqlParameter("@Line_No",SqlDbType.VarChar,50){Value=data.Line_No},
                new SqlParameter("@LineName",SqlDbType.VarChar,80){Value=data.LineName},
                new SqlParameter("@IDNumber",SqlDbType.VarChar,80){Value=data.IDNumber},
                new SqlParameter("@IssuingAuthority",SqlDbType.VarChar,255){Value=data.IssuingAuthority},
                new SqlParameter("@DateOfIssue",SqlDbType.DateTime){Value=data.DateOfIssue==""?DBNull.Value:(object)data.DateOfIssue},
                new SqlParameter("@IDTermOfValidity",SqlDbType.VarChar,50){Value=data.IDTermOfValidity},
                new SqlParameter("@BirthDay",SqlDbType.DateTime){Value=data.BirthDay==""?DBNull.Value:(object)data.BirthDay},
                new SqlParameter("@PlaceOrigin",SqlDbType.VarChar,50){Value=data.PlaceOrigin},
                new SqlParameter("@Nation",SqlDbType.VarChar,50){Value=data.Nation},
                new SqlParameter("@HomeAddress",SqlDbType.VarChar,255){Value=data.HomeAddress},
                new SqlParameter("@AttendanceData",SqlDbType.DateTime){Value=data.AttendanceData==""?DBNull.Value:(object)data.AttendanceData},
                new SqlParameter("@AttendanceRegulations",SqlDbType.VarChar,50){Value=data.AttendanceRegulations},
                new SqlParameter("@CompletionData",SqlDbType.DateTime){Value=data.CompletionData==""?DBNull.Value:(object)data.CompletionData},
                new SqlParameter("@ProbationPeriod",SqlDbType.Bit){Value=data.ProbationPeriod},
                new SqlParameter("@SalaryCategory",SqlDbType.VarChar,50){Value=data.SalaryCategory},
                new SqlParameter("@Introducer",SqlDbType.VarChar,50){Value=data.Introducer},
                new SqlParameter("@PositionsGrade",SqlDbType.VarChar,50){Value=data.PositionsGrade},
                new SqlParameter("@Rank",SqlDbType.VarChar,50){Value=data.Rank},
                new SqlParameter("@LogicalCardNumber",SqlDbType.VarChar,50){Value=data.LogicalCardNumber},
                new SqlParameter("@PhysicalCardNumber",SqlDbType.VarChar,50){Value=data.PhysicalCardNumber},
                new SqlParameter("@PhoneNumber",SqlDbType.VarChar,50){Value=data.PhoneNumber},
                new SqlParameter("@EmergencyContact",SqlDbType.VarChar,50){Value=data.EmergencyContact},
                new SqlParameter("@EmergencyContactPhone",SqlDbType.VarChar,50){Value=data.EmergencyContactPhone},
                new SqlParameter("@EmErgencyContactAddress",SqlDbType.VarChar,255){Value=data.EmErgencyContactAddress},
                new SqlParameter("@PaymentMode",SqlDbType.VarChar,50){Value=data.PaymentMode},
                new SqlParameter("@Height",SqlDbType.VarChar,50){Value=data.Height},
                new SqlParameter("@Weight",SqlDbType.VarChar,50){Value=data.Weight},
                new SqlParameter("@LeftEyeVision",SqlDbType.VarChar,50){Value=data.LeftEyeVision},
                new SqlParameter("@RightEyeVision",SqlDbType.VarChar,50){Value=data.RightEyeVision},
                new SqlParameter("@note",SqlDbType.VarChar,255){Value=data.note},
                new SqlParameter("@ContractNumber",SqlDbType.VarChar,50){Value=data.ContractNumber},
                new SqlParameter("@ContractSigning",SqlDbType.DateTime){Value=data.ContractSigning==""?DBNull.Value:(object)data.ContractSigning},
                new SqlParameter("@ExpirationContract",SqlDbType.DateTime){Value=data.ExpirationContract==""?DBNull.Value:(object)data.ExpirationContract},
                new SqlParameter("@IDCardPeriod",SqlDbType.DateTime){Value=data.IDCardPeriod==""?DBNull.Value:(object)data.IDCardPeriod},
                new SqlParameter("@Job",SqlDbType.Bit){Value=data.Job},
                new SqlParameter("@leaveDate",SqlDbType.DateTime){Value=data.leaveDate==""?DBNull.Value:(object)data.leaveDate},
                new SqlParameter("@TurnoverType",SqlDbType.VarChar,50){Value=data.TurnoverType},
                new SqlParameter("@ReasonsForLeaving",SqlDbType.VarChar,255){Value=data.ReasonsForLeaving},
                new SqlParameter("@Blacklist",SqlDbType.Bit){Value=data.Blacklist},
                new SqlParameter("@married",SqlDbType.Bit){Value=data.married},
                new SqlParameter("@FreeCard",SqlDbType.Bit){Value=data.FreeCard},
                new SqlParameter("@OvertimeApplication",SqlDbType.Bit){Value=data.OvertimeApplication},
                new SqlParameter("@createddate",SqlDbType.DateTime){Value=data.createddate==""?DBNull.Value:(object)data.createddate},
                new SqlParameter("@FilingMan",SqlDbType.VarChar,50){Value=data.FilingMan},
                new SqlParameter("@modificationDate",SqlDbType.DateTime){Value=data.modificationDate==""?DBNull.Value:(object)data.modificationDate},
                new SqlParameter("@Modifier",SqlDbType.VarChar,50){Value=data.Modifier},
                new SqlParameter("@workType",SqlDbType.VarChar,50){Value=data.workType},
                new SqlParameter("@workGrade",SqlDbType.VarChar,50){Value=data.workGrade},
                new SqlParameter("@Photo",SqlDbType.Bit){Value=data.Photo},
                new SqlParameter("@MinimalSector",SqlDbType.VarChar,50){Value=data.MinimalSector},

            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public int insertTimeAttendance_Employee_File1Dal(TimeAttendance_Employee_File data, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@JobNumber",SqlDbType.VarChar,50){Value=data.JobNumber},
                new SqlParameter("@ChineseName",SqlDbType.VarChar,80){Value=data.ChineseName},
                new SqlParameter("@Gender",SqlDbType.VarChar,50){Value=data.Gender},
                new SqlParameter("@Education",SqlDbType.VarChar,50){Value=data.Education},
                new SqlParameter("@Post",SqlDbType.VarChar,50){Value=data.Post},
                new SqlParameter("@EmployeeCategory",SqlDbType.VarChar,50){Value=data.EmployeeCategory},
                new SqlParameter("@EntryDate",SqlDbType.DateTime){Value=data.EntryDate==""?DBNull.Value:(object)data.EntryDate},
                new SqlParameter("@DepartmentNo",SqlDbType.VarChar,50){Value=data.DepartmentNo},
                new SqlParameter("@DepartmentName",SqlDbType.VarChar,80){Value=data.DepartmentName},
                new SqlParameter("@GroupNo",SqlDbType.VarChar,50){Value=data.GroupNo},
                new SqlParameter("@GroupName",SqlDbType.VarChar,80){Value=data.GroupName},
                new SqlParameter("@Line_No",SqlDbType.VarChar,50){Value=data.Line_No},
                new SqlParameter("@LineName",SqlDbType.VarChar,80){Value=data.LineName},
                new SqlParameter("@IDNumber",SqlDbType.VarChar,80){Value=data.IDNumber},
                new SqlParameter("@IssuingAuthority",SqlDbType.VarChar,255){Value=data.IssuingAuthority},
                new SqlParameter("@DateOfIssue",SqlDbType.DateTime){Value=data.DateOfIssue==""?DBNull.Value:(object)data.DateOfIssue},
                new SqlParameter("@IDTermOfValidity",SqlDbType.VarChar,50){Value=data.IDTermOfValidity},
                new SqlParameter("@BirthDay",SqlDbType.DateTime){Value=data.BirthDay==""?DBNull.Value:(object)data.BirthDay},
                new SqlParameter("@PlaceOrigin",SqlDbType.VarChar,50){Value=data.PlaceOrigin},
                new SqlParameter("@Nation",SqlDbType.VarChar,50){Value=data.Nation},
                new SqlParameter("@HomeAddress",SqlDbType.VarChar,255){Value=data.HomeAddress},
                new SqlParameter("@AttendanceData",SqlDbType.DateTime){Value=data.AttendanceData==""?DBNull.Value:(object)data.AttendanceData},
                new SqlParameter("@AttendanceRegulations",SqlDbType.VarChar,50){Value=data.AttendanceRegulations},
                new SqlParameter("@CompletionData",SqlDbType.DateTime){Value=data.CompletionData==""?DBNull.Value:(object)data.CompletionData},
                new SqlParameter("@ProbationPeriod",SqlDbType.Bit){Value=data.ProbationPeriod},
                new SqlParameter("@SalaryCategory",SqlDbType.VarChar,50){Value=data.SalaryCategory},
                new SqlParameter("@Introducer",SqlDbType.VarChar,50){Value=data.Introducer},
                new SqlParameter("@PositionsGrade",SqlDbType.VarChar,50){Value=data.PositionsGrade},
                new SqlParameter("@Rank",SqlDbType.VarChar,50){Value=data.Rank},
                new SqlParameter("@LogicalCardNumber",SqlDbType.VarChar,50){Value=data.LogicalCardNumber},
                new SqlParameter("@PhysicalCardNumber",SqlDbType.VarChar,50){Value=data.PhysicalCardNumber},
                new SqlParameter("@PhoneNumber",SqlDbType.VarChar,50){Value=data.PhoneNumber},
                new SqlParameter("@EmergencyContact",SqlDbType.VarChar,50){Value=data.EmergencyContact},
                new SqlParameter("@EmergencyContactPhone",SqlDbType.VarChar,50){Value=data.EmergencyContactPhone},
                new SqlParameter("@EmErgencyContactAddress",SqlDbType.VarChar,255){Value=data.EmErgencyContactAddress},
                new SqlParameter("@PaymentMode",SqlDbType.VarChar,50){Value=data.PaymentMode},
                new SqlParameter("@Height",SqlDbType.VarChar,50){Value=data.Height},
                new SqlParameter("@Weight",SqlDbType.VarChar,50){Value=data.Weight},
                new SqlParameter("@LeftEyeVision",SqlDbType.VarChar,50){Value=data.LeftEyeVision},
                new SqlParameter("@RightEyeVision",SqlDbType.VarChar,50){Value=data.RightEyeVision},
                new SqlParameter("@note",SqlDbType.VarChar,255){Value=data.note},
                new SqlParameter("@ContractNumber",SqlDbType.VarChar,50){Value=data.ContractNumber},
                new SqlParameter("@ContractSigning",SqlDbType.DateTime){Value=data.ContractSigning==""?DBNull.Value:(object)data.ContractSigning},
                new SqlParameter("@ExpirationContract",SqlDbType.DateTime){Value=data.ExpirationContract==""?DBNull.Value:(object)data.ExpirationContract},
                new SqlParameter("@IDCardPeriod",SqlDbType.DateTime){Value=data.IDCardPeriod==""?DBNull.Value:(object)data.IDCardPeriod},
                new SqlParameter("@Job",SqlDbType.Bit){Value=data.Job},
                new SqlParameter("@leaveDate",SqlDbType.DateTime){Value=data.leaveDate==""?DBNull.Value:(object)data.leaveDate},
                new SqlParameter("@TurnoverType",SqlDbType.VarChar,50){Value=data.TurnoverType},
                new SqlParameter("@ReasonsForLeaving",SqlDbType.VarChar,255){Value=data.ReasonsForLeaving},
                new SqlParameter("@Blacklist",SqlDbType.Bit){Value=data.Blacklist},
                new SqlParameter("@married",SqlDbType.Bit){Value=data.married},
                new SqlParameter("@FreeCard",SqlDbType.Bit){Value=data.FreeCard},
                new SqlParameter("@OvertimeApplication",SqlDbType.Bit){Value=data.OvertimeApplication},
                //new SqlParameter("@createddate",SqlDbType.DateTime){Value=data.createddate==""?DBNull.Value:(object)data.createddate},
                new SqlParameter("@FilingMan",SqlDbType.VarChar,50){Value=data.FilingMan},
                new SqlParameter("@modificationDate",SqlDbType.DateTime){Value=data.modificationDate==""?DBNull.Value:(object)data.modificationDate},
                new SqlParameter("@Modifier",SqlDbType.VarChar,50){Value=data.Modifier},
                new SqlParameter("@workType",SqlDbType.VarChar,50){Value=data.workType},
                new SqlParameter("@workGrade",SqlDbType.VarChar,50){Value=data.workGrade},
                new SqlParameter("@Photo",SqlDbType.Bit){Value=data.Photo},
                new SqlParameter("@MinimalSector",SqlDbType.VarChar,50){Value=data.MinimalSector},

            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public int updateTimeAttendance_Employee_File1Dal(TimeAttendance_Employee_File data, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@JobNumber",SqlDbType.VarChar,50){Value=data.JobNumber},
                new SqlParameter("@ChineseName",SqlDbType.VarChar,80){Value=data.ChineseName},
                new SqlParameter("@Gender",SqlDbType.VarChar,50){Value=data.Gender},
                new SqlParameter("@Education",SqlDbType.VarChar,50){Value=data.Education},
                new SqlParameter("@Post",SqlDbType.VarChar,50){Value=data.Post},
                new SqlParameter("@EmployeeCategory",SqlDbType.VarChar,50){Value=data.EmployeeCategory},
                new SqlParameter("@EntryDate",SqlDbType.DateTime){Value=data.EntryDate==""?DBNull.Value:(object)data.EntryDate},
                new SqlParameter("@DepartmentNo",SqlDbType.VarChar,50){Value=data.DepartmentNo},
                new SqlParameter("@DepartmentName",SqlDbType.VarChar,80){Value=data.DepartmentName},
                new SqlParameter("@GroupNo",SqlDbType.VarChar,50){Value=data.GroupNo},
                new SqlParameter("@GroupName",SqlDbType.VarChar,80){Value=data.GroupName},
                new SqlParameter("@Line_No",SqlDbType.VarChar,50){Value=data.Line_No},
                new SqlParameter("@LineName",SqlDbType.VarChar,80){Value=data.LineName},
                new SqlParameter("@IDNumber",SqlDbType.VarChar,80){Value=data.IDNumber},
                new SqlParameter("@IssuingAuthority",SqlDbType.VarChar,255){Value=data.IssuingAuthority},
                new SqlParameter("@DateOfIssue",SqlDbType.DateTime){Value=data.DateOfIssue==""?DBNull.Value:(object)data.DateOfIssue},
                new SqlParameter("@IDTermOfValidity",SqlDbType.VarChar,50){Value=data.IDTermOfValidity},
                new SqlParameter("@BirthDay",SqlDbType.DateTime){Value=data.BirthDay==""?DBNull.Value:(object)data.BirthDay},
                new SqlParameter("@PlaceOrigin",SqlDbType.VarChar,50){Value=data.PlaceOrigin},
                new SqlParameter("@Nation",SqlDbType.VarChar,50){Value=data.Nation},
                new SqlParameter("@HomeAddress",SqlDbType.VarChar,255){Value=data.HomeAddress},
                new SqlParameter("@AttendanceData",SqlDbType.DateTime){Value=data.AttendanceData==""?DBNull.Value:(object)data.AttendanceData},
                new SqlParameter("@AttendanceRegulations",SqlDbType.VarChar,50){Value=data.AttendanceRegulations},
                new SqlParameter("@CompletionData",SqlDbType.DateTime){Value=data.CompletionData==""?DBNull.Value:(object)data.CompletionData},
                new SqlParameter("@ProbationPeriod",SqlDbType.Bit){Value=data.ProbationPeriod},
                new SqlParameter("@SalaryCategory",SqlDbType.VarChar,50){Value=data.SalaryCategory},
                new SqlParameter("@Introducer",SqlDbType.VarChar,50){Value=data.Introducer},
                new SqlParameter("@PositionsGrade",SqlDbType.VarChar,50){Value=data.PositionsGrade},
                new SqlParameter("@Rank",SqlDbType.VarChar,50){Value=data.Rank},
                new SqlParameter("@LogicalCardNumber",SqlDbType.VarChar,50){Value=data.LogicalCardNumber},
                new SqlParameter("@PhysicalCardNumber",SqlDbType.VarChar,50){Value=data.PhysicalCardNumber},
                new SqlParameter("@PhoneNumber",SqlDbType.VarChar,50){Value=data.PhoneNumber},
                new SqlParameter("@EmergencyContact",SqlDbType.VarChar,50){Value=data.EmergencyContact},
                new SqlParameter("@EmergencyContactPhone",SqlDbType.VarChar,50){Value=data.EmergencyContactPhone},
                new SqlParameter("@EmErgencyContactAddress",SqlDbType.VarChar,255){Value=data.EmErgencyContactAddress},
                new SqlParameter("@PaymentMode",SqlDbType.VarChar,50){Value=data.PaymentMode},
                new SqlParameter("@Height",SqlDbType.VarChar,50){Value=data.Height},
                new SqlParameter("@Weight",SqlDbType.VarChar,50){Value=data.Weight},
                new SqlParameter("@LeftEyeVision",SqlDbType.VarChar,50){Value=data.LeftEyeVision},
                new SqlParameter("@RightEyeVision",SqlDbType.VarChar,50){Value=data.RightEyeVision},
                new SqlParameter("@note",SqlDbType.VarChar,255){Value=data.note},
                new SqlParameter("@ContractNumber",SqlDbType.VarChar,50){Value=data.ContractNumber},
                new SqlParameter("@ContractSigning",SqlDbType.DateTime){Value=data.ContractSigning==""?DBNull.Value:(object)data.ContractSigning},
                new SqlParameter("@ExpirationContract",SqlDbType.DateTime){Value=data.ExpirationContract==""?DBNull.Value:(object)data.ExpirationContract},
                new SqlParameter("@IDCardPeriod",SqlDbType.DateTime){Value=data.IDCardPeriod==""?DBNull.Value:(object)data.IDCardPeriod},
                new SqlParameter("@Job",SqlDbType.Bit){Value=data.Job},
                new SqlParameter("@leaveDate",SqlDbType.DateTime){Value=data.leaveDate==""?DBNull.Value:(object)data.leaveDate},
                new SqlParameter("@TurnoverType",SqlDbType.VarChar,50){Value=data.TurnoverType},
                new SqlParameter("@ReasonsForLeaving",SqlDbType.VarChar,255){Value=data.ReasonsForLeaving},
                new SqlParameter("@Blacklist",SqlDbType.Bit){Value=data.Blacklist},
                new SqlParameter("@married",SqlDbType.Bit){Value=data.married},
                new SqlParameter("@FreeCard",SqlDbType.Bit){Value=data.FreeCard},
                new SqlParameter("@OvertimeApplication",SqlDbType.Bit){Value=data.OvertimeApplication},
                new SqlParameter("@createddate",SqlDbType.DateTime){Value=data.createddate==""?DBNull.Value:(object)data.createddate},
                new SqlParameter("@FilingMan",SqlDbType.VarChar,50){Value=data.FilingMan},
                //new SqlParameter("@modificationDate",SqlDbType.DateTime){Value=data.modificationDate==""?DBNull.Value:(object)data.modificationDate},
                new SqlParameter("@Modifier",SqlDbType.VarChar,50){Value=data.Modifier},
                new SqlParameter("@workType",SqlDbType.VarChar,50){Value=data.workType},
                new SqlParameter("@workGrade",SqlDbType.VarChar,50){Value=data.workGrade},
                new SqlParameter("@Photo",SqlDbType.Bit){Value=data.Photo},
                new SqlParameter("@MinimalSector",SqlDbType.VarChar,50){Value=data.MinimalSector},

            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public List<TimeAttendance_Employee_File> LikeSelectTimeAttendance_Employee_File1Dal(string JobNumberRoChineseName, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<TimeAttendance_Employee_File> list = new List<TimeAttendance_Employee_File>();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@JobNumber",SqlDbType.VarChar,50){Value="%"+JobNumberRoChineseName+"%"}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new TimeAttendance_Employee_File()
                            {
                                JobNumber = reader.GetString(0),
                                ChineseName = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Gender = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Education = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Post = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                EmployeeCategory = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                EntryDate = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToString(),
                                DepartmentNo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                DepartmentName = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                GroupNo = reader.IsDBNull(9) ? "" : reader.GetString(9),
                                GroupName = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                Line_No = reader.IsDBNull(11) ? "" : reader.GetString(11),
                                LineName = reader.IsDBNull(12) ? "" : reader.GetString(12),
                                IDNumber = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                IssuingAuthority = reader.IsDBNull(14) ? "" : reader.GetString(14),
                                DateOfIssue = reader.IsDBNull(15) ? "" : reader.GetDateTime(15).ToString(),
                                IDTermOfValidity = reader.IsDBNull(16) ? "" : reader.GetString(16),
                                BirthDay = reader.IsDBNull(17) ? "" : reader.GetDateTime(17).ToString(),
                                PlaceOrigin = reader.IsDBNull(18) ? "" : reader.GetString(18),
                                Nation = reader.IsDBNull(19) ? "" : reader.GetString(19),
                                HomeAddress = reader.IsDBNull(20) ? "" : reader.GetString(20),
                                AttendanceData = reader.IsDBNull(21) ? "" : reader.GetDateTime(21).ToString(),
                                AttendanceRegulations = reader.IsDBNull(22) ? "" : reader.GetString(22),
                                CompletionData = reader.IsDBNull(23) ? "" : reader.GetDateTime(23).ToString(),
                                ProbationPeriod = reader.IsDBNull(24) ? false : reader.GetBoolean(24),
                                SalaryCategory = reader.IsDBNull(25) ? "" : reader.GetString(25),
                                Introducer = reader.IsDBNull(26) ? "" : reader.GetString(26),
                                PositionsGrade = reader.IsDBNull(27) ? "" : reader.GetString(27),
                                Rank = reader.IsDBNull(28) ? "" : reader.GetString(28),
                                LogicalCardNumber = reader.IsDBNull(29) ? "" : reader.GetString(29),
                                PhysicalCardNumber = reader.IsDBNull(30) ? "" : reader.GetString(30),
                                PhoneNumber = reader.IsDBNull(31) ? "" : reader.GetString(31),
                                EmergencyContact = reader.IsDBNull(32) ? "" : reader.GetString(32),
                                EmergencyContactPhone = reader.IsDBNull(33) ? "" : reader.GetString(33),
                                EmErgencyContactAddress = reader.IsDBNull(34) ? "" : reader.GetString(34),
                                PaymentMode = reader.IsDBNull(35) ? "" : reader.GetString(35),
                                Height = reader.IsDBNull(36) ? "" : reader.GetString(36),
                                Weight = reader.IsDBNull(37) ? "" : reader.GetString(37),
                                LeftEyeVision = reader.IsDBNull(38) ? "" : reader.GetString(38),
                                RightEyeVision = reader.IsDBNull(39) ? "" : reader.GetString(39),
                                note = reader.IsDBNull(40) ? "" : reader.GetString(40),
                                ContractNumber = reader.IsDBNull(41) ? "" : reader.GetString(41),
                                ContractSigning = reader.IsDBNull(42) ? "" : reader.GetDateTime(42).ToString(),
                                ExpirationContract = reader.IsDBNull(43) ? "" : reader.GetDateTime(43).ToString(),
                                IDCardPeriod = reader.IsDBNull(44) ? "" : reader.GetDateTime(44).ToString(),
                                Job = reader.IsDBNull(45) ? false : reader.GetBoolean(45),
                                leaveDate = reader.IsDBNull(46) ? "" : reader.GetDateTime(46).ToString(),
                                TurnoverType = reader.IsDBNull(47) ? "" : reader.GetString(47),
                                ReasonsForLeaving = reader.IsDBNull(48) ? "" : reader.GetString(48),
                                Blacklist = reader.IsDBNull(49) ? false : reader.GetBoolean(49),
                                married = reader.IsDBNull(50) ? false : reader.GetBoolean(50),
                                FreeCard = reader.IsDBNull(51) ? false : reader.GetBoolean(51),
                                OvertimeApplication = reader.IsDBNull(52) ? false : reader.GetBoolean(52),
                                createddate = reader.IsDBNull(53) ? "" : reader.GetDateTime(53).ToString(),
                                FilingMan = reader.IsDBNull(54) ? "" : reader.GetString(54),
                                modificationDate = reader.IsDBNull(55) ? "" : reader.GetDateTime(55).ToString(),
                                Modifier = reader.IsDBNull(56) ? "" : reader.GetString(56),
                                workType = reader.IsDBNull(57) ? "" : reader.GetString(57),
                                workGrade = reader.IsDBNull(58) ? "" : reader.GetString(58),
                                Photo = reader.IsDBNull(59) ? false : reader.GetBoolean(59),
                                MinimalSector = reader.IsDBNull(60) ? "" : reader.GetString(60),
                            });
                        }
                    }
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

        //public int deleteTimeAttendance_Employee_File1Dal(string JobNumber,string SQLCommand)
        //{
        //    string sql = SQLhelp.GetSQLCommand(SQLCommand);

        //}
    }
}
