using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeAccess
/// </summary>
public class ProductTypeAccess
{
	public ProductTypeAccess()
	{		
	}
    public DataSet GetAllProductType()
    {
        DataSet ds = new DataSet();
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT TypeId, Name FROM dbo.tblProductType WHERE Active=1";
            SqlDataAdapter myCommand = new SqlDataAdapter(query, DBConnection.conn);
            myCommand.Fill(ds, "Categories");
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        finally
        {
            if (DBConnection.conn != null)
            {
                DBConnection.conn.Close();
            }
        }
        return ds;
    }

    public bool UpdateProductType(ProductType prodType)
    {
        bool isUpdated = false;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblProductType SET Name=@name WHERE ProductId=@prodId";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                isUpdated = true;
            }
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        finally
        {
            DBConnection.conn.Close();
        }
        return isUpdated;
    }

    public bool DeleteProductType(ProductType prodType)
    {
        bool isDeleted = false;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblProductType SET Active=0 WHERE ProductId=@prodId";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                query = "UPDATE dbo.tblProduct SET Active=0 WHERE ProductId=@prodId";
                isDeleted = true;
            }
            
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        finally
        {
            DBConnection.conn.Close();
        }
        return isDeleted;
    }
}