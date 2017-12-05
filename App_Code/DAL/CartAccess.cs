using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartAccess
/// </summary>
public class CartAccess
{
	public CartAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<Cart> getCartProductsForUser(int userId)
    {
        List<Cart> cartProducts = new List<Cart>();
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT c.ProductId, c.Quantity, p.ImageUrl, p.Name, p.Price FROM dbo.tblCart c INNER JOIN dbo.tblProduct p "+ 
                            "ON p.ProductId = c.ProductId  WHERE c.UserId=@UserId";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cart oCart = new Cart();
                oCart.product1.ProductId = int.Parse(reader["ProductId"].ToString());
                oCart.product1.Name = reader["Name"].ToString();
                oCart.product1.Price = Decimal.Parse(reader["Price"].ToString());
                oCart.product1.ImageUrl = reader["ImageUrl"].ToString();
                oCart.Quantity = int.Parse(reader["Quantity"].ToString());
                cartProducts.Add(oCart);
            }
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        catch (FormatException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        catch (ArgumentNullException e)
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
        return cartProducts;
    }

    public bool addCart(Cart oCart)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            String query = "INSERT INTO dbo.tblCart (UserId, ProductId, Quantity, AddedDate) VALUES (@UserId, @ProductId, @Quantity, @AddedDate)";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@UserId", oCart.UserId);
            cmd.Parameters.AddWithValue("@ProductId", oCart.product1.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", oCart.Quantity);
            cmd.Parameters.AddWithValue("@AddedDate", oCart.AddedDate);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
            }
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        catch (Exception e)
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
        return status;
    }
    public bool updateCart(Cart oCart)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            String query = "UPDATE dbo.tblCart SET Quantity = @Quantity WHERE UserId = @UserId AND Product = @ProductId";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@UserId", oCart.UserId);
            cmd.Parameters.AddWithValue("@ProductId", oCart.product1.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", oCart.Quantity);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
            }
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        catch (Exception e)
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
        return status;
    }
    public bool deleteCart(Cart oCart)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            String query = "DELETE FROM dbo.tblCart WHERE UserId=@UserId AND ProductId=@ProductId ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@UserId", oCart.UserId);
            cmd.Parameters.AddWithValue("@ProductId", oCart.product1.ProductId);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
            }
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        catch (Exception e)
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
        return status;
    }
}