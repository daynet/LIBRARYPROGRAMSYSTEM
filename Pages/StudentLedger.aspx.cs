using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text;
using System.Configuration;
using System.IO;

public partial class Page_StudentLedger : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        myReportDocument.Close();
        GC.Collect();
        myReportDocument.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       // string StudentID = Request.QueryString["Stud_Id"].ToString();
        string StudentID = Convert.ToString(Request.QueryString["id"]);
        LoadReport(Convert.ToString(StudentID));
    }
    public void LoadReport(string StudentID = "")
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

        Processing p = new Processing();

        try
        {

            string Path = Server.MapPath("StudentLedger.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\StudentLedger.rpt";
            myReportDocument.Load(Path);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "TPS");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
            myReportDocument.SetParameterValue("@studentid", StudentID);

            //CrystalReportViewer1.ReportSource = myReportDocument;
            //CrystalReportViewer1.DataBind();

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
        }
        catch (Exception Ex)
        {
            //LogFile L = new LogFile();
            //L.LogError("StudentLedger.aspx");
            //L.LogError(Ex.Message.ToString());
            //L.LogError(Session["User"].ToString());
            //Response.Write(Ex.Message);

        }

        finally
        {

        }
    }
}