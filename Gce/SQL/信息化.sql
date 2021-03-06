USE [GPSTest]
GO
/****** Object:  Table [dbo].[Tb_Command]    Script Date: 01/26/2018 10:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_Command](
	[Command] [varchar](100) NOT NULL,
	[SQLstring] [varchar](8000) NOT NULL,
	[_MASK_FROM_V2] [timestamp] NOT NULL,
 CONSTRAINT [PK_Tb_Command] PRIMARY KEY CLUSTERED 
(
	[Command] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'CheckedPAbnormalInput', N'select COUNT(*) from PAbnormalInput where ZhiDan=@zhidan and ProblemDescription=@problem')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkedPEncodingSetting', N'select COUNT(*) from PEncodingSetting where BarcodeEncoding=@be ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkedPExceptionTypes', N'select COUNT(*) from PExceptionTypes where ExceptionTypes=@et')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkedPMCplan_table', N'select COUNT(*) from PMCplan_table where CorporateName=@corporatename and ZhiDan=@zhidan ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkedPStaffResume', N'select COUNT(*) from PStaffResume where Name=@name and WorkNumber=@worknumber')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkedPTypesWork', N'select COUNT(*) from PTypesWork where TypesWork=@typeswork ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'CheckProductionLinePC_title', N'select COUNT(*) from ProductionLinePC_title where LineName=@line')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkProductSet_New', N'select COUNT(*) from ProductSet_New where ProductClass=@productcalss and Stations=@stations ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkProductSet_New_title', N'select COUNT(*) from ProductSet_New_title where ProductClass=@productcalss')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'checkUserNeme', N'select COUNT(UserName) from PUsers where UserName=@username')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'ConditionsSelectPEncodingSetting', N'select * from PEncodingSetting where BarcodeEncoding=@be ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteClassType_table', N' delete ClassType_table where classType=@classType ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePAbnormalInput', N'delete PAbnormalInput where ID=@id ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePCapacityConfiguration', N'delete PCapacityConfiguration where ZhiDan=@zd ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePEncodingSetting', N'delete PEncodingSetting where BarcodeEncoding=@be ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePMCplan_table', N'delete PMCplan_table where CorporateName=@corporatename and ZhiDan=@zhidan ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePRequiredTime_Detailed', N'delete PRequiredTime_Detailed where ProductType=@producttype and RequiredTimeGUID=@requiretimeguid1 ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteProductionLinePC', N'delete ProductionLinePC where Pcname=@pcname and ProductType=@producttype and LineName=@linename and CompanyName=@companyname')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteProductionLinePC_title', N'delete ProductionLinePC_title where LineName=@ln and CompanyName=@cn ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteProductSet_New', N'delete ProductSet_New where ProductClass=@productcalss ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteProductSet_New_title', N'delete ProductSet_New_title where ProductClass=@productcalss ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteProductSet_NewStations', N'delete ProductSet_New where ProductClass=@productcalss and Stations=@stations ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePStaffResume', N'delete PStaffResume where Name=@name and WorkNumber=@worknumber ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePTypesWork', N'delete PTypesWork where TypesWork=@typeswork ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePurchaseReceipt', N'delete PurchaseReceipt where PurchaseReceiptID=@PurchaseReceiptID ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePurchaseReceiptRow', N'delete PurchaseReceipt where PurchaseReceiptID=(select  top 1 PurchaseReceiptID  from PurchaseReceipt where PurchaseNo=@pn and SupplierName=@sn and BatchNo=@bn
and MaterialCode=@mc and MaterialName=@mn and MaterialSpecifications=@ms and ProductQuantity=@pq
and CheckAudit=0 and CheckQualified=0 and CheckSpecialMining=0 and UpdateTime >= CONVERT(varchar(10), getdate(), 120))')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePWarehouseTable_title', N'delete PWarehouseTable_title where ID=@ID  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deletePWorkSchedule', N'delete from PWorkSchedule where CompanyName=@cn')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteTimeAttendance_AttendanceInformation_machine', N'  delete TimeAttendance_AttendanceInformation_machine where MachineID=@MachineID   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteTimeAttendance_Department', N' delete TimeAttendance_Department where DepartmentNo=@DepartmentNo ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'deleteTimeAttendance_Employee_File1', N' delete TimeAttendance_Employee_File where JobNumber=@JobNumber    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertClassType_table', N' insert into ClassType_table(classType) values(@classType) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPAbnormalInput', N'insert into PAbnormalInput(ZhiDan,SchoolPersonnel,CompanyName,LineOf,WorkStation,ProblemDescription,ExceptionTypes,Node1,UpdateTime)
values(@zhidan,@school,@company,@line,@workstation,@problem,@exception,@node,GETDATE())')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'InsertPCapacityConfiguration', N'insert into PCapacityConfiguration(ZhiDan,ProductClass) values(@zd,@pc)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPEncodingSetting', N'insert into PEncodingSetting(BarcodeEncoding,ProblemDescription,ES_ExceptionTypes) values(@be,@pd,@eet)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPExceptionTypes', N'insert into PExceptionTypes(ExceptionTypes) values(@et)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPMCplan_table', N'insert into PMCplan_table(CorporateName,ZhiDan,TotalOrder,RequiredTimeGUID,CustomerName,ShippingDate,Remarks,CreationTime,UpdateTime)
values(@corporatename,@zhidan,@totalorder,@requiretimeguid,@customername,@shippingdate,@remarks,GETDATE(),GETDATE())
')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPRequiredTime_Detailed', N'insert into PRequiredTime_Detailed(ProductType,RequiredTimeGUID,RequiredTime) values(@producttype,@requiretimeguid,@requiredtime) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'InsertProductionEfficiencySummary', N'insert into ProductionEfficiencySummary(ProductionClass,ZhiDan,SoftModel,  ProductClass,Hours,actualHours,Ratio,sumHours,sum,FailureRate,FailureNuber,UpdateTime)  values(@ProductionClass,@ZhiDan,@SoftModel,@ProductClass,@Hours,@actualHours,@Ratio  ,@sumHours,@sum,@FailureRate,@FailureNuber,getdate())')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertProductionLinePC', N'insert into ProductionLinePC(Pcname,ProductType,LineName,CompanyName) values(@pcname,@producttype,@linename,@companyname)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertProductionLinePC_title', N'insert into ProductionLinePC_title(LineName,CompanyName) values(@ln,@cn)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertProductSet_New', N'insert into ProductSet_New(ProductClass,Stations,EfficiencyQuantity,TheNumberOf,UpdataTime) values(@productcalss,@stations,@efficiencyquantity,@thenumberof,GETDATE())')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertProductSet_New_title', N'insert into ProductSet_New_title(ProductClass,UpdataTime) values(@productcalss,GETDATE()) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPStaffResume', N'insert into PStaffResume(Name,WorkNumber,Gender,Age,WorkTypes,Levels,FactoryTime,CompanyName,UpdateTime)    
values(@name,@worknumber,@gender,@age,@worktype,@levels,@factorytime,@companyname,GETDATE())')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPTypesWork', N'insert into PTypesWork(TypesWork) values(@typeswork) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPurchaseReceipt', N'insert into PurchaseReceipt(PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity,ProductQuantity1,CheckAudit,CheckQualified,CheckSpecialMining,note,ScanningTime,UpdateTime,UpdateTime1,UserName,OrderState)    values(@PurchaseReceiptID,@PurchaseNo,@SupplierName,@BatchNo,@MaterialCode,@MaterialName,@MaterialSpecifications,@ProductQuantity,@ProductQuantity1,@CheckAudit,@CheckQualified,@CheckSpecialMining,@note,@ScanningTime,@UpdateTime,GETDATE(),@UserName,@OrderState)   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPUsers_Function', N' insert into PUsers_Function(UserName,FunctionName,FunctionJurisdiction,FunctionGUID) values(@UserName,@FunctionName,@FunctionJurisdiction,@FunctionGUID) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPUsers_Function_Detailed', N' insert into PUsers_Function_Detailed(UserName,FunctionName,FunctionJurisdiction,FunctionGUID) values(@UserName,@FunctionName,@FunctionJurisdiction,@FunctionGUID) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPWarehouseTable_Detailed', N'insert into PWarehouseTable_Detailed(PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity,note,UpdateTime,StorageAddress,UserName)
values(@PurchaseReceiptID,@PurchaseNo,@SupplierName,@BatchNo,@MaterialCode,@MaterialName,@MaterialSpecifications,@ProductQuantity,@note,GETDATE(),@StorageAddress,@UserName)  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPWarehouseTable_PickingOut', N'insert into PWarehouseTable_PickingOut(PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity,note,UpdateTime,StorageAddress,UserName)
values(@PurchaseReceiptID,@PurchaseNo,@SupplierName,@BatchNo,@MaterialCode,@MaterialName,@MaterialSpecifications,@ProductQuantity,@note,GETDATE(),@StorageAddress,@UserName) 
  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPWarehouseTable_ReturnGoods', N'insert into PWarehouseTable_ReturnGoods(PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity,note,UpdateTime,UserName)
values(@PurchaseReceiptID,@PurchaseNo,@SupplierName,@BatchNo,@MaterialCode,@MaterialName,@MaterialSpecifications,@ProductQuantity,@note,GETDATE(),@UserName)  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPWarehouseTable_title', N'insert into PWarehouseTable_title(ID,WarehouseName,FID) values(@ID,@WarehouseName,@FID) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertPWorkSchedule', N'insert into PWorkSchedule(CompanyName,MorningOnWorkTime,MorningUnderWorkTime,AfternoonOnWorkTime,AfternoonUnderWorkTime,NightOnWorkTime,UpdateTime,Flag)  values(@companyname,@moringon,@morningun,@afteron,@afterun,@nighton,GETDATE(),@flag)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertTimeAttendance_AttendanceInformation_machine', N' insert into TimeAttendance_AttendanceInformation_machine(MachineID,ComInterface,BaudRate,IPAddress,MachinePosition,MachineUse)
values(@MachineID,@ComInterface,@BaudRate,@IPAddress,@MachinePosition,@MachineUse)  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertTimeAttendance_AttendanceSchedule', N'   insert into TimeAttendance_AttendanceSchedule(JobNumber,Name,AttendanceTime,UpdateTime,MachineID,MachinePosition)
 values(@JobNumber,@Name,@AttendanceTime,@UpdateTime,@MachineID,@MachinePosition) ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertTimeAttendance_Department', N'insert into TimeAttendance_Department(DepartmentNo,DepartmentName,ParentDepartmentNo,ParentDepartmentName,NumberOfStaff,InTheNumberOfStaff,ExceedNumberOfStaff,note)
values(@DepartmentNo,@DepartmentName,@ParentDepartmentNo,@ParentDepartmentName,@NumberOfStaff,@InTheNumberOfStaff,@ExceedNumberOfStaff,@note)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertTimeAttendance_Employee_File', N'  insert into TimeAttendance_Employee_File(JobNumber,ChineseName,Gender,Education,Post,EmployeeCategory,
EntryDate,DepartmentNo,DepartmentName,GroupNo,GroupName,Line_No,LineName,IDNumber,IssuingAuthority,DateOfIssue,IDTermOfValidity,BirthDay,PlaceOrigin,Nation,
HomeAddress,AttendanceData,AttendanceRegulations,CompletionData,ProbationPeriod,SalaryCategory,Introducer,PositionsGrade,Rank,LogicalCardNumber,PhysicalCardNumber,
PhoneNumber,EmergencyContact,EmergencyContactPhone,EmErgencyContactAddress,PaymentMode,Height,Weight,LeftEyeVision,RightEyeVision,note,ContractNumber,ContractSigning,
ExpirationContract,IDCardPeriod,Job,leaveDate,TurnoverType,ReasonsForLeaving,Blacklist,married,FreeCard,OvertimeApplication,createddate,FilingMan,modificationDate,
Modifier,workType,workGrade,Photo,MinimalSector) 
values(@JobNumber,@ChineseName,@Gender,@Education,@Post,@EmployeeCategory,
@EntryDate,@DepartmentNo,@DepartmentName,@GroupNo,@GroupName,@Line_No,@LineName,@IDNumber,@IssuingAuthority,@DateOfIssue,@IDTermOfValidity,@BirthDay,@PlaceOrigin,@Nation,
@HomeAddress,@AttendanceData,@AttendanceRegulations,@CompletionData,@ProbationPeriod,@SalaryCategory,@Introducer,@PositionsGrade,@Rank,@LogicalCardNumber,@PhysicalCardNumber,
@PhoneNumber,@EmergencyContact,@EmergencyContactPhone,@EmErgencyContactAddress,@PaymentMode,@Height,@Weight,@LeftEyeVision,@RightEyeVision,@note,@ContractNumber,@ContractSigning,
@ExpirationContract,@IDCardPeriod,@Job,@leaveDate,@TurnoverType,@ReasonsForLeaving,@Blacklist,@married,@FreeCard,@OvertimeApplication,@createddate,@FilingMan,@modificationDate,
@Modifier,@workType,@workGrade,@Photo,@MinimalSector)     ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertTimeAttendance_Employee_File1', N'   insert into TimeAttendance_Employee_File(JobNumber,ChineseName,Gender,Education,Post,EmployeeCategory,
EntryDate,DepartmentNo,DepartmentName,GroupNo,GroupName,Line_No,LineName,IDNumber,IssuingAuthority,DateOfIssue,IDTermOfValidity,BirthDay,PlaceOrigin,Nation,
HomeAddress,AttendanceData,AttendanceRegulations,CompletionData,ProbationPeriod,SalaryCategory,Introducer,PositionsGrade,Rank,LogicalCardNumber,PhysicalCardNumber,
PhoneNumber,EmergencyContact,EmergencyContactPhone,EmErgencyContactAddress,PaymentMode,Height,Weight,LeftEyeVision,RightEyeVision,note,ContractNumber,ContractSigning,
ExpirationContract,IDCardPeriod,Job,leaveDate,TurnoverType,ReasonsForLeaving,Blacklist,married,FreeCard,OvertimeApplication,createddate,FilingMan,modificationDate,
Modifier,workType,workGrade,Photo,MinimalSector) 
values(@JobNumber,@ChineseName,@Gender,@Education,@Post,@EmployeeCategory,
@EntryDate,@DepartmentNo,@DepartmentName,@GroupNo,@GroupName,@Line_No,@LineName,@IDNumber,@IssuingAuthority,@DateOfIssue,@IDTermOfValidity,@BirthDay,@PlaceOrigin,@Nation,
@HomeAddress,@AttendanceData,@AttendanceRegulations,@CompletionData,@ProbationPeriod,@SalaryCategory,@Introducer,@PositionsGrade,@Rank,@LogicalCardNumber,@PhysicalCardNumber,
@PhoneNumber,@EmergencyContact,@EmergencyContactPhone,@EmErgencyContactAddress,@PaymentMode,@Height,@Weight,@LeftEyeVision,@RightEyeVision,@note,@ContractNumber,@ContractSigning,
@ExpirationContract,@IDCardPeriod,@Job,@leaveDate,@TurnoverType,@ReasonsForLeaving,@Blacklist,@married,@FreeCard,@OvertimeApplication,GETDATE(),@FilingMan,@modificationDate,
@Modifier,@workType,@workGrade,@Photo,@MinimalSector)       ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'insertUsers', N'insert into PUsers(UserName,UserPassword,systemAdimin,Limite,Department,AddUser)     values(@UserName,@UserPassword,@systemAdimin,@Limite,@Department,@AddUser)  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'LikeSelectTimeAttendance_Employee_File1', N'  select* from TimeAttendance_Employee_File
where JobNumber like @JobNumber or ChineseName like @JobNumber       ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'PWarehouseTable_DetailedPWarehouseTable_PickingOutSUM', N'select  
 (select ISNULL(SUM(ProductQuantity),0) from PWarehouseTable_Detailed
 where MaterialName=@MaterialName)
 -
  (select ISNULL(SUM(ProductQuantity),0) from PWarehouseTable_PickingOut
 where MaterialName=@MaterialName)  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'PWarehouseTable_DetailedPWarehouseTable_PickingOutSUMTop1', N'  select top 1 PurchaseNo, SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,  (select ISNULL(SUM(ProductQuantity),0) from PWarehouseTable_Detailed   where MaterialName=@MaterialName)   -    
			(select ISNULL(SUM(ProductQuantity),0) from PWarehouseTable_PickingOut   where MaterialName=@MaterialName) as ProductQuantity,note
from PWarehouseTable_Detailed  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectAllTimeAttendance_Employee_File1', N' select* from TimeAttendance_Employee_File    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectAllTimeAttendance_Employee_File1ParentDepartmentNo', N'  select  DepartmentNo,DepartmentName from TimeAttendance_Department where ParentDepartmentNo=(select DepartmentNo from TimeAttendance_Department where ParentDepartmentNo='''')    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectAssembly', N'declare @flg bit  
set @flg=@f  
if(@flg=1)  
begin  
select ZhiDan,Computer,TestTime,SoftModel 
from Gps_AutoTest_Result
where  Computer is not null  and TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end  
else 
begin  
select ZhiDan,Computer,TestTime,SoftModel
from Gps_AutoTest_Result 
where  TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectAssemblySMT', N'declare @flg bit  
set @flg=@f  
if(@flg=1)  
begin  
select ZhiDan,Computer,TestTime ,SoftModel
from Gps_AutoTest_Result2 
where Computer is not null  and TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end  
else  
begin  
select ZhiDan,Computer,TestTime,SoftModel 
from Gps_AutoTest_Result2 
where  TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end
')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectClassType_table', N' select* from ClassType_table ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectColumn_name', N'declare @objid int,@objname char(40)
set @objname = ''ProductSet''
select @objid = id from sysobjects where id = object_id(@objname)
select ''Column_name'' = name from syscolumns where id = @objid order by colid')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectConditionsQueryPStaffResume', N'select Name,WorkNumber from PStaffResume  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectConditionsQueryPStaffResume2', N'select Name,WorkNumber,CompanyName from PStaffResume')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectCountProductionLinePC', N'select COUNT(*) from  ProductionLinePC 
where Pcname=@pcname and ProductType=@producttype and LineName=@linename and CompanyName=@companyname')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectDistinctPUsers', N' select distinct Department from PUsers   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectErrorMessage1', N'declare @zhidan1 varchar(100)
set @zhidan1=@zhidan
if @zhidan1<>'''' 
begin
select ZhiDan,SoftModel,Version,SN,ErrorMessage1,Computer,TestTime 
from LTestLogMessage 
where ZhiDan=@zhidan1 and ErrorMessage1 is not null and TestTime>=@begintime and TestTime<=@endtime 
order by Computer + ErrorMessage1
end
else
begin
select ZhiDan,SoftModel,Version,SN,ErrorMessage1,Computer,TestTime 
from LTestLogMessage 
where  ErrorMessage1 is not null and TestTime>=@begintime and TestTime<=@endtime 
order by Computer + ErrorMessage1
end  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectErrorMessage2', N'declare @zhidan1 varchar(100)
set @zhidan1=@zhidan
if @zhidan1<>''''
begin
 select ZhiDan,SoftModel,Version,SN,ErrorMessage2,Computer2,TestTime 
 from LTestLogMessage   
 where ZhiDan=@zhidan1 and ErrorMessage2 is not null and TestTime>=@begintime and TestTime<=@endtime 
 order by Computer2 + ErrorMessage2  
end
else
begin
 select ZhiDan,SoftModel,Version,SN,ErrorMessage2,Computer2,TestTime 
 from LTestLogMessage   
 where ErrorMessage2 is not null and TestTime>=@begintime and TestTime<=@endtime 
 order by Computer2 + ErrorMessage2  
end ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectErrorMessage3', N'declare @zhidan1 varchar(100)  
set @zhidan1=@zhidan  
if @zhidan1<>''''   
begin  
select ZhiDan,SoftModel,Version,SN,ErrorMessage4,Computer4,TestTime   
from LTestLogMessage   
where ZhiDan=@zhidan1 and ErrorMessage4 is not null and TestTime>=@begintime and TestTime<=@endtime   
order by Computer4 + ErrorMessage4  end  
else  
begin  
select ZhiDan,SoftModel,Version,SN,ErrorMessage4,Computer4,TestTime   
from LTestLogMessage   
where  ErrorMessage4 is not null and TestTime>=@begintime and TestTime<=@endtime   
order by Computer4 + ErrorMessage4  end   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectErrorMessage4', N'declare @zhidan1 varchar(100)
set @zhidan1=@zhidan
if @zhidan1<>''''
begin 
select ZhiDan,SoftModel,Version,SN,ErrorMessage3,Computer3,TestTime 
from LTestLogMessage 
where ZhiDan=@zhidan1 and ErrorMessage3 is not null and TestTime>=@begintime and TestTime<=@endtime 
order by Computer3 + ErrorMessage3  
end
else
begin
select ZhiDan,SoftModel,Version,SN,ErrorMessage3,Computer3,TestTime 
from LTestLogMessage 
where  ErrorMessage3 is not null and TestTime>=@begintime and TestTime<=@endtime 
order by Computer3 + ErrorMessage3 
end   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'SelectIncomingInspection', N'select* from PurchaseReceipt pr where pr.CheckAudit=0')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectLPrintMarkData', N'  declare @flg bit    
set @flg=@f    
if(@flg=1)    
begin    
select ZhiDan,Computer,TestTime,SoftModel   
from LPrintMarkData  
where  Computer is not null  and TestTime>=@begintime and TestTime<=@endtime   
order by TestTime    
end    
else   
begin    
select ZhiDan,Computer,TestTime,SoftModel  
from LPrintMarkData   
where  TestTime>=@begintime and TestTime<=@endtime   
order by TestTime    end ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectLTestLogMessage', N'select COUNT(*) from LTestLogMessage llm where  llm.TestTime>=@TimeBegin and llm.TestTime<=@TimeEnd and llm.ErrorMessage1 is not null   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectLTestLogMessage2', N'select COUNT(*) from LTestLogMessage llm where  llm.TestTime>=@TimeBegin and llm.TestTime<=@TimeEnd and llm.ErrorMessage2 is not null    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectLTestLogMessage3', N'select COUNT(*) from LTestLogMessage llm   where  llm.TestTime>=@TimeBegin and llm.TestTime<=@TimeEnd and llm.ErrorMessage4 is not null ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectLTestLogMessageSMT', N'select COUNT(*) from LTestLogMessage llm where  llm.TestTime>=@TimeBegin and llm.TestTime<=@TimeEnd and llm.ErrorMessage3 is not null  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPAbnormalInput', N'  select* from PAbnormalInput  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPackaging', N'declare @flg bit  
set @flg=@f  
if(@flg=1)  
begin  
select ZhiDan,Computer,TestTime ,SoftModel
from Gps_CartonBoxTwenty_Result 
where  Computer is not null  and TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end  
else  
begin  
select ZhiDan,Computer,TestTime,SoftModel 
from Gps_CartonBoxTwenty_Result 
where TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end
')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPCapacityConfiguration', N'select * from  PCapacityConfiguration ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPCapacityConfigurationNumber', N' select COUNT(*) from PCapacityConfiguration where ZhiDan=@zhidan  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPCapacityConfigurationProductClass', N'select ProductClass from PCapacityConfiguration where ZhiDan =@zd')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPEncodingSetting', N'select* from PEncodingSetting')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPExceptionTypes', N'select* from PExceptionTypes')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPFunctionMenuFID0', N'select * from PFunctionMenu where FID in (select ID from PFunctionMenu where ID in (select ID from PFunctionMenu where FID=''0'')) order by ID ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPFunctionMenuFID00', N' select * from PFunctionMenu where FID=''0''  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPFunctionMenuFID01', N' select * from PFunctionMenu where FID not in(select ID from PFunctionMenu where ID in (select ID from PFunctionMenu where FID=''0''))and FID<>''0'' order by ID ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPMCplan_table', N'select * from PMCplan_table ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPRequiredTime_Detailed', N'select * from PRequiredTime_Detailed ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductClass', N'select* from ProductSet where ProductClass=@pc')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductionLinePC', N'select * from ProductionLinePC where LineName=@ln')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductionLinePC_title', N'select * from ProductionLinePC_title')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductionLinePC_titleLineName', N'select LineName from ProductionLinePC_title where CompanyName=@companyname')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductionType', N'select* from ProductionType')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductionTypeOnWorkTimeType', N'   declare @OnWorkTimeType1 varchar(50)
 set @OnWorkTimeType1=@OnWorkTimeType
 if @OnWorkTimeType1<>''''
 begin
  select ProductType from ProductionType where OnWorkTimeType=@OnWorkTimeType1 
 end
 else
 begin
 select ProductType from ProductionType
 end  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductionTypeProductType', N'select ProductType from ProductionType where OnWorkTimeType=@onwork or OnWorkTimeTypeNight=@onwork')
GO
print 'Processed 100 total records'
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductPerformanceAssembly', N'declare @bit bit,@order varchar(100),@softmodel varchar(20),@timebegin datetime,@timeend datetime  
set @bit=@bt  
set @order=@ord  
set @softmodel=@sof  
set @timebegin=@begin  
set @timeend=@end  
if @bit = 1  
begin   
if @order<>'''' and @softmodel=''''   
begin    
select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel,Computer  
from Gps_AutoTest_Result         
where Result<>0 and ZhiDan=@order    
order by AssemblyTime,AssemblyOrder   
end   
if @order='''' and @softmodel<>''''   
begin    
select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel,Computer  
from Gps_AutoTest_Result         
where Result<>0 and SoftModel=@softmodel    
order by AssemblyTime,AssemblyOrder   
end   
if @order<>'''' and @softmodel<>''''   
begin    
select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel,Computer  
from Gps_AutoTest_Result         
where Result<>0 and SoftModel=@softmodel and ZhiDan=@order    
order by AssemblyTime,AssemblyOrder   
end  
end  
else  
begin   
if @order<>'''' and @softmodel=''''   
begin    
select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel,Computer  
from Gps_AutoTest_Result        
 where Result<>0 and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
 order by AssemblyTime,AssemblyOrder   
 end   
 if @order='''' and @softmodel<>''''   
 begin    
 select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel,Computer  
 from Gps_AutoTest_Result         
 where Result<>0 and SoftModel=@softmodel and TestTime>=@timebegin and TestTime<=@timeend     
 order by AssemblyTime,AssemblyOrder   
 end   
 if @order<>'''' and @softmodel<>''''   
 begin    
 select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel,Computer  
 from Gps_AutoTest_Result         
 where Result<>0 and SoftModel=@softmodel and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
 order by AssemblyTime,AssemblyOrder   
 end  
 if @order='''' and @softmodel=''''
 begin
   select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel,Computer  
 from Gps_AutoTest_Result    
 where Result<>0 and TestTime>=@timebegin and TestTime<=@timeend     
 order by AssemblyTime,AssemblyOrder   
 end
 end   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductPerformanceAssemblySMT', N'  declare @bit bit,@order varchar(100),@softmodel varchar(20),@timebegin datetime,@timeend datetime  
 set @bit=@bt  set @order=@ord  set @softmodel=@sof  set @timebegin=@begin  set @timeend=@end  
 if @bit = 1  
 begin   
 if @order<>'''' and @softmodel=''''   
 begin    
 select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel ,Computer 
 from Gps_AutoTest_Result2           
 where Result<>0 and ZhiDan=@order    
 order by AssemblyTime,AssemblyOrder   
 end   
 if @order='''' and @softmodel<>''''   
 begin    
 select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel ,Computer 
 from Gps_AutoTest_Result2           
 where Result<>0 and SoftModel=@softmodel    
 order by AssemblyTime,AssemblyOrder   
 end   
 if @order<>'''' and @softmodel<>''''   
 begin    
 select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel ,Computer 
 from Gps_AutoTest_Result2           
 where Result<>0 and SoftModel=@softmodel and ZhiDan=@order    
 order by AssemblyTime,AssemblyOrder   
 end  
 end  
 else  
 begin   
 if @order<>'''' and @softmodel=''''   
 begin    
 select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel ,Computer 
 from Gps_AutoTest_Result2         
  where Result<>0 and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
  order by AssemblyTime,AssemblyOrder   
  end   
  if @order='''' and @softmodel<>''''   
  begin    
  select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel ,Computer 
  from Gps_AutoTest_Result2           
  where Result<>0 and SoftModel=@softmodel and TestTime>=@timebegin and TestTime<=@timeend     
  order by AssemblyTime,AssemblyOrder   
  end   
  if @order<>'''' and @softmodel<>''''   
  begin    
  select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel ,Computer 
  from Gps_AutoTest_Result2          
  where Result<>0 and SoftModel=@softmodel and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
  order by AssemblyTime,AssemblyOrder   
  end  
  if @order='''' and @softmodel=''''
  select ZhiDan as AssemblyOrder,TestTime as AssemblyTime ,SoftModel as AssemblySoftModel ,Computer 
  from Gps_AutoTest_Result2  
  where Result<>0 and TestTime>=@timebegin and TestTime<=@timeend     
  order by AssemblyTime,AssemblyOrder   
  end    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductPerformanceLPrintMarkData', N'  declare @bit bit,@order varchar(100),@softmodel varchar(20),@timebegin datetime,@timeend datetime     
  set @bit=@bt  set @order=@ord  set @softmodel=@sof  set @timebegin=@begin  set @timeend=@end     
  if @bit = 1     
  begin      
  if @order<>'' and @softmodel=''      
  begin       
  select ZhiDan as PrinMarkZhiDan,TestTime as PrinMarTime ,SoftModel as PrinMarSoftModel ,Computer    
  from LPrintMarkData              
  where  ZhiDan=@order       
  order by PrinMarTime,PrinMarkZhiDan      
  end      
  if @order='' and @softmodel<>''      
  begin       
  select ZhiDan as PrinMarkZhiDan,TestTime as PrinMarTime ,SoftModel as PrinMarSoftModel ,Computer    
  from LPrintMarkData              
  where SoftModel=@softmodel       
  order by PrinMarTime,PrinMarkZhiDan      
  end      
  if @order<>'' and @softmodel<>''      
  begin       
  select ZhiDan as PrinMarkZhiDan,TestTime as PrinMarTime ,SoftModel as PrinMarSoftModel ,Computer    
  from LPrintMarkData               
  where  SoftModel=@softmodel and ZhiDan=@order       
  order by PrinMarTime,PrinMarkZhiDan      
  end     
  end     
  else     
  begin      
  if @order<>'' and @softmodel=''      
  begin       
  select ZhiDan as PrinMarkZhiDan,TestTime as PrinMarTime ,SoftModel as PrinMarSoftModel ,Computer    
  from LPrintMarkData             
  where  ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend         
  order by PrinMarTime,PrinMarkZhiDan       
  end       
  if @order='' and @softmodel<>''       
  begin        
  select ZhiDan as PrinMarkZhiDan,TestTime as PrinMarTime ,SoftModel as PrinMarSoftModel ,Computer    
  from LPrintMarkData              
  where  SoftModel=@softmodel and TestTime>=@timebegin and TestTime<=@timeend         
  order by PrinMarTime,PrinMarkZhiDan       
  end       
  if @order<>'' and @softmodel<>''       
  begin        
  select ZhiDan as PrinMarkZhiDan,TestTime as PrinMarTime ,SoftModel as PrinMarSoftModel ,Computer    
  from LPrintMarkData             
  where  SoftModel=@softmodel and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend         
  order by PrinMarTime,PrinMarkZhiDan       
  end      
  if @order='' and @softmodel=''    
  select ZhiDan as PrinMarkZhiDan,TestTime as PrinMarTime ,SoftModel as PrinMarSoftModel ,Computer    
  from LPrintMarkData      
  where TestTime>=@timebegin and TestTime<=@timeend         
  order by PrinMarTime,PrinMarkZhiDan       
  end    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductPerformancePackaging', N' declare @bit bit,@order varchar(100),@softmodel varchar(20),@timebegin datetime,@timeend datetime  
 set @bit=@bt  set @order=@ord  set @softmodel=@sof  set @timebegin=@begin  set @timeend=@end  
 if @bit = 1  
 begin   
 if @order<>'''' and @softmodel=''''   
 begin    
 select ZhiDan as PackagingOrder, TestTime as PackagingTime,SoftModel as PackagingSoftModel ,Computer   
 from Gps_CartonBoxTwenty_Result           
 where  ZhiDan=@order    
 order by PackagingTime,PackagingOrder   
 end   
 if @order='''' and @softmodel<>''''   
 begin    
 select ZhiDan as PackagingOrder, TestTime as PackagingTime,SoftModel as PackagingSoftModel ,Computer   
 from Gps_CartonBoxTwenty_Result         
 where  SoftModel=@softmodel    
 order by PackagingTime,PackagingOrder   
 end   
 if @order<>'''' and @softmodel<>''''   
 begin    
 select ZhiDan as PackagingOrder, TestTime as PackagingTime,SoftModel as PackagingSoftModel ,Computer   
 from Gps_CartonBoxTwenty_Result          
 where  SoftModel=@softmodel and ZhiDan=@order    
 order by PackagingTime,PackagingOrder   
 end  
 end  
 else  
 begin   
 if @order<>'''' and @softmodel=''''   
 begin    
 select ZhiDan as PackagingOrder, TestTime as PackagingTime,SoftModel as PackagingSoftModel ,Computer   
 from Gps_CartonBoxTwenty_Result          
 where ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
 order by PackagingTime,PackagingOrder   
 end   
 if @order='''' and @softmodel<>''''   
 begin    
 select ZhiDan as PackagingOrder, TestTime as PackagingTime,SoftModel as PackagingSoftModel ,Computer   
 from Gps_CartonBoxTwenty_Result          
 where  SoftModel=@softmodel and TestTime>=@timebegin and TestTime<=@timeend     
 order by PackagingTime,PackagingOrder   
 end   
 if @order<>'''' and @softmodel<>''''   
 begin    
 select ZhiDan as PackagingOrder, TestTime as PackagingTime,SoftModel as PackagingSoftModel ,Computer   
 from Gps_CartonBoxTwenty_Result        
 where  SoftModel=@softmodel and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
 order by PackagingTime,PackagingOrder   
 end  
 if @order='''' and @softmodel=''''
 begin
 select ZhiDan as PackagingOrder, TestTime as PackagingTime,SoftModel as PackagingSoftModel ,Computer   
 from Gps_CartonBoxTwenty_Result
 where TestTime>=@timebegin and TestTime<=@timeend
 order by PackagingTime,PackagingOrder
 end
 end  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductPerformanceTest', N'declare @bit bit,@order varchar(100),@softmodel varchar(20),@timebegin datetime,@timeend datetime  
 set @bit=@bt  set @order=@ord  set @softmodel=@sof  set @timebegin=@begin  set @timeend=@end  
 if @bit = 1  
 begin   
 if @order<>'''' and @softmodel=''''  
 begin    
 select ZhiDan as TestOrder,TestTime as TestTime , SoftModel as TestSoftModel,Computer   
 from Gps_CoupleTest_Result           
 where Result<>0 and ZhiDan=@order    
 order by TestTime,TestOrder   
 end   if @order='''' and @softmodel<>''''   
 begin    
 select ZhiDan as TestOrder,TestTime as TestTime , SoftModel as TestSoftModel,Computer  
 from Gps_CoupleTest_Result            
 where Result<>0 and SoftModel=@softmodel    
 order by TestTime,TestOrder   
 end   
 if @order<>'''' and @softmodel<>''''   
 begin    
 select ZhiDan as TestOrder,TestTime as TestTime , SoftModel as TestSoftModel,Computer   
 from Gps_CoupleTest_Result       
 where Result<>0 and SoftModel=@softmodel and ZhiDan=@order    
 order by TestTime,TestOrder   
 end  
 end  
 else  
 begin   
 if @order<>'''' and @softmodel=''''  
 begin    
 select ZhiDan as TestOrder,TestTime as TestTime , SoftModel as TestSoftModel,Computer   
 from Gps_CoupleTest_Result      
 where Result<>0 and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
 order by TestTime,TestOrder   
 end   
 if @order='''' and @softmodel<>''''   
 begin    
 select ZhiDan as TestOrder,TestTime as TestTime , SoftModel as TestSoftModel,Computer   
 from Gps_CoupleTest_Result         
 where Result<>0 and SoftModel=@softmodel and TestTime>=@timebegin and TestTime<=@timeend     
 order by TestTime,TestOrder   
 end   
 if @order<>'''' and @softmodel<>''''   
 begin    
 select ZhiDan as TestOrder,TestTime as TestTime , SoftModel as TestSoftModel,Computer   
 from Gps_CoupleTest_Result        
 where Result<>0 and SoftModel=@softmodel and ZhiDan=@order and TestTime>=@timebegin and TestTime<=@timeend     
 order by TestTime,TestOrder   
 end  
 if @order='''' and @softmodel=''''
 begin
 select ZhiDan as TestOrder,TestTime as TestTime , SoftModel as TestSoftModel,Computer   
 from Gps_CoupleTest_Result
 where Result<>0 and TestTime>=@timebegin and TestTime<=@timeend     
 order by TestTime,TestOrder
 end
 end ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductSet_New', N'select * from ProductSet_New')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductSet_New_title', N'select* from ProductSet_New_title')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductSet_New_titleTop1', N'select top 1 ProductClass from ProductSet_New_title ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductSet_NewClass', N'select * from ProductSet_New where ProductClass=@productclass ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductSet_NewForProductClass', N'select* from ProductSet_New where ProductClass=(select ProductClass from PCapacityConfiguration where ZhiDan=@zhidan)')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'SelectProductTop1', N'select top 1 * from ProductSet ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectProductType', N'select ProductType from ProductionType')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPStaffResume', N'select* from PStaffResume ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPTypesWork', N'select* from PTypesWork ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseNoPurchaseReceipt', N' select PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity,ProductQuantity1,CheckQualified,CheckQualifiedUserName,note,UpdateTime1,OrderState  
 from PurchaseReceipt 
 where  CheckQualified=''未检测'' order by OrderState desc    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseReceiptCheckQualified', N' select QualifiedTime2,PurchaseNo,MaterialCode,MaterialName,SupplierName,ProductQuantity1,   QualifiedRate,CheckQualifiedUserName,WhetherQualified,
 CheckSpecialMining,note,CheckQualified,CheckNumber,classType,ProblemDescription,AttributionResponsibility,Presentation8D    
 from PurchaseReceipt       
 where CheckQualified=''已检测''     ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseReceiptCheckQualifiedStatistics', N'  create table #table(
	SupplierName varchar(80),
	sumNumber int,
	FinalJudgment int ,
	QualifiedNumber int,
	NotQualifiedNumber int,
	QualifiedRate int,
 ) 
 DECLARE @SupplierName varchar(80),@Number1 int,@Number2 int,@Number3 int,@Number4 int,@begintime datetime,@endtime datetime
 set @begintime=@beginTime1 set @endtime=@endTime1
 declare  my_cursor
 cursor  for 
 
 select distinct SupplierName from PurchaseReceipt where CheckQualified=''已检测'' and QualifiedTime2>=@begintime and QualifiedTime2<=@endtime
 
 open my_cursor
FETCH NEXT FROM my_cursor into @SupplierName 
while @@FETCH_STATUS = 0
begin
 

 set @Number1 = (select COUNT(SupplierName) from PurchaseReceipt  where CheckQualified=''已检测'' and SupplierName = @SupplierName)
 set @Number2 = (select COUNT(SupplierName) from PurchaseReceipt  where CheckQualified=''已检测'' and SupplierName = @SupplierName and WhetherQualified=0)
 set @Number3 = (select COUNT(SupplierName) from PurchaseReceipt  where CheckQualified=''已检测'' and SupplierName = @SupplierName and WhetherQualified=1)
 set @Number4= Round(1-(CONVERT(float,@Number2)/CONVERT(float,@Number1)),2)*100
 
 insert into #table(SupplierName,sumNumber,FinalJudgment,QualifiedNumber,NotQualifiedNumber,QualifiedRate) values(@SupplierName,@Number1,@Number2,@Number3,@Number2,@Number4)
 FETCH NEXT FROM my_cursor into @SupplierName
end
select* from #table
close my_cursor
DEALLOCATE my_cursor
drop table #table     ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseReceiptChoose', N'  select PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity1,QualifiedRate,note,OrderState,UpdateTime1 
 from PurchaseReceipt  
 where  SpecialCompletion<>1 and CheckSpecialMining=''特采''  order by OrderState desc    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseReceiptFinancialEntry', N'select PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity,ProductQuantity1,note,UpdateTime1,OrderState,
FinancialEntry,FinancialEntryName,FinancialEntryTime 
from PurchaseReceipt
where FinancialEntry is null
order by OrderState desc ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseReceiptIncomingAudit', N'  
  select PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity1,CheckAudit,QualifiedRate,FinancialEntry,UpdateTime1,OrderState,note,WhetherQualified,NotChooseNumber      
  from PurchaseReceipt    
  where CheckQualifiedUserName is not null and FinancialEntry=''已录入''and (WhetherQualified=0 or SpecialCompletion=1)  and ReturnGoods is null  order by OrderState desc        ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'SelectPurchaseReceiptLatestData', N'select* from PurchaseReceipt pr  where pr.PurchaseNo=(select top 1 t.PurchaseNo from PurchaseReceipt t order by t.UpdateTime desc)
and pr.CheckAudit=1
order by pr.UpdateTime desc')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseReceiptReturnGoods', N'select PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,NotChooseNumber,note,UpdateTime1,CheckSpecialMining,ProductQuantity1 
from  PurchaseReceipt  
where CheckAudit=''已审核''  and (WhetherQualified=0 or SpecialCompletion=1) and ReturnGoods is null  order by OrderState desc  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPurchaseReceiptWhether', N'select PurchaseReceiptID,PurchaseNo,SupplierName,BatchNo,MaterialCode,MaterialName,MaterialSpecifications,ProductQuantity1,ChooseNumber,note,UpdateTime1,CheckSpecialMining from  PurchaseReceipt
where CheckAudit=''已审核''  and (WhetherQualified=1 or SpecialCompletion=1) and Storage is null
order by OrderState desc ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPUsers', N' select* from PUsers   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPUsers_Function', N' select * from PUsers_Function  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPUsers_Function_Detailed', N' select * from PUsers_Function_Detailed ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPUsers_Function_DetailedLogin', N' select * from PUsers_Function_Detailed where UserName=@UserName ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPUsers_FunctionLogin', N'  select * from PUsers_Function where UserName=@UserName ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPUsersNotSystemAdimin', N' select* from PUsers where systemAdimin=0  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPWarehouseTable_Detailed', N' select* from PWarehouseTable_Detailed  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPWarehouseTable_DetailedMaterialName', N'  select distinct MaterialName from PWarehouseTable_Detailed  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPWarehouseTable_DetailedProductQuantity', N' select distinct MaterialName, (select ISNULL(SUM(ProductQuantity),0) from PWarehouseTable_Detailed   where MaterialName=@MaterialName)   -    
			(select ISNULL(SUM(ProductQuantity),0) from PWarehouseTable_PickingOut   where MaterialName=@MaterialName) as ProductQuantity 

from PWarehouseTable_Detailed
  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPWarehouseTable_PickingOut', N' select* from PWarehouseTable_PickingOut ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPWarehouseTable_title', N'select* from PWarehouseTable_title where FID=@FID ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectPWorkSchedule', N'select* from PWorkSchedule')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectSoftModel', N'select* into #t from(
select distinct SoftModel,ZhiDan from Gps_AutoTest_Result     
where TestTime>=@begintime and TestTime<=@endtime   
union    select distinct SoftModel ,ZhiDan from Gps_CoupleTest_Result   
 where TestTime>=@begintime and TestTime<=@endtime  
union     select distinct SoftModel,ZhiDan from Gps_AutoTest_Result2  
where TestTime>=@begintime and TestTime<=@endtime    
)A
select* from #t
where 1=1 ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectSumCartonBoxTwentyNumber', N'select  count(ZhiDan) from Gps_CartonBoxTwenty_Result where ZhiDan =@zhidan')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectSumZhiDanNumber', N'select Setting2 from LOrderMessage where ZhiDan like @zhidan')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTest', N'declare @flg bit  
set @flg=@f  
if(@flg=1)  
begin  
select ZhiDan,Computer,TestTime,SoftModel 
from Gps_CoupleTest_Result 
where Computer is not null  and TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end  
else  
begin  
select ZhiDan,Computer,TestTime ,SoftModel
from Gps_CoupleTest_Result 
where  TestTime>=@begintime and TestTime<=@endtime 
order by TestTime  
end')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTimeAttendance_AttendanceInformation_machine', N' select* from TimeAttendance_AttendanceInformation_machine    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTimeAttendance_DepartmentParentDepartmentNo', N'select* from TimeAttendance_Department where ParentDepartmentNo=@ParentDepartmentNo ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTimeAttendance_Employee_FileDepartmentNo', N'     select* from TimeAttendance_Employee_File where DepartmentNo=@MinimalSector    ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTimeAttendance_Employee_FileGroupNo', N'  select* from TimeAttendance_Employee_File where GroupNo=@MinimalSector     ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTimeAttendance_Employee_FileLine_No', N'    select* from TimeAttendance_Employee_File where Line_No=@MinimalSector         ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTimeAttendance_Employee_FileMinimalSector', N'   select* from TimeAttendance_Employee_File where MinimalSector=@MinimalSector   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTop10ProductSet', N'select top 10 ps.ProductClass from ProductSet ps where ps.ProductClass like @pc')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectTop10zOrder', N'select distinct top 10  gcbt.ZhiDan as zOrder
from Gps_CartonBoxTwenty_Result gcbt join Gps_AutoTest_Result gatr on gcbt.ZhiDan=gatr.ZhiDan join Gps_CoupleTest_Result gctr on 
gatr.ZhiDan = gctr.ZhiDan
where gcbt.ZhiDan like @pc')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectzOrder', N'select* into #t from(
select distinct ZhiDan as zOrder  from Gps_AutoTest_Result     
 where TestTime>=@begintime and TestTime<=@endtime    
union      
select distinct ZhiDan as zOrder  from Gps_CoupleTest_Result   
 where TestTime>=@begintime and TestTime<=@endtime     
union       
select distinct ZhiDan as zOrder from Gps_AutoTest_Result2 
    
 where TestTime>=@begintime and TestTime<=@endtime  
)A
select distinct * from #t
where 1=1 and zOrder is not null ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectzOrder1', N'declare @productName varchar(20), @begintime datetime,@endtime datetime 
set @productName=@pn set @begintime=@begin set @endtime=@end
if @productName=''鑫芯'' 
begin
  select* into #t 
from(  
select distinct ZhiDan as zOrder  
from Gps_AutoTest_Result        
where TestTime>=@begintime and TestTime<=@endtime     
 union        
 select distinct ZhiDan as zOrder  
 from Gps_CoupleTest_Result      
 where TestTime>=@begintime and TestTime<=@endtime )A
 select distinct * from #t  where 1=1 and zOrder is not null    
order by zOrder
drop table #t
end
 else if @productName=''几米'' or @productName=''几米（夜班）测试''
begin

select* into #t1 
from(       
 select distinct ZhiDan as zOrder 
 from Gps_AutoTest_Result2          
 where TestTime>=@begintime and TestTime<=@endtime    )A  
select distinct * from #t1  where 1=1 and zOrder is not null 
order by zOrder
drop table #t1
end 
else if  @productName=''''
begin

	select* into #t2 
from(  
select distinct ZhiDan as zOrder  
from Gps_AutoTest_Result        
where TestTime>=@begintime and TestTime<=@endtime     
 union        
 select distinct ZhiDan as zOrder  
 from Gps_CoupleTest_Result      
 where TestTime>=@begintime and TestTime<=@endtime       
 union         
 select distinct ZhiDan as zOrder 
 from Gps_AutoTest_Result2          
 where TestTime>=@begintime and TestTime<=@endtime    )A  
select distinct * from #t2  where 1=1 and zOrder is not null 
order by zOrder
drop table #t2
end  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'selectzOrderAndSoftModel', N'select* into #t from(
select distinct ZhiDan as zOrder,SoftModel  from Gps_AutoTest_Result     
 where TestTime>=@begintime and TestTime<=@endtime    
union      
select distinct ZhiDan as zOrder,SoftModel  from Gps_CoupleTest_Result   
 where TestTime>=@begintime and TestTime<=@endtime     
union       
select distinct ZhiDan as zOrder,SoftModel from Gps_AutoTest_Result2 
    
 where TestTime>=@begintime and TestTime<=@endtime  
)A
select distinct * from #t
where 1=1 and zOrder is not null  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'Top1_PWorkSchedule', N'select top 1 * from PWorkSchedule order by UpdateTime')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'Top10ProductName', N'select distinct top 10  ps.ProductName from ProductSet ps')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'UpdatePAbnormalInput', N'update PAbnormalInput set ZhiDan=@zhidan,SchoolPersonnel=@school,CompanyName=@company,LineOf=@line,WorkStation=@workstation,  ProblemDescription=@problem,ExceptionTypes=@exception,Node1=@node,UpdateTime=GETDATE()  
where ID=@id')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'UpdatePCapacityConfiguration', N'update PCapacityConfiguration set ProductClass=@pc where zhidan=@zd ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePEncodingSetting', N'update PEncodingSetting set BarcodeEncoding=@be,ProblemDescription=@pd,ES_ExceptionTypes=@eet
where BarcodeEncoding=@be ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePMCplan_table', N'update PMCplan_table set CorporateName=@corporatename,ZhiDan=@zhidan,TotalOrder=@totalorder,RequiredTimeGUID=@requiretimeguid,
CustomerName=@customername,ShippingDate=@shippingdate,Remarks=@remarks,UpdateTime=GETDATE()
where CorporateName=@corporatename1 and ZhiDan=@zhidan1 ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'UpdateProductionLinePC', N'update ProductionLinePC set Pcname=@pcname,ProductType=@type,LineName=@ln,CompanyName=@cn
where Pcname=@pn')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateProductionLinePC_title', N'update ProductionLinePC_title set LineName=@nln,CompanyName=@cn  where LineName=@ln')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateProductionTypeOnWorkTimeType', N'update ProductionType set OnWorkTimeType=@onwork where ProductType=@pt')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateProductionTypeOnWorkTimeTypeNight', N'update ProductionType set OnWorkTimeTypeNight=@onwork where ProductType=@pt')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateProductSet_New', N'update ProductSet_New set EfficiencyQuantity=@efficiencyquantity,TheNumberOf=@thenumberof,UpdataTime=GETDATE()
where ProductClass=@productcalss and Stations=@stations ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePStaffResume', N'update PStaffResume 
set Name=@name,WorkNumber=@worknumber,Gender=@gender,Age=@age,WorkTypes=@worktype,Levels=@levels, FactoryTime=@factorytime,CompanyName=@companyname ,UpdateTime=GETDATE()    
where Name=@name1 and WorkNumber=@worknumber1')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePTypesWork', N'update PTypesWork set TypesWork=@typeswork where TypesWork=@typeswork1 ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePurchaseReceipt', N'UPDATE [GPSTest].[dbo].[PurchaseReceipt]     SET      [PurchaseNo] = @PurchaseNo        ,[SupplierName] = @SupplierName        ,[BatchNo] = @BatchNo        ,[MaterialCode] = @MaterialCode        ,[MaterialName] = @MaterialName        ,[MaterialSpecifications] = @MaterialSpecifications        ,[ProductQuantity] = @ProductQuantity        ,[ProductQuantity1] = @ProductQuantity1        ,[CheckAudit] = @CheckAudit        ,[CheckQualified] = @CheckQualified        ,[CheckSpecialMining] = @CheckSpecialMining        ,[note] = @note        ,[ScanningTime] = @ScanningTime        ,[UpdateTime] = @UpdateTime        ,[UpdateTime1] = GETDATE()        ,[UserName] = @UserName ,OrderState=@OrderState  WHERE [PurchaseReceiptID]=@PurchaseReceiptID  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePurchaseReceiptChoose', N'update PurchaseReceipt set ChooseNumber=@ChooseNumber,NotChooseNumber=@NotChooseNumber,ChooseTime1=@ChooseTime1,ChooseName=@ChooseName,SpecialCompletion=1,ChooseTime2=GETDATE()
where PurchaseReceiptID=@PurchaseReceiptID ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePurchaseReceiptFinancialEntry', N'update PurchaseReceipt set FinancialEntry=@FinancialEntry,FinancialEntryName=@FinancialEntryName,FinancialEntryTime=GETDATE()
where PurchaseReceiptID=@PurchaseReceiptID   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePurchaseReceiptIncomingAudit', N'  update PurchaseReceipt     
 set CheckAudit=@CheckAudit,CheckSpecialMining=@CheckSpecialMining,CheckAuditUserName=@CheckAuditUserName,WhetherQualified=@WhetherQualified, 
  UpdateTime1=GETDATE(),note=note++@note,AttributionResponsibility=@AttributionResponsibility,Presentation8D=@Presentation8D,ReturnGoods=@ReturnGoods      
 where  PurchaseReceiptID=@PurchaseReceiptID     ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePurchaseReceiptQualified', N' update PurchaseReceipt       set CheckQualified=@CheckQualified,CheckQualifiedUserName=@CheckQualifiedUserName,QualifiedTime1=@QualifiedTime1,QualifiedTime2=@QualifiedTime2,QualifiedRate=@QualifiedRate,WhetherQualified=@WhetherQualified,   CheckNumber=@CheckNumber,classType=@classType,ProblemDescription=@ProblemDescription,CheckAudit=@CheckAudit         
 where PurchaseReceiptID=@PurchaseReceiptID   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePurchaseReceiptReturnGoods', N'update PurchaseReceipt set ReturnGoods=@ReturnGoods
where PurchaseReceiptID=@PurchaseReceiptID  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePurchaseReceiptStorage', N'update PurchaseReceipt set Storage=@Storage
where PurchaseReceiptID=@PurchaseReceiptID  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePUsers_Function', N' update PUsers_Function set FunctionJurisdiction=@NewFunctionJurisdiction 
where UserName=@UserName and FunctionGUID=@FunctionGUID and FunctionName=@FunctionName   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePUsers_Function_Detailed', N' update PUsers_Function_Detailed set FunctionJurisdiction=@NewFunctionJurisdiction 
where UserName=@UserName and FunctionGUID=@FunctionGUID and FunctionName=@FunctionName   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePUsersAddUser', N'update PUsers set AddUser=@Limite where UserName=@UserName  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePUsersLimite', N' update PUsers SET Limite=@Limite where UserName=@UserName  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePWarehouseTable_title', N'update PWarehouseTable_title set WarehouseName=@WarehouseName
where ID=@ID ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updatePWorkSchedule', N'update PWorkSchedule set CompanyName=@comp,MorningOnWorkTime=@morningon,MorningUnderWorkTime=@morningun,AfternoonOnWorkTime=@afteron,
AfternoonUnderWorkTime=@afterun,NightOnWorkTime=@nighton
where CompanyName=@comp')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateTimeAttendance_AttendanceInformation_machine', N'   update TimeAttendance_AttendanceInformation_machine 
 set ComInterface=@ComInterface,BaudRate=@BaudRate,IPAddress=@IPAddress,MachinePosition=@MachinePosition,MachineUse=@MachineUse
 where MachineID=@MachineID  ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateTimeAttendance_Department', N' update TimeAttendance_Department set DepartmentName=@DepartmentName,NumberOfStaff=@NumberOfStaff,InTheNumberOfStaff=@InTheNumberOfStaff,ExceedNumberOfStaff=@ExceedNumberOfStaff,
 note=@note
 where DepartmentNo=@DepartmentNo ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateTimeAttendance_Employee_File1', N'   update TimeAttendance_Employee_File set   ChineseName=@ChineseName,Gender=@Gender,Education=@Education,Post=@Post,EmployeeCategory=@EmployeeCategory,
EntryDate=@EntryDate,DepartmentNo=@DepartmentNo,DepartmentName=@DepartmentName,GroupNo=@GroupNo,GroupName=@GroupName,Line_No=@Line_No,LineName=@LineName,IDNumber=@IDNumber,
IssuingAuthority=@IssuingAuthority,DateOfIssue=@DateOfIssue,IDTermOfValidity=@IDTermOfValidity,BirthDay=@BirthDay,PlaceOrigin=@PlaceOrigin,Nation=@Nation,
HomeAddress=@HomeAddress,AttendanceData=@AttendanceData,AttendanceRegulations=@AttendanceRegulations,CompletionData=@CompletionData,ProbationPeriod=@ProbationPeriod,
SalaryCategory=@SalaryCategory,Introducer=@Introducer,PositionsGrade=@PositionsGrade,Rank=@Rank,LogicalCardNumber=@LogicalCardNumber,PhysicalCardNumber=@PhysicalCardNumber,
PhoneNumber=@PhoneNumber,EmergencyContact=@EmergencyContact,EmergencyContactPhone=@EmergencyContactPhone,EmErgencyContactAddress=@EmErgencyContactAddress,PaymentMode=@PaymentMode,
Height=@Height,Weight=@Weight,LeftEyeVision=@LeftEyeVision,RightEyeVision=@RightEyeVision,note=@note,ContractNumber=@ContractNumber,ContractSigning=@ContractSigning,
ExpirationContract=@ExpirationContract,IDCardPeriod=@IDCardPeriod,Job=@Job,leaveDate=@leaveDate,TurnoverType=@TurnoverType,ReasonsForLeaving=@ReasonsForLeaving,Blacklist=@Blacklist,
married=@married,FreeCard=@FreeCard,OvertimeApplication=@OvertimeApplication,modificationDate=GETDATE(),
Modifier=@Modifier,workType=@workType,workGrade=@workGrade,Photo=@Photo,MinimalSector=@MinimalSector
where JobNumber=@JobNumber   ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'updateUsersPassword', N' update PUsers set UserPassword=@password where UserName=@username ')
INSERT [dbo].[Tb_Command] ([Command], [SQLstring]) VALUES (N'UsersLogin', N'select * from PUsers where UserName=@username and UserPassword=@password ')