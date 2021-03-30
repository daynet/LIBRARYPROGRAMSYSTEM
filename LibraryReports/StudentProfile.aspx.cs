using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class LibraryReports_StudentProfile : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void hdnValue_ValueChanged(object sender, EventArgs e)
    {


        if (RbtStudent.Checked == true)
        {
            if (txtStudentId.Text.ToString().Contains("-") == true)
            {



                string[] StudentId = new string[2];
                StudentId = txtStudentId.Text.ToString().Split('-');
                txtStudentId.Text = StudentId[0].ToString();
                txtStudentName.Text = StudentId[2].ToString();
            }
        }

        else
        {
           if (TxtStaffFacID.Text.ToString().Contains("-") == true)
            {
                string[] StudentId = new string[2];
                StudentId = txtStudentId.Text.ToString().Split('-');
                TxtStaffFacID.Text = StudentId[0].ToString();
                txtStudentName.Text = StudentId[2].ToString();
            }
        }

        

      
       
    }
    protected void BtnLoad_Click(object sender, EventArgs e)
    {
        string Path = "";
        if (RbtStudent.Checked == true)
        {
            Path = Server.MapPath("ENROLLMENTFORM.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\ENROLLMENTFORM.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@LinkId", txtStudentId.Text);
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        else
        {
            Path = Server.MapPath("EmployeeProfile.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Reports\\EmployeeProfile.rpt";
            myReportDocument.Load(Path);
            myReportDocument.SetParameterValue("@Personid", TxtStaffFacID.Text);
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        }
        TxtStaffFacID.Text = "";
        txtStudentName.Text = "";
        txtStudentId.Text = "";
       
          
        
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
}