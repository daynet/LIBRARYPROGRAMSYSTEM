using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// Summary description for CommonFunctions
/// </summary>
public static class CommonFunctions
{
    public static DateTime GetProperDate(string value)
    {
        string[] date = new string[3];
        date = value.Split('/');
        DateTime dt = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
        return dt;
    }
    public static void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
    {
        if (total == 0) return;
        int i, count = 1;
        ArrayList lst = new ArrayList();
        lst.Add(gvrc[0]);
        var ctrl = gvrc[0].Cells[startIndex];
        for (i = 1; i < gvrc.Count; i++)
        {
            TableCell nextCell = gvrc[i].Cells[startIndex];
            if (ctrl.Text == nextCell.Text)
            {
                count++;
                nextCell.Visible = false;
                lst.Add(gvrc[i]);
            }
            else
            {
                if (count > 1)
                {
                    ctrl.RowSpan = count;
                    GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                }
                count = 1;
                lst.Clear();
                ctrl = gvrc[i].Cells[startIndex];
                lst.Add(gvrc[i]);
            }
        }
        if (count > 1)
        {
            ctrl.RowSpan = count;
            GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
        }
        count = 1;
        lst.Clear();
    }
    public static byte[] UploadImage(FileUpload img)
    {
        try
        {

            Byte[] imgByte = null;

            if (img.HasFile && img.PostedFile != null)
            {

                //To create a PostedFile

                HttpPostedFile File = img.PostedFile;

                //Create byte Array with file len

                imgByte = new Byte[File.ContentLength];

                //force the control to load data in array

                File.InputStream.Read(imgByte, 0, File.ContentLength);

            }

            else
            {

                HttpPostedFile File = img.PostedFile;

                imgByte = new Byte[Convert.ToInt32(File.ContentLength)];

                File.InputStream.Read(imgByte, 0, File.ContentLength);

            }

            return imgByte;

        }
        catch (Exception Ex)
        {
            return null;
        }
    }
    public static DataTable ToDataTable<T>(this IList<T> data)
    {
        try
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }
        catch (Exception Ex)
        {
            return null;
        }
    }
    public static string RandomGenerator()
    {
        try
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        catch (Exception Ex)
        {
            return "";
        }
    }
    public static string GetDateinstring(string date)
    {
        try {
            string[] stringdate = new string[3];
            stringdate = date.Split('/');
            DateTime date1 = new DateTime(Convert.ToInt32(stringdate[2]), Convert.ToInt32(stringdate[1]), Convert.ToInt32(stringdate[0]));
            return date1.ToString("yyyyMMdd");
        }
        catch (Exception Ex)
        {
            return "";
        }
    }
    /*public static System.Drawing.Image getImage(byte[] imgByte)
    {
        try {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(imgByte, 0, imgByte.Length);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(memoryStream);
            HttpContext.Current.Response.ContentType = "image/Jpeg";
            ImageResize ir = new ImageResize();
            ir.File = imagen;
            ir.Height = 60;
            ir.Width = 60;
            return ir.GetThumbnail();
        }
        catch (Exception Ex)
        {
            return null;           
        }
    }*/

    public static bool CheckUserAuthentication(Int32 User_Id, string FormName)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@User_ID", User_Id);
            param[1] = new SqlParameter("@Form_Name", FormName);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParamSecurity(param, "ValidateFormLevel");
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)
                return true;

            return false;
        }
        catch (Exception Ex)
        {
            return false;
        }
    }

    //Added by SHIHAB A.M 6/Mar/2016
    /// <summary>
    /// This method will convert the supplied DataTable 
    /// to XML string.
    /// </summary>
    /// <param name="dtBuildSQL">DataTable to be converted.</param>
    /// <returns>XML string format of the DataTable.</returns>
    public static string ConvertDataTableToXML(System.Data.DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "dtData";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
  
}