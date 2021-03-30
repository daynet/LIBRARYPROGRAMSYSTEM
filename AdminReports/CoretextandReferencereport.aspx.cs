using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using System.Data;
using System.Reflection;
using CrystalDecisions.Reporting;
using CrystalDecisions;
using System.Data.SqlClient;
using System.Collections;

public partial class Page_CoretextandReferencereport : System.Web.UI.Page
{
    DBHandler DBH = new DBHandler();
    ReportDocument myReportDocument = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCddList();
        }
    }

    public void BindCddList()
    {
        Processing term = new Processing();
        DrpCDD.DataSource = term.BindCdd();
        DrpCDD.DataTextField = "Cdd_Code";
        DrpCDD.DataValueField = "Cdd_Id";
        DrpCDD.DataBind();

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

            string Path = "C";
            if (rdotype.SelectedValue == "C")
            {

                Path = Server.MapPath("cddcoreReport.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\cddcoreReport.rpt";

            }
            else
            {
                Path = Server.MapPath("cddTextReport.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\cddTextReport.rpt";

            }

            myReportDocument.Load(Path);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");

            myReportDocument.SetParameterValue("@curriculumid", DrpCDD.SelectedValue);
            myReportDocument.SetParameterValue("@degreeid", Drpdegree.SelectedValue);

            //stream1 = null;
            //ExportOptions ex = myReportDocument.ExportOptions;
            //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
            //ExportRequestContext x = new ExportRequestContext();
            //x.ExportInfo = ex;
            //stream1 = (System.IO.MemoryStream)myReportDocument.FormatEngine.ExportToStream(x);
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            ////Response.ContentType = "application/excel";
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
            //L.LogError("CoretextandReferencereport.aspx");
            //L.LogError(Ex.Message.ToString());
            //L.LogError(Session["User"].ToString());
            //Response.Write(Ex.Message);

        }

        finally
        {
        }
    }  

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    public void LoadToExcel()
    {
        int curriculumId = Convert.ToInt32(DrpCDD.SelectedValue);
        int degreeId = Convert.ToInt32(Drpdegree.SelectedValue);
        ArrayList pa = new ArrayList();
        ArrayList pv = new ArrayList();
        pa.Add("@curriculumid");
        pa.Add("@degreeid");

        pv.Add(curriculumId);
        pv.Add(degreeId);

        DataTable Dtb1 = new DataTable();
        if (rdotype.SelectedValue == "C")
        {
            DBH.AdminCreateDataTable(Dtb1, "sp_DisplayCDDCoreText", true, pa, pv);
        }
        else
        {
            DBH.AdminCreateDataTable(Dtb1, "sp_DisplayCDDTextref", true, pa, pv);
        }
       
        ExportToExcel(Dtb1);
    }

    private void ExportToExcel(DataTable Dtb)
    {

        gV_CoreText.DataSource = Dtb;
        gV_CoreText.DataBind();

        string result = ExcelUtility.ToExcel(gV_CoreText.DataSource);
        ExcelUtility.ExportToExcel(result);


    }

    protected void BtnExcel_Click(object sender, EventArgs e)
    {
        LoadToExcel();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }
}