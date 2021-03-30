using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_PrintClient : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        rptStudent.Dispose();
        GC.Collect();
    }
    protected void DownloadFile( string filePath)
    {

        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filePath);
        Response.WriteFile(filePath);
        Response.End();
          
       
        //Response.TransmitFile(filePath);
      

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();         
            string path = "";       
            string LinkId = "";

            String StudentID = Request.QueryString["studid"];

            DataSet ds = new DataSet();
            System.Data.SqlClient.SqlDataAdapter da = default(System.Data.SqlClient.SqlDataAdapter);
            string strSQL = null;


            dynamic SQLcon = new SqlConnection(ConfigurationManager.ConnectionStrings["SkylineUniversityConnPortal"].ToString());
                    try
                    {
                        strSQL = "exec SHP_ApplicationForm '" + StudentID + "'";

                        // strSQL = "SELECT  staffdetails.Empid, staffdetails.empname, staffdetails.empdesignation, staffdetails.empdepartment, staffdetails.etype, staffdetails.priority, staffdetails.phoneno, staffdetails.emailid, staffdetails.epassword, staffdetails.eAddress, staffdetails.qulification, staffdetails.imagedata, staffdetails.imgetype, staffdetails.imagelength, staffdetails.extno, tb_advising.f_id, tb_advising.stud_id, tb_advising.sap_status, tb_advising.Conditionaladmission, tb_advising.repeatingcourse, tb_advising.toc_Course, EMPMASTER.OFFICEEXT FROM   staffdetails INNER JOIN tb_advising ON staffdetails.Empid = tb_advising.f_id INNER JOIN EMPMASTER ON staffdetails.Empid = EMPMASTER.EMPID where tb_advising.stud_id='" & Session["StudentID"] & "'"
                        da = new System.Data.SqlClient.SqlDataAdapter(strSQL, SQLcon);
                        da.Fill(ds);
                    }
                    catch
                    {

                    }

            try
            {
                LinkId = Session["LinkId"].ToString();
            }
            catch
            {
                LinkId = ds.Tables[0].Rows[0]["LinkID"].ToString();
            }
            string UName = Request.QueryString["UName"].ToString();


            if (UName.Contains(".pdf"))
            {
                
            }
            else
            {
                if  (UName == "FS")
                {
                    
                }
                else  if (UName == "FW")
                {
                    
                    
                }
// PLEASE CHECK IT
                else if (UName == "FO")
                {
                   
                }             

                else if (UName == "MQP")
                {
                    
                   
                }
                else if (UName == "MC")
                {
                   
                    
                }

                else
                {
                    string RegNo = ds.Tables[0].Rows[0]["RegistrationNo_CDB"].ToString();
                path = "~/" + UName + ".rpt";
                path = Server.MapPath(path);
                rptStudent.Load(path);
                if ((UName == "ENROLLMENTFORM") || (UName.Contains("hostel_application")) || (UName == "local_guardian_visa_application") || (UName == "Student_Visa_Processing_request_Form") || (UName == "Student_personal_details_visa_applcation"))
                    rptStudent.SetParameterValue("@LinkId", LinkId);
                else if ((UName == "CpdEventsReportMain"))
                {  
                      
                 }
                else if ((UName == "RPT_INSTRUCTION"))
                {
                   
                }
                else if ((UName == "RefundPolicy"))
                {
                    
                }
                else if ((UName == "MktCheckListReport"))
                {
                    
                }
                else if ((UName == "RefundPolicy - MQP"))
                {
                    
                }
                else
                    rptStudent.SetParameterValue("@registerid", LinkId);
                }
                rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
                CrystalReportViewer1.Visible = false;
                CrystalReportViewer1.ReportSource = rptStudent;
                CrystalReportViewer1.DataBind();
                CrystalReportViewer1.HasCrystalLogo = false;
                CrystalReportViewer1.HasDrilldownTabs = false;
                CrystalReportViewer1.HasDrillUpButton = false;
                CrystalReportViewer1.HasGotoPageButton = true;
                CrystalReportViewer1.HasPageNavigationButtons = true;
               
                CrystalReportViewer1.HasRefreshButton = false;
                CrystalReportViewer1.HasSearchButton = false;
                CrystalReportViewer1.HasToggleGroupTreeButton = false;
                CrystalReportViewer1.HasToggleParameterPanelButton = false;
             
                CrystalReportViewer1.BackColor = System.Drawing.Color.White;
                
                System.IO.Stream oStream = null;
                byte[] byteArray = null;
                oStream = rptStudent.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rptStudent.Close();
                rptStudent.Dispose();



             
               }
        }
        catch (Exception ex)
        {
             Response.Write (ex.ToString());

        }
    }
   
}


   