using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

public partial class Page_CalendarauditSummaryPrinReport : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }
    public void LoadReport()
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
        Processing p = new Processing();
        try
        {
            if (Request.QueryString["Type"] == "S")
            {
                string Department = Request.QueryString["Department"].ToString();
                string Semester = Request.QueryString["Semester"].ToString();
                string Year = Request.QueryString["Year"].ToString();
                string ItemType = Request.QueryString["ItemType"].ToString();
                string Path = Server.MapPath("CalenderAuditSummary.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\CalenderAuditSummary.rpt";
                myReportDocument.Load(Path);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
                myReportDocument.SetParameterValue("@department", Department);
                myReportDocument.SetParameterValue("@semester", Semester);
                myReportDocument.SetParameterValue("@year", Year);
                myReportDocument.SetParameterValue("@ItemType", ItemType);
            }

            else if (Request.QueryString["Type"] == "C")
            {
                string Department = Request.QueryString["Department"].ToString();
                string Semester = Request.QueryString["Semester"].ToString();
                string Year = Request.QueryString["Year"].ToString();
                string ItemType = Request.QueryString["ItemType"].ToString();
                string Path = Server.MapPath("CalenderauditCummulative.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\CalenderauditCummulative.rpt";
                myReportDocument.Load(Path);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
                myReportDocument.SetParameterValue("@department", Department);
                myReportDocument.SetParameterValue("@semester", Semester);
                myReportDocument.SetParameterValue("@year", Year);
                myReportDocument.SetParameterValue("@ItemType", ItemType);
            }
            else
            {
                string Department = Request.QueryString["Department"].ToString();
                string Semester = Request.QueryString["Semester"].ToString();
                string Year = Request.QueryString["Year"].ToString();
                string ItemType = Request.QueryString["ItemType"].ToString();
                string Path = Server.MapPath("calendarFeedback.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\calendarFeedback.rpt";
                myReportDocument.Load(Path);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
                myReportDocument.SetParameterValue("@department", Department);
                myReportDocument.SetParameterValue("@semester", Semester);
                myReportDocument.SetParameterValue("@year", Year);
                myReportDocument.SetParameterValue("@ItemType", ItemType);
            }           

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
        }
        catch (Exception Ex)
        {
            //LogFile L = new LogFile();
            //L.LogError("CalendarAuditSummaryPrintReport.aspx");
            //L.LogError(Ex.Message.ToString());
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