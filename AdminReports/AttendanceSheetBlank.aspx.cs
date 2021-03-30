using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

public partial class AttendanceSheetBlank : System.Web.UI.Page
{

    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDropDownList();
            BindTerm();
            BindFaculty();
            BindBatches();
        }
        //LoadReport();
    }
    public void BindDropDownList()
    {
        try
        {
            Processing term = new Processing();
            DrpAcademicYear.DataSource = term.BindAcc();
            DrpAcademicYear.DataTextField = "AcadYear_Desc";
            DrpAcademicYear.DataValueField = "AcadYear_ID";
            DrpAcademicYear.DataBind();
        }
        catch (Exception Ex) { }
    }
    public void BindTerm()
    {
        Processing term = new Processing();
        DrpTerm.DataSource = term.BindSemesterAcYear_ALL(Convert.ToInt32(DrpAcademicYear.SelectedValue));
        DrpTerm.DataTextField = "Semester_Desc";
        DrpTerm.DataValueField = "Semester_RefID";
        DrpTerm.DataBind();
    }
    protected void DrpAcademicYear_SelectedIndexChanged1(object sender, EventArgs e)
    {
        BindTerm();
    }
    protected void DrpTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
       BindBatches();
    }
    public void BindFaculty()
    {
        try
        {
            Processing obj = new Processing();
            drpFaculty.DataSource = obj.BindFaculty();
            drpFaculty.DataTextField = "EMPName";
            drpFaculty.DataValueField = "EMPID";
            drpFaculty.DataBind();
            drpFaculty.Items.Insert(0, new ListItem("Select", "0"));
            drpFaculty.SelectedIndex = 0;
            //if (!string.IsNullOrEmpty(Convert.ToString(Session["UserId"])))
            //{
            //    //string UserID = Convert.ToString(Session["UserId"]);
            //    //if (Convert.ToString(Session["Role"]) != "Admin" && Convert.ToString(Session["Role"]) != "AdminDept" && Convert.ToString(Session["Role"]) != "Examination")
            //    //{
            //        drpFaculty.Enabled = false;
            //        drpFaculty.SelectedValue = UserID;
            //   // }
            //}
        }
        catch (Exception Ex) { }
    }
    public void BindBatches()
    {
        if (!string.IsNullOrEmpty(Convert.ToString(drpFaculty.Text)))
        {
            Processing term = new Processing();
            drp_Batch.DataSource = term.BindBatch(0, "", Convert.ToInt32(drpFaculty.SelectedValue), 0, 0, 0, Convert.ToInt32(DrpTerm.SelectedValue), "SelectByFaculty", 0, DateTime.Now, DateTime.Now, DateTime.Now, "");
            drp_Batch.DataTextField = "BatchCode";
            drp_Batch.DataValueField = "Batch_id";
            drp_Batch.DataBind();
            drp_Batch.Items.Insert(0, new ListItem("Select", "0"));
        }
        else
        {
            drp_Batch.DataSource = null;
            drp_Batch.DataBind();
            drp_Batch.Items.Insert(0, new ListItem("Select", "0"));
        }
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

            string Path = Server.MapPath("BatwiseStudentDetailReport.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\BatwiseStudentDetailReport.rpt";
            myReportDocument.Load(Path);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
            myReportDocument.SetParameterValue("@Batch_ID", drp_Batch.SelectedItem.Value);
            
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
            //L.LogError("AdvisoryAttendanceSheetBlank.aspx");
            //L.LogError(Ex.Message.ToString());
            //L.LogError(Session["User"].ToString());
            //Response.Write(Ex.Message);
        }
        finally
        {
        }
    }
    protected void drpFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindBatches();
        }
        catch (Exception Ex) { }
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }
}