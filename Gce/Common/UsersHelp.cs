using Gce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gce_Common
{
    public static class UsersHelp
    {
        public static List<Users> Userslist = new List<Users>();

        public static Dictionary<string,bool> ParentDic = new Dictionary<string,bool>();
        public static Dictionary<string, Dictionary<string, bool>> ChildDic = new Dictionary<string, Dictionary<string, bool>>();

        //
        public static Dictionary<string, bool> chidic1 = new Dictionary<string, bool>();
        public static Dictionary<string, bool> chidic2 = new Dictionary<string, bool>();
        public static Dictionary<string, bool> chidic3 = new Dictionary<string, bool>();
        public static Dictionary<string, bool> chidic4 = new Dictionary<string, bool>();
        public static Dictionary<string, bool> chidic5 = new Dictionary<string, bool>();

        //是否登录
        public static bool checkLogin = false;
        //是否是管理员
        public static bool systemAdimin = false;
        //是否有赋予权限的权限
        public static bool Limite = false;
        //是否有添加用户的权限
        public static bool AddUser = false;

        ///仓库管理
        //扫描二维码
        public static bool ScanQrCode = false;
        //财务录入ERP
        public static bool FinancialInput = false;
        //来料审核
        public static bool IncomingAudit = false;
        //来料入库 
        public static bool Warehousing = false;
        //采购入仓单
        public static bool LeviteOrder = false;
        //来料退货
        public static bool IncomingMaterialReturns = false;
        //领料出仓
        public static bool TheMaterialWarehouse = false;

        ///-----------------------///
        ///质检管理
        //来料检验单
        public static bool IncomingInspection = false;
        //特采挑选
        public static bool SelectionOfSpecialPicks = false;
        //质检汇总查询
        public static bool QualityInspectionSummaryInquiry = false;
        ///-----------------------///
        
        ///生产管理
        //生产效能管理
        public static bool Production_efficiency_management = false;
        #region 生产效能管理详细功能权限
        //参数调用
        public static bool Production_efficiency_management_Parameter_call = false;
        //参数设置
        public static bool Production_efficiency_management_Parameter_setting = false;
        //数据导出
        public static bool Production_efficiency_management_DataOut = false;
        #endregion
        ///-----------------------///
        
        //生产分时段记录
        public static bool Dayparting = false;
        #region 生产分时段记录详细功能权限
        //上下班时间配置
        public static bool Dayparting_Commuting_time_allocation = false;
        //生产线PC配置
        public static bool Dayparting_Production_PC_configuration = false;
        //数据导出
        public static bool Dayparting_DataOut = false;
        #endregion
        ///-----------------------///
        
        //员工履历表
        public static bool StaffResume = false;
        #region 员工履历表详细功能权限
        //新增
        public static bool StaffResume_New = false;
        //修改
        public static bool StaffResume_Modify = false;
        //删除
        public static bool StaffResume_Delete = false;
        //工种配置
        public static bool StaffResume_Job_allocation = false;
        //数据导出
        public static bool StaffResume_DataOut = false;
        #endregion
        ///-----------------------///
        //不良品录入与查询
        public static bool abnormal = false;
        #region 不良品录入与查询详细功能权限
        //不良品录入
        public static bool abnormal_Defective_product_entry = false;
        //修改
        public static bool abnormal_Modify = false;
        //删除
        public static bool abnormal_Delete = false;
        //数据导出
        public static bool abnormal_DataOut = false;
        #endregion
        ///-----------------------///
        ///PMC管理
        //PMC计划
        public static bool PMCplan = false;
        #region PMC计划详细功能权限
        //修改
        public static bool PMCplan_Modify = false;
        //删除
        public static bool PMCplan_Delete = false;
        //PMC计划录入
        public static bool PMCplan_PMC_plan_entry = false;
        //数据导出
        public static bool PMCplan_DataOute = false;
        #endregion


        public static void SetUsers(List<Users> list, bool checkLogin, bool limite,bool adduser, bool systemadimin)
        {
            UsersHelp.Userslist = list;
            UsersHelp.checkLogin = checkLogin;
            UsersHelp.Limite = limite;
            UsersHelp.systemAdimin = systemadimin;
            UsersHelp.AddUser = adduser;
            UsersHelp.ClearDIc();
        }

        public static void ClearDIc()
        {
            ParentDic.Clear();
            ChildDic.Clear();
            chidic1.Clear();
            chidic2.Clear();
            chidic3.Clear();
            chidic4.Clear();
            chidic5.Clear();
        }

        public static void SetJurisdiction(Dictionary<string,Dictionary<string,bool>> DataDic)
        {
            try
            {
                foreach (KeyValuePair<string, Dictionary<string, bool>> dic in DataDic)
                {
                    if (dic.Key == "UserName")//确定父级权限
                    {                        
                        foreach (KeyValuePair<string, bool> item in dic.Value)
                        {
                            if (!ParentDic.ContainsKey(item.Key))
                            {
                                ParentDic.Add(item.Key, item.Value);
                            }

                            switch (item.Key)
                            {
                                case "仓库汇总查询":
                                    ScanQrCode = item.Value;
                                    break;
                                case "采购入仓单":
                                    LeviteOrder = item.Value;
                                    break;
                                case "来料检验单":
                                    IncomingInspection = item.Value;
                                    break;
                                case "生产效能管理":
                                    Production_efficiency_management = item.Value;
                                    break;
                                case "生产分时段记录":
                                    Dayparting = item.Value;
                                    break;
                                case "员工履历表":
                                    StaffResume = item.Value;
                                    break;
                                case "不良品录入与查询":
                                    abnormal = item.Value;
                                    break;
                                case "PMC计划":
                                    PMCplan = item.Value;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (dic.Key)
                        {
                            case "仓库汇总查询":

                                break;
                            case "采购入仓单":

                                break;
                            case "来料检验单":

                                break;
                            case "生产效能管理":
                                foreach (KeyValuePair<string, bool> item in dic.Value)
                                {
                                    if (!chidic1.ContainsKey(item.Key))
                                    {
                                        chidic1.Add(item.Key, item.Value);
                                    }

                                    switch (item.Key)
                                    {
                                        case "参数调用":
                                            Production_efficiency_management_Parameter_call = item.Value;
                                            break;
                                        case "参数设置":
                                            Production_efficiency_management_Parameter_setting = item.Value;
                                            break;
                                        case "数据导出":
                                            Production_efficiency_management_DataOut = item.Value;
                                            break;
                                    }
                                }
                                if (!ChildDic.ContainsKey(dic.Key))
                                {
                                    ChildDic.Add(dic.Key, chidic1);
                                }
                                break;
                            case "生产分时段记录":
                                foreach (KeyValuePair<string, bool> item in dic.Value)
                                {

                                    if (!chidic2.ContainsKey(item.Key))
                                    {
                                        chidic2.Add(item.Key, item.Value);
                                    }


                                    switch (item.Key)
                                    {
                                        case "上下班时间配置":
                                            Dayparting_Commuting_time_allocation = item.Value;
                                            break;
                                        case "生产线PC配置":
                                            Dayparting_Production_PC_configuration = item.Value;
                                            break;
                                        case "数据导出":
                                            Dayparting_DataOut = item.Value;
                                            break;
                                    }
                                }
                                if (!ChildDic.ContainsKey(dic.Key))
                                {
                                    ChildDic.Add(dic.Key, chidic2);
                                }
                                break;
                            case "员工履历表":
                                foreach (KeyValuePair<string, bool> item in dic.Value)
                                {

                                    if (!chidic3.ContainsKey(item.Key))
                                    {
                                        chidic3.Add(item.Key, item.Value);
                                    }
                                    

                                    switch (item.Key)
                                    {
                                        case "新增":
                                            StaffResume_New = item.Value;
                                            break;
                                        case "修改":
                                            StaffResume_Modify = item.Value;
                                            break;
                                        case "删除":
                                            StaffResume_Delete = item.Value;
                                            break;
                                        case "工种配置":
                                            StaffResume_Job_allocation = item.Value;
                                            break;
                                        case "数据导出":
                                            StaffResume_DataOut = item.Value;
                                            break;
                                    }
                                    if (!ChildDic.ContainsKey(dic.Key))
                                    {
                                        ChildDic.Add(dic.Key, chidic3);
                                    }
                                }
                                break;
                            case "不良品录入与查询":
                                foreach (KeyValuePair<string, bool> item in dic.Value)
                                {

                                    if (!chidic4.ContainsKey(item.Key))
                                    {
                                        chidic4.Add(item.Key, item.Value);
                                    }


                                    switch (item.Key)
                                    {
                                        case "不良品录入":
                                            abnormal_Defective_product_entry = item.Value;
                                            break;
                                        case "修改":
                                            abnormal_Modify = item.Value;
                                            break;
                                        case "删除":
                                            abnormal_Delete = item.Value;
                                            break;
                                        case "数据导出":
                                            abnormal_DataOut = item.Value;
                                            break;
                                    }
                                }
                                if (!ChildDic.ContainsKey(dic.Key))
                                {
                                    ChildDic.Add(dic.Key, chidic4);
                                }
                                break;
                            case "PMC计划":
                                foreach (KeyValuePair<string, bool> item in dic.Value)
                                {

                                    if (!chidic5.ContainsKey(item.Key))
                                    {
                                        chidic5.Add(item.Key, item.Value);
                                    }


                                    switch (item.Key)
                                    {
                                        case "PMC计划录入":
                                            PMCplan_PMC_plan_entry = item.Value;
                                            break;
                                        case "修改":
                                            PMCplan_Modify = item.Value;
                                            break;
                                        case "删除":
                                            PMCplan_Delete = item.Value;
                                            break;
                                        case "数据导出":
                                            PMCplan_DataOute = item.Value;
                                            break;
                                    }
                                }
                                if (!ChildDic.ContainsKey(dic.Key))
                                {
                                    ChildDic.Add(dic.Key, chidic5);
                                }
                                break;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 注销用户权限和登录状态
        /// </summary>
        public static void DisposeJurisdiction()
        {
            ClearDIc();
            //是否登录
            checkLogin = false;
            //是否是管理员
            systemAdimin = false;

            ///仓库管理
            //扫描二维码
            ScanQrCode = false;
            //采购入仓单
            LeviteOrder = false;

            ///-----------------------///
            ///质检管理
            //来料检验单
            IncomingInspection = false;
            ///-----------------------///

            ///生产管理
            //生产效能管理
            Production_efficiency_management = false;
            #region 生产效能管理详细功能权限
            //参数调用
            Production_efficiency_management_Parameter_call = false;
            //参数设置
            Production_efficiency_management_Parameter_setting = false;
            //数据导出
            Production_efficiency_management_DataOut = false;
            #endregion
            ///-----------------------///

            //生产分时段记录
            Dayparting = false;
            #region 生产分时段记录详细功能权限
            //上下班时间配置
            Dayparting_Commuting_time_allocation = false;
            //生产线PC配置
            Dayparting_Production_PC_configuration = false;
            //数据导出
            Dayparting_DataOut = false;
            #endregion
            ///-----------------------///

            //员工履历表
            StaffResume = false;
            #region 员工履历表详细功能权限
            //新增
            StaffResume_New = false;
            //修改
            StaffResume_Modify = false;
            //删除
            StaffResume_Delete = false;
            //工种配置
            StaffResume_Job_allocation = false;
            //数据导出
            StaffResume_DataOut = false;
            #endregion
            ///-----------------------///
            //不良品录入与查询
            abnormal = false;
            #region 不良品录入与查询详细功能权限
            //不良品录入
            abnormal_Defective_product_entry = false;
            //修改
            abnormal_Modify = false;
            //删除
            abnormal_Delete = false;
            //数据导出
            abnormal_DataOut = false;
            #endregion
            ///-----------------------///
            ///PMC管理
            //PMC计划
            PMCplan = false;
            #region PMC计划详细功能权限
            //修改
            PMCplan_Modify = false;
            //删除
            PMCplan_Delete = false;
            //PMC计划录入
            PMCplan_PMC_plan_entry = false;
            //数据导出
            PMCplan_DataOute = false;
            #endregion
        }
    }
}
