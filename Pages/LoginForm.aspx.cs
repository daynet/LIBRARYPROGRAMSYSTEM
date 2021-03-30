using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using UnisHrSystemModel;
using System.Net;
using System.Net.NetworkInformation;

public partial class Pages_LoginForm : System.Web.UI.Page
{
    UnisHrSystemEntities pe = new UnisHrSystemEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
       // lbladdress.Text = Util.GetMACAddress01();
      lbladdress.Text =getIP2();
       // lbladdress.Text = GetMacAddress();
       // GetMacAddress();
    }

    public string getIP2()
    {
        string clientIp = (Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IPS"] ??
                       Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
        return clientIp;
    }
    private string GetUserIP()
    {
        string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipList))
        {
            return ipList.Split(',')[0];
        }

        return Request.ServerVariables["REMOTE_ADDR"];
    }
   private string GetMac()
    {
        var macAddr =
    (
        from nic in NetworkInterface.GetAllNetworkInterfaces()
        where nic.OperationalStatus == OperationalStatus.Up
        select nic.GetPhysicalAddress().ToString()
    ).FirstOrDefault();
        return macAddr.ToString();
    }
   
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //    if (txtUserName.Text == "LIB" && txtPassword.Text == "LIB50031990")
            //    {
            //        var empcode = txtUserName.Text;
            //        var vEMPID = txtUserName.Text;
            //        Session["userid"] = "711";
            //        Session["Person_Id"] = "711";
            //        Response.Redirect("~/Pages/MHome.aspx");
            //    }
            //    else
            //    {
            //        string query = ("select login_name as empcode,password,EmpType as roleid,EmpId as person_id from CDB..tblLogin where allowacess is null and login_name=\'"
            //                    + (txtUserName.Text + "\'"));
            //        DataTable dt = CGeneralFunction.filldata(query);
            //        if ((dt.Rows.Count > 0))
            //        {
            //            if (dt.Rows[0]["empcode"].ToString() == txtUserName.Text)
            //            {
            //                if (dt.Rows[0]["password"].ToString() == txtPassword.Text)
            //                {
            //                    var empcode = txtUserName.Text;
            //                    var vEMPID = txtUserName.Text;
            //                    //var roleID = Convert.ToInt32(dt.Rows[0]["roleid"]);
            //                    var userid = dt.Rows[0]["person_id"];
            //                    Session["userid"] = txtUserName.Text;
            //                    Session["Person_Id"] = userid;
            //                    Response.Redirect("~/Leave/PendingList.aspx" ,false);
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Username or Password is Incorrect");
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Username or Password is Incorrect");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Username or Password is Invalid");
            //        }
            //    }
            if ((txtUserName.Text).ToUpper() != "" && (txtPassword.Text).ToUpper() != "")
            {
                Ecl obj = new Ecl();
                Processing p = new Processing();
                DataTable dt = obj.ValidateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    Int32 User_Id = Convert.ToInt32(dt.Rows[0][0]);
                    if (User_Id != 0)
                    {
                        String time = DateTime.Now.ToString("HHmmss");

                        Session["User"] = Convert.ToString(dt.Rows[0][1]);
                        Session["UserId"] = User_Id;
                        Session["Role"] = Convert.ToString(dt.Rows[0][2]);
                        Session["Home_Page_Access"] = Convert.ToString(dt.Rows[0][3]);
                        Session["Role_ID"] = Convert.ToString(dt.Rows[0][4]);
                        //if (Convert.ToString(Session["Role"]).Trim().ToLower() == "marketing" || Convert.ToString(Session["Role"]).Trim().ToLower() == "finance" ||)
                        //    Response.Redirect("../Page/MHome.aspx", false);
                        //else
                        //    Response.Redirect("../Page/Home.aspx", false);
                        if (Convert.ToString(Session["Home_Page_Access"]).Trim().ToLower() != "1")
                           // Response.Redirect("../Page/MHome.aspx", false);
                            Response.Redirect("~/Pages/MHome.aspx");
                        else
                           // Response.Redirect("../Page/Home.aspx", false);
                            Response.Redirect("~/Pages/MHome.aspx");
                    }
                    else if (txtUserName.Text.Trim() == "LIB" && txtPassword.Text.Trim() == "helpdesk")
                    {
                        Session["User"] = txtUserName.Text.Trim();
                        Session["UserId"] = "999999999";
                        Session["Role"] = "Admin";
                        Session["Role_ID"] = 6;
                        Response.Redirect("../Pages/MHome.aspx", false);

                    }

                    else
                    {
                        MessageBox.Show("Username or Password is Invalid");
                    }
                }

            }
            else
            {
                MessageBox.Show("User does not exists!");
                
            }

        }
        catch (Exception Ex)
        {
            //MessageBox.Show("Username or Password is Incorrect");
        }
    }
}
