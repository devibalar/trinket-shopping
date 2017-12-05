using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for ProductBLL
/// </summary>
public class ProductBLL
{
    ProductAccess prodacc = new ProductAccess();
	public ProductBLL()
	{		
	}
  

    public List<Product> GetProducts(string type)
    {
        List<Product> products = new List<Product>();
        products = prodacc.GetProducts(type);
        return products;
    }

    public DataTable GetAllProducts(int typeId)
    {
        DataTable dt = new DataTable();
        if (typeId < 100)
        {           
            dt= prodacc.GetAllProducts(typeId);
        }
        return dt;
    }

    public DataTable GetAllProducts(int typeId, string prodName)
    {
        DataTable dt = new DataTable();
        if (typeId < 100)
        {
            dt = prodacc.GetAllProducts(typeId, prodName);
        }
        return dt;
    }
    public DataTable GetAllProducts(int typeId, string prodName, decimal fromPrice, decimal toPrice)
    {
        DataTable dt = new DataTable();
        if (typeId < 100)
        {
            dt = prodacc.GetAllProducts(typeId, prodName, fromPrice, toPrice);
        }
        return dt;
    }

    public Product GetAProduct(int productId)
    {
        Product product  = prodacc.GetAProduct(productId);
        return product;
    }

    public bool addProduct(Product product, int quantity)
    {
        bool isAdded = prodacc.AddProduct(product,quantity);
        return isAdded;
    }

    public bool updateProduct(Product product, int quantity)
    {
        bool isUpdated = prodacc.UpdateProduct(product, quantity);
        return isUpdated;
    }

    public bool deleteProduct(int productId)
    {
        bool isDeleted = prodacc.DeleteProduct(productId);
        return isDeleted;
    }
}