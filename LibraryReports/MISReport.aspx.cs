using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;

public partial class LibraryReports_MISReport : System.Web.UI.Page
{
    Settings S = new Settings();
    Processing P = new Processing();
    ReportDocument myReportDocument = new ReportDocument();
    DataTable Dtb = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindSchool();
            BindDegreeType(ddlSchools.SelectedValue);
            BindDegreeCode(Convert.ToInt32(ddlDegreeType.SelectedValue));
            BindCddList();
            Year();
            BindSemAll();
        }
    }

    public void BindSchool()
    {
        try
        {
            ddlSchools.DataSource = S.GetSChoolTypeCDP();
            ddlSchools.DataTextField = "SCHOOLNAME";
            ddlSchools.DataValueField = "SCHOOLCODE";
            ddlSchools.DataBind();
        }
        catch (Exception Ex) { }
    }
    public void BindDegreeType(string SchoolCode)
    {
        ddlDegreeType.DataSource = S.GetDegreeTypeBySchoolCode(SchoolCode);
        ddlDegreeType.DataTextField = "DegreeType";
        ddlDegreeType.DataValueField = "DegreeTypeId";
        ddlDegreeType.DataBind();
        if (DrpReportOption.SelectedValue == "BOOK ISSUE SUMMARY")
        {
            ddlDegreeType.Items.Remove(ddlDegreeType.Items.FindByValue("9"));
        }

    }
    public void BindDegreeCode(int DegreeType)
    {
        ddlDegreeCode.DataSource = S.BindDegreeCodeByProgram(DegreeType);
        ddlDegreeCode.DataTextField = "DegreeCode";
        ddlDegreeCode.DataValueField = "Degree_ID";
        ddlDegreeCode.DataBind();
        ddlDegreeCode.Items.Insert(0, new ListItem("ALL", "0"));
    }
    public void BindCddList()
    {
        ddlCurriculum.DataSource = P.BindCdd();
        ddlCurriculum.DataTextField = "Cdd_Code";
        ddlCurriculum.DataValueField = "Cdd_Id";
        ddlCurriculum.DataBind();
    }
    public void BindSemAll()
    {
        ddlSemester.DataSource = P.BindSemAll();
        ddlSemester.DataTextField = "Semester_Desc";
        ddlSemester.DataValueField = "Semester_RefID";
        ddlSemester.DataBind();
    }

    protected void Year()
    {

        for (int i = 1564; i <= DateTime.Now.Year; i++)
        {
            ddlCopyrightFromDate.Items.Add(i.ToString());
        }
        ddlCopyrightFromDate.Items.Insert(0, new ListItem("ALL", "0"));
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }

    public DateTime FromDate(TextBox FromDateValue)
    {
        string[] stringdate1 = new string[3];
        if (FromDateValue.Text != "")
            stringdate1 = FromDateValue.Text.Split('/');
        else
            stringdate1 = "01/01/1990".Split('/');
        DateTime FromDate = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));

        return FromDate;
    }

    public DateTime ToDate(TextBox ToDateValue)
    {
        string[] stringdate2 = new string[3];
        if (txtTodate.Text != "")
            stringdate2 = txtTodate.Text.Split('/');
        else
            stringdate2 = "01/01/1990".Split('/');
        stringdate2 = txtTodate.Text.Split('/');

        DateTime EndDate = new DateTime(Convert.ToInt32(stringdate2[2]), Convert.ToInt32(stringdate2[1]), Convert.ToInt32(stringdate2[0]));

        return EndDate;
    }

    public void LoadReport()
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();


        try
        {
            DateTime DtFromDate =new  DateTime();
            DateTime DtToDate = new DateTime();

            DtFromDate = FromDate(TxtFromDate);
            DtToDate = FromDate(txtTodate);

            string Path = "";

            if (DrpReportOption.SelectedValue == "CANCELLED STUDENTS")
            {
                Path = Server.MapPath("CancelledStudentsDetails.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\CancelledStudentsDetails.rpt";
                myReportDocument.Load(Path);
                myReportDocument.SetParameterValue("@StarDate", DtFromDate);
                myReportDocument.SetParameterValue("@EndDate", DtToDate);
                myReportDocument.SetParameterValue("@School", ddlSchools.SelectedValue);
                myReportDocument.SetParameterValue("@DegreeTypeID", ddlDegreeType.SelectedValue);
                myReportDocument.SetParameterValue("@DegreeID", ddlDegreeCode.SelectedValue);
                
            }
            else if (DrpReportOption.SelectedValue == "BOOK ISSUE SUMMARY")
            {
                Path = Server.MapPath("BOOKISSUESUMMARY.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\BOOKISSUESUMMARY.rpt";
                myReportDocument.Load(Path);
                myReportDocument.SetParameterValue("@FromDate", DtFromDate);
                myReportDocument.SetParameterValue("@ToDate", DtToDate);
                myReportDocument.SetParameterValue("@DegreeTypeID", ddlDegreeType.SelectedValue);
                myReportDocument.SetParameterValue("@CurriculumID", ddlCurriculum.SelectedValue);
                myReportDocument.SetParameterValue("@School", ddlSchools.SelectedValue);
            }
            else if (DrpReportOption.SelectedValue == "BOOKS NOT COLLECTED STATISTICS")
            {
                Path = Server.MapPath("BooksNotCollectedStatistics.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\BooksNotCollectedStatistics.rpt";
                myReportDocument.Load(Path);
                myReportDocument.SetParameterValue("@FromDate", DtFromDate);
                myReportDocument.SetParameterValue("@ToDate", DtToDate);
                myReportDocument.SetParameterValue("@DegreeTypeID", ddlDegreeType.SelectedValue);
                myReportDocument.SetParameterValue("@CurriculumID", ddlCurriculum.SelectedValue);
                myReportDocument.SetParameterValue("@School", ddlSchools.SelectedValue);
            }
            else if (DrpReportOption.SelectedValue == "BOOK VALIDITY")
            {
                Path = Server.MapPath("BooksValidity.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\BooksValidity.rpt";
                myReportDocument.Load(Path);
                myReportDocument.SetParameterValue("@copyrightdate", ddlCopyrightFromDate.SelectedValue);
            }
           
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
            
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

        }

        finally
        {
        }
    }

    //public void LoadBookValidityReport()
    //{
    //    System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
        
    //    try
    //    {
    //        string Path = Server.MapPath("BooksValidity.rpt");
    //        Path = Path.Substring(0, Path.LastIndexOf('\\'));
    //        Path = Path.Substring(0, Path.LastIndexOf('\\'));
    //        Path = Path + "\\Reports\\BooksValidity.rpt";
    //        myReportDocument.Load(Path);

    //        myReportDocument.SetParameterValue("@copyrightdate", 0);

    //        myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
    //        System.IO.Stream oStream = null;
    //        byte[] byteArray = null;
    //        oStream = myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
    //        byteArray = new byte[oStream.Length];
    //        oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
    //        Response.ClearContent();
    //        Response.ClearHeaders();
    //        Response.ContentType = "application/pdf";
    //        Response.BinaryWrite(byteArray);
    //        Response.Flush();
    //        Response.Close();
    //        myReportDocument.Close();
    //        myReportDocument.Dispose();
    //        GC.Collect();
    //    }
    //    catch (Exception Ex)
    //    {

    //    }

    //    finally
    //    {
    //    }
    //}

    //public void LoadBookBookIssueSummary()
    //{
    //    System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
        
    //    try
    //    {
    //        DateTime DtFromDate = new DateTime();
    //        DateTime DtToDate = new DateTime();

    //        DtFromDate = FromDate(TxtFromDate);
    //        DtToDate = FromDate(txtTodate);

    //        string Path = Server.MapPath("BOOKISSUESUMMARY.rpt");
    //        Path = Path.Substring(0, Path.LastIndexOf('\\'));
    //        Path = Path.Substring(0, Path.LastIndexOf('\\'));
    //        Path = Path + "\\Reports\\BOOKISSUESUMMARY.rpt";
    //        myReportDocument.Load(Path);

    //        myReportDocument.SetParameterValue("@FromDate", DtFromDate);
    //        myReportDocument.SetParameterValue("@ToDate", DtToDate);
    //        myReportDocument.SetParameterValue("@DegreeTypeID", ddlDegreeType.SelectedValue);
    //        myReportDocument.SetParameterValue("@CurriculumID", ddlCurriculum.SelectedValue);
    //        myReportDocument.SetParameterValue("@School", ddlSchools.SelectedValue);

    //        myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
    //        System.IO.Stream oStream = null;
    //        byte[] byteArray = null;
    //        oStream = myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
    //        byteArray = new byte[oStream.Length];
    //        oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
    //        Response.ClearContent();
    //        Response.ClearHeaders();
    //        Response.ContentType = "application/pdf";
    //        Response.BinaryWrite(byteArray);
    //        Response.Flush();
    //        Response.Close();
    //        myReportDocument.Close();
    //        myReportDocument.Dispose();
    //        GC.Collect();
    //    }
    //    catch (Exception Ex)
    //    {

    //    }

    //    finally
    //    {
    //    }
    //}

    public void BindGrid()
    {
        DateTime DtFromDate = new DateTime();
        DateTime DtToDate = new DateTime();

        DtFromDate = FromDate(TxtFromDate);
        DtToDate = FromDate(txtTodate);

        //if (RbtCancelledStudent.Checked)
        if (DrpReportOption.SelectedValue == "CANCELLED STUDENTS")
        {           
            Dtb = S.BindCancelledStudentsReport(DtFromDate, DtToDate, ddlSchools.SelectedValue, Convert.ToInt32(ddlDegreeType.SelectedValue), Convert.ToInt32(ddlDegreeCode.SelectedValue));
            GrvDetails.DataSource = Dtb;
            GrvDetails.DataBind();

            LoadExcel();

        }
        //else if (RbtBookValidity.Checked)
        else if (DrpReportOption.SelectedValue == "BOOK VALIDITY")
        {
            Dtb = S.BindBooksValidityReport(Convert.ToInt32(ddlCopyrightFromDate.SelectedValue));
            GrvDetails.DataSource = Dtb;
            GrvDetails.DataBind();
            LoadExcel();
        }
        else if (DrpReportOption.SelectedValue == "BOOK ISSUE SUMMARY")
        {
            Dtb = S.BindBookIssueSummaryReport(DtFromDate, DtToDate, ddlSchools.SelectedValue, Convert.ToInt32(ddlDegreeType.SelectedValue), Convert.ToInt32(ddlCurriculum.SelectedValue));
            GrvDetails.DataSource = Dtb;
            GrvDetails.DataBind();
            LoadExcel();
        }

        else if (DrpReportOption.SelectedValue == "BOOKS NOT COLLECTED STATISTICS")
        {
            Dtb = S.BindBookNotCollectStatsticsReport(DtFromDate, DtToDate, ddlSchools.SelectedValue, Convert.ToInt32(ddlDegreeType.SelectedValue), Convert.ToInt32(ddlCurriculum.SelectedValue));
            GrvDetails.DataSource = Dtb;
            GrvDetails.DataBind();
            LoadExcel();
        }

    }

    public void LoadExcel()
    {
        try
        {
            string result = ExcelUtility.ToExcel(GrvDetails.DataSource);
            ExcelUtility.ExportToExcel(result);
        }
        catch
        {

        }
    }

    protected void ddlSchools_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DrpReportOption.SelectedValue == "CANCELLED STUDENTS")
            {
                BindDegreeType(ddlSchools.SelectedValue);
            }
            else if (DrpReportOption.SelectedValue == "BOOK ISSUE SUMMARY")
            {
                lblDegreeCode.Attributes.Add("style", "display:none;");
                ddlDegreeCode.Attributes.Add("style", "display:none;");
                lblCurriculum.Attributes.Add("style", "display:inline;");
                ddlCurriculum.Attributes.Add("style", "display:inline;");
            }
            
        }
        catch (Exception Ex) { }
    }

    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindDegreeCode(Convert.ToInt32(ddlDegreeType.SelectedValue));
        }
        catch (Exception Ex) { }
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        if (DrpReportOption.SelectedValue == "CANCELLED STUDENTS" || DrpReportOption.SelectedValue == "BOOK ISSUE SUMMARY"
            || DrpReportOption.SelectedValue == "BOOK VALIDITY" || DrpReportOption.SelectedValue == "BOOKS NOT COLLECTED STATISTICS")
        {
            LoadReport();
        }       
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
            LoadExcel();
        }
        catch
        {

        }
    }

}