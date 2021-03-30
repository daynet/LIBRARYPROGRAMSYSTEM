using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;

public partial class LibraryReports_KohaReports : System.Web.UI.Page
{
    Processing P = new Processing();
    static string BorrowerID;
    static string ReportName;
    DataTable DT = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadDropDown();
        }
    }

    public void LoadDropDown()
    {
        DDLAY.DataSource = P.BindAcc();
        DDLAY.DataTextField = "AcadYear_Desc";
        DDLAY.DataValueField = "AcadYear_ID";
        DDLAY.DataBind();
        LoadSemester();
    }

    public void LoadSemester()
    {
        DDLSemester.DataSource = P.BindSemesterAcYear_ALL(Convert.ToInt32(DDLAY.SelectedValue));
        DDLSemester.DataTextField = "Semester_Desc";
        DDLSemester.DataValueField = "Semester_RefID";
        DDLSemester.DataBind();
    }
    protected void hdnValue_ValueChanged(object sender, EventArgs e)
    {
        if (txtStudentId.Text.ToString().Contains("-") == true)
        {
            string[] StudentId = new string[2];
            StudentId = txtStudentId.Text.ToString().Split('-');
            txtStudentId.Text = StudentId[1].ToString();
            BorrowerID = StudentId[0].ToString();
        }

    }
    protected void BtnInvReport_Click(object sender, EventArgs e)
    {
       

        GrdInvReport.DataSource =BindGrid();
        GrdInvReport.DataBind();
    }

    private DataTable   BindGrid()
    {
     
   
        if (DrpReport.SelectedValue.ToString() == "CurrentBooks")
        {
            DT = P.KohaReport(BorrowerID, "CurrentBooks", "");
            ReportName = "Current Book(Total Book)";
        }
        if (DrpReport.SelectedValue.ToString() == "OverDue")
        {
            DT = P.KohaReport(BorrowerID, "OverDue", "");
            ReportName = "OverDue";
            
        }
        if (DrpReport.SelectedValue.ToString() == "Semesterwise")
        {
            DT = P.KohaReport(BorrowerID, "Semesterwise", "", Convert.ToInt32(DDLSemester.SelectedValue));
            ReportName = "Semesterwise";
        }
        if (DrpReport.SelectedValue.ToString() == "Facultywise")
        {
            DT = P.KohaReport(BorrowerID, "Facultywise", "", Convert.ToInt32(DDLSemester.SelectedValue));
            ReportName = "Book taken by Students Faculty wise Details";
           
        }
        if (DrpReport.SelectedValue.ToString() == "BookreturnDetails")
        {
            DT = P.KohaReport(BorrowerID, "BookreturnDetails", "", Convert.ToInt32(DDLSemester.SelectedValue));
            ReportName = "Book Return Details";
          
        }
        if (DrpReport.SelectedValue.ToString() == "StudentWise")
        {
            DT = P.KohaReport(BorrowerID, "StudentWise", "", Convert.ToInt32(DDLSemester.SelectedValue));
            ReportName = "StudentWise Details";

        }
        return DT;
    }
    protected void DDLAY_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemester();
    }
    protected void DDLSemester_SelectedIndexChanged(object sender, EventArgs e)
    {

     }



    protected void BtnBlkLoad_Click(object sender, EventArgs e)
    {

        GrdInvReport.DataSource = BindBulkReport();
        GrdInvReport.DataBind();

    }

    private DataTable  BindBulkReport()
    {
     
        if (DDLReport.SelectedValue.ToString() == "OverDueStatistics")
        {
            DT = P.KohaReport("", "Statistics", "");
           
        }
        if (DDLReport.SelectedValue.ToString() == "OverDueTypes")
        {
            DT = P.KohaReport("", "OverDueTypes", DDLBookType.SelectedValue.ToString());
           
        }
        if (DDLReport.SelectedValue.ToString() == "OverDueLevel")
        {
            DT = P.KohaReport("", "OverDueStatistics", DDLBookType.SelectedValue.ToString());
          
        }
        if (DDLReport.SelectedValue.ToString() == "Not Collected")
        {
            DT = P.KohaReport("", "Not Collected", "");
           
        }
        if (DDLReport.SelectedValue.ToString() == "Coursewise")
        {
            DT = P.KohaReport("", "Coursewise", "");
           
        }

        
        return DT;
    }


    protected void BtnInvEReport_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
            try
            {
                string result = ExcelUtility.ToExcel(DT);
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
            // lbl_ack.Visible = true;
            // lbl_ack.Text = "Please Select all the values";
        }
    }
    protected void BtnBlkDownload_Click(object sender, EventArgs e)
    {
        try
        {
            BindBulkReport();
            try
            {
                string result = ExcelUtility.ToExcel(DT);
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
            // lbl_ack.Visible = true;
            // lbl_ack.Text = "Please Select all the values";
        }
    }
}