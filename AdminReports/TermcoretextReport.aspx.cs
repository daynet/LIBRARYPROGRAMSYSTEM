using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

public partial class Page_TermcoretextReport : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_sem();
        }

    }
    public void Bind_sem()
    {
        try
        {
            Processing term = new Processing();
            drp_Semester.DataSource = term.BindSemester();
            drp_Semester.DataTextField = "Semester_Desc";
            drp_Semester.DataValueField = "Semester_RefID";
            drp_Semester.DataBind();

        }
        catch
        {
        }
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        try
        {
            LoadReport();
        }
        catch
        {
        }
    }
    public void LoadReport()
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

        Processing p = new Processing();

        try
        {

            string Path = "C";
            if (rdotype.SelectedValue == "C")
            {

                Path = Server.MapPath("termcore.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\termcore.rpt";

            }
            else
            {
                Path = Server.MapPath("termcore_1.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\termcore_1.rpt";

            }

            myReportDocument.Load(Path);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");

            myReportDocument.SetParameterValue("@semid", drp_Semester.SelectedValue);
            myReportDocument.SetParameterValue("@degreeid", Drpdegree.SelectedValue);


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
            //L.LogError("TermcoretextReport.aspx");
            //L.LogError(Ex.Message.ToString());
            //L.LogError(Session["User"].ToString());
            //Response.Write(Ex.Message);

        }

        finally
        {
        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        myReportDocument.Close();
        GC.Collect();
        myReportDocument.Dispose();
    }
}