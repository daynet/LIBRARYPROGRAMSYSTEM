using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Collections;

public partial class Page_StudentBlockReport : System.Web.UI.Page
{
    DataAccessLayerERP DALERP = new DataAccessLayerERP();
    ReportDocument myReportDocument = new ReportDocument();
    DBHandler DBH = new DBHandler();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDept(Convert.ToString(Session["Role"]));
        }

    }
    protected void BindDept(string Role)
    {
        Processing P = new Processing();
        DrpDepartment.DataSource = P.BindDepartmentForBlocking(Role);
        DrpDepartment.DataTextField = "Dept";
        DrpDepartment.DataValueField = "ID";
        DrpDepartment.DataBind();
        
    }


    public void LoadReport()
    {
        if (ChkExportExcel.Checked == true)
        {
            ArrayList pa = new ArrayList();
            ArrayList pv = new ArrayList();
            pa.Add("@Dept");
            pv.Add(Convert.ToInt32(DrpDepartment.SelectedValue));
            if (RdbExpotexcel.SelectedValue == "ST")
            {
                DataTable Dtb1 = new DataTable();
                DBH.AdminCreateDataTable(Dtb1, "sp_student_portalblock_summary", true, pa, pv);
                string ExcelName = DrpDepartment.SelectedItem.Text + "- Statistics";
                ExportToExcel(Dtb1, ExcelName);
            }
            else
            {

                DataTable Dtb2 = new DataTable();
                DBH.AdminCreateDataTable(Dtb2, "sp_block_studentsDetails_Departmentwise", true, pa, pv);
                string ExcelName = DrpDepartment.SelectedItem.Text + " - Details";
                ExportToExcel(Dtb2, ExcelName);
            }
        }
        else
        {
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

            Processing p = new Processing();

            try
            {

                string Path = Server.MapPath("Student_portalblock_summary.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\Student_portalblock_summary.rpt";
                myReportDocument.Load(Path);

                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "AdminExam");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
                myReportDocument.SetParameterValue("@Dept", Convert.ToInt32(DrpDepartment.SelectedValue));



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
                //L.LogError("StudentBlockReport.aspx");
                //L.LogError(Ex.Message.ToString());
                //L.LogError(Session["User"].ToString());
                //Response.Write(Ex.Message);

            }

            finally
            {

            }
        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }
    protected void btnload_Click(object sender, System.EventArgs e)
    {
        LoadReport();
    }

    private void ExportToExcel(DataTable Dtb,string Name)
    {

        GrvGrid.DataSource = Dtb;
        GrvGrid.DataBind();

        string result = ToExcel(GrvGrid.DataSource, Name);
        ExportToExcel(result, Name);


    }

    public static string ToExcel(object dataSource, string Name)
    {
        GridView grid = new GridView { DataSource = dataSource };
        grid.DataBind();

        StringBuilder sb = new StringBuilder();
        foreach (TableCell cell in grid.HeaderRow.Cells)
            sb.Append(string.Format("\"{0}\",", cell.Text));
        sb.Remove(sb.Length - 1, 1);
        sb.AppendLine();

        foreach (GridViewRow row in grid.Rows)
        {
            foreach (TableCell cell in row.Cells)
                sb.Append(string.Format("\"{0}\",", cell.Text.Trim().Replace("&nbsp;", string.Empty)));
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine();
        }
        ExportToExcel(sb.ToString(), Name);
        return "";
    }

    protected void ChkExportExcel_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkExportExcel.Checked == true)
        {
            RdbExpotexcel.Visible = true;
        }
        else
        {
            RdbExpotexcel.Visible = false;
        }
    }

    public static void ExportToExcel(string data, string Name)
    {
        
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + Name + ".csv");
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        HttpContext.Current.Response.ContentType = "text/csv";
        HttpContext.Current.Response.Write(data);
        HttpContext.Current.Response.End();
    }
}