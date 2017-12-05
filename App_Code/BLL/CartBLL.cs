using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartBLL
/// </summary>
public class CartBLL
{
    CartAccess ocartAccess = new CartAccess(); 
	public CartBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<Cart> getAllProductsForUser(int userId)
    {
        List<Cart> cartProducts = ocartAccess.getCartProductsForUser(userId);
        return cartProducts;
    }

    public bool addCart(Cart oCart)
    {
        bool status = ocartAccess.addCart(oCart);
        return status;
    }
    public bool updateCart(Cart oCart)
    {
        bool status = ocartAccess.updateCart(oCart);
        return status;
    }
    public bool deleteCart(Cart oCart)
    {
        bool status = ocartAccess.deleteCart(oCart);
        return status;
    }
}