using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Person_Id"].ToString() == "" || Session["Person_Id"].ToString() == null)
                Response.Redirect("LoginForm.aspx", false);
            int Count = 0;
            DataTable dt = CGeneralFunction.filldata("select count(*) from cdb..TRANSACTION_DETAILS where Attr1='1' and Forwarded_To='" + Session["Person_Id"].ToString() + "'");
            foreach (DataRow ro in dt.Rows)
            {
                Count = int.Parse(ro[0].ToString());
            }
            if (Count > 0)
            {
                //imgRequest.ImageUrl = "~/Icons/notifcation-message.png";
                //lblCount.Visible = true;
                //div1.Visible = true;
                //lblCount.Text = Count.ToString();
            }
            else
            {
                //imgRequest.ImageUrl = "~/Icons/notification-on.png";
                //lblCount.Visible = false;
                //div1.Visible = false;
            }
        }
        catch
        {
            Response.Redirect("LoginForm.aspx", false);
        }
    }
}
