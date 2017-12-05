using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart
{
    private int userId;
    private Product product=new Product();
    private int quantity;
    private DateTime addedDate;

    public Cart()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Cart(int userId, Product product, int quantity)
    {
        this.userId = userId;
        this.product = product;
        this.quantity = quantity;
    }

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    public Product product1
    {
        get { return product; }
        set { product = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public DateTime AddedDate
    {
        get { return addedDate; }
        set { addedDate = value; }
    }

}