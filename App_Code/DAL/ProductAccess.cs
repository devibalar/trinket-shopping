using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductAccess
/// </summary>
public class ProductAccess
{
	public ProductAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<Product> GetProducts(string type)
    {
        List<Product> products = new List<Product>();
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT prod.ProductId, prod.Name, prod.Price, prod.Description, prod.ImageUrl"
                            +" FROM dbo.tblProduct prod JOIN dbo.tblProductType typ ON typ.TypeID = prod.TypeID"
                            + " WHERE typ.Name=@type";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@type", type);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = int.Parse(reader["ProductId"].ToString());
                product.Name = reader["Name"].ToString();
                product.Price = Decimal.Parse(reader["Price"].ToString());
                product.Description = reader["Description"].ToString();
                product.ImageUrl = reader["ImageUrl"].ToString();
                products.Add(product);
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
        return products;
    }

    public List<Product> GetProducts(int typeId)
    {
        List<Product> products = new List<Product>();
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT ProductId, Name, Price, Description, ImageUrl FROM dbo.tblProduct WHERE TypeID=@typeid";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@typeid", typeId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = int.Parse(reader["ProductId"].ToString());
                product.Name = reader["Name"].ToString();
                product.Price = Decimal.Parse(reader["Price"].ToString());
                product.Description = reader["Description"].ToString();
                product.ImageUrl = reader["ImageUrl"].ToString();
                products.Add(product);
            }
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
        return products;
    }

    public DataTable GetAllProducts(int typeId)
    {
        DataTable dt = null;
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT prod.ProductId, prod.Name, prod.Price, prod.Description, prod.ImageUrl, inv.Quantity  FROM dbo.tblProduct prod "+
                                "JOIN dbo.tblInventory inv ON inv.ProductID = prod.ProductID WHERE TypeID=@typeid and OutOfStock=0";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@typeid", typeId);
            dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
            }
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
        return dt;
    }

    public DataTable GetAllProducts(int typeId, string productName)
    {
        DataTable dt = null;
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT prod.ProductId, prod.Name, prod.Price, prod.Description, prod.ImageUrl, inv.Quantity  FROM dbo.tblProduct prod " +
                                "JOIN dbo.tblInventory inv ON inv.ProductID = prod.ProductID WHERE prod.TypeID=@typeid AND inv.OutOfStock=0 AND prod.Name LIKE @prodName";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@typeid", typeId);
            cmd.Parameters.AddWithValue("@prodName", "%" + productName + "%");
            dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
            }
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
        return dt;
    }

    public DataTable GetAllProducts(int typeId, string productName, decimal fromPrice, decimal toPrice)
    {
        DataTable dt = null;
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT prod.ProductId, prod.Name, prod.Price, prod.Description, prod.ImageUrl, inv.Quantity  FROM dbo.tblProduct prod " +
                                "JOIN dbo.tblInventory inv ON inv.ProductID = prod.ProductID WHERE prod.TypeID=@typeid AND inv.OutOfStock=0 AND prod.Name LIKE @prodName AND "
                                + "prod.Price BETWEEN @fromPrice AND @toPrice ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@typeid", typeId);
            cmd.Parameters.AddWithValue("@prodName", "%" + productName + "%");
            cmd.Parameters.AddWithValue("@fromPrice",fromPrice);
            cmd.Parameters.AddWithValue("@toPrice", toPrice);
            dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
            }
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
        return dt;
    } 

    public Product GetAProduct(int productId)
    {
        Product product =  new Product();
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT ProductId,Name, Price, Description, ImageUrl FROM dbo.tblProduct WHERE ProductId = @productId";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@productId", productId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                product.ProductId = int.Parse(reader["ProductId"].ToString());
                product.Name = reader["Name"].ToString();
                product.Price = Decimal.Parse( reader["Price"].ToString());
                product.Description = reader["Description"].ToString();
                product.ImageUrl = reader["ImageUrl"].ToString();
            }
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
        return product;
    }
    public bool AddProduct(Product prod, int quantity)
    {
        bool isAdded = false;     
        try
        {
            DBConnection.conn.Open();
           
            SqlCommand cmd = new SqlCommand("dbo.InsertProduct", DBConnection.conn);
            cmd.Parameters.AddWithValue("@Name", prod.Name);
            cmd.Parameters.AddWithValue("@Price", prod.Price);
            cmd.Parameters.AddWithValue("@Description", prod.Description);
            cmd.Parameters.AddWithValue("@ImageUrl", prod.ImageUrl);
            cmd.Parameters.AddWithValue("@TypeId", prod.TypeId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.CommandType = CommandType.StoredProcedure;
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {             
                 isAdded = true;
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
        return isAdded;
    }

    public bool UpdateProduct(Product prod, int quantity)
    {
        bool isUpdated = false;
        int prodId = prod.ProductId;
        string prodNme =prod.Name;
        decimal prodPrice = prod.Price;
        string prodDesc = prod.Description;
        string prodImg = prod.ImageUrl;
        int prodQuantity = quantity;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblProduct SET Name=@prodNme, Price=@prodPrice, Description=@prodDesc, ImageUrl=@prodImg WHERE ProductId=@prodId  ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@prodId", prodId);
            cmd.Parameters.AddWithValue("@prodNme", prodNme);
            cmd.Parameters.AddWithValue("@prodPrice", prodPrice);
            cmd.Parameters.AddWithValue("@prodDesc", prodDesc);
            cmd.Parameters.AddWithValue("@prodImg", prodImg);          
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                query = "UPDATE dbo.tblInventory SET Quantity=@prodQuantity WHERE ProductId=@prodId";
                SqlCommand cmd1 = new SqlCommand(query, DBConnection.conn);
                cmd1.Parameters.AddWithValue("@prodId", prodId);
                cmd1.Parameters.AddWithValue("@prodQuantity", prodQuantity);
                result = cmd1.ExecuteNonQuery();
                if (result > 0)
                {
                    isUpdated = true;
                }
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
        return isUpdated;
    }

    public bool DeleteProduct(int productId)
    {
        bool isDeleted = false; 
        try
        {
            DBConnection.conn.Open();
            string query = "DELETE FROM dbo.tblInventory WHERE ProductId=@prodId";
            SqlCommand cmd1 = new SqlCommand(query, DBConnection.conn);
            cmd1.Parameters.AddWithValue("@prodId", productId);
            int result = cmd1.ExecuteNonQuery();                
            if (result > 0)
            {
                query = "DELETE FROM dbo.tblProduct WHERE ProductId=@prodId  ";
                SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
                cmd.Parameters.AddWithValue("@prodId", productId);
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    isDeleted = true;
                }
            }
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
        return isDeleted;
    }
}