using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.Configuration;

public partial class Pages_RelativeAttendance : System.Web.UI.Page
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
                populatedropdown3(1);
                Pnl_Adm.Visible = true;
        //    }
        //    else
        //    {
        //        if (Session["RoleId"].ToString() == "1")
        //        {
        //            populatedropdown1();
                 
        //        }
        //        else if (Session["RoleId"].ToString() == "7")
        //        {
        //            populatedropdown();
                  
        //        }
               
        //    }

        }
        //else
        //{
        //    btnSearch_Click(sender, e);
        //}
    }

    void populatedropdown()
    {
        strsql = "select    distinct c.Code,cs.Id   from   tblStudent as s inner join tblClassSection as cs on cs.Id=s.ClassSectionId " +
                 " inner join tblClassMaster as c on c.Id=cs.ClassId inner join tblSection as sc on sc.Id=cs.SectionId " +
                 " inner join tblFaculty as f on f.Id=cs.TeacherId where  cs.Status=1 and TeacherId= '" + Session["EMPID"].ToString() + "'";
        CBH.Populate(ddlClass, strsql, "All");
    }

    void populatedropdown1()
    {
        strsql = "select    distinct c.Code,cs.Id   from   tblStudent as s inner join tblClassSection as cs on cs.Id=s.ClassSectionId " +
                 " inner join tblClassMaster as c on c.Id=cs.ClassId inner join tblSection as sc on sc.Id=cs.SectionId " +
                 " inner join tblFaculty as f on f.Id=cs.TeacherId  where  cs.Status=1 ";
        CBH.Populate(ddlClass, strsql, "All");
    }

   

    public void LoadReport()
    {
        lbmsg.Text = "";

        if (ChkStudent.Checked != true)
        {

            if (Pnl_Adm.Visible == true)
            {

                //if (ddlSem.SelectedIndex == 0)
                //{
                //    lbmsg.Text = "Please Select Semester!";
                //    lbmsg.ForeColor = System.Drawing.Color.Blue;
                //    return;
                //}
                //if (ddlFaculty.SelectedIndex == 0)
                //{
                //    lbmsg.Text = "Please Select Faculty!";
                //    lbmsg.ForeColor = System.Drawing.Color.Blue;
                //    return;
                //}
            }

            if (txtfromDate.Text.ToString() == "")
            {
                lbmsg.Text = "Please Select From Date!";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }

            if (txttodate.Text.ToString() == "")
            {
                lbmsg.Text = "Please Select To Date!";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            if ((ddlNSym.SelectedIndex > 0) && (Convert.ToString(txtNatt.Text) == ""))
            {
                lbmsg.Text = "Please enter -Ve(%) !";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            if ((ddlRSym.SelectedIndex > 0) && (Convert.ToString(txtRatt.Text) == ""))
            {
                lbmsg.Text = "Please enter RATT(%) !";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            if ((ddlASym.SelectedIndex > 0) && (Convert.ToString(txtAtd.Text) == ""))
            {
                lbmsg.Text = "Please enter ATD(%) !";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
        }
        else
        {

            if (txtStud.Text.ToString() == "")
            {
                lbmsg.Text = "Please Enter Student ID!";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            if (txtfromDate.Text.ToString() == "")
            {
                lbmsg.Text = "Please Select From Date!";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }

            if (txttodate.Text.ToString() == "")
            {
                lbmsg.Text = "Please Select To Date!";
                lbmsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
        }
        Int32 Natt, Ratt, Atd, FacId, BatchID;
        Natt = -1;
        Ratt = -1;
        Atd = -1;

        if (ddlFaculty.Items.Count == 0)
        {
            FacId = 0;
            if (Session["RoleId"].ToString() != "9") 
            {
               FacId =  Convert.ToInt32(Session["EMPID"].ToString());
            }

        }
        else
        {
            FacId=Convert.ToInt32(ddlFaculty.SelectedValue);
        }
        if (ddlClass.Items.Count == 0)
        {
            BatchID = 0;
        }
        else
        {
            BatchID = Convert.ToInt32(ddlClass.SelectedValue);
        }

        if (txtNatt.Text != "")
            Natt = Convert.ToInt32( txtNatt.Text);
        if (txtRatt.Text != "")
            Natt =  Convert.ToInt32( txtRatt.Text);
        if (txtAtd.Text != "")
            Natt =  Convert.ToInt32( txtNatt.Text);

        if (ChkStudent.Checked == true)
        {
            Natt = -1;
            Ratt = -1;
            Atd = -1;
        }

        Attendance a = new Attendance();
      //  ReportDocument myReportDocument;
        myReportDocument = new ReportDocument();
        try
        {
            string Path = Server.MapPath("RelativeAttendance.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\RelativeAttendance.rpt";
            myReportDocument.Load(Path);

            string FromDate = DateTime.Parse(txtfromDate.Text).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(txttodate.Text).ToString("yyyyMMdd");

            DataTable mytab = new DataTable();
            ArrayList pa = new ArrayList();
            ArrayList pv = new ArrayList();
            pa.Add("@edate1");
            pv.Add(FromDate);
            pa.Add("@edate2");
            pv.Add(ToDate);
            if (ChkStudent.Checked == true)
            {
                Natt = -1;
                Ratt = -1;
                Atd = -1;

                pa.Add("@class_id");
                pv.Add(0);
                pa.Add("@Natt");
                pv.Add(Natt);
                pa.Add("@Ratt");
                pv.Add(Ratt);
                pa.Add("@Atd");
                pv.Add(Atd);
                pa.Add("@Nsymbol");
                pv.Add("");
                pa.Add("@Rsymbol");
                pv.Add("");
                pa.Add("@Asymbol");
                pv.Add("");
                pa.Add("@StudId");
                pv.Add(txtStud.Text);
                if (Pnl_Adm.Visible == true)
                {
                    pa.Add("@SemId");
                    pv.Add(0);
                    pa.Add("@FacultyId");
                    pv.Add(0);
                }
            }
            else
            {
                pa.Add("@class_id");
                pv.Add(BatchID);
                pa.Add("@Natt");
                pv.Add(Natt);
                pa.Add("@Ratt");
                pv.Add(Ratt);
                pa.Add("@Atd");
                pv.Add(Atd);
                pa.Add("@Nsymbol");
                pv.Add(Convert.ToString(ddlNSym.SelectedValue));
                pa.Add("@Rsymbol");
                pv.Add(Convert.ToString(ddlRSym.SelectedValue));
                pa.Add("@Asymbol");
                pv.Add(Convert.ToString(ddlASym.SelectedValue));
                pa.Add("@StudId");
                pv.Add(Convert.ToString(txtStud.Text));
                if (Pnl_Adm.Visible == true)
                {
                  
                    pa.Add("@SemId");
                    pv.Add(ddlSem.SelectedValue);
                   
                }
                pa.Add("@FacultyId");
                pv.Add(FacId);
            }
            DBH.CreateDataTableAttendance(mytab, "SP_CONSOLIDATED_RATT", true, pa, pv);
            //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "MYFENCE");
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
            //myReportDocument.SetParameterValue("@Date", ToDate);
            //myReportDocument.SetParameterValue("@BatchID", 0);
            //myReportDocument.SetParameterValue("@TeacherID", 0);

            myReportDocument.SetDataSource(mytab);


            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
            SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Myfence"].ToString());
            string ServerName = SqlConnectionStringBuilder.DataSource;
            string DatabaseName = SqlConnectionStringBuilder.InitialCatalog;
            Boolean IntegratedSecurity = SqlConnectionStringBuilder.IntegratedSecurity;
            string UserID = SqlConnectionStringBuilder.UserID;
            string Password = SqlConnectionStringBuilder.Password;

            ConnectionInfo con = new ConnectionInfo();
            con.ServerName = ServerName;
            con.DatabaseName = DatabaseName;
            if (IntegratedSecurity != true)
            {
                con.UserID = UserID;
                con.Password = Password;
            }

            CrystalReportViewer1.ReportSource = myReportDocument;
            Session["myReportDocument"] = myReportDocument;
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


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        populatedropdown3(2);
        ddlFaculty.Items.Clear();
        ddlClass.Items.Clear();
    }

    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        populatedropdown3(3);
        ddlClass.Items.Clear();
    }

    protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClass.DataSource = CGeneralFunction.filldataattendance("select 0 as SN,0 as Id,'<Select>' as Description union all select Distinct 1 as SN,CS.Id ,CM.Description  from tblStudent S inner join tblClassSection CS on S.ClasssectionId = CS.Id inner join tblClassMaster CM on CS.ClassId =CM.Id where CS.Status =1 and S.Status = 1 and CS.TeacherId =" + ddlFaculty.SelectedValue + " and CS.AcademicYearId = " + ddlSem.SelectedValue);

        ddlClass.DataTextField = "Description";
        ddlClass.DataValueField = "Id";
        ddlClass.DataBind();
    }

    void populatedropdown3(int Flag)
    {
        if (Flag == 1)
        {
            string strsql = "Select Distinct AcadYear_Desc,Acadyear_Id from CDB_Academic_Pro ..acadeamicyear_master where Active=1 order by Acadyear_Id desc";
            CBH.Populate(ddlYear, strsql);
            populatedropdown3(2);
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

    protected void ChkStudent_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkStudent.Checked == true)
        {
             
        }
        else
        {
        }
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }
}