using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

/// <summary>
/// Summary description for Settings
/// </summary>
public class Settings
{

    public DataTable ViewGrade(int ID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@id  ", ID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_displaydate");
        return ds.Tables[0];
    }
    public DataTable ViewGradeDetail(int ID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@id  ", ID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_GradeDetail");
        return ds.Tables[0];
    }
    public DataTable PolicyInsert(Int32 Pid,Int32 did)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@pid", Pid);
        param[1] = new SqlParameter("@did",did);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_insertpolicy]");
        return ds.Tables[0];

    }
    public DataTable PolicyMasterView(Int32 Pid, string Acd_Year)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@year", Pid);
        param[1] = new SqlParameter("@type", Acd_Year);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_showpolicybenefits");
        return ds.Tables[0];

    }
    public Int32 UpdateGrade(Int32 gradeid, string grade, decimal rangefrom, decimal rangeto)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@id", gradeid);
        param[1] = new SqlParameter("@gradename", grade);
        param[2] = new SqlParameter("@rangefrom", rangefrom);
        param[3] = new SqlParameter("@rangeto", rangeto);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "sp_updategraderange");

    }

    public DataTable PolicyMaster(Int32 Pid, Int32 Acd_Year, string P_Type, Int32 Type_ID, string P_SubCategory, Int32 Desg_ID, bool IsFamily, bool IsActive, bool IsFinance, string Effective_From, string Effective_Till, decimal MinValue, decimal MaxValue, Int32 Tps_GroupID, Int32 Grade_ID, string EndDate, string Remarks, string Operation, Int32 FrequencyId, Int32 NoOfChild, Int32 Age, Int32 DeptID, decimal amount)
    {
        SqlParameter[] param = new SqlParameter[23];
        param[0] = new SqlParameter("@Pid", Pid);
        param[1] = new SqlParameter("@Acd_Year", Acd_Year);
        param[2] = new SqlParameter("@P_Type", P_Type);
        param[3] = new SqlParameter("@Type_ID", Type_ID);
        param[4] = new SqlParameter("@P_SubCategory ", P_SubCategory);
        param[5] = new SqlParameter("@Desg_ID", Desg_ID);
        param[6] = new SqlParameter("@IsFamily", IsFamily);
        param[7] = new SqlParameter("@IsActive", IsActive);
        param[8] = new SqlParameter("@IsFinance", IsFinance);
        param[9] = new SqlParameter("@Effective_From", Effective_From);
        param[10] = new SqlParameter("@Effective_Till", Effective_Till);
        param[11] = new SqlParameter("@MinValue", MinValue);
        param[12] = new SqlParameter("@MaxValue", MaxValue);
        param[13] = new SqlParameter("@Tps_GroupID", Tps_GroupID);
        param[14] = new SqlParameter("@Grade_ID", Grade_ID);
        param[15] = new SqlParameter("@EndDate", EndDate);
        param[16] = new SqlParameter("@Remarks", Remarks);
        param[17] = new SqlParameter("@Operation", Operation);
        param[18] = new SqlParameter("@FrequencyId", FrequencyId);
        param[19] = new SqlParameter("@NoOfChildren", NoOfChild);
        param[20] = new SqlParameter("@Age", Age);
        param[21] = new SqlParameter("@DeptID", DeptID);
        param[22] = new SqlParameter("@amount", amount);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[PolicyMaster]");
        return ds.Tables[0];

    }


    public DataTable policysearch(string Operation, int yearid, int grade)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@Acd_Year", yearid);
        param[2] = new SqlParameter("@Grade", grade);
        //param[2] = new SqlParameter("@benefits", benefits);
        //param[3] = new SqlParameter("@grade", grade);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_policysetsearch]");
        return ds.Tables[0];
    }

    public Int32 InsertPolicyMaster(Int32 Pid, Int32 Acd_Year, string P_Type, Int32 Type_ID, string P_SubCategory, Int32 Desg_ID, bool IsFamily, bool IsActive, bool IsFinance, string Effective_From, string Effective_Till, decimal MinValue, decimal MaxValue, Int32 Tps_GroupID, Int32 Grade_ID, string EndDate, string Remarks, string Operation, Int32 FrequencyId, Int32 NoOfChild, Int32 Age, Int32 deptID, decimal amount)
    {
        SqlParameter[] param = new SqlParameter[23];
        param[0] = new SqlParameter("@Pid", Pid);
        param[1] = new SqlParameter("@Acd_Year", Acd_Year);
        param[2] = new SqlParameter("@P_Type", P_Type);
        param[3] = new SqlParameter("@Type_ID", Type_ID);
        param[4] = new SqlParameter("@P_SubCategory ", P_SubCategory);
        param[5] = new SqlParameter("@Desg_ID", Desg_ID);
        param[6] = new SqlParameter("@IsFamily", IsFamily);
        param[7] = new SqlParameter("@IsActive", IsActive);
        param[8] = new SqlParameter("@IsFinance", IsFinance);
        param[9] = new SqlParameter("@Effective_From", Effective_From);
        param[10] = new SqlParameter("@Effective_Till", Effective_Till);
        param[11] = new SqlParameter("@MinValue", MinValue);
        param[12] = new SqlParameter("@MaxValue", MaxValue);
        param[13] = new SqlParameter("@Tps_GroupID", Tps_GroupID);
        param[14] = new SqlParameter("@Grade_ID", Grade_ID);
        param[15] = new SqlParameter("@EndDate", EndDate);
        param[16] = new SqlParameter("@Remarks", Remarks);
        param[17] = new SqlParameter("@Operation", Operation);
        param[18] = new SqlParameter("@FrequencyId", FrequencyId);
        param[19] = new SqlParameter("@NoOfChildren", NoOfChild);
        param[20] = new SqlParameter("@Age", Age);
        param[21] = new SqlParameter("@DeptID", deptID);
        param[22] = new SqlParameter("@amount", amount);

        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "PolicyMaster");

    }

    public Int32 InsertPolicyMasterResearch(Int32 Pid, Int32 Acd_Year, string P_Type, Int32 Type_ID, string P_SubCategory, Int32 Desg_ID, decimal LMaxDhs, bool IsActive, bool IsFinance, decimal LPartFees, decimal LPerDein, decimal LSMaxDhs, decimal LSPartFees, Int32 Tps_GroupID, Int32 Grade_ID, string EndDate, string Remarks, string Operation, Int32 FrequencyId, decimal LSPerDein, decimal RMaxDhs
        , decimal RPartFees, decimal rPerDein, decimal IMaxDhs, decimal IPartFees, decimal IPerDein, Int32 DeptId, decimal amount
        )
    {
        SqlParameter[] param = new SqlParameter[28];
        param[0] = new SqlParameter("@Pid", Pid);
        param[1] = new SqlParameter("@Acd_Year", Acd_Year);
        param[2] = new SqlParameter("@P_Type", P_Type);
        param[3] = new SqlParameter("@Type_ID", Type_ID);
        param[4] = new SqlParameter("@P_SubCategory ", P_SubCategory);
        param[5] = new SqlParameter("@Desg_ID", Desg_ID);
        param[6] = new SqlParameter("@LMaxDhs", LMaxDhs);
        param[7] = new SqlParameter("@IsActive", IsActive);
        param[8] = new SqlParameter("@IsFinance", IsFinance);
        param[9] = new SqlParameter("@LPartFees", LPartFees);
        param[10] = new SqlParameter("@LPerDein", LPerDein);
        param[11] = new SqlParameter("@LSMaxDhs", LSMaxDhs);
        param[12] = new SqlParameter("@LSPartFees", LSPartFees);
        param[13] = new SqlParameter("@Tps_GroupID", Tps_GroupID);
        param[14] = new SqlParameter("@Grade_ID", Grade_ID);
        param[15] = new SqlParameter("@EndDate", EndDate);
        param[16] = new SqlParameter("@Remarks", Remarks);
        param[17] = new SqlParameter("@Operation", Operation);
        param[18] = new SqlParameter("@FrequencyId", FrequencyId);
        param[19] = new SqlParameter("@RMaxDhs", RMaxDhs);
        param[20] = new SqlParameter("@LSPerDein", LSPerDein);
        param[21] = new SqlParameter("@RPartFees", RPartFees);
        param[22] = new SqlParameter("@rPerDein", rPerDein);
        param[23] = new SqlParameter("@IMaxDhs", IMaxDhs);
        param[24] = new SqlParameter("@IPartFees", IPartFees);
        param[25] = new SqlParameter("@IPerDein", IPerDein);
        param[26] = new SqlParameter("@DeptID", DeptId);
        param[27] = new SqlParameter("@amount", amount);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "PolicyMasterResearch");

    }

    SqlConnection conn = new SqlConnection(CGLOBAL.getConnectionString());
    public Settings()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //public DataTable NOHRSWORKED(string Month, string Year, String Type)
    //{
    //    SqlParameter[] param = new SqlParameter[3];
    //    param[0] = new SqlParameter("@Month", Month);
    //    param[1] = new SqlParameter("@Year", Year);
    //    param[2] = new SqlParameter("@Type", Type);
    //    DataAccessLayer da = new DataAccessLayer();
    //    DataSet ds = da.getDataByParam(param, "SP_WeeklyWorkHoursConsolidated_Formated_Consolidated");
    //    if (ds != null && ds.Tables.Count > 0)
    //        return ds.Tables[0];
    //    else
    //        return null;
    //}

    public DataTable NOHRSWORKED(string FromDate, string ToDate, String Type)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        param[2] = new SqlParameter("@Type", Type);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_NOHRS_WORKED");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }


    //public DataTable Attendance(string Month, string Year, String Type)
    //{
    //    SqlParameter[] param = new SqlParameter[3];
    //    param[0] = new SqlParameter("@Month", Month);
    //    param[1] = new SqlParameter("@Year", Year);
    //    param[2] = new SqlParameter("@Type", Type);
    //    DataAccessLayer da = new DataAccessLayer();
    //    DataSet ds = da.getDataByParam(param, "sp_LateEntrySemesterreport_MONTH_HRD_Main_EXCEL");
    //    if (ds != null && ds.Tables.Count > 0)
    //        return ds.Tables[0];
    //    else
    //        return null;
    //}

    public DataTable Attendance(string FromDate, string ToDate, String Type, int EMPID)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@StartDate", FromDate);
        param[1] = new SqlParameter("@EndDate", ToDate);
        param[2] = new SqlParameter("@Type", Type);
        param[3] = new SqlParameter("@EMPID", EMPID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_DAILYINOUT_SHIFTWISE1");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable LeaveDetailsAcadamic(string Year)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Year", Year);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_LeaveDetails_Academics");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable LeaveDetailsStaff(string Year)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@AYID", Year);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_HRD_LEAVE_Consolidated_Main_Excel");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable GetEmpCode(string Type, int Flag)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Type", Type);
        param[1] = new SqlParameter("@Flag", Flag);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetEmpCode]");
        return ds.Tables[0];

    }
    public static string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                nic.OperationalStatus == OperationalStatus.Up)
            {
                return Convert.ToString(nic.GetPhysicalAddress());
            }
        }
        return null;
    }
    public DataTable GetincrementEmployees(DateTime Date)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Date", Date);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetincrementEmployees]");
        return ds.Tables[0];

    }
    public Int32 UpdateWeekendRTP(string PersonID, Boolean RTP,Int32 Month)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Month", Month);
        param[1] = new SqlParameter("@RTP", RTP);
        param[2] = new SqlParameter("@PersonID", RTP);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "UpdateWeekendRTP");

    }
    public Int32 InsertFurniture(Int32 Empid, Decimal Amount, Boolean RTP, Int32 CreatedBy, string IsNewEntry, Boolean ISMaintanance, Decimal ActualAmount, int AYearID,string IssueDate)
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Empid", Empid);
        param[1] = new SqlParameter("@Amount", Amount);
        param[2] = new SqlParameter("@RTP ", RTP);
        param[3] = new SqlParameter("@IsNewEntry ", IsNewEntry);
        param[4] = new SqlParameter("@CreatedBy ", CreatedBy);
        param[5] = new SqlParameter("@Mac", GetMacAddress());
        param[6] = new SqlParameter("@ISMaintanance", ISMaintanance);
        param[7] = new SqlParameter("@ActualAmount", ActualAmount);
        param[8] = new SqlParameter("@AYearID", AYearID);
        param[9] = new SqlParameter("@IssueDate", IssueDate);

        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "InsertFurnitureAllowance");

    }
    public Int32 UpdatePersonElemtsRefNo(Int32 PersonId, DateTime Date, string Reference, Boolean Iss)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@PersonId", PersonId);
        param[1] = new SqlParameter("@Date", Date);
        param[2] = new SqlParameter("@Ref", Reference);
        param[3] = new SqlParameter("@Iss", Iss);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "UpdatePersonElemtsRefNo");

    }
    public Int32 InsertUserLogDetails(Int32 PersonId,string PageName,string StepPerformed,string IPAddress)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@PersonID", PersonId);
        param[1] = new SqlParameter("@PageName", PageName);
        param[2] = new SqlParameter("@IPAddress", IPAddress);
        param[3] = new SqlParameter("@StepPerformed", StepPerformed);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "InsertUserLogDetails");
    }

    public Int32 InsertInitialAirticket(Int32 Empid, Decimal Amount, string Section, Boolean Copy, Boolean RTP, Int32 User, Boolean Valid)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Empid", Empid);
        param[1] = new SqlParameter("@Amount", Amount);
        param[2] = new SqlParameter("@Section", Section);
        param[3] = new SqlParameter("@Copy", Copy);
        param[4] = new SqlParameter("@RTP ", RTP);
        param[5] = new SqlParameter("@User", User);
        param[6] = new SqlParameter("@Mac", GetMacAddress());
        param[7] = new SqlParameter("@Valid", Valid);

        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "InsertInitialAirticket");

    }
    public DataTable PolicyMaster(Int32 Pid, Int32 Acd_Year, string P_Type, Int32 Type_ID, string P_SubCategory, Int32 Desg_ID, bool IsFamily, bool IsActive, bool IsFinance, string Effective_From, string Effective_Till, decimal MinValue, decimal MaxValue, Int32 Tps_GroupID, Int32 Grade_ID, string EndDate, string Remarks, string Operation, Int32 FrequencyId, Int32 NoOfChild, Int32 Age, decimal amount)
    {
        SqlParameter[] param = new SqlParameter[22];
        param[0] = new SqlParameter("@Pid", Pid);
        param[1] = new SqlParameter("@Acd_Year", Acd_Year);
        param[2] = new SqlParameter("@P_Type", P_Type);
        param[3] = new SqlParameter("@Type_ID", Type_ID);
        param[4] = new SqlParameter("@P_SubCategory ", P_SubCategory);
        param[5] = new SqlParameter("@Desg_ID", Desg_ID);
        param[6] = new SqlParameter("@IsFamily", IsFamily);
        param[7] = new SqlParameter("@IsActive", IsActive);
        param[8] = new SqlParameter("@IsFinance", IsFinance);
        param[9] = new SqlParameter("@Effective_From", Effective_From);
        param[10] = new SqlParameter("@Effective_Till", Effective_Till);
        param[11] = new SqlParameter("@MinValue", MinValue);
        param[12] = new SqlParameter("@MaxValue", MaxValue);
        param[13] = new SqlParameter("@Tps_GroupID", Tps_GroupID);
        param[14] = new SqlParameter("@Grade_ID", Grade_ID);
        param[15] = new SqlParameter("@EndDate", EndDate);
        param[16] = new SqlParameter("@Remarks", Remarks);
        param[17] = new SqlParameter("@Operation", Operation);
        param[18] = new SqlParameter("@FrequencyId", FrequencyId);
        param[19] = new SqlParameter("@NoOfChildren", NoOfChild);
        param[20] = new SqlParameter("@Age", Age);
        param[21] = new SqlParameter("@amount", amount);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[PolicyMaster]");
        return ds.Tables[0];

    }
    //public Int32 InsertPolicyMaster(Int32 Pid, Int32 Acd_Year, string P_Type, Int32 Type_ID, string P_SubCategory, Int32 Desg_ID, bool IsFamily, bool IsActive, bool IsFinance, string Effective_From, string Effective_Till, decimal MinValue, decimal MaxValue, Int32 Tps_GroupID, Int32 Grade_ID, string EndDate, string Remarks, string Operation, Int32 FrequencyId, Int32 NoOfChild, Int32 Age, Int32 deptID, decimal amount)
    //{
    //    SqlParameter[] param = new SqlParameter[23];
    //    param[0] = new SqlParameter("@Pid", Pid);
    //    param[1] = new SqlParameter("@Acd_Year", Acd_Year);
    //    param[2] = new SqlParameter("@P_Type", P_Type);
    //    param[3] = new SqlParameter("@Type_ID", Type_ID);
    //    param[4] = new SqlParameter("@P_SubCategory ", P_SubCategory);
    //    param[5] = new SqlParameter("@Desg_ID", Desg_ID);
    //    param[6] = new SqlParameter("@IsFamily", IsFamily);
    //    param[7] = new SqlParameter("@IsActive", IsActive);
    //    param[8] = new SqlParameter("@IsFinance", IsFinance);
    //    param[9] = new SqlParameter("@Effective_From", Effective_From);
    //    param[10] = new SqlParameter("@Effective_Till", Effective_Till);
    //    param[11] = new SqlParameter("@MinValue", MinValue);
    //    param[12] = new SqlParameter("@MaxValue", MaxValue);
    //    param[13] = new SqlParameter("@Tps_GroupID", Tps_GroupID);
    //    param[14] = new SqlParameter("@Grade_ID", Grade_ID);
    //    param[15] = new SqlParameter("@EndDate", EndDate);
    //    param[16] = new SqlParameter("@Remarks", Remarks);
    //    param[17] = new SqlParameter("@Operation", Operation);
    //    param[18] = new SqlParameter("@FrequencyId", FrequencyId);
    //    param[19] = new SqlParameter("@NoOfChildren", NoOfChild);
    //    param[20] = new SqlParameter("@Age", Age); 
    //    param[21] = new SqlParameter("@DeptID", deptID);
    //    param[22] = new SqlParameter("@amount", amount);


    //    DataAccessLayer da = new DataAccessLayer();
    //    return da.InsertValues(param, "PolicyMaster");

    //}
    public DataTable GetDataforReport(int payrollid, int dept, string procedure)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@iPayrollid", payrollid);
        param[1] = new SqlParameter("@iDept", dept);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, procedure);
        return ds.Tables[0];

    }
    public DateTime GetProperDate(string OrgDate)
    {
        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB"); //dd/MM/yyyy
        string[] ProperDate;
        if (sysFormat == "M/d/yyyy" || sysFormat == "MM/dd/yyyy")
        {
            //try
            //{
            //    if (OrgDate.Contains("/"))
            //    {
            //        ProperDate = OrgDate.Split('/');
            //    }
            //    else
            //    {
            //        ProperDate = OrgDate.Split('-');
            //    }
            //    return DateTime.Parse(ProperDate[2].ToString() + "/" + ProperDate[0].ToString() + "/" + ProperDate[1].ToString());
            //}
            //catch
            //{
            if (OrgDate.Contains("/"))
            {
                ProperDate = OrgDate.Split('/');
            }
            else
            {
                ProperDate = OrgDate.Split('-');
            }
            return new DateTime(Convert.ToInt32(ProperDate[2].ToString()), Convert.ToInt32(ProperDate[1].ToString()), Convert.ToInt32(ProperDate[0].ToString()));
            //}
        }
        else if (sysFormat == "d/M/yyyy" || sysFormat == "dd/MM/yyyy")
        {
            if (OrgDate.Contains("/"))
            {
                ProperDate = OrgDate.Split('/');
            }
            else
            {
                ProperDate = OrgDate.Split('-');
            }
            //return DateTime.Parse(ProperDate[2].ToString() + "/" + ProperDate[1].ToString() + "/" + ProperDate[0].ToString());
            return new DateTime(Convert.ToInt32(ProperDate[2].ToString()), Convert.ToInt32(ProperDate[1].ToString()), Convert.ToInt32(ProperDate[0].ToString()));
        }
        else
        {
            return DateTime.Parse(OrgDate);
        }
    }
    public string GetProperDate1(string OrgDate)
    {
        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB"); //dd/MM/yyyy
        string[] ProperDate;
        if (sysFormat == "M/d/yyyy" || sysFormat == "MM/dd/yyyy")
        {
            //try
            //{
            //    if (OrgDate.Contains("/"))
            //    {
            //        ProperDate = OrgDate.Split('/');
            //    }
            //    else
            //    {
            //        ProperDate = OrgDate.Split('-');
            //    }
            //    return DateTime.Parse(ProperDate[2].ToString() + "/" + ProperDate[0].ToString() + "/" + ProperDate[1].ToString());
            //}
            //catch
            //{
            if (OrgDate.Contains("/"))
            {
                ProperDate = OrgDate.Split('/');
            }
            else
            {
                ProperDate = OrgDate.Split('-');
            }
            return Convert.ToInt32(ProperDate[2].ToString()) + "/" + Convert.ToInt32(ProperDate[1].ToString()) + "/" + Convert.ToInt32(ProperDate[0].ToString());
            //}
        }
        else
        {
            if (OrgDate.Contains("/"))
            {
                ProperDate = OrgDate.Split('/');
            }
            else
            {
                ProperDate = OrgDate.Split('-');
            }
            //return DateTime.Parse(ProperDate[2].ToString() + "/" + ProperDate[1].ToString() + "/" + ProperDate[0].ToString());
            return Convert.ToInt32(ProperDate[2].ToString()) + "/" + Convert.ToInt32(ProperDate[1].ToString()) + "/" + Convert.ToInt32(ProperDate[0].ToString());
        }
    }
    public string DateStringInDDMMYYY(string OrgDate) // Created by silky 
    {
        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB"); //dd/MM/yyyy
        string[] ProperDate = new string[3];
        if (sysFormat == "M/d/yyyy" || sysFormat == "MM/dd/yyyy")
        {

            if (OrgDate.Contains("/"))
            {
                ProperDate = OrgDate.Split('/');
            }
            return Convert.ToInt32(ProperDate[1].ToString()) + "/" + Convert.ToInt32(ProperDate[0].ToString()) + "/" + Convert.ToInt32(ProperDate[2].ToString().Substring(0, 4));
        }
        else if (sysFormat == "dd/MM/yyyy")
        {
            if (OrgDate.Contains("/"))
            {
                ProperDate = OrgDate.Split('/');
            }
            return Convert.ToInt32(ProperDate[0].ToString()) + "/" + Convert.ToInt32(ProperDate[1].ToString()) + "/" + Convert.ToInt32(ProperDate[2].ToString().Substring(0, 4));
        }
        else if (sysFormat == "yyyy/MM/dd")
        {

            if (OrgDate.Contains("/"))
            {
                ProperDate = OrgDate.Split('/');
            }
            return Convert.ToInt32(ProperDate[2].ToString().Substring(0, 2)) + "/" + Convert.ToInt32(ProperDate[1].ToString()) + "/" + Convert.ToInt32(ProperDate[0].ToString());

        }
        else
        {
            return OrgDate;
        }
    }

    public Int32 InsertApplication(int TypeId, int ApplicationId, Boolean CancelStatus, string CancelRemarks)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@TypeId", TypeId);
        param[1] = new SqlParameter("@AppLink", ApplicationId);
        param[2] = new SqlParameter("@CancelRemarks", CancelRemarks);
        param[3] = new SqlParameter("@cancelStatus", CancelStatus);
        param[4] = new SqlParameter("@Mac", GetMacAddress());
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "InsertApplication");

    }

    public DataTable Gettype(int empid, int Typeid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@empid1", empid);
        param[1] = new SqlParameter("@typeid", Typeid);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_CancelApplication]");
        return ds.Tables[0];

    }
    public DataTable GetTeacherLoadReport(int SemesterId, int QuarterId, string procedure)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@semesterid", SemesterId);
        param[1] = new SqlParameter("@quarter", QuarterId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, procedure);
        return ds.Tables[0];

    }
    //public DataTable Getrecurrentairticket(Int32 status)
    //{
    //    SqlParameter[] param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@Status", status);
    //    DataAccessLayer da = new DataAccessLayer();
    //    DataSet ds = da.getDataByParam(param, "sp_Payroll_recurringAirTicket");
    //    return ds.Tables[0];

    //}
    public DataTable GetLeaveBalancePayment(Int32 Ac_Year)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Ac_Year", Ac_Year);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "GetLeaveBalancepayment");
        return ds.Tables[0];

    }
    //public DataTable Getrecurrentairticket(Int32 status)
    //{
    //    SqlParameter[] param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@Status", status);
    //    DataAccessLayer da = new DataAccessLayer();
    //    DataSet ds = da.getDataByParam(param, "sp_Payroll_recurringAirTicket");
    //    return ds.Tables[0];

    //}
    //public Int32 InsertRecurrentInitialAirticket(Int32 Empid, int appid, Decimal Amount, string Section, Boolean copystatus, Int32 User, Boolean Paid)
    //{
    //    SqlParameter[] param = new SqlParameter[8];
    //    param[0] = new SqlParameter("@Empno", Empid);
    //    param[1] = new SqlParameter("@applicntid", appid);
    //    param[2] = new SqlParameter("@Amount", Amount);
    //    param[3] = new SqlParameter("@Section", Section);
    //    param[4] = new SqlParameter("@CopyStatus ", copystatus);
    //    param[5] = new SqlParameter("@User", User);
    //    param[6] = new SqlParameter("@Mac", GetMacAddress());
    //    param[7] = new SqlParameter("@paid", Paid);

    //    DataAccessLayer da = new DataAccessLayer();
    //    return da.InsertValues(param, "sp_recurrentairticket");

    //}

    public DataTable Getrecurrentairticket(Int32 status, int ay)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Status", status);
        param[1] = new SqlParameter("@AYID", ay);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_Payroll_recurringAirTicket");
        return ds.Tables[0];

    }
    public Int32 InsertRecurrentInitialAirticket(Int32 Empid, int appid, Decimal Amount, string Section, Boolean copystatus, Int32 User, Boolean Paid, int ay,bool chkrep)
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Empno", Empid);
        param[1] = new SqlParameter("@applicntid", appid);
        param[2] = new SqlParameter("@Amount", Amount);
        param[3] = new SqlParameter("@Section", Section);
        param[4] = new SqlParameter("@CopyStatus ", copystatus);
        param[5] = new SqlParameter("@User", User);
        param[6] = new SqlParameter("@Mac", GetMacAddress());
        param[7] = new SqlParameter("@paid", Paid);
        param[8] = new SqlParameter("@ay", ay);
        param[9] = new SqlParameter("@chkrep", chkrep);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "sp_recurrentairticket");

    }



    public DataTable GetrecurrentairticketSearch(Int32 status, int paid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Status", status);
        param[1] = new SqlParameter("@paid", paid);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_payroll_recurringsearch");
        return ds.Tables[0];

    }
    public DataTable InsertIncrementLetterAlowance(Int32 PersonId, DateTime Date, string Reference, string acctext, int user)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@PersonId", PersonId);
        param[1] = new SqlParameter("@Date", Date);
        param[2] = new SqlParameter("@Ref", Reference);
        param[3] = new SqlParameter("@acctext", acctext);
        param[4] = new SqlParameter("@createdip", GetMacAddress());
        param[5] = new SqlParameter("@createdid", user);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_InsertIncrementLetterAlowance");
        return ds.Tables[0];
    }

    public DataTable getempidallowance(Int32 PersonId, DateTime Date, string Reference)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@PersonId", PersonId);
        param[1] = new SqlParameter("@Date", Date);
        param[2] = new SqlParameter("@Ref", Reference);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_GetIncrementLetterAlowance");
        return ds.Tables[0];
    }
    public DataTable InsertIncrementLetterstatus(Int32 PersonId, DateTime Date, string Reference, string acctext, int user)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@PersonId", PersonId);
        param[1] = new SqlParameter("@Date", Date);
        param[2] = new SqlParameter("@Ref", Reference);
        param[3] = new SqlParameter("@acctext", acctext);
        param[4] = new SqlParameter("@createdip", GetMacAddress());
        param[5] = new SqlParameter("@createdid", user);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_InsertIncrementLetterstatus");
        return ds.Tables[0];
    }
    public DataTable getempidstatus(Int32 PersonId, DateTime Date, string Reference)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@PersonId", PersonId);
        param[1] = new SqlParameter("@Date", Date);
        param[2] = new SqlParameter("@Ref", Reference);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_GetIncrementLetterstatus");
        return ds.Tables[0];
    }

    public Int32 InsertArrearDetails(string EmpID, Decimal Increment, Decimal Arrear, Int32 Days, Decimal PreviousSalary, Decimal CurSalary,
       Int32 CreatedBy, string CreatedIP, int AYearID, int RTP, string Operation, string PaidStatus)
    {
        SqlParameter[] param = new SqlParameter[12];
        param[0] = new SqlParameter("@Empid", EmpID);
        param[1] = new SqlParameter("@Increment", Increment);
        param[2] = new SqlParameter("@Arrear ", Arrear);
        param[3] = new SqlParameter("@Days ", Days);
        param[4] = new SqlParameter("@PreviousSalary ", PreviousSalary);
        param[5] = new SqlParameter("@CurSalary", CurSalary);
        param[6] = new SqlParameter("@CreatedBy", CreatedBy);
        param[7] = new SqlParameter("@CreatedIP", CreatedIP);
        param[8] = new SqlParameter("@AYearID", AYearID);
        param[9] = new SqlParameter("@RTP", RTP);
        param[10] = new SqlParameter("@Operation", Operation);
        param[11] = new SqlParameter("@PaidStatus", PaidStatus);

        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_SaveArrears");

    }

    public DataTable BindArrears(string EmpID, Decimal Increment, Decimal Arrear, Int32 Days, Decimal PreviousSalary, Decimal CurSalary,
        Int32 CreatedBy, string CreatedIP, int AYearID, int RTP, string Operation, string PaidStatus)
    {
        SqlParameter[] param = new SqlParameter[12];
        param[0] = new SqlParameter("@Empid", EmpID);
        param[1] = new SqlParameter("@Increment", Increment);
        param[2] = new SqlParameter("@Arrear ", Arrear);
        param[3] = new SqlParameter("@Days ", Days);
        param[4] = new SqlParameter("@PreviousSalary ", PreviousSalary);
        param[5] = new SqlParameter("@CurSalary", CurSalary);
        param[6] = new SqlParameter("@CreatedBy", CreatedBy);
        param[7] = new SqlParameter("@CreatedIP", CreatedIP);
        param[8] = new SqlParameter("@AYearID", AYearID);
        param[9] = new SqlParameter("@RTP", RTP);
        param[10] = new SqlParameter("@Operation", Operation);
        param[11] = new SqlParameter("@PaidStatus", PaidStatus);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_SaveArrears");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindAcc()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("GETAcaYear");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindSemesterByAccdYear(Int32 Year_Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Acc_Year_Id", Year_Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_semesterByYear");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable get_CoursesBy_empid_SemID(int semID, string empID)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Empid", empID);
        param[1] = new SqlParameter("@SemID", semID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_get_courses_by_empid_semID");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindFinAcc()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("SP_GetFinAcYear");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable DashboardNationality()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("SP_Nationalitywise");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }




    public DataTable DisplayCancel(int EmpNumber)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpNumber", EmpNumber);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "sp_displayopenList_Cancel");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable ViewCandidateData()
    {
        
        
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("SP_ViewCandidate_Data");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    //public DataTable ViewQualifiedCandidateData()
    //{


    //    DataAccessLayer da = new DataAccessLayer();
    //    DataSet ds = da.getDataByParam("SP_ViewCandidate_Data");
    //    if (ds != null && ds.Tables.Count > 0)
    //        return ds.Tables[0];
    //    else
    //        return null;
    //}

    public DataTable ViewQualifiedCandidateData()
    {


        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("SP_ViewQualifiedCandidateData");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable HODMAILEDCandidateData()
    {


        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("SP_CANDIDATEDATA_MAILED");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

  

    public DataTable HODSELECTEDCandidateData(int ID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Type", ID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_HODSELECTED_CANDIDATE");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable GetCandidateDetails(int ID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@ID", ID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_GETCANDIDATE_DETAILS");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }




    public DataTable LoadDropDown(int ID, String ParameterName, int AppType = 0)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@Parameter", ParameterName);
        param[2] = new SqlParameter("@AppType", AppType);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_loadDropDown");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable LoadValues(int Parameter1, String Parameter2, string Parameter3, String Operation)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Parameter1", Parameter1);
        param[1] = new SqlParameter("@Parameter2", Parameter2);
        param[2] = new SqlParameter("@Parameter3", Parameter3);
        param[3] = new SqlParameter("@Operation", Operation);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_LoadValues");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable getAdvertisement(Int32 ID, Int32 Position, Int32 Media, DateTime FromDate, DateTime ToDate, int CreatedBy, string CreatedIP, string Operation, String Remarks, int Ayear, int HOD, Decimal Budget, Byte[] FIleContent, String FileName, String FileExtension)
    {
        SqlParameter[] param = new SqlParameter[15];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@Position", Position);
        param[2] = new SqlParameter("@Media", Media);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        param[5] = new SqlParameter("@CreatedBy", CreatedBy);
        param[6] = new SqlParameter("@CreatedIP", CreatedIP);
        param[7] = new SqlParameter("@Operation", Operation);
        param[8] = new SqlParameter("@Remarks", Remarks);
        param[9] = new SqlParameter("@Ayear", Ayear );
        param[10] = new SqlParameter("@HOD", HOD);
        param[11] = new SqlParameter("@Budget", Budget);
        param[12] = new SqlParameter("@FileContent", FIleContent);
        param[13] = new SqlParameter("@FileName", FileName);
        param[14] = new SqlParameter("@FileExtension", FileExtension); 
       

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_MEDIA");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public Int32 Advertisement(Int32 ID, Int32 Position, Int32 Media, DateTime FromDate, DateTime ToDate, int CreatedBy, string CreatedIP, string Operation, String Remarks, int Ayear, int HOD,Decimal  Budget,Byte[] FIleContent,String FileName,String FileExtension)
    {
        SqlParameter[] param = new SqlParameter[15];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@Position", Position);
        param[2] = new SqlParameter("@Media", Media);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        param[5] = new SqlParameter("@CreatedBy", CreatedBy);
        param[6] = new SqlParameter("@CreatedIP", CreatedIP);
        param[7] = new SqlParameter("@Operation", Operation);
        param[8] = new SqlParameter("@Remarks", Remarks );
        param[9] = new SqlParameter("@Ayear", Ayear);
        param[10] = new SqlParameter("@HOD", HOD);
        param[11] = new SqlParameter("@Budget", Budget);
        param[12] = new SqlParameter("@FileContent", FIleContent);
        param[13] = new SqlParameter("@FileName", FileName);
        param[14] = new SqlParameter("@FileExtension", FileExtension); 

        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_MEDIA");
    }

    public Int32 OfferLetter(Int32 ID, Int32 AIP, String Name, String EmpType, int Ayear, int Designation, string ContractType,int Grade,int SubGrade ,int CValitity, int CreatedBy, string CreatedIP,string Operation,DateTime OfferLetterDate)
    {
        SqlParameter[] param = new SqlParameter[14];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@AIP", AIP);
        param[2] = new SqlParameter("@Name", Name);
        param[3] = new SqlParameter("@EmpType", EmpType);
        param[4] = new SqlParameter("@Ayear", Ayear);
        param[5] = new SqlParameter("@Designation", Designation);
        param[6] = new SqlParameter("@ContractType", ContractType);
        param[7] = new SqlParameter("@Grade", Grade);
        param[8] = new SqlParameter("@SubGrade", SubGrade);
        param[9] = new SqlParameter("@Contractvalidity", CValitity);
        param[10] = new SqlParameter("@Operation", Operation);
        param[11] = new SqlParameter("@CreatedBy", CreatedBy);
        param[12] = new SqlParameter("@CreatedIP", CreatedIP);
        param[13] = new SqlParameter("@OfferLetterDate", OfferLetterDate);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_Offer_Letter");
    }

    public DataTable  GetOfferLetter(Int32 ID, Int32 AIP, String Name, String EmpType, int Ayear, int Designation, string ContractType, int Grade, int SubGrade, int CValitity, int CreatedBy, string CreatedIP, string Operation,DateTime OfferLetterDate)
    {
        SqlParameter[] param = new SqlParameter[14];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@AIP", AIP);
        param[2] = new SqlParameter("@Name", Name);
        param[3] = new SqlParameter("@EmpType", EmpType);
        param[4] = new SqlParameter("@Ayear", Ayear);
        param[5] = new SqlParameter("@Designation", Designation);
        param[6] = new SqlParameter("@ContractType", ContractType);
        param[7] = new SqlParameter("@Grade", Grade);
        param[8] = new SqlParameter("@SubGrade", SubGrade);
        param[9] = new SqlParameter("@Contractvalidity", CValitity);
        param[10] = new SqlParameter("@Operation", Operation);
        param[11] = new SqlParameter("@CreatedBy", CreatedBy);
        param[12] = new SqlParameter("@CreatedIP", CreatedIP);
        param[13] = new SqlParameter("@OfferLetterDate", OfferLetterDate);
       
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_Offer_Letter");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public Int32 ResourceRequest(Int32 ID, int Position, String PositionRequired, string EmpType, DateTime ProjectStartDate, string GenderPreference,
        string NationalityPreference, int Qualification, int JobDescription, int Noresource, string SpecificSkills, int CreatedBy, string CreatedIP, string Operation, int Experience, int Ayear, string ExperienceTxt, string AcadamicSkilssTxt, string OtherReq, string FinRemarks = "", bool FinBudget = false, Decimal FinAmount = 0, bool HRR = false, bool HRJD = false, String HRRemarks="")
    {
        SqlParameter[] param = new SqlParameter[25];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@Position", Position);
        param[2] = new SqlParameter("@PositionRequired", PositionRequired);
        param[3] = new SqlParameter("@EmpType", EmpType);
        param[4] = new SqlParameter("@ProjectStartDate", ProjectStartDate);
        param[5] = new SqlParameter("@GenderPreference", GenderPreference);
        param[6] = new SqlParameter("@NationalityPreference", NationalityPreference);
        param[7] = new SqlParameter("@Qualification", Qualification);
        param[8] = new SqlParameter("@JobDescription", JobDescription);
        param[9] = new SqlParameter("@Noresource", Noresource);
        param[10] = new SqlParameter("@SpecificSkills", SpecificSkills);
        param[11] = new SqlParameter("@CreatedBy", CreatedBy);
        param[12] = new SqlParameter("@CreatedIP", CreatedIP);
        param[13] = new SqlParameter("@Operation", Operation);
        param[14] = new SqlParameter("@Expereience", Experience);
        param[15] = new SqlParameter("@Ayear", Ayear);
        param[16] = new SqlParameter("@Exp", ExperienceTxt);
        param[17] = new SqlParameter("@Askilss", AcadamicSkilssTxt);
        param[18] = new SqlParameter("@Oreq", OtherReq);
        param[19] = new SqlParameter("@FinRemarks", FinRemarks);
        param[20] = new SqlParameter("@FABudget", FinBudget);
        param[21] = new SqlParameter("@FAmount", FinAmount);
        param[22] = new SqlParameter("@HRR", HRR);
        param[23] = new SqlParameter("@HRJD", HRJD);
        param[24] = new SqlParameter("@HRRemarks", HRRemarks);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_ResourceRequest");

    }

    public DataTable  getResourceRequest(Int32 ID, int Position, String PositionRequired, string EmpType, DateTime ProjectStartDate, string GenderPreference,
    string NationalityPreference, int Qualification, int JobDescription, int Noresource, string SpecificSkills, int CreatedBy, string CreatedIP, string Operation, int Experience, int Ayear, string ExperienceTxt, string AcadamicSkilssTxt, string OtherReq, string FinRemarks = "", bool FinBudget = false, Decimal FinAmount = 0, bool HRR = false, bool HRJD = false, String HRRemarks = "")
    {
        SqlParameter[] param = new SqlParameter[25];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@Position", Position);
        param[2] = new SqlParameter("@PositionRequired", PositionRequired);
        param[3] = new SqlParameter("@EmpType", EmpType);
        param[4] = new SqlParameter("@ProjectStartDate", ProjectStartDate);
        param[5] = new SqlParameter("@GenderPreference", GenderPreference);
        param[6] = new SqlParameter("@NationalityPreference", NationalityPreference);
        param[7] = new SqlParameter("@Qualification", Qualification);
        param[8] = new SqlParameter("@JobDescription", JobDescription);
        param[9] = new SqlParameter("@Noresource", Noresource);
        param[10] = new SqlParameter("@SpecificSkills", SpecificSkills);
        param[11] = new SqlParameter("@CreatedBy", CreatedBy);
        param[12] = new SqlParameter("@CreatedIP", CreatedIP);
        param[13] = new SqlParameter("@Operation", Operation);
        param[14] = new SqlParameter("@Expereience", Experience);
        param[15] = new SqlParameter("@Ayear", Ayear);
        param[16] = new SqlParameter("@Exp", ExperienceTxt);
        param[17] = new SqlParameter("@Askilss", AcadamicSkilssTxt);
        param[18] = new SqlParameter("@Oreq", OtherReq);
        param[19] = new SqlParameter("@FinRemarks", FinRemarks);
        param[20] = new SqlParameter("@FABudget", FinBudget);
        param[21] = new SqlParameter("@FAmount", FinAmount);
        param[22] = new SqlParameter("@HRR", HRR);
        param[23] = new SqlParameter("@HRJD", HRJD);
        param[24] = new SqlParameter("@HRRemarks", HRRemarks);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_ResourceRequest");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public Int32 Category(String Category,Int32 OrganizationID)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Category", Category);
        param[1] = new SqlParameter("@OrganizationID", OrganizationID);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_Category_insert");

    }

    public Int32 Organization(int ID, String Name, String Location, int OrgType, int Country, bool IsActive, String Operation,String ModifiedBy)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@OrgName", Name);
        param[2] = new SqlParameter("@Location", Location);
        param[3] = new SqlParameter("@OrgType", OrgType);
        param[4] = new SqlParameter("@Country", Country);
        param[5] = new SqlParameter("@Isactive", IsActive);
        param[6] = new SqlParameter("@Operation", Operation);
        param[7] = new SqlParameter("@ModifiedBy", ModifiedBy);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_Organization");
    }

    public Int32 SUbDepartment(string DeptName,int ReportingDept,int MainDept,int OrgID,string CreatedBy,String Operation,int ID)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@DeptName", DeptName);
        param[1] = new SqlParameter("@ReportingDept", ReportingDept);
        param[2] = new SqlParameter("@MainDept", MainDept);
        param[3] = new SqlParameter("@OrgID", OrgID);
        param[4] = new SqlParameter("@CreatedBY", CreatedBy);
        param[5] = new SqlParameter("@Operation", Operation);
        param[6] = new SqlParameter("@ID", ID);
       
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_Department");
    }

    public DataTable InsertMainDepartment(string POSITION_NAME, int REPORTING_ID, int ORG_ID,
        string Operation, int ID)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@POSITION_NAME", POSITION_NAME);
        param[1] = new SqlParameter("@REPORTING_ID", REPORTING_ID);
        param[2] = new SqlParameter("@ORG_ID", ORG_ID);
        param[3] = new SqlParameter("@Operation", Operation);
        param[4] = new SqlParameter("@ID", ID);


        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "Sp_INSERT_MAINDepartMent");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;

    }
    public Int32 UpdateRecruitment(int LinkID, int Status, String Department)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@LinkID", LinkID);
        param[1] = new SqlParameter("@Status", Status);
        param[2] = new SqlParameter("@Department", Department);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_UpdateRecruitment");

    }

    public DataTable  CandidateData( String Operation,int ID)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@ID", ID);        
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "SP_ViewCandidate");

        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }


    public Int32 UpdateRecruitment_HOD(int LinkID, int Status, String Department)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@LinkID", LinkID);
        param[1] = new SqlParameter("@Status", Status);
        param[2] = new SqlParameter("@Department", Department);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_UpdateRecruitment_HOD");

    }

    public Int32 HOD2HR(int LinkID, int HOD, String HOD_NAME, string Remarks, string CreatedBy)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@LinkID", LinkID);
        param[1] = new SqlParameter("@HOD", HOD);
        param[2] = new SqlParameter("@HOD_NAME", HOD_NAME);
        param[3] = new SqlParameter("@Remarks", Remarks);
        param[4] = new SqlParameter("@CreatedBy", CreatedBy);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_HOD2HR");

    }



    public Int32 InsertSendMailLog(int LinkID, int HOD, String HODName, bool Status, string Remarks, string CreatedBy)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@LinkID", LinkID);
        param[1] = new SqlParameter("@HOD", HOD);
        param[2] = new SqlParameter("@HOD_NAME", HODName);
        param[3] = new SqlParameter("@MailSendStatus", Status);
        param[4] = new SqlParameter("@Remarks", Remarks);
        param[5] = new SqlParameter("@CreatedBy", CreatedBy);
        DataAccessLayer da = new DataAccessLayer();
        return da.InsertValues(param, "SP_InsertSendMailLog");

    }

    public DataTable GetSChoolTypeCDP()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam("SP_GetSchoolTypeCDP");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable GetDegreeTypeBySchoolCode(string SchoolCode)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@SchoolCode", SchoolCode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_GetDegreeTypeBySchoolCode");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindDegreeCodeByProgram(int DegreeTypeID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@DegreeTypeID", DegreeTypeID);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_GetDegreeCodeByProgram");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindCancelledStudentsReport(DateTime FromDate, DateTime EndDate, string School = "", int DegreeTypeID = 0, int DegreeCode = 0)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@StarDate", FromDate);
        param[1] = new SqlParameter("@EndDate", EndDate);
        param[2] = new SqlParameter("@School", School);
        param[3] = new SqlParameter("@DegreeTypeID", DegreeTypeID);
        param[4] = new SqlParameter("@DegreeID", DegreeCode);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_KOHA_CANCELLED_DETAILS");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindCancelledStudentsStatisticsReport(DateTime FromDate, DateTime EndDate, string School = "", int DegreeTypeID = 0, int DegreeCode = 0)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@StarDate", FromDate);
        param[1] = new SqlParameter("@EndDate", EndDate);
        param[2] = new SqlParameter("@School", School);
        param[3] = new SqlParameter("@DegreeTypeID", DegreeTypeID);
        param[4] = new SqlParameter("@DegreeID", DegreeCode);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_KOHA_CANCELLED_STATISTICS");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindBooksValidityReport(int copyrightdate = 0)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@copyrightdate", copyrightdate);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_BooksValidity");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindBookIssueSummaryReport(DateTime FromDate, DateTime EndDate, string School = "", int DegreeTypeID = 0, int CurriculumID = 0)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", EndDate);
        param[2] = new SqlParameter("@DegreeTypeID", DegreeTypeID);
        param[3] = new SqlParameter("@CurriculumID", CurriculumID);
        param[4] = new SqlParameter("@School", School);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_BOOKISSUANCE_DETAILS_REPORT");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindBookNotCollectStatsticsReport(DateTime FromDate, DateTime EndDate, string School = "", int DegreeTypeID = 0, int CurriculumID = 0)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", EndDate);
        param[2] = new SqlParameter("@DegreeTypeID", DegreeTypeID);
        param[3] = new SqlParameter("@CurriculumID", CurriculumID);
        param[4] = new SqlParameter("@School", School);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_BOOKNOTCOLLECTEDDETAILS");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
}