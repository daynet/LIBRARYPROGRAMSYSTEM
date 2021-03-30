using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (Session["Person_Id"].ToString() == "" || Session["Person_Id"].ToString() == null)
            //    Response.Redirect("../Pages/LoginForm.aspx", false);
            //if (Session["Person_Id"].ToString() != "83")
            //{
            //    Response.Redirect("../Pages/LoginForm.aspx", false);
            //}
            int Count = 0;
            //DataTable dt = CGeneralFunction.filldata("select count(*) from cdb..TRANSACTION_DETAILS where Attr1='1' and Forwarded_To='" + Session["Person_Id"].ToString() + "'");
            //foreach (DataRow ro in dt.Rows)
            //{
            //    Count = int.Parse(ro[0].ToString());
            //}
            if (Count > 0)
            {
                //imgRequest.ImageUrl = "~/Icons/notifcation-message.png";
                //lblCount.Visible = true;
                //div1.Visible = true;
                //lblCount.Text = Count.ToString();
                LblNotification.Text = Count.ToString();
            }
            else
            {
                //imgRequest.ImageUrl = "~/Icons/notification-on.png";
                //lblCount.Visible = false;
                //div1.Visible = false;
                
            }

           // LblPageName.Text = Session["PageName"].ToString();
            StringBuilder str = new StringBuilder();
            DataTable dtt = CGeneralFunction.filldata("exec SP_Menu");

            for (int i = 0; i <= dtt.Rows.Count-1; i++)
            {
                str.Append(dtt.Rows[i][0].ToString());
            }


           
            ltrlMenu.Text = str.ToString();
        }

               
         
        catch(Exception Ex)
        {

           // throw Ex;
            Response.Redirect("../Pages/LoginForm.aspx", false);
        }
    }
}
