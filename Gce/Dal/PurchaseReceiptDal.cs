using Gce_Model;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Gce_Dal
{
    public class PurchaseReceiptDal
    {
        /// <summary>
        /// 插入采购入库表
        /// </summary>
        /// <param name="list"></param>
        public void SetQrcodeStrDal(List<PurchaseReceipt> list)
        {
            //获取数据库命令表中的SQL语句
            string sql = SQLhelp.GetSQLCommand("InsertPurchaseReceipt");
            //SQL参数数组
            SqlParameter[] pms = new SqlParameter[]{
                    new SqlParameter("@pchno",SqlDbType.VarChar,80){Value=list[0].PurchaseNo},
                    new SqlParameter("@sn",SqlDbType.VarChar,80){Value=list[0].SupplierName},
                    new SqlParameter("@bc",SqlDbType.VarChar,80){Value=list[0].BatchNo},
                    new SqlParameter("@mc",SqlDbType.VarChar,80){Value=list[0].MaterialCode},
                    new SqlParameter("@mn",SqlDbType.VarChar,80){Value=list[0].MaterialName},
                    new SqlParameter("@ms",SqlDbType.VarChar,80){Value=list[0].MaterialSpecifications},
                    new SqlParameter("@pq",SqlDbType.Int){Value=list[0].ProductQuantity},
                    new SqlParameter("@ca",SqlDbType.Bit){Value=list[0].CheckAudit},
                    new SqlParameter("@cq",SqlDbType.Bit){Value=list[0].CheckQualified},
                    new SqlParameter("@csm",SqlDbType.Bit){Value=list[0].CheckSpecialMining},
                    new SqlParameter("@note",SqlDbType.VarChar,8000){Value=list[0].note},
            };
            try
            {
               int i = SQLhelp.ExecuteNonQuery(sql,CommandType.Text,pms);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 删除一条采购入库表数据
        /// </summary>
        /// <param name="list"></param>
        public void DeletePurchaseReceiptRowDal(List<string> list)
        {
            string sql = SQLhelp.GetSQLCommand("deletePurchaseReceiptRow");

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@pn",SqlDbType.VarChar,80){Value=list[0]},
                new SqlParameter("@sn",SqlDbType.VarChar,80){Value=list[1]},
                new SqlParameter("@bn",SqlDbType.VarChar,80){Value=list[2]},
                new SqlParameter("@mc",SqlDbType.VarChar,80){Value=list[3]},
                new SqlParameter("@mn",SqlDbType.VarChar,80){Value=list[4]},
                new SqlParameter("@ms",SqlDbType.VarChar,80){Value=list[5]},
                new SqlParameter("@pq",SqlDbType.Int){Value=list[6]}
            };
            try
            {
                int i = SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
            }
            catch{}
        }
        /// <summary>
        /// 来料入仓单查询
        /// </summary>
        /// <returns></returns>
        public List<IncomingInspectionModel> selectPurchaseNoPurchaseReceiptDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<IncomingInspectionModel> list = new List<IncomingInspectionModel>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new IncomingInspectionModel()
                            {
                                PurchaseReceiptID = reader.GetString(0),
                                PurchaseNo = reader.GetString(1),
                                SupplierName = reader.GetString(2),
                                BatchNo = reader.GetString(3),
                                MaterialCode = reader.GetString(4),
                                MaterialName = reader.GetString(5),
                                MaterialSpecifications = reader.GetString(6),
                                ProductQuantity = reader.GetInt32(7),
                                ProductQuantity1 = reader.GetInt32(8),
                                CheckQualified = reader.GetString(9),
                                CheckQualifiedUserName = reader.IsDBNull(10)? "" : reader.GetString(10),
                                note = reader.IsDBNull(11) ? "" : reader.GetString(11),
                                Updatetime1 = reader.GetDateTime(12),
                                OrderState = reader.IsDBNull(13)?0:reader.GetInt32(13)
                            });
                        }
                        return list;
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
        /// 扫码入库插入
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public int insertPurchaseReceiptDal(List<PurchaseReceipt> list,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                    new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=list[0].PurchaseReceiptID},
                    new SqlParameter("@PurchaseNo",SqlDbType.VarChar,80){Value=list[0].PurchaseNo},
                    new SqlParameter("@SupplierName",SqlDbType.VarChar,80){Value=list[0].SupplierName},
                    new SqlParameter("@BatchNo",SqlDbType.VarChar,80){Value=list[0].BatchNo},
                    new SqlParameter("@MaterialCode",SqlDbType.VarChar,80){Value=list[0].MaterialCode},
                    new SqlParameter("@MaterialName",SqlDbType.VarChar,80){Value=list[0].MaterialName},
                    new SqlParameter("@MaterialSpecifications",SqlDbType.VarChar,80){Value=list[0].MaterialSpecifications},
                    new SqlParameter("@ProductQuantity",SqlDbType.Int){Value=list[0].ProductQuantity},
                    new SqlParameter("@ProductQuantity1",SqlDbType.Int){Value=list[0].ProductQuantity1},
                    new SqlParameter("@CheckAudit",SqlDbType.VarChar,50){Value=list[0].CheckAudit},
                    new SqlParameter("@CheckQualified",SqlDbType.VarChar,50){Value=list[0].CheckQualified},
                    new SqlParameter("@CheckSpecialMining",SqlDbType.VarChar,50){Value=list[0].CheckSpecialMining},
                    new SqlParameter("@note",SqlDbType.VarChar,8000){Value=list[0].note},
                    new SqlParameter("@ScanningTime",SqlDbType.DateTime){Value=list[0].ScanningTime},
                    new SqlParameter("@Updatetime",SqlDbType.DateTime){Value=list[0].Updatetime},
                    new SqlParameter("@UserName",SqlDbType.VarChar,80){Value=list[0].UserName},
                    new SqlParameter("@OrderState",SqlDbType.Int){Value=list[0].OrderState}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 更新PurchaseReceipt表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="SQLComand"></param>
        /// <returns></returns>
        public int updatePurchaseReceiptDal(List<PurchaseReceipt> list, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                    new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=list[0].PurchaseReceiptID},
                    new SqlParameter("@PurchaseNo",SqlDbType.VarChar,80){Value=list[0].PurchaseNo},
                    new SqlParameter("@SupplierName",SqlDbType.VarChar,80){Value=list[0].SupplierName},
                    new SqlParameter("@BatchNo",SqlDbType.VarChar,80){Value=list[0].BatchNo},
                    new SqlParameter("@MaterialCode",SqlDbType.VarChar,80){Value=list[0].MaterialCode},
                    new SqlParameter("@MaterialName",SqlDbType.VarChar,80){Value=list[0].MaterialName},
                    new SqlParameter("@MaterialSpecifications",SqlDbType.VarChar,80){Value=list[0].MaterialSpecifications},
                    new SqlParameter("@ProductQuantity",SqlDbType.Int){Value=list[0].ProductQuantity},
                    new SqlParameter("@ProductQuantity1",SqlDbType.Int){Value=list[0].ProductQuantity1},
                    new SqlParameter("@CheckAudit",SqlDbType.VarChar,50){Value=list[0].CheckAudit},
                    new SqlParameter("@CheckQualified",SqlDbType.VarChar,50){Value=list[0].CheckQualified},
                    new SqlParameter("@CheckSpecialMining",SqlDbType.VarChar,50){Value=list[0].CheckSpecialMining},
                    new SqlParameter("@note",SqlDbType.VarChar,8000){Value=list[0].note},
                    new SqlParameter("@ScanningTime",SqlDbType.DateTime){Value=list[0].ScanningTime},
                    new SqlParameter("@Updatetime",SqlDbType.DateTime){Value=list[0].Updatetime},
                    new SqlParameter("@UserName",SqlDbType.VarChar,80){Value=list[0].UserName},
                    new SqlParameter("@OrderState",SqlDbType.Int){Value=list[0].OrderState}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int deletePurchaseReceiptDal(string PurchaseReceiptID,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=PurchaseReceiptID}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// 质检更新合格率
        /// </summary>
        /// <param name="incoming"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePurchaseReceiptQualifiedDal(IncomingInspectionModel incoming,bool WhetherQualified,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {

                new SqlParameter("@CheckQualified",SqlDbType.VarChar,50){Value=incoming.CheckQualified},
                new SqlParameter("@CheckQualifiedUserName",SqlDbType.VarChar,50){Value=incoming.CheckQualifiedUserName},
                new SqlParameter("@QualifiedTime1",SqlDbType.DateTime){Value=incoming.QualifiedTime1},
                new SqlParameter("@QualifiedTime2",SqlDbType.DateTime){Value=incoming.QualifiedTime2},
                new SqlParameter("@QualifiedRate",SqlDbType.Float){Value=incoming.QualifiedRate},
                new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=incoming.PurchaseReceiptID},
                new SqlParameter("@WhetherQualified",SqlDbType.Bit){Value=WhetherQualified},
                new SqlParameter("@CheckNumber",SqlDbType.Int){Value=incoming.CheckNumber},
                new SqlParameter("@classType",SqlDbType.VarChar,80){Value=incoming.classType},
                new SqlParameter("@ProblemDescription",SqlDbType.VarChar,255){Value=incoming.ProblemDescription},
                new SqlParameter("@CheckAudit",SqlDbType.VarChar,80){Value=WhetherQualified?"审核":"未审核"},
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 加载财务录入功能查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<FinancialInputERPModel> selectPurchaseReceiptFinancialEntryDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<FinancialInputERPModel> list = new List<FinancialInputERPModel>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new FinancialInputERPModel()
                            {
                                PurchaseReceiptID = reader.GetString(0),
                                PurchaseNo = reader.GetString(1),
                                SupplierName = reader.GetString(2),
                                BatchNo = reader.GetString(3),
                                MaterialCode = reader.GetString(4),
                                MaterialName = reader.GetString(5),
                                MaterialSpecifications = reader.GetString(6),
                                ProductQuantity = reader.GetInt32(7),
                                ProductQuantity1 = reader.GetInt32(8),
                                note = reader.IsDBNull(9) ? "" : reader.GetString(9),
                                Updatetime1 = reader.GetDateTime(10),
                                OrderState = reader.IsDBNull(11) ? 0 : reader.GetInt32(11),
                                FinancialEntry = reader.IsDBNull(12) ? "" : reader.GetString(12),
                                FinancialEntryName = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                FinancialEntryTime = reader.IsDBNull(14)?DateTime.Now: reader.GetDateTime(14)
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
        /// 财务录入ERP更新
        /// </summary>
        /// <param name="finerp"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePurchaseReceiptFinancialEntryDal(FinancialInputERPModel finerp,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
              new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=finerp.PurchaseReceiptID},
              new SqlParameter("@FinancialEntry",SqlDbType.VarChar,50){Value=finerp.FinancialEntry},
              new SqlParameter("@FinancialEntryName",SqlDbType.VarChar,50){Value=finerp.FinancialEntryName}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 审核查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<IncomingAuditModel> selectPurchaseReceiptIncomingAuditDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<IncomingAuditModel> list = new List<IncomingAuditModel>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new IncomingAuditModel()
                            {
                                PurchaseReceiptID=reader.GetString(0),
                                PurchaseNo = reader.GetString(1),
                                SupplierName = reader.GetString(2),
                                BatchNo = reader.GetString(3),
                                MaterialCode = reader.GetString(4),
                                MaterialName = reader.GetString(5),
                                MaterialSpecifications = reader.GetString(6),
                                ProductQuantity1 = reader.IsDBNull(15)?reader.GetInt32(7):reader.GetInt32(15),
                                CheckAudit=reader.IsDBNull(8)?"未审核":reader.GetString(8),
                                QualifiedRate=reader.IsDBNull(9)?0.00:reader.GetDouble(9),
                                FinancialEntry=reader.IsDBNull(10)?"未录入":reader.GetString(10),
                                Updatetime1=reader.GetDateTime(11),
                                OrderState=reader.IsDBNull(12)?0:reader.GetInt32(12),
                                note=reader.IsDBNull(13)?"":reader.GetString(13),
                                WhetherQualified=reader.IsDBNull(14)?false:reader.GetBoolean(14)
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
        /// 审核更新
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="CheckSpecialMining"></param>
        /// <param name="CheckAuditUserName"></param>
        /// <param name="WhetherQualified"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePurchaseReceiptIncomingAuditDal(string PurchaseReceiptID, string CheckAudit, string CheckSpecialMining, string CheckAuditUserName, string note, string AttributionResponsibility, string Presentation8D, bool WhetherQualified, string ReturnGoods, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@CheckAudit",SqlDbType.VarChar,50){Value=CheckAudit},
                new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=PurchaseReceiptID},
                new SqlParameter("@CheckSpecialMining",SqlDbType.VarChar,80){Value=CheckSpecialMining},
                new SqlParameter("@CheckAuditUserName",SqlDbType.VarChar,50){Value=CheckAuditUserName},
                new SqlParameter("@WhetherQualified",SqlDbType.Bit){Value=WhetherQualified},
                new SqlParameter("@note",SqlDbType.VarChar,8000){Value=note},
                new SqlParameter("@AttributionResponsibility",SqlDbType.VarChar,50){Value=AttributionResponsibility},
                new SqlParameter("@Presentation8D",SqlDbType.VarChar,50){Value=Presentation8D},
                new SqlParameter("@ReturnGoods",SqlDbType.VarChar,20){Value=SqlNull(ReturnGoods)}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        public static object SqlNull(object obj)
        {
            if (obj == null || obj.ToString() == "")
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }
        /// <summary>
        /// 扫码查询挑选信息
        /// </summary>
        /// <param name="PurchaseNo"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<ChooseModel> selectPurchaseReceiptChooseDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<ChooseModel> liste = new List<ChooseModel>();

            try
            { 
                using(SqlDataReader reader=SQLhelp.ExecuteReader(sql,CommandType.Text))
                {
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            liste.Add(new ChooseModel()
                            {
                                PurchaseReceiptID = reader.GetString(0),
                                PurchaseNo = reader.GetString(1),
                                SupplierName = reader.GetString(2),
                                BatchNo = reader.GetString(3),
                                MaterialCode = reader.GetString(4),
                                MaterialName = reader.GetString(5),
                                MaterialSpecifications = reader.GetString(6),
                                ProductQuantity1 = reader.GetInt32(7),
                                QualifiedRate=reader.IsDBNull(8)?0.00:reader.GetDouble(8),
                                note=reader.IsDBNull(9)?"":reader.GetString(9),
                                OrderState=reader.IsDBNull(10)?0:reader.GetInt32(10),
                                Updatetime1=reader.GetDateTime(11)
                            });
                        }
                    }
                    return liste;
                }   
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 挑选更新
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="ChooseNumber"></param>
        /// <param name="NotChooseNumber"></param>
        /// <param name="ChooseTime1"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePurchaseReceiptChooseDal(string PurchaseReceiptID, int ChooseNumber, int NotChooseNumber, string ChooseName, DateTime ChooseTime1, string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
              new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=PurchaseReceiptID},
              new SqlParameter("@ChooseNumber",SqlDbType.Int){Value=ChooseNumber},
              new SqlParameter("@NotChooseNumber",SqlDbType.Int){Value=NotChooseNumber},
              new SqlParameter("@ChooseTime1",SqlDbType.DateTime){Value=ChooseTime1},
              new SqlParameter("@ChooseName",SqlDbType.VarChar,50){Value=ChooseName}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 来料入库查询
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<IncomingWarehousingModel> selectPurchaseReceiptWhetherDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<IncomingWarehousingModel> list = new List<IncomingWarehousingModel>();

            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new IncomingWarehousingModel()
                            {
                                PurchaseReceiptID = reader.GetString(0),
                                PurchaseNo = reader.GetString(1),
                                SupplierName = reader.GetString(2),
                                BatchNo = reader.GetString(3),
                                MaterialCode = reader.GetString(4),
                                MaterialName = reader.GetString(5),
                                MaterialSpecifications = reader.GetString(6),
                                ProductQuantity1 = reader.GetInt32(7),
                                ChooseNumber=reader.IsDBNull(8)?0:reader.GetInt32(8),
                                note=reader.IsDBNull(9)?"":reader.GetString(9),
                                Updatetime1=reader.GetDateTime(10),
                                CheckSpecialMining=reader.IsDBNull(11)?"":reader.GetString(11)
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
        /// 标记已入库
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="Storage"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePurchaseReceiptStorageDal(string PurchaseReceiptID,string Storage,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=PurchaseReceiptID},
                new SqlParameter("@Storage",SqlDbType.VarChar,20){Value=Storage}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 查询退货信息
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<PWarehouseTable_ReturnGoods> selectPurchaseReceiptReturnGoodsDal(string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);
            List<PWarehouseTable_ReturnGoods> list=new List<PWarehouseTable_ReturnGoods>();
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new PWarehouseTable_ReturnGoods()
                            {
                                PurchaseReceiptID = reader.GetString(0),
                                PurchaseNo = reader.GetString(1),
                                SupplierName = reader.GetString(2),
                                BatchNo = reader.GetString(3),
                                MaterialCode = reader.GetString(4),
                                MaterialName = reader.GetString(5),
                                MaterialSpecifications = reader.GetString(6),
                                ProductQuantity = reader.IsDBNull(7)?0:reader.GetInt32(7),                               
                                note = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                Updatetime = reader.GetDateTime(9),
                                CheckSpecialMining = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                ProductQuantity1 = reader.IsDBNull(11) ? 0 : reader.GetInt32(11)
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
        /// 退货标记更新
        /// </summary>
        /// <param name="PurchaseReceiptID"></param>
        /// <param name="ReturnGoods"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public int updatePurchaseReceiptReturnGoodsDal(string PurchaseReceiptID, string ReturnGoods,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@PurchaseReceiptID",SqlDbType.VarChar,100){Value=PurchaseReceiptID},
                new SqlParameter("@ReturnGoods",SqlDbType.VarChar,20){Value=ReturnGoods}
            };

            return SQLhelp.ExecuteNonQuery(sql, CommandType.Text, pms);
        }
        /// <summary>
        /// 质检汇总查询
        /// </summary>
        /// <param name="list"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<selectPurchaseReceiptCheckQualifiedModel> selectPurchaseReceiptCheckQualifiedDal(List<selectPurchaseReceiptCheckQualifiedModel> list,DateTime beginTime,DateTime endTime,string SQLCommand)
        {
            StringBuilder sql = new StringBuilder(SQLhelp.GetSQLCommand(SQLCommand));
            List<SqlParameter> listsqlpar = new List<SqlParameter>();
            List<string> whereList = new List<string>();
            List<selectPurchaseReceiptCheckQualifiedModel> rlist = new List<selectPurchaseReceiptCheckQualifiedModel>();

            if (list.Count > 0)
            {
                if (list[0].PurchaseNo.Length > 0)
                {
                    whereList.Add(" PurchaseNo=@PurchaseNo ");
                    listsqlpar.Add(new SqlParameter("@PurchaseNo", SqlDbType.VarChar, 80) { Value = list[0].PurchaseNo });
                }

                if (list[0].MaterialCode.Length > 0)
                {
                    whereList.Add(" MaterialCode=@MaterialCode ");
                    listsqlpar.Add(new SqlParameter("@MaterialCode", SqlDbType.VarChar, 80) { Value = list[0].MaterialCode });
                }
                if(list[0].MaterialName.Length>0)
                {
                    whereList.Add(" MaterialName=@MaterialName ");
                    listsqlpar.Add(new SqlParameter("@MaterialName", SqlDbType.VarChar, 80) { Value = list[0].MaterialName });
                }
                if (list[0].SupplierName.Length > 0)
                {
                    whereList.Add(" SupplierName=@SupplierName ");
                    listsqlpar.Add(new SqlParameter("@SupplierName", SqlDbType.VarChar, 80) { Value = list[0].SupplierName });
                }
                if (list[0].QualifiedRate.Length > 0)
                {
                    whereList.Add(" SupplierName=@SupplierName ");
                    listsqlpar.Add(new SqlParameter("@SupplierName", SqlDbType.Float) { Value = Convert.ToDouble(list[0].SupplierName) });
                }
            }

            if (beginTime.Year.ToString() != "1")
            {
                whereList.Add(" QualifiedTime2>=@time ");
                listsqlpar.Add(new SqlParameter("@time", SqlDbType.DateTime) { Value = beginTime });
            }
            if (endTime.Year.ToString() != "1")
            {
                whereList.Add(" QualifiedTime2<=@time1 ");
                listsqlpar.Add(new SqlParameter("@time1", SqlDbType.DateTime) { Value = endTime });
            }

            if (whereList.Count > 0)
            {
                sql.Append(" and ");
                //然后把后面的查询条件连起来
                sql.Append(string.Join(" and ", whereList));
                sql.Append(" order by QualifiedTime2 ");
            }

            if (listsqlpar.Count > 0)
            {
                SqlParameter[] pms = listsqlpar.ToArray();

                try
                {
                    using (SqlDataReader reader = SQLhelp.ExecuteReader(sql.ToString(), CommandType.Text, pms))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                rlist.Add(new selectPurchaseReceiptCheckQualifiedModel()
                                {
                                    QualifiedTime2=reader.GetDateTime(0),
                                    PurchaseNo=reader.GetString(1),
                                    MaterialCode=reader.GetString(2),
                                    MaterialName=reader.GetString(3),
                                    SupplierName=reader.GetString(4),
                                    ProductQuantity1=reader.GetInt32(5),
                                    QualifiedRate=reader.GetDouble(6).ToString()+"%",
                                    CheckQualifiedUserName=reader.GetString(7),
                                    WhetherQualified = reader.GetBoolean(8) ? "合格" : "不合格",
                                    CheckSpecialMining = reader.GetString(9) == "特采" ? "特采" : reader.GetBoolean(8)?"非特采":"退货",
                                    note=reader.GetString(10),
                                    CheckNumber=reader.IsDBNull(12)?0:reader.GetInt32(12),
                                    classType=reader.IsDBNull(13)?"":reader.GetString(13),
                                    ProblemDescription=reader.IsDBNull(14)?"":reader.GetString(14),
                                    AttributionResponsibility=reader.IsDBNull(15)?"":reader.GetString(15),
                                    Presentation8D=reader.IsDBNull(16)?"":reader.GetString(16)
                                });
                            }
                        }
                        return rlist;
                    }
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    using (SqlDataReader reader = SQLhelp.ExecuteReader(sql.ToString(), CommandType.Text))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                rlist.Add(new selectPurchaseReceiptCheckQualifiedModel()
                                {
                                    QualifiedTime2 = reader.GetDateTime(0),
                                    PurchaseNo = reader.GetString(1),
                                    MaterialCode = reader.GetString(2),
                                    MaterialName = reader.GetString(3),
                                    SupplierName = reader.GetString(4),
                                    ProductQuantity1 = reader.GetInt32(5),
                                    QualifiedRate = reader.GetDouble(6).ToString() + "%",
                                    CheckQualifiedUserName = reader.GetString(7),
                                    WhetherQualified = reader.GetBoolean(8)?"合格":"不合格",
                                    CheckSpecialMining = reader.GetString(9) == "特采" ? "特采" : reader.GetBoolean(8) ? "非特采" : "退货",
                                    note = reader.GetString(10),
                                    CheckNumber = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                                    classType = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                    ProblemDescription = reader.IsDBNull(14) ? "" : reader.GetString(14),
                                    AttributionResponsibility = reader.IsDBNull(15) ? "" : reader.GetString(15),
                                    Presentation8D = reader.IsDBNull(16) ? "" : reader.GetString(16)
                                });
                            }
                        }
                        return rlist;
                    }
                }
                catch
                {
                    throw;
                }
            }

        }
        /// <summary>
        /// 质检统计查询
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="SQLCommand"></param>
        /// <returns></returns>
        public List<StatisticsQueryModel> selectPurchaseReceiptCheckQualifiedStatisticsDal(int Number,DateTime beginTime,DateTime endTime,string SQLCommand)
        {
            string sql = SQLhelp.GetSQLCommand(SQLCommand);

            List<StatisticsQueryModel> list = new List<StatisticsQueryModel>();

            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@beginTime1",SqlDbType.DateTime){Value=beginTime},
                new SqlParameter("@endTime1",SqlDbType.DateTime){Value=endTime}
            };
            try
            {
                using (SqlDataReader reader = SQLhelp.ExecuteReader(sql, CommandType.Text, pms))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new StatisticsQueryModel()
                            {
                                SupplierName=reader.GetString(0),
                                sumNumber=reader.GetInt32(1),
                                FinalJudgment=reader.GetInt32(2),
                                QualifiedNumber=reader.GetInt32(3),
                                NotQualifiedNumber=reader.GetInt32(4),
                                QualifiedRate=reader.GetInt32(5).ToString()+"%",
                                MuBiao =reader.GetInt32(5)>=Number?"达标":"不达标"
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
    }
}   
