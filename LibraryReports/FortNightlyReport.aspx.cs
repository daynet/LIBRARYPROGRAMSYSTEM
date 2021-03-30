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


public partial class LibraryReports_FortNightlyReport : System.Web.UI.Page
{
    Processing P = new Processing();
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            LoadDropDown();
            BindCddList();
            cleardata();
        }
    }
    protected void cleardata()
    {
        RdbReportOption.SelectedValue="DETAILS";
    }
    public void LoadDropDown()
    {
        DrpAyYear.DataSource = P.BindAcc();
        DrpAyYear.DataTextField = "AcadYear_Desc";
        DrpAyYear.DataValueField = "AcadYear_ID";
        DrpAyYear.DataBind();
        LoadSemester();
    }

    public void LoadSemester()
    {
        DrpSemester.DataSource = P.BindSemesterAcYear_ALL(Convert.ToInt32(DrpAyYear.SelectedValue));
        DrpSemester.DataTextField = "Semester_Desc";
        DrpSemester.DataValueField = "Semester_RefID";
        DrpSemester.DataBind();
    }
    protected void DDLAY_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemester();
    }
    public void BindCddList()
    {
        DrpCurriculum.DataSource = P.BindCdd();
        DrpCurriculum.DataTextField = "Cdd_Code";
        DrpCurriculum.DataValueField = "Cdd_Id";
        DrpCurriculum.DataBind();

    }
    public void BindGrid()
    {

        string[] stringdate1 = new string[3];
        if (TxtFromDate.Text!="")
        stringdate1 = TxtFromDate.Text.Split('/');
        else
         stringdate1 = "01/01/1990".Split('/');
        DateTime FromDate = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));


        string[] stringdate2 = new string[3];
        if (txtTodate.Text != "")
            stringdate2 = txtTodate.Text.Split('/');
        else
            stringdate2 = "01/01/1990".Split('/');
        stringdate2 = txtTodate.Text.Split('/');

        String Operation = "";

        if (DrpReportOption.SelectedValue == "BOOK ISSUANCE")
        {
            Operation = "BOOK ISSUANCE";
        }
        else if (DrpReportOption.SelectedValue == "BOOKS NOTCOLLECTED")
        {
            Operation = "BOOKS NOTCOLLECTED";
        }
        else if (DrpReportOption.SelectedValue == "BOOKS RETURN STATUS")
        {
            Operation = "BOOKS RETURN STATUS";
        }
        else if (DrpReportOption.SelectedValue == "REFERENCE BOOKS UTILIZATION")
        {
            Operation = "REFERENCE BOOKS UTILIZATION";
        }
        else if (DrpReportOption.SelectedValue == "ALL BOOKS RETURN STATUS")
        {
            Operation = "BOOK ISSUANCE";
        }
        else if (DrpReportOption.SelectedValue == "TRANSACTION DETAILS")
        {
            Operation = "TRANSACTION DETAILS";
        }
        else if (DrpReportOption.SelectedValue == "BOOKS NOT RETURNED")
        {
            Operation = "BOOKS NOT RETURNED";
        }

        DateTime EndDate = new DateTime(Convert.ToInt32(stringdate2[2]), Convert.ToInt32(stringdate2[1]), Convert.ToInt32(stringdate2[0]));

        DataTable Dtb = P.BindFortNightlyReport(FromDate, EndDate, Operation, Convert.ToInt32(DrpProgram.SelectedValue),
            Convert.ToInt32(DrpCurriculum.SelectedValue), Convert.ToInt32(DrpSemester.SelectedValue), 
            DDLBookType.SelectedValue,DrpUserType.SelectedValue,RdbReportOption.SelectedValue );
        GrvDetails.DataSource = Dtb;
        GrvDetails.DataBind();
    }

    protected void BtnLoad_Click(object sender, EventArgs e)
    {
        if (ChkExportExcel.Checked == true)
        {
            BindGrid();
        }
        else
        {
            LoadReport();
        }
    }
    protected void BtnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
            try
            {
                string result = ExcelUtility.ToExcel(GrvDetails.DataSource);
                ExcelUtility.ExportToExcel(result);
            }
            catch
            {
                // lbl_ack.Visible = true;
                // lbl_ack.Text = "Please check Excel configuration !!!";
            }
        }
        catch
        {

        }
    }

    protected void BtnExportStudentDetails_Click(object sender, EventArgs e)
    {
        try
        {
            BindStudentDetailsGrid();
            try
            {
                string result = ExcelUtility.ToExcel(GrvDetails.DataSource);
                ExcelUtility.ExportToExcel(result);
            }
            catch
            {
                // lbl_ack.Visible = true;
                // lbl_ack.Text = "Please check Excel configuration !!!";
            }
        }
        catch
        {

        }
    }



    public void BindStudentDetailsGrid()
    {

        string[] stringdate1 = new string[3];
        if (TxtFromDate.Text != "")
            stringdate1 = TxtFromDate.Text.Split('/');
        else
            stringdate1 = "01/01/1990".Split('/');
        DateTime FromDate = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));


        string[] stringdate2 = new string[3];
        if (txtTodate.Text != "")
            stringdate2 = txtTodate.Text.Split('/');
        else
            stringdate2 = "01/01/1990".Split('/');
        stringdate2 = txtTodate.Text.Split('/');

        String Operation = "";

        if (DrpReportOption.SelectedValue == "BOOK ISSUANCE")
        {
            Operation = "BOOK ISSUANCE";
        }
        else if (DrpReportOption.SelectedValue == "BOOKS NOTCOLLECTED")
        {
            Operation = "BOOKS NOTCOLLECTED";
        }
        else if (DrpReportOption.SelectedValue == "BOOKS RETURN STATUS")
        {
            Operation = "BOOKS RETURN STATUS";
        }
        else if (DrpReportOption.SelectedValue == "REFERENCE BOOKS UTILIZATION")
        {
            Operation = "REFERENCE BOOKS UTILIZATION";
        }
        else if (DrpReportOption.SelectedValue == "ALL BOOKS RETURN STATUS")
        {
            Operation = "BOOK ISSUANCE";
        }
        else if (DrpReportOption.SelectedValue == "TRANSACTION DETAILS")
        {
            Operation = "TRANSACTION DETAILS";
        }
        else if (DrpReportOption.SelectedValue == "BOOKS NOT RETURNED")
        {
            Operation = "BOOKS NOT RETURNED";
        }

        DateTime EndDate = new DateTime(Convert.ToInt32(stringdate2[2]), Convert.ToInt32(stringdate2[1]), Convert.ToInt32(stringdate2[0]));

        DataTable Dtb = P.BindFortNightlyReportStudentDetails(FromDate, EndDate, Operation, Convert.ToInt32(DrpProgram.SelectedValue),
            Convert.ToInt32(DrpCurriculum.SelectedValue), Convert.ToInt32(DrpSemester.SelectedValue),
            DDLBookType.SelectedValue, DrpUserType.SelectedValue, RdbReportOption.SelectedValue);
        GrvDetails.DataSource = Dtb;
        GrvDetails.DataBind();
    }



    protected void ChkExportExcel_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkExportExcel.Checked == true)
        {
            LblReportType.Visible = true;
            RdbReportOption.Visible = true;
        }
        else
        {
            LblReportType.Visible = false;
            RdbReportOption.Visible = false;
        }
    }
    protected void LoadReport()
    {
        try
        {

            string[] stringdate1 = new string[3];
            if (TxtFromDate.Text != "")
                stringdate1 = TxtFromDate.Text.Split('/');
            else
                stringdate1 = "01/01/1990".Split('/');
            DateTime FromDate = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));


            string[] stringdate2 = new string[3];
            if (txtTodate.Text != "")
                stringdate2 = txtTodate.Text.Split('/');
            else
                stringdate2 = "01/01/1990".Split('/');
            stringdate2 = txtTodate.Text.Split('/');

            DateTime EndDate = new DateTime(Convert.ToInt32(stringdate2[2]), Convert.ToInt32(stringdate2[1]), Convert.ToInt32(stringdate2[0]));

        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
            string Path ="";

        Processing p = new Processing();

        String Operation = "";

        if (DrpReportOption.SelectedValue == "BOOK ISSUANCE")
           {
                Path = Server.MapPath("BookIssuance.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Reports\\BookIssuance.rpt";
                Operation = "BOOK ISSUANCE";
           }
           else if (DrpReportOption.SelectedValue == "BOOKS NOTCOLLECTED")
           {
               Path = Server.MapPath("BookNotCollected.rpt");
               Path = Path.Substring(0, Path.LastIndexOf('\\'));
               Path = Path.Substring(0, Path.LastIndexOf('\\'));
               Path = Path + "\\Reports\\BookNotCollected.rpt";
               Operation = "BOOKS NOTCOLLECTED";
           }
        else if (DrpReportOption.SelectedValue == "BOOKS RETURN STATUS")
           {
               Path = Server.MapPath("BookReturnStatus.rpt");
               Path = Path.Substring(0, Path.LastIndexOf('\\'));
               Path = Path.Substring(0, Path.LastIndexOf('\\'));
               Path = Path + "\\Reports\\BookReturnStatus.rpt";
               Operation = "BOOKS RETURN STATUS";
           }
        else if (DrpReportOption.SelectedValue == "BOOKS NOT RETURNED")
        {
            Path = Server.MapPath("BookNotReturnStatus.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\BookNotReturnStatus.rpt";
            Operation = "BOOKS NOT RETURNED";
        }

        else if (DrpReportOption.SelectedValue == "REFERENCE BOOKS UTILIZATION")
        {
            Path = Server.MapPath("ConsolidatedReportBooksUsage.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\ConsolidatedReportBooksUsage.rpt";
            Operation = "REFERENCE BOOKS UTILIZATION";
        }

        else if (DrpReportOption.SelectedValue == "ALL BOOKS ISSUANCE STATUS")
        {
            Path = Server.MapPath("ConsolidatedReportBookIssuance.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\ConsolidatedReportBookIssuance.rpt";
            Operation = "BOOK ISSUANCE";
        }

        else if (DrpReportOption.SelectedValue == "TRANSACTION DETAILS")
        {
            Path = Server.MapPath("TransactionReport.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\TransactionReport.rpt";
            Operation = "TRANSACTION DETAILS";
        }

        myReportDocument.Load(Path);

        myReportDocument.SetParameterValue("@FromDate", FromDate);
        myReportDocument.SetParameterValue("@Todate", EndDate);
        myReportDocument.SetParameterValue("@Operation", Operation);
        myReportDocument.SetParameterValue("@DegreeTypeID", Convert.ToInt32(DrpProgram.SelectedValue));
        myReportDocument.SetParameterValue("@CurriculumID", Convert.ToInt32(DrpCurriculum.SelectedValue));
        myReportDocument.SetParameterValue("@SemesterID", Convert.ToInt32(DrpSemester.SelectedValue));
        myReportDocument.SetParameterValue("@BookType", DDLBookType.SelectedValue);
        myReportDocument.SetParameterValue("@UserType", DrpUserType.SelectedValue);

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
    }

}