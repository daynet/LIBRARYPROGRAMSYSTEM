using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;

public partial class Page_EnrollmentReport_Viewer : System.Web.UI.Page
{
    int Semester_ID;
     int Option;
     ReportDocument myReportDocument = new ReportDocument();
     ReportDocument myReportDocument1 = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                Semester_ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                ViewState.Add("Semester_ID", Semester_ID);
                Option = Convert.ToInt32(Request.QueryString["Option"].ToString());
                ViewState.Add("Option", Option);
                if (Option == 2)
                {
                    ViewState.Add("ShiftID", Convert.ToInt32(Request.QueryString["ShiftID"].ToString()));
                    ViewState.Add("LevelID", Convert.ToInt32(Request.QueryString["LevelID"].ToString()));
                    ViewState.Add("SectionID", Convert.ToInt32(Request.QueryString["SectionID"].ToString()));
                }
                else if (Option == 3)
                {
                    ViewState.Add("FacultyID", Convert.ToInt32(Request.QueryString["FacultyID"].ToString()));
                }
                else if (Option == 4 || Option == 8)
                {
                    ViewState.Add("StudID", Request.QueryString["StudID"].ToString());
                }
                else if (Option == 6)
                {
                    ViewState.Add("BatchID", Convert.ToInt32(Request.QueryString["BatchID"].ToString()));
                }
                else if (Option == 7)
                {
                    ViewState.Add("WeekDay_ID", Convert.ToInt32(Request.QueryString["WeekDay_ID"].ToString()));
                    ViewState.Add("SessionID", Convert.ToInt32(Request.QueryString["SessionID"].ToString()));
                }
                LoadReport();
            }

            catch (Exception ex)
            {
            }
        }
    }
    protected void LoadReport()
    {  
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

        Processing p = new Processing();

        try
        {

        if (Option == 1)
        {
            string Path = Server.MapPath("CourseEnrolledSummayReport.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\CourseEnrolledSummayReport.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Semester_ID", Semester_ID);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 2)
        {
            string Path="";
            if (Convert.ToInt32(ViewState["ShiftID"].ToString()) == 3)
            {
                Path = Server.MapPath("Levelwisereport.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\Levelwisereport.rpt";
            }
            else
            {
                Path = Server.MapPath("LevelwisereportWeekday.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\LevelwisereportWeekday.rpt";
            }

            
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@groupid", Convert.ToInt32(ViewState["SectionID"].ToString()));
            myReportDocument.SetParameterValue("@levelid", Convert.ToInt32(ViewState["LevelID"].ToString()));
            myReportDocument.SetParameterValue("@semesterid", Semester_ID);
            myReportDocument.SetParameterValue("@shift", Convert.ToInt32(ViewState["ShiftID"].ToString()));
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 3)
        {
            string Path = Server.MapPath("FacultySchedule.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\FacultySchedule.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Semester_ID", Semester_ID);
            myReportDocument.SetParameterValue("@Faculty_ID", Convert.ToInt32(ViewState["FacultyID"].ToString()));
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 4)
        {
            
            //string Path = Server.MapPath("StudentClassSession.rpt");
            string Path = Server.MapPath("StudentClassSessionNew.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            //Path = Path + "\\Reports\\StudentClassSession.rpt";
            Path = Path + "\\Reports\\StudentClassSessionNew.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Semester_ID", Semester_ID);
            myReportDocument.SetParameterValue("@StudId", ViewState["StudID"].ToString());
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 5)
        {
            string Path = Server.MapPath("CourseEnrollmentStatusReport.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\CourseEnrollmentStatusReport.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Semester_ID", Semester_ID);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 6)
        {
            string Path = Server.MapPath("BatwiseStudentDetailReport.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\BatwiseStudentDetailReport.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Batch_ID", Convert.ToInt32(ViewState["BatchID"].ToString()));
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 7)
        {
            string Path = Server.MapPath("StudentClashReport.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\StudentClashReport.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Semester_ID", Semester_ID);
            myReportDocument.SetParameterValue("@WeekDay_ID", Convert.ToInt32(ViewState["WeekDay_ID"].ToString()));
            myReportDocument.SetParameterValue("@SessionID", Convert.ToInt32(ViewState["SessionID"].ToString()));
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 8)
        {
            string Path = Server.MapPath("Student_Wise_Batch_Details.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\Student_Wise_Batch_Details.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@SemID", Semester_ID);
            myReportDocument.SetParameterValue("@StudID", ViewState["StudID"].ToString());
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else if (Option == 9)
        {
            string Path = Server.MapPath("SemesterWiseBatchReport.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\SemesterWiseBatchReport.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Semester_ID", Semester_ID);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
       
        //stream1 = null;
        //ExportOptions ex = myReportDocument.ExportOptions;
        //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
        //ExportRequestContext x = new ExportRequestContext();
        //x.ExportInfo = ex;
        //stream1 = (System.IO.MemoryStream)myReportDocument.FormatEngine.ExportToStream(x);
        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.BinaryWrite(stream1.ToArray());
        //Response.End();
        //stream1.Close();

        System.IO.Stream oStream = null;
        byte[] byteArray = null;
        oStream = myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        byteArray = new byte[oStream.Length];
        oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(byteArray);
        Response.Flush();
        Response.Close();
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
        }
        catch (Exception Ex)
        {
            //LogFile L = new LogFile();
            //L.LogError("Page_EnrollmentReport_Viewer");
            //L.LogError(Ex.Message.ToString());
            //L.LogError( Option.ToString());
            //L.LogError(Session["User"].ToString());
            //Response.Write(Ex.Message);

        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }

}