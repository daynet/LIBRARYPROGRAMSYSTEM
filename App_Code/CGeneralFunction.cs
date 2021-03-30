using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Collections.Generic;
using System.Net.NetworkInformation;
public class CGeneralFunction
{
    public static DataTable filldata(string vqry)
    {
        SqlDataAdapter da = new SqlDataAdapter(vqry, CGLOBAL.getConnectionString());
        DataTable dt = new DataTable();
        da.Fill(dt);
        da = null;
        return dt;
    }

    public static DataTable filldataattendance(string vqry)
    {
        SqlDataAdapter da = new SqlDataAdapter(vqry, CGLOBAL.getConnectionStringattendance());
        DataTable dt = new DataTable();
        da.Fill(dt);
        da = null;
        return dt;
    }


    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }
    public static DataTable fillACSDBdata(string vqry)
    {
        SqlDataAdapter da = new SqlDataAdapter(vqry, CGLOBAL.getNewConnectionString());
        DataTable dt = new DataTable();
        da.Fill(dt);
        da = null;
        return dt;
    }
    public static bool isvaliddata(string vquery)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = vquery;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }
        catch (Exception ex)
        {
            return false;  
        }
    }
    
    public static int isExisting(string vquery)
    {
        int lid = 0;
        SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
        SqlCommand cmd = new SqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = vquery;
        SqlDataReader reader = default(SqlDataReader);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lid = int.Parse(reader[0].ToString());
            //lid = lid + 1;
        }
        reader.Close();
        if ((lid <= 0))
        {
            con.Close();
            cmd.Dispose();
            return lid;
        }
        con.Close();
        cmd.Dispose();
        return lid;
    }
    public static bool delete(string vquery)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = vquery;
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public static bool save(string vquery)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = vquery.ToUpper();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public static string GetString(string vquery)
    {
        string Value = "";
        SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
        SqlCommand cmd = new SqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = vquery;
        SqlDataReader reader = default(SqlDataReader);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Value = reader[0].ToString();
            //lid = lid + 1;
        }
        reader.Close();
        con.Close();
        cmd.Dispose();
        return Value;
    }


    public static bool saveolderp(string vquery, int @personid)
    {
        try
        {
            SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = vquery;
            cmd.Parameters.Add("@personid", SqlDbType.Int).Value = @personid;
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public DataTable BindSemester()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("GetSem");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataSet GetEmailDetails(int contid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpContractID", contid);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[PrintContract]");
        return ds;
    }
    public string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                nic.OperationalStatus == OperationalStatus.Up)
            {
                return Convert.ToString(nic.GetPhysicalAddress());
            }
        }
        return null;
    }
    public DataSet GetEmailsent(int contid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpContractID", contid);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_GetEmailsent]");
        return ds;
    }

    public static int isPTPayrollRunExist(string vquery)
    {
        int lid = 0;
        SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
        SqlCommand cmd = new SqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = vquery;
        SqlDataReader reader = default(SqlDataReader);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lid = int.Parse(reader[0].ToString());
            //lid = lid + 1;
        }
        reader.Close();
        if ((lid <= 0))
        {
            con.Close();
            cmd.Dispose();
            return lid;
        }
        con.Close();
        cmd.Dispose();
        return lid;
    }


    public DataTable BindFilterationAcadamicYear()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.AdminExamgetDataByParam("GetAcademicYear");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }


    public DataTable BindFilterationContract()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("SP_ContractMaster");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }

    public DataTable BindFilterationEmpName()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("SP_ContractEmpName");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindEmployeeDetails(int EmpNumber, int AcadamicYear, int SemesterID, int ContractType)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@EmpNumber", EmpNumber);
        param[1] = new SqlParameter("@AcadamicYear", AcadamicYear);
        param[2] = new SqlParameter("@SemesterID", SemesterID);
        param[3] = new SqlParameter("@ContractType", ContractType);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[SP_FilterEmpContractDetails]");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;
    }
    public DataTable BindFilterationSemester(int AcyearID)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@AcyearID", AcyearID);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[SP_GetFilterationSemester]");
        if (ds != null && ds.Tables.Count > 0)
            return ds.Tables[0];
        else
            return null;


    }


    public string InsertJobdescriptionmaster(int JobID, string Jobtitle, string Reporting_To, string Leave_Guidelines, string Leave_Replace, string Educational_Req, string Know_Skills, string Key_Areas
         , string strategic_res, string operation_res, string Yearly_planning, string Reporting_Res,
         string Coord_Res, string calendar_checklist, string presentation, string orientation, string training, string audit
        , string policy_manual, string handbook, string created_by, string created_Ip)
    {
        try
        {
            // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            SqlConnection conn = new SqlConnection(CGLOBAL.getConnectionString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[SP_INSERT_JOBDESC]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@JOB_ID", JobID);
            cmd.Parameters.AddWithValue("@JOB_TITLE", Jobtitle);
            cmd.Parameters.AddWithValue("@Reporting_to", Reporting_To);
            cmd.Parameters.AddWithValue("@Leave_Guidelines", Leave_Guidelines);
            cmd.Parameters.AddWithValue("@Leave_Replacement", Leave_Replace);
            cmd.Parameters.AddWithValue("@Educational_req", Educational_Req);
            cmd.Parameters.AddWithValue("@Know_Skills", Know_Skills);
            cmd.Parameters.AddWithValue("@Key_areas", Key_Areas);
            cmd.Parameters.AddWithValue("@Strategic_res", strategic_res);
            cmd.Parameters.AddWithValue("@Operation_res", operation_res);
            cmd.Parameters.AddWithValue("@Yearly_planning", Yearly_planning);
            cmd.Parameters.AddWithValue("@Reporting_res", Reporting_Res);
            cmd.Parameters.AddWithValue("@CoOrd_Res", Coord_Res);
            cmd.Parameters.AddWithValue("@Calendar_Checklist", calendar_checklist);
            cmd.Parameters.AddWithValue("@Presentation", presentation);
            cmd.Parameters.AddWithValue("@Orientation", orientation);
            cmd.Parameters.AddWithValue("@Training", training);
            cmd.Parameters.AddWithValue("@Audit", audit);
            cmd.Parameters.AddWithValue("@Policy_Manual", policy_manual);
            cmd.Parameters.AddWithValue("@handbook", handbook);
            cmd.Parameters.AddWithValue("@CreatedBy", created_by);
            cmd.Parameters.AddWithValue("@createdIP", created_Ip);

            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "RegisterNo";
        }
        catch
        {
            return "error";
        }
    }

    public static DataTable Fill_JobDesc_Details()
    {
        SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            //cmd = new SqlCommand("sp_DailyPresent", con);
            cmd = new SqlCommand("SP_GETJOBDESC_DETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public static  DataTable FillDesignation()
    {
        SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            //cmd = new SqlCommand("sp_DailyPresent", con);
            cmd = new SqlCommand("SP_GETDESIGNATION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable ReportingDepartment()
    {
        SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            //cmd = new SqlCommand("sp_DailyPresent", con);
            cmd = new SqlCommand("SP_REPORTINGTO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static DataTable Load_JobDesc_Details(int Jobdesc_ID)
    {
        SqlConnection con = new SqlConnection(CGLOBAL.getConnectionString());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            //cmd = new SqlCommand("sp_DailyPresent", con);
            cmd = new SqlCommand("SP_LOAD_JOBDESC_DETAILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@JOBDESC_ID", Jobdesc_ID);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}







