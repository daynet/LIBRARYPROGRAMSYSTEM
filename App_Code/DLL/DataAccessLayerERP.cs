using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;

public class DataAccessLayerERP : Object
{
    private string connection;

    public DataAccessLayerERP()
    {
        connection = null;
        this.connection = ConfigurationManager.ConnectionStrings["AdminExam"].ToString();
    }
 
    public DataSet getDataByParam(string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }

    public bool insertBulk(string tablename, DataTable dt)
    {
        string _connectionString = this.connection;
        SqlConnection SQLcon = new SqlConnection(_connectionString);
        SQLcon.Open();
        using (SqlBulkCopy bc = new SqlBulkCopy((SqlConnection)SQLcon))
        {
            bc.DestinationTableName = tablename;
            bc.WriteToServer(dt);
            bc.Close();
        }
        SQLcon.Close();
        return true;
    }
    public DataSet getDataByParam(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            int i = param.Length;
            for (int j = 0; j < i; j++)
                dataAdapter.SelectCommand.Parameters.Add(param[j]);
            dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }    
    
    public Int32 GetIdentity(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
            return 0;
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
       
    }
    
    public int getResultByParam(SqlParameter[] param, string strStoreProcedure, string strOutput)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        int result = 0;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteScalar();
            result = Convert.ToInt32(cmd.Parameters[strOutput].Value.ToString());
            return result;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return result;
    }

    public string getValueByParam(SqlParameter[] param, string strStoreProcedure, string strOutput)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        string result = "";
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteScalar();
            result = Convert.ToString(cmd.Parameters[strOutput].Value.ToString());
            return result;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return result;
    }

    public Int32 InsertValues(SqlParameter[] param, string Procedure)
    {
        try
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(Procedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteNonQuery();
            return 1;
        }
        catch (Exception Ex)
        { return 0; }

    }

    public DataSet getResult(string strStoreProcedure)   
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return ds;
    }
    public DataTable CreateDataTable(SqlParameter[] param, string strStoreProcedure, bool isstoredprocedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataTable dt = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandTimeout = 5000;
            if (isstoredprocedure == true)
            {
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                int i = param.Length;
                for (int j = 0; j < i; j++)
                    dataAdapter.SelectCommand.Parameters.Add(param[j]);
            }
            else
            {
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
            }
            // dataAdapter.SelectCommand.ExecuteNonQuery();
            dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.SelectCommand.Parameters.Clear();
            dataAdapter.Dispose();
            dt.Dispose();
        }
        return null;
    }

    public void PopulateDropDown(DropDownList Drp_, String StrSql, bool isstoredprocedure = false)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataTable dt = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(StrSql, con);
            if (isstoredprocedure == true)
            {
                //dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                //int i = param.Length;
                //for (int j = 0; j < i; j++)
                //    dataAdapter.SelectCommand.Parameters.Add(param[j]);
            }
            else
            {
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
            }
            // dataAdapter.SelectCommand.ExecuteNonQuery();
            dt = new DataTable();
            dataAdapter.Fill(dt);
            Drp_.DataSource = dt;
            Drp_.DataTextField = dt.Columns[0].ColumnName.ToString();
            Drp_.DataValueField = dt.Columns[1].ColumnName.ToString();
            Drp_.DataBind();
            // return dt;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.SelectCommand.Parameters.Clear();
            dataAdapter.Dispose();
            dt.Dispose();
        }
        // return null;
    }

    public string GetDateString(DateTime _Date)
    {
        int mm, yyyy, dd;
        string FormatedDate;
        mm = _Date.Month;
        dd = _Date.Day;
        yyyy = _Date.Year;
        FormatedDate = dd.ToString("00") + "/" + MonthString(mm) + "/" + yyyy.ToString();
        return FormatedDate;

    }
    public object getresult(string strStoreProcedure)
    {
        SqlConnection con = null;
        object Result = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(strStoreProcedure, con);
            Result = (object)cmd.ExecuteScalar();
            return Result;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();

        }
        return null;
    }
    private string MonthString(int mm)
    {
        string Month = "";
        switch (mm)
        {
            case 1:
                Month = "Jan";
                break;
            case 2:
                Month = "Feb";
                break;
            case 3:
                Month = "Mar";
                break;
            case 4:
                Month = "Apr";
                break;
            case 5:
                Month = "May";
                break;
            case 6:
                Month = "Jun";
                break;
            case 7:
                Month = "Jul";
                break;
            case 8:
                Month = "Aug";
                break;
            case 9:
                Month = "Sep";
                break;
            case 10:
                Month = "Oct";
                break;
            case 11:
                Month = "Nov";
                break;
            case 12:
                Month = "Dec";
                break;
        }
        return Month;
    }
}

