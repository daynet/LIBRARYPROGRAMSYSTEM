using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for Attendance
/// </summary>
public class Attendance
{
	public Attendance()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable SetINOUT(Int32 id, string InTime, string OutTime, string CDate)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Id", id);
        param[1] = new SqlParameter("@InTime", InTime);
        param[2] = new SqlParameter("@OutTime", OutTime);
        param[3] = new SqlParameter("@CDate", CDate);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GETPUNCHESBTINOUT]");
        return
        ds.Tables[0];

    }
    public DataTable GETStudentBusPunchReport(int ClassId, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@DATE", ClassId);
        param[1] = new SqlParameter("@Bus", Date);
        
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetStudentBusPunchedReport]");
        return ds.Tables[0];
    }
    public DataTable GETStudentBusPunchReport1(int Bus, string Date, string FTime, string ToTime)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Date", Date);
        param[1] = new SqlParameter("@Bus", Bus);
        param[2] = new SqlParameter("@FromTime", FTime);
        param[3] = new SqlParameter("@ToTime", ToTime);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetStudentBusPunchedReport]");
        return ds.Tables[0];
    }

    public DataTable GETBusNotLiveReport(string Date)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[BusNotLive]");
        return ds.Tables[0];
    }
    public DataTable GetMorningNotOUTReport(string Date)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[MorningException]");
        return ds.Tables[0];
    }
    public DataTable GetStaybackExceptionReport(string Date)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@CDate", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[StaybackException]");
        return ds.Tables[0];
    }
    public DataTable GetAfterNoonExceptionReport(string Date, string FromTime, string ToTime)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Date", Date);
        param[1] = new SqlParameter("@FromTime", FromTime);
        param[2] = new SqlParameter("@ToTime", ToTime);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[AfterNoonException]");
        return ds.Tables[0];
    }
    public DataTable InOutExceptionReport(string Date, string FromTime, string ToTime)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Date", Date);
        param[1] = new SqlParameter("@FromTime", FromTime);
        param[2] = new SqlParameter("@ToTime", ToTime);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[StudentException]");
        return ds.Tables[0];
    }
    public DataTable GetINOUTReport(int ClassId, string ToDate, string FromDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@deptno", ClassId);
        param[1] = new SqlParameter("@vDate", ToDate);
        param[2] = new SqlParameter("@vEdate", FromDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GETINOUTREPORT]");
        return ds.Tables[0];
    }
    public DataTable LabWiseDaliyInOut(string  Date, int ClassSectionId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Date", Date);
        param[1] = new SqlParameter("@ClassSectionId", ClassSectionId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[LabWiseDaliyInOut]");
        return ds.Tables[0];
    }
    public DataTable GetAttendance(string Subject, DateTime TodayDate)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Subject", Subject);
        param[1] = new SqlParameter("@TodayDate", TodayDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAttendance]");
        return ds.Tables[0];
    }
    public DataTable GetBatchCode(int EmpId, string Subjects)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@EmpId", EmpId);
        param[1] = new SqlParameter("@Subjects", Subjects);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetBatchCode]");
        return ds.Tables[0];
    }
    public DataTable GetSubject(int EmpId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpId", EmpId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSubject]");
        return ds.Tables[0];
    }
    public DataTable GetUserDetails(string UserName,string Password)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserName", UserName);
        param[1] = new SqlParameter("@Password", Password);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetUserDetails]");
        return ds.Tables[0];
    }
    public DataTable GetSListForFaculty(string ClassId, string DivId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ClassId", ClassId);
        param[1] = new SqlParameter("@DivId", DivId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSListForFacultyDetails]");
        return ds.Tables[0];
    }  
    public DataTable GetSListForFaculty001(string ClassId, string DivId,string DDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ClassId", ClassId);
        param[1] = new SqlParameter("@DivId", DivId);
        param[2] = new SqlParameter("@Date", DDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSListForFacultyDetails002]");
        return ds.Tables[0];
    }
     public DataTable GetSListForFaculty1(int ClassSectionId,int LabCode,int HeadCount)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ClassSectionId", ClassSectionId);
        param[1] = new SqlParameter("@TerminalID", LabCode);
        param[2] = new SqlParameter("@headcount", HeadCount);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSListForFacultyDetails1]");
        return ds.Tables[0];
    }
    public DataTable GetSListForPreview(string ClassId, string DivId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ClassId", ClassId);
        param[1] = new SqlParameter("@DivId", DivId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSListForPreview]");
        return ds.Tables[0];
    }
    public DataTable GetLateArrivalList(string EDate)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EDate", EDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetLateArrivalList]");
        return ds.Tables[0];
    }
    public DataTable GetMisMatchNotFilledList(string EDate)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EDate", EDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMisMatchNotFilledList]");
        return ds.Tables[0];
    }
    public DataTable GetNotTrackedList(string EDate)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EDate", EDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetNotTrackedList]");
        return ds.Tables[0];
    }
    public DataTable GetWeek(int EmpId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpId", EmpId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetWeek]");
        return ds.Tables[0];
    }
    public string InsertAttendance(string StudentId,string Session,bool IsPresent,string Week)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RFIDConn"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertAttendance", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", StudentId);
            cmd.Parameters.AddWithValue("@SessionId", Session);
            cmd.Parameters.AddWithValue("@IsPresent", IsPresent);
            cmd.Parameters.AddWithValue("@Week", Week);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "STUD Saved!!! ";
        }
        catch
        {
            return "STUD Try Again!!!";
        }
    }
    public DataTable GetLevel()
    {
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam("[GetLevels]");
        return ds.Tables[0];
    }
    public DataTable GetAllBatches(string Level,string Shift, string EmpId)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Level", Level);
        param[1] = new SqlParameter("@Timming", Shift);
        param[2] = new SqlParameter("@EmpId", EmpId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAllBatches]");
        return ds.Tables[0];
    }
    public DataTable GetEmailId(string BatchCode)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@BatchCode", BatchCode);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAllEmailId]");
        return ds.Tables[0];
    }
    public string InsertAttendanceInTEnter(string Name,string EmpId, string Session)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RFIDConn"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertAttendanceInTEnter", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@Session", Session);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "ACSDB Saved!!!";
        }
        catch
        {
            return "ACSDB Try Again!!!";
        }
    }
    public DataTable GetMCCode(string EmpId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpId", EmpId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMCCode]");
        return ds.Tables[0];
    }
    public DataTable STAYBACK_ATTENDANCE_STUDENT_MATCHED_WITH_RFID_EAEP_Rport(string edate1, int class_id)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@edate1", edate1);
        param[1] = new SqlParameter("@class_id", class_id);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[STAYBACK_ATTENDANCE_STUDENT_MATCHED_WITH_RFID_EAEP_Rport]");
        return ds.Tables[0];
    }
    public DataTable ATTENDANCE_STUDENT_FROM_CLASS_ENTRY(string edate1, string edate2, int class_id)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@edate1", edate1);
        param[1] = new SqlParameter("@edate2", edate2);
        param[2] = new SqlParameter("@class_id", class_id);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[ATTENDANCE_STUDENT_FROM_CLASS_ENTRY]");
        return ds.Tables[0];
    }
    public DataTable ATTENDANCE_STUDENT_FROM_CLASS_ALL_SOURCES_EXCEPTION(string edate1, int flag)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@edate1", edate1);
        param[1] = new SqlParameter("@flag", flag);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[ATTENDANCE_STUDENT_FROM_CLASS_ALL_SOURCES_EXCEPTION]");
        return ds.Tables[0];
    }
    public DataTable SP_GET_STUDLIST_CARD_NOTSWIPED(string vdate, int class_id)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@vdate", vdate);
        param[1] = new SqlParameter("@classid", class_id);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[SP_GET_STUDLIST_CARD_NOTSWIPED]");
        return ds.Tables[0];
    }
    public DataTable Sp_getStudList_CardnotSwipedWithAttendance(string vdate, int class_id)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@vdate", vdate);
        param[1] = new SqlParameter("@classid", class_id);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[Sp_getStudList_CardnotSwipedWithAttendance]");
        return ds.Tables[0];
    }
    public DataTable ATTENDANCE_STUDENT_FROM_CLASS_ALL_SOURCES(string vdate, int class_id)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@edate1", vdate);
        param[1] = new SqlParameter("@class_id", class_id);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[ATTENDANCE_STUDENT_FROM_CLASS_ALL_SOURCES]");
        return ds.Tables[0];
    }
    public DataTable Sp_MatchClassAttendanceWithRfid(string vdate,string Shift, int class_id)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ODate", vdate);
        param[1] = new SqlParameter("@Shift", Shift);
        param[2] = new SqlParameter("@classId", class_id);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMorningAttendance]");
        return ds.Tables[0];
    }
    public DataTable ATTENDANCE_STUDENT_MATCHED_WITH_RFID_TEMP(string vdate, int Flag, string Value)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@edate1", vdate);
        param[1] = new SqlParameter("@Flag", Flag);
        param[2] = new SqlParameter("@Value", Value);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[ATTENDANCE_STUDENT_MATCHED_WITH_RFID_TEMP]");
        return ds.Tables[0];
    }
    public DataTable StayBackWithOutReason(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetStayBackWithOutReason]");
        return ds.Tables[0];
    }
    public DataTable GetStayBackWithReason(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetStayBackWithReason]");
        return ds.Tables[0];
    }
    public DataTable GetMorningMisMatch(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMorningMisMatch]");
        return ds.Tables[0];
    }
    public DataTable GetMorningMisMatchVB(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMorningMisMatchVB]");
        return ds.Tables[0];
    }
    public DataTable GetMismatchNotDoneVB(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMismatchNotDoneVB]");
        return ds.Tables[0];
    }
    public DataTable UploadData(string Date)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[UploadData]");
        return ds.Tables[0];
    }
    public DataTable GetAttendanceTakenList(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAttendanceTakenList]");
        return ds.Tables[0];
    }
    public DataTable GetAttendanceNotTakenList(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAttendanceNotTakenList]");
        return ds.Tables[0];
    }
    public DataTable GetMorningClassAttendanceReport(int ClassSectionId, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ClassSectionId", ClassSectionId);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMorningClassAttendanceReport]");
        return ds.Tables[0];
    }
    public DataTable GetMorningRFIDAttendanceReport(int ClassSectionId, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ClassSectionId", ClassSectionId);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMorningRFIDAttendanceReport]");
        return ds.Tables[0];
    }
    public DataTable GetCheckBusRFIDAttendance(string FromDate, string FTime, string ToTime)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Date", FromDate);
        param[1] = new SqlParameter("@FromTime", FTime);
        param[2] = new SqlParameter("@ToTime", ToTime);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetCheckBusRFIDAttendance]");
        return ds.Tables[0];
    }
    public DataTable GetConsolidatedAttendance(int Class, string FromDate, string ToDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@class_id", Class);
        param[1] = new SqlParameter("@edate1", FromDate);
        param[2] = new SqlParameter("@edate2", ToDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[ATTENDANCE_STUDENT_FROM_CLASS_ENTRY]");
        return ds.Tables[0];
    }
    public DataTable GetConsolidatedAttendancePercentage(int Class, string FromDate, string ToDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@class_id", Class);
        param[1] = new SqlParameter("@edate1", FromDate);
        param[2] = new SqlParameter("@edate2", ToDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[SP_CONSOLIDATED_ATTENDANCE]");
        return ds.Tables[0];
    }
    public DataTable GetConsolidatedAttendancePercentageSession(int Class, string FromDate, string ToDate, string Session)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@class_id", Class);
        param[1] = new SqlParameter("@edate1", FromDate);
        param[2] = new SqlParameter("@edate2", ToDate);
        param[3] = new SqlParameter("@session", Session);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[SP_CONSOLIDATED_NEGPERCENTAGE]");
        return ds.Tables[0];
    }
    public DataTable GetINOUTReport(int ClassId, string FromDate)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ClassSectionId", ClassId);
        param[1] = new SqlParameter("@Date", FromDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[ClassWiseDaliyInOut]");
        return ds.Tables[0];
    }

    public DataTable SetDropdownList(int Flag)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Flag", Flag);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetDropdown]");
        return ds.Tables[0];
    }
    public DataTable GetBusDetails(int BusId, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@BusId", BusId);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetBusDetails]");
        return ds.Tables[0];
    }
    public DataTable GetSinglePuches(int Flag, string Date, int ClassId)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Date", Date);
        param[2] = new SqlParameter("@ClassId", ClassId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSinglePuches]");
        return ds.Tables[0];
    }
    public DataTable GetMorningClassAttendanceReportVB(int ClassSectionId, string Date, string  SectionID)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ClassSectionId", ClassSectionId);
        param[1] = new SqlParameter("@Date", Date);
        param[2] = new SqlParameter("@SectionID", SectionID);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMorningClassAttendanceReportVB]");
        return ds.Tables[0];
    }
    public DataTable StayBackWithOutReasonVB(int Wing, string Date)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Wing", Wing);
        param[1] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetStayBackWithOutReasonVB]");
        return ds.Tables[0];
    }
    public DataTable GetAbsentesereport(string Date)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAbsentesereport]");
        return ds.Tables[0];
    }


    public DataTable GET_EXCEL_ABSENTEES_REPORT(string Date)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@exam_date", Date);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_final_exam_abs]");
        return ds.Tables[0];
    }

    public DataTable GetSListForFacultyUndertaking(string ClassId, string DivId, string DDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@ClassId", ClassId);
        param[1] = new SqlParameter("@DivId", DivId);
        param[2] = new SqlParameter("@Date", DDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSListForFacultyDetails_UnterTaking]");
        return ds.Tables[0];
    }
}