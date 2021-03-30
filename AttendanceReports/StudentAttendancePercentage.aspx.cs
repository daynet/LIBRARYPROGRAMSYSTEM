using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;

public partial class Pages_StudentAttendancePercentage : System.Web.UI.Page
{
    CBHandler CBH = new CBHandler();
    DBHandler DBH = new DBHandler(); string strsql = "";
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Session["RoleId"].ToString() == "9")
            //{
                populatedropdown2(1);
                Pnl_Adm.Visible = true;
            //}
            //else
            //{
            //    if (Session["RoleId"].ToString() == "1")
            //    {
            //        populatedropdown1();
            //    }
            //    else if (Session["RoleId"].ToString() == "7")
            //    {
            //        populatedropdown();
            //    }
            //}

        }
        else
        {
            btnSearch_Click(sender, e);
        }
    }

    void populatedropdown()
    {
        strsql = "select    distinct c.Code,cs.Id   from   tblStudent as s inner join tblClassSection as cs on cs.Id=s.ClassSectionId " +
                 " inner join tblClassMaster as c on c.Id=cs.ClassId inner join tblSection as sc on sc.Id=cs.SectionId " +
                 " inner join tblFaculty as f on f.Id=cs.TeacherId where     cs.Status=1 and TeacherId= '" + Session["EMPID"].ToString() + "'";
        CBH.Populate(ddlClass, strsql, "All");
    }

    void populatedropdown1()
    {
        strsql = "select    distinct c.Code,cs.Id   from   tblStudent as s inner join tblClassSection as cs on cs.Id=s.ClassSectionId " +
                 " inner join tblClassMaster as c on c.Id=cs.ClassId inner join tblSection as sc on sc.Id=cs.SectionId " +
                 " inner join tblFaculty as f on f.Id=cs.TeacherId   where     cs.Status=1";
        CBH.Populate(ddlClass, strsql, "All");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lbmsg.Text = "";
        if (Pnl_Adm.Visible == true)
        {
          
            if (ddlSem.SelectedIndex == 0)
            {
                lbmsg.Text = "Please Select Semester!";
                lbmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlFaculty.SelectedIndex == 0)
            {
                lbmsg.Text = "Please Select Faculty!";
                lbmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        if (txtfromDate.Text.ToString() == "")
        {
            lbmsg.Text = "Please Select From Date!";
            lbmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (txttodate.Text.ToString() == "")
        {
            lbmsg.Text = "Please Select To Date!";
            lbmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        Attendance a = new Attendance();
      //  ReportDocument myReportDocument;
        myReportDocument = new ReportDocument();
        try
        {
            string Path = Server.MapPath("AttendanceAll.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\AttendanceAll.rpt";
            myReportDocument.Load(Path);

            string FromDate = DateTime.Parse(txtfromDate.Text).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(txttodate.Text).ToString("yyyyMMdd");

            DataTable mytab = new DataTable();
            ArrayList pa = new ArrayList();
            ArrayList pv = new ArrayList();

            pa.Add("@class_id");
            pv.Add(ddlClass.SelectedValue);
            pa.Add("@edate1");
            pv.Add(FromDate);
            pa.Add("@edate2");
            pv.Add(ToDate);
            if (Pnl_Adm.Visible == true)
            {
                pa.Add("@SemId");
                pv.Add(ddlSem.SelectedValue);
                pa.Add("@FacultyId");
                pv.Add(ddlFaculty.SelectedValue);
            }
            DBH.CreateDataTable(mytab, "SP_CONSOLIDATED_ATTENDANCE", true, pa, pv);

            myReportDocument.SetDataSource(mytab);
            CrystalReportViewer1.ReportSource = myReportDocument;
            CrystalReportViewer1.DataBind();
        }
        catch (Exception Ex)
        {

        }
        finally
        {
            // myReportDocument.Close();
            // myReportDocument.Dispose();
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        populatedropdown2(2);
        ddlFaculty.Items.Clear();
        ddlClass.Items.Clear();
    }

    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        populatedropdown2(3);
        ddlClass.Items.Clear();
    }

    protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'<Select>' as Description union all select Distinct 1 as SN,CS.Id ,CM.Description  from tblStudent S inner join tblClassSection CS on S.ClasssectionId = CS.Id inner join tblClassMaster CM on CS.ClassId =CM.Id where CS.Status =1 and S.Status = 1 and CS.TeacherId =" + ddlFaculty.SelectedValue + " and CS.AcademicYearId = " + ddlSem.SelectedValue);

        ddlClass.DataTextField = "Description";
        ddlClass.DataValueField = "Id";
        ddlClass.DataBind();
    }

    void populatedropdown2(int Flag)
    {
        if (Flag == 1)
        {
            string strsql = "Select Distinct AcadYear_Desc,Acadyear_Id from CDB_Academic_Pro ..acadeamicyear_master where Active=1 order by Acadyear_Id desc";
            CBH.Populate(ddlYear, strsql);
            populatedropdown2(2);
        }
        else if (Flag == 2)
        {
            string strsql = "Select Semester_Desc='<Select>',Acadyear_Id=0  union all select Distinct Semester_Desc,Semester_RefID from CDB_Academic_Pro ..Semester_Reference a " +
                            "inner join tblClassSection b on a.Semester_RefID = b.AcademicYearId where b.Status =1 and a.AcadYear_Id = " + ddlYear.SelectedValue +
                            " Order by Semester_Desc";
            CBH.Populate(ddlSem, strsql);
        }
        else if (Flag == 3)
        {
            string strsql = "Select Name='<Select>',Acadyear_Id=0  union all select Distinct Name=Title + ' ' +  FirstName+' ' + MiddleName + ' ' + LastName,a.TeacherId from tblClassSection a  " +
             "inner join tblFaculty b on a.TeacherId = b.id  " +
             "where a.AcademicYearId = " + ddlSem.SelectedValue + "  and b.Status =1 and a.Status=1 Order by Name";
            CBH.Populate(ddlFaculty, strsql);
        }

    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }
}