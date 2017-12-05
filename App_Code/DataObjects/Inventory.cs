using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Inventory
/// </summary>
public class Inventory
{
    private int productId;
    private int quantity;
    private bool outOfStock;

	public Inventory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Inventory( int quantity, bool outOfStock)
    {
       // this.productId = productId;
        this.quantity = quantity;
        this.outOfStock = outOfStock;
    }
    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public bool OutOfStock
    {
        get { return outOfStock; }
        set { outOfStock = value; }
    }
}