using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;

public partial class Pages_ClassAttendanceVB : System.Web.UI.Page
{
    DBHandler DBH = new DBHandler();
    CBHandler CBH = new CBHandler();
    string strsql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            try
            {

                populatedropdown1(1);
                Pnl_Adm.Visible = true;
                txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //if (Session["Role_ID"].ToString() == "9")
                //{
                //    populatedropdown1(1);
                //    Pnl_Adm.Visible = true;
                //    txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //}
                //else
                //{
                //    //if (Session["RoleId"].ToString() == "1")
                //    //{
                //    //    ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'Select' as Description union all select 1 as SN,tblClassSection.Id,tblClassMaster.Code+' '+tblSection.Code as Description from tblClassSection inner join tblClassMaster on tblClassMaster.Id=tblClassSection.ClassId inner join tblSection on tblSection.Id=tblClassSection.SectionId where tblClassMaster.Code like 'Class%' order by SN,Description");
                //    //    ddlClass.Enabled = true;
                //    //}
                //    //else if (Session["RoleId"].ToString() == "7")
                //    //{
                //    ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'<Select>' as Description union all select 1 as SN,tblClassSection.Id,tblClassMaster.Code+' '+tblSection.Code as Description from tblClassSection inner join tblClassMaster on tblClassMaster.Id=tblClassSection.ClassId inner join tblSection on tblSection.Id=tblClassSection.SectionId where tblClassMaster.Code like 'Class%' order by SN,Description");
                //    // ddlClass.Enabled = false;
                //    ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'<Select>' as Description union all select distinct 1 as SN,CS.Id ,CM.Description  from tblStudent S inner join tblClassSection CS on S.ClasssectionId = CS.Id inner join tblClassMaster CM on CS.ClassId =CM.Id where CS.Status =1 and CS.TeacherId =" + Session["UserId"].ToString());
                //    ddlClass.SelectedValue = Session["ClassSectionId"].ToString();
                //    //}
                //    //else if (Session["RoleId"].ToString() == "3" || Session["RoleId"].ToString() == "4" || Session["RoleId"].ToString() == "5" || Session["RoleId"].ToString() == "6")
                //    //{
                //    //    ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'<Select>' as Description union all select 1 as SN,tblClassSection.Id,tblClassMaster.Code+' '+tblSection.Code as Description from tblClassSection inner join tblClassMaster on tblClassMaster.Id=tblClassSection.ClassId inner join tblSection on tblSection.Id=tblClassSection.SectionId where tblClassMaster.Code like 'Class%' and tblClassSection.Id in (select ClassSectionId from tblDesignationAllocation where FacultyId='" + Session["EMPID"].ToString() + "') order by SN,Description");
                //    //    ddlClass.Enabled = true;
                //    //}
                //    //ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'<Select>' as Description union all select 1 as SN,tblClassSection.Id,tblClassMaster.Code+' '+tblSection.Code as Description from tblClassSection inner join tblClassMaster on tblClassMaster.Id=tblClassSection.ClassId inner join tblSection on tblSection.Id=tblClassSection.SectionId where tblClassMaster.Code like 'Class%' and tblClassSection.Id in (select ClassSectionId from tblDesignationAllocation where FacultyId='" + Session["UserId"].ToString() + "') order by SN,Description");
                //    //ddlClass.Enabled = true;
                //    ddlClass.DataTextField = "Description";
                //    ddlClass.DataValueField = "Id";
                //    ddlClass.DataBind();
                //    txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //    populatedropdown2();
                //}
            }
            catch (Exception Ex)
            {
            }
        }
        else
        {
            btnSearch_Click(sender, e);
        }
    }

    void populatedropdown2()
    {
        string strsql = "  select Distinct Session_Code as SessionName,L.Session_ID from tblClassMaster C " +
                        " inner join tblLSessionMaster L on substring(REVERSE(Code),2,1)=L.Attr1 inner join tblClassSection as cs on cs.ClassId =c.Id   " +
                        " where   cs.ID = " + ddlClass.SelectedValue;
        CBH.Populate(ddlSession, strsql);
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

        if (ddlClass.SelectedIndex == 0)
        {
            lbmsg.Text = "Please Select Class First!";
            lbmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (txtDate.Text == "")
        {
            lbmsg.Text = "Please Enter Date First!";
            lbmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        Attendance a = new Attendance();
        ReportDocument myReportDocument;
        myReportDocument = new ReportDocument();
        try
        {
            string Path = Server.MapPath("ClassAttendanceVB.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Report\\ClassAttendanceVB.rpt";
            myReportDocument.Load(Path);

            DataTable mytab = new DataTable();
            int Flag = 1;
            ArrayList pa = new ArrayList();
            ArrayList pv = new ArrayList();
      
            pa.Add("@ClassSectionId");
            pv.Add(ddlClass.SelectedValue);
            pa.Add("@Date");
            pv.Add(DateTime.Parse(txtDate.Text).ToString("yyyyMMdd"));
            pa.Add("@SessionID");
            pv.Add(ddlSession.SelectedValue);
            if (Pnl_Adm.Visible==true) 
            {
                pa.Add("@SemId");
                pv.Add(ddlSem.SelectedValue);
                pa.Add("@FacultyId");
                pv.Add(ddlFaculty.SelectedValue);
            }

            DBH.AttendanceCreateDataTable(mytab, "SP_BATCHWISEATT_FORSESSION", true, pa, pv);
            myReportDocument.SetDataSource(mytab);
            CrystalReportViewer1.ReportSource = myReportDocument;
            CrystalReportViewer1.DataBind();
        }
        catch (Exception Ex)
        {
            lbmsg.Text = "Please Enter Correct Value!";
            lbmsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            // myReportDocument.Close();
            // myReportDocument.Dispose();
        }
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        populatedropdown2();
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        populatedropdown1(2);      
        ddlFaculty.Items.Clear();
        ddlClass.Items.Clear();
    }

    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        populatedropdown1(3);
        ddlClass.Items.Clear();
    }

    protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'<Select>' as Description union all select Distinct 1 as SN,CS.Id ,CM.Description  from tblStudent S inner join tblClassSection CS on S.ClasssectionId = CS.Id inner join tblClassMaster CM on CS.ClassId =CM.Id where CS.Status =1 and S.Status = 1 and CS.TeacherId =" + ddlFaculty.SelectedValue + " and CS.AcademicYearId = " + ddlSem.SelectedValue);


        ddlClass.DataTextField = "Description";
        ddlClass.DataValueField = "Id";
        ddlClass.DataBind();
        
        //populatedropdown2();
    }

    void populatedropdown1(int Flag)
    {
        if (Flag == 1)
        {
            //string strsql = "Select '<Select>' as Description,0 as Id union all Select Semester_Desc as Description,Semester_RefId as Id from CDB_Academic_Pro ..Semester_Reference where Isactive = 1";
            string strsql = "Select Distinct AcadYear_Desc,Acadyear_Id from CDB_Academic_Pro ..acadeamicyear_master where Active=1 order by Acadyear_Id desc";
            CBH.Populate(ddlYear, strsql);
            populatedropdown1(2);
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
            string strsql = "Select Name='<Select>',Acadyear_Id=0  union all select Distinct Name=Title + ' ' + FirstName+' ' + MiddleName + ' ' + LastName,a.TeacherId from tblClassSection a  " +
             "inner join tblFaculty b on a.TeacherId = b.id  " +
             "where a.AcademicYearId = " + ddlSem.SelectedValue + "  and b.Status =1 and a.Status=1 Order by Name";
             CBH.Populate(ddlFaculty, strsql);    
        }

        //string strsql = "  select STUFF(SUBSTRING(L.Session_From,1,4),3,0,':')+ '-' + STUFF(SUBSTRING(L.Session_Till ,1,4),3,0,':')  as SessionName,L.Session_ID from tblClassMaster C " +
        //                       " inner join tblLSessionMaster L on substring(REVERSE(Code),2,1)=L.Attr1 inner join tblClassSection as cs on cs.ClassId =c.Id   " +
        //                       "where   cs.ID = " + ddlClass.SelectedValue;
       
    }
}