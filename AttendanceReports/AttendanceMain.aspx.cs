using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Pages_AttendanceMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtDate.Text = Util.DateString(DateTime.Now);
                //populatebatchs();
                PopulateBath_NEW();
            }
            catch
            {
                Response.Redirect("Login.aspx", false);
            }
        }
    }
    protected void gvStayBackReason_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (!isalloweddatedate() && Session["RoleId"].ToString() != "9")
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('This facility is blocked by administration, Contact Admin!!.')</script>");
            return;
        }
        try
        {
            if (e.CommandName == "View")
            {
                DataTable dt;
                string csId = Convert.ToString(e.CommandArgument);
                dt = CGeneralFunction.filldata("Usp_BatchwiseStatus " + csId);
                if (dt.Rows.Count != 0)
                    gridView.DataSource = dt;
                else
                    gridView.DataSource = null;

                gridView.DataBind();
                ME1.Show();
            }
            else
            {
                int ClassSectionId = Convert.ToInt32(e.CommandArgument.ToString());
                DataTable dt = CGeneralFunction.filldataattendance("select ClassId,SectionId from tblClassSection where Id='" + ClassSectionId + "'");
                Session["Class_Id"] = dt.Rows[0]["ClassId"].ToString();
                Session["Div_Id"] = dt.Rows[0]["SectionId"].ToString();
                Session["ClassSectionId"] = ClassSectionId;
                Response.Redirect("Attendance.aspx?CId=" + ClassSectionId + "&&DDate=" + txtDate.Text.Trim(), false);
            }
        }
        catch
        {
        }
    }
    protected void gvStayBackReason_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gvStayBackReason_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblSN = (Label)e.Row.FindControl("lblSN");
        //    lblSN.Text = (e.Row.RowIndex + 1).ToString();
        //}
    }

    protected void btngo_Click(object sender, EventArgs e)
    {
       // populatebatchs();
        PopulateBath_NEW();
    }
    private Boolean isalloweddatedate()
    { 
       DateTime Today=  DateTime .Now ;
      DateTime AttDate=DateTime.Parse ( txtDate.Text.Trim());
      TimeSpan diff  = Today.Subtract(AttDate);
      if (diff.Days > 1 || AttDate > Today)
      {
          return false;
      }
      else
      {
          return true;
      }
    }
    private void populatebatchs()
    {
        if (!isalloweddatedate() && Session["RoleId"].ToString() != "9")
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('This facility is blocked by administration, Contact Admin!!.')</script>");
            return;
        }
        if (Session["RoleId"] != null)
        {
            DataTable dt = new DataTable();
            if (Session["RoleId"].ToString() == "1" || Session["RoleId"].ToString() == "9")
            {
                dt = CGeneralFunction.filldataattendance("select ClassSectionId as class_id,c.Code as ClassName,Sc.code as DivisionName,Isnull(f.FirstName,'')+' '+Isnull(f.MiddleName,'')+' '+Isnull(f.LastName,'') as ClassRoom,COUNT(*) as TotalStudent, case [dbo].[CheckAttendanceStatuswithdate](s.ClassSectionId,'" + txtDate.Text.Trim() + "') when 0 then '../Icons/Red.png' else '../Icons/Green.png' end as AttStatus from tblStudent as s inner join tblClassSection as cs on cs.Id=s.ClassSectionId   inner join tblClassMaster as c on c.Id=cs.ClassId inner join tblSection as sc on sc.Id=cs.SectionId inner join tblFaculty as f on f.Id=cs.TeacherId where S.Attr2 ='A' and S.Status=1 and CS.Status =1 group by c.Code,Sc.code,ClassSectionId,Isnull(f.FirstName,'')+' '+Isnull(f.MiddleName,'')+' '+Isnull(f.LastName,'')  order by AttStatus");
            }
            else if (Session["RoleId"].ToString() == "7")
            {
                dt = CGeneralFunction.filldataattendance("select ClassSectionId as class_id,c.Code as ClassName,Sc.code as DivisionName,CD.Cdd_Description as ClassRoom,COUNT(*) as TotalStudent, case [dbo].[CheckAttendanceStatuswithdate](s.ClassSectionId,'" + txtDate.Text.Trim() + "')  when 0 then '../Icons/Red.png' else '../Icons/Green.png' end as AttStatus from tblStudent as s inner join tblClassSection as cs on cs.Id=s.ClassSectionId   inner join tblClassMaster as c on c.Id=cs.ClassId inner join tblSection as sc on sc.Id=cs.SectionId inner join tblFaculty as f on f.Id=cs.TeacherId inner join AdminExam ..tbl_Batch B on B.Batch_Id =C.Attr1 inner join AdminExam ..Course_def_Master CD on CD.Cdd_ID =B.Cdd_id  where  S.Attr2 ='A' and S.Status=1 and TeacherId='" + Session["EMPID"].ToString() + "' and CS.Status =1 group by c.Code,Sc.code,ClassSectionId,Isnull(f.FirstName,'')+' '+Isnull(f.MiddleName,'')+' '+Isnull(f.LastName,''),CD.Cdd_Description order by AttStatus");
            }
            else if (Session["RoleId"].ToString() == "3" || Session["RoleId"].ToString() == "4" || Session["RoleId"].ToString() == "5" || Session["RoleId"].ToString() == "6")
            {
                dt = CGeneralFunction.filldataattendance("select ClassSectionId as class_id,c.Code as ClassName,Sc.code as DivisionName,Isnull(f.FirstName,'')+' '+Isnull(f.MiddleName,'')+' '+Isnull(f.LastName,'') as ClassRoom,COUNT(*) as TotalStudent, case [dbo].[CheckAttendanceStatuswithdate](s.ClassSectionId,'" + txtDate.Text.Trim() + "') when 0 then '../Icons/Red.png' else '../Icons/Green.png' end as AttStatus from tblStudent as s inner join tblClassSection as cs on cs.Id=s.ClassSectionId   inner join tblClassMaster as c on c.Id=cs.ClassId inner join tblSection as sc on sc.Id=cs.SectionId inner join tblFaculty as f on f.Id=cs.TeacherId where cs.Id in (select ClassSectionId from tblDesignationAllocation where S.Attr2 ='A'  and S.Status=1 and FacultyId='" + Session["EMPID"].ToString() + "') and CS.Status =1 group by c.Code,Sc.code,ClassSectionId,Isnull(f.FirstName,'')+' '+Isnull(f.MiddleName,'')+' '+Isnull(f.LastName,'')  order by AttStatus");
            }
            if (dt.Rows.Count != 0)
                gvStayBackReason.DataSource = dt;
            else
                gvStayBackReason.DataSource = null;
            gvStayBackReason.DataBind();
            pnlMyClass.Visible = true;
        }
    }

    private void PopulateBath_NEW()
    {
        if (!isalloweddatedate() && Session["RoleId"].ToString() != "9")
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('This facility is blocked by administration, Contact Admin!!.')</script>");
            return;
        }
        if (Session["RoleId"] != null)
        {
            int EMPID = -1;
            if (Session["RoleId"].ToString() == "1" || Session["RoleId"].ToString() == "9")
            {
                EMPID = -1;
            }
            else
            {
                EMPID = Convert.ToInt32(Session["EMPID"].ToString());
            }
            DataTable Dtb = new DataTable();
            ArrayList Pa = new ArrayList();
            ArrayList Pv = new ArrayList();
            DBHandler DBH = new DBHandler();
            Pa.Add("@Date");
            Pv.Add(txtDate.Text.Trim());
            Pa.Add("@TeacherID");
            Pv.Add(EMPID);
            DBH.AttendanceCreateDataTable(Dtb, "SP_Total_Present", true, Pa, Pv);
            if (Dtb.Rows.Count != 0)
                gvStayBackReason.DataSource = Dtb;
            else
                gvStayBackReason.DataSource = null;
            gvStayBackReason.DataBind();
            pnlMyClass.Visible = true;
        }
    }

    protected void btnClose_click(object sender, ImageClickEventArgs e)
    {
        try { ME1.Hide(); }
        catch (Exception Ex) { }
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvStayBackReason.PageIndex = e.NewPageIndex;
        PopulateBath_NEW();

    }
}