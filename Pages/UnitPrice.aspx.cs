using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Pages_UnitPrice : System.Web.UI.Page
{
    Processing P = new Processing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        save();
    }
    protected void save()
    {
        DataTable Dtb=new DataTable();

           string[] stringdate1 = new string[3];
        if (TxtDate.Text!="")
        stringdate1 = TxtDate.Text.Split('/');
        else
         stringdate1 = "01/01/1990".Split('/');
        DateTime EffectiveDate = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));


        if (txtID.Text == "")
        {
            Dtb = P.INSERTBOOKPRICE("INSERT", Convert.ToDecimal(TxtPrice.Text), EffectiveDate, 0, Convert.ToInt32(Session["UserId"]));
        }
        else
        {
            Dtb = P.INSERTBOOKPRICE("UPDATE", Convert.ToDecimal(TxtPrice.Text), EffectiveDate, Convert.ToInt32(txtID.Text), Convert.ToInt32(Session["UserId"]));
        }
        if (Dtb.Rows.Count > 0)
        {
            if (Convert.ToInt32(Dtb.Rows[0][0]) > 0)
            {
                BindGrid();
                BtnSave.Text = "SAVE";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data saved succesfully!!');", true);
            }
        }

    }
    protected void GrvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("EditRow"))
            {
                Setdata(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void Setdata(int ID)
    {
        DataTable DTB = P.INSERTBOOKPRICE("SELECT BYID", Convert.ToDecimal(0), DateTime.Now, ID, 0);
        if (DTB.Rows.Count > 0)
        {
            txtID.Text = Convert.ToString(DTB.Rows[0]["ID"]);
            TxtPrice.Text = Convert.ToString(DTB.Rows[0]["Price"]);
            TxtDate.Text = Convert.ToDateTime(DTB.Rows[0]["EffectiveDate"]).ToString("dd/MM/yyyy");
            BtnSave.Text = "UPDATE";
        }
    }
    public void BindGrid()
    {
        DataTable DTB = P.INSERTBOOKPRICE("SELECT", 0, DateTime.Now, 0, Convert.ToInt32(Session["UserId"]));
        GrvDetails.DataSource = DTB;
        GrvDetails.DataBind();
    }
}