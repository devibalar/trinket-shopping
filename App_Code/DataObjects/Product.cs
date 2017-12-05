using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product:ProductType
{
    private int productId;
    private string name;
    private decimal price;
    private string description;
    private string imageUrl;

    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Product(int productId, string name, decimal price, string description, string imageUrl, int quantity )
    {
        this.productId = productId;
        this.name = name;
        this.price = price;
        this.description = description;
        this.imageUrl = imageUrl;
        Inventory inv = new Inventory(quantity,false);
    }

    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string ImageUrl
    {
        get { return imageUrl; }
        set { imageUrl = value; }
    }
}