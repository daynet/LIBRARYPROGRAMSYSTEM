using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Configuration;

using System.Net.Sockets;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Processing
/// </summary>
public class Processing
{
    SqlConnection connTps;
    SqlConnection connAdvisory;
    public Processing()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataTable BindCalenderDropdown(string Operation, int EmpID, string CalName, int AY, String Date)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@EmpID", EmpID);
        param[2] = new SqlParameter("@CalName", CalName);
        param[3] = new SqlParameter("@AY", AY);
        param[4] = new SqlParameter("@Date", Date);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_DisplayCalenderName");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable KohaReport(string ID, string Operation, string Type, Int32 SemesterID = 0)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@Opeation", Operation);
        param[2] = new SqlParameter("@Type", Type);
        param[3] = new SqlParameter("@Semester", SemesterID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_Koha_Procedures_individual");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    //Added by pratheeba n

    public DataTable BindAcc()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam("GETAcaYear");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindSemesterAcYear_ALL(int AcYrID)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@AcYrID", AcYrID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "GetSemAcYr_ALL");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;

    }
    public DataTable BindFaculty()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam("sp_GetFaculty");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindBatch(Int32 Batch_id, string BatchCode, Int32 Faculty_id, Int32 Cdd_id, Int32 Shift_id, Int32 Room_id, Int32 Semester_id, string Operation, Int32 CreatedBy, DateTime StartDate, DateTime EndDate, DateTime ExamDate, string Session)
    {
        SqlParameter[] param = new SqlParameter[14];
        param[0] = new SqlParameter("@Batch_id", Batch_id);
        param[1] = new SqlParameter("@BatchCode", BatchCode);
        param[2] = new SqlParameter("@Faculty_id", Faculty_id);
        param[3] = new SqlParameter("@Cdd_id", Cdd_id);
        param[4] = new SqlParameter("@Shift_id", Shift_id);
        param[5] = new SqlParameter("@Room_id", Room_id);
        param[6] = new SqlParameter("@Semester_id", Semester_id);
        param[7] = new SqlParameter("@Operation", Operation);
        param[8] = new SqlParameter("@CreatedBy", CreatedBy);
        param[9] = new SqlParameter("@MacAddress", GetMacAddress());
        param[10] = new SqlParameter("@StartDate", StartDate);
        param[11] = new SqlParameter("@EndDate", EndDate);
        param[12] = new SqlParameter("@ExamDate", ExamDate);
        param[13] = new SqlParameter("@Sessions", Session);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "sp_batch_TEST");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
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

    public DataTable BindSemester()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam("GetSem");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindCdd()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam("GETCDDList");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindSem()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdminExamgetDataByParam("SP_SEM");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindDepartmentForBlocking(string Role)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Role", Role);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "PopulateDepartment_ForBlockReport");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable Bind_ExcelReportLIst(string Role)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Role", Role);
        //param[1] = new SqlParameter("@Stud_Regno", Stud_Regno);
        //param[2] = new SqlParameter("@Operation", Operation);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_ADMINEXCEL_REPORTS");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindERPYEAR()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam("BINDERP_YEAR");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindERPSemester(string AcadYear)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@ACADYEAR", AcadYear);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_BINDERP_SEMESTER");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindERPFacultyOnly(int faculty_id, int semesterid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@FACULTY_ID", faculty_id);
        param[1] = new SqlParameter("@SEMESTER_ID", semesterid);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_BINDERPFACULTY_ONLY");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindERPSemester(int Semesterid, int Empid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@SEMESTER_ID", Semesterid);
        param[1] = new SqlParameter("@EMPID", Empid);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_BINDERP_BATCHCODE");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindStudentPortalDetails(string Operation, string Stud_ID)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@Stud_ID", Stud_ID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_GetPortalLoginDetails");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public string GetIP()
    {
        string VisitorsIPAddr = "";
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if ((HttpContext.Current.Request.UserHostAddress.Length != 0))
        {
            VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
        }
        return VisitorsIPAddr.ToString();
    }

    public DataTable UPdatePortalBlockDetails(string LoginId, string Stud_ID, Boolean Fin, Boolean Lib, Boolean Adm, Boolean SSD, Boolean Hrd, Int32 UserID, string Remarks)
    {
        SqlParameter[] param = new SqlParameter[11];
        param[0] = new SqlParameter("@LoginId", LoginId);
        param[1] = new SqlParameter("@Stud_ID", Stud_ID);
        param[2] = new SqlParameter("@Fin", Fin);
        param[3] = new SqlParameter("@Lib", Lib);
        param[4] = new SqlParameter("@Adm", Adm);
        param[5] = new SqlParameter("@SSD", SSD);
        param[6] = new SqlParameter("@Hrd", Hrd);
        param[7] = new SqlParameter("@UserID", UserID);
        param[8] = new SqlParameter("@IpAddress", GetIP());
        param[9] = new SqlParameter("@MacAddress", GetMacAddress());
        param[10] = new SqlParameter("@Remarks", Remarks);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdmingetDataByParam(param, "SP_UpdateStudentPortalBlock");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable GetExportedStudentdetails_Blocking(string Operation)
    {
        DataSet ds = new DataSet();

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Operation", Operation);
        DataAccessLayer da = new DataAccessLayer();
        ds = da.AdmingetDataByParam(param, "SP_BindExcelExportStudent_BulkBlocing");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindFortNightlyReport(DateTime FromDate, DateTime Todate, string Operation, Int32 DegreeTypeID,
        Int32 CurriculumID, Int32 SemesterID, string Type, string UserType, string ReportType)
    {

        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@Operation", Operation);
        param[3] = new SqlParameter("@DegreeTypeID", DegreeTypeID);
        param[4] = new SqlParameter("@CurriculumID", CurriculumID);
        param[5] = new SqlParameter("@SemesterID", SemesterID);
        param[6] = new SqlParameter("@BookType", Type);
        param[7] = new SqlParameter("@UserType", UserType);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = new DataSet();
        if (ReportType == "DETAILS")
            ds = da.LibrarygetDataByParam(param, "SP_FORTNIGHTLYREPORTS");
        else
            ds = da.LibrarygetDataByParam(param, "SP_FORTNIGHTLYREPORTS_STATISTICS_FOREXCELDOWNLOAD");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindFortNightlyReportStudentDetails(DateTime FromDate, DateTime Todate, string Operation, Int32 DegreeTypeID,
      Int32 CurriculumID, Int32 SemesterID, string Type, string UserType, string ReportType)
    {

        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@Operation", Operation);
        param[3] = new SqlParameter("@DegreeTypeID", DegreeTypeID);
        param[4] = new SqlParameter("@CurriculumID", CurriculumID);
        param[5] = new SqlParameter("@SemesterID", SemesterID);
        param[6] = new SqlParameter("@BookType", Type);
        param[7] = new SqlParameter("@UserType", UserType);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = new DataSet();

        ds = da.LibrarygetDataByParam(param, "SP_FORTNIGHTLYREPORTS_STUDENTDETAILS");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable INSERTBOOKPRICE(string Operation, Decimal Price, DateTime EffectiveDate, Int32 ID, Int32 UserID)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@Price", Price);
        param[2] = new SqlParameter("@EffectiveDate", EffectiveDate);
        param[3] = new SqlParameter("@ID", ID);
        param[4] = new SqlParameter("@CreatedBy", UserID);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_INSERTBOOKPRICE");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable SP_Conference_Room_request(string @StudentId, DateTime @RequestedDate, string @RequestedTime, Int32 @CreatedBy, string @Operation)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@StudentId", @StudentId);
        param[1] = new SqlParameter("@RequestedDate", @RequestedDate);
        param[2] = new SqlParameter("@RequestedTime", @RequestedTime);
        param[3] = new SqlParameter("@CreatedBy", @CreatedBy);
        param[4] = new SqlParameter("@Operation", @Operation);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_Conference_Room_request");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindSemAll()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdminExamgetDataByParam("GetSemAll");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindMaterialData()
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[0];
        DataSet ds = da.getDataByParamPortal(param, "SP_library_Material");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable SP_Book_Requisition(Int32 @BRId, string @Student_Id, string @Book_Title,
        string @Author, string @Publisher, string @ISBN, int @Qty, decimal @UnitPrice, Int32 @Material,
        string @LibraryRemarks, Int32 @CreatedBy, string @Operation)
    {
        SqlParameter[] param = new SqlParameter[13];
        param[0] = new SqlParameter("@BRId", @BRId);
        param[1] = new SqlParameter("@Student_Id", @Student_Id);
        param[2] = new SqlParameter("@Book_Title", @Book_Title);
        param[3] = new SqlParameter("@Author", @Author);
        param[4] = new SqlParameter("@Publisher", @Publisher);
        param[5] = new SqlParameter("@ISBN", @ISBN);
        param[6] = new SqlParameter("@Qty", @Qty);
        param[7] = new SqlParameter("@UnitPrice", @UnitPrice);
        param[8] = new SqlParameter("@Material", @Material);
        param[9] = new SqlParameter("@LibraryRemarks", @LibraryRemarks);
        param[10] = new SqlParameter("@CreatedBy", @CreatedBy);
        param[11] = new SqlParameter("@CreatedIp", GetIP());
        param[12] = new SqlParameter("@Operation", @Operation);


        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_Book_Requisition");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable SP_Faculty_review(Int32 @Rid, string @FacultyId, string @BookTitle,
       string @Author, string @Publisher, string @ISBN, string @LO, string @Knowledge, string @Skills,
       string @Competency, string @Syllabus, Int32 @CreatedBy, string @Operation)
    {
        SqlParameter[] param = new SqlParameter[13];
        param[0] = new SqlParameter("@Rid", @Rid);
        param[1] = new SqlParameter("@FacultyId", @FacultyId);
        param[2] = new SqlParameter("@BookTitle", @BookTitle);
        param[3] = new SqlParameter("@Author", @Author);
        param[4] = new SqlParameter("@Publisher", @Publisher);
        param[5] = new SqlParameter("@ISBN", @ISBN);
        param[6] = new SqlParameter("@LO", @LO);
        param[7] = new SqlParameter("@Knowledge", @Knowledge);
        param[8] = new SqlParameter("@Skills", @Skills);
        param[9] = new SqlParameter("@Competency", @Competency);
        param[10] = new SqlParameter("@Syllabus", @Syllabus);
        param[11] = new SqlParameter("@CreatedBy", @CreatedBy);
        param[12] = new SqlParameter("@Operation", @Operation);


        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_Faculty_review");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable INSERTCOURSEMAPPING(string Operation, Int32 ID, int DegreeTypeID,string CDD_CODE,string KOHA_CDDCODE, DateTime EffectiveDate,  Int32 UserID)

    {
      
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@DegreeTypeID", DegreeTypeID);
        param[2] = new SqlParameter("@CDD_CODE", CDD_CODE);
        param[3] = new SqlParameter("@Koha_CDD_CODE", KOHA_CDDCODE);
        param[4] = new SqlParameter("@EffectiveStartdate", EffectiveDate);
        param[5] = new SqlParameter("@CreatedBy", UserID);
        param[6] = new SqlParameter("@CreatedIP", GetIP());
        param[7] = new SqlParameter("@ID", ID);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_INSERT_COURSECODE_MAPPING");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    //Added by shihab on 15/09/2019...
    public DataTable BookReturnDueDateEntry(string Operation, Int32 Id = 0, int SemesterId = 0, DateTime? DueDate = null, string Description = ""
                                            , bool? IsActive = null, Int32 CreatedBy = 0, string CreatedIP = "")
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@Id", Id);
        param[2] = new SqlParameter("@SemesterId", SemesterId);
        param[3] = new SqlParameter("@DueDate", DueDate);
        param[4] = new SqlParameter("@Description", Description);
        param[5] = new SqlParameter("@IsActive", IsActive);
        param[6] = new SqlParameter("@CreatedBy", CreatedBy);
        param[7] = new SqlParameter("@CreatedIP", CreatedIP);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "Sp_Tb_BookReturnDueDateEntry");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    //Added by shihab on 15/09/2019...
    public DataTable LoadDropDown(string Operation, Int32? Id = null)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@Id", Id);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "Sp_LoadDropDown");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    //Added by shihab on 15/09/2019...
    public DataSet LoadEMailData(string Operation, string dueDate = "", Int32? Id = null, string UserType = "STUDENT")
    {
       // SqlParameter[] param = new SqlParameter[3]
            SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Operation", Operation);
        param[1] = new SqlParameter("@DueDate", dueDate);
        param[2] = new SqlParameter("@Id", Id);
        param[3] = new SqlParameter("@UserType", UserType);
        

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "Sp_LoadDropDown");
        if (ds != null && ds.Tables.Count > 0)
            return ds;
        else
            return null;
    }
    //Added by shihab on 15/09/2019...
    public DataTable InsertEmailData(DataTable Dt)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@DTEmailData", Dt);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.LibrarygetDataByParam(param, "SP_INSERT_EMAIL_DATA");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
}
