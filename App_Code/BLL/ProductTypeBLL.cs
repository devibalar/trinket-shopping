using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ProductTypeBLL
/// </summary>
public class ProductTypeBLL
{
	public ProductTypeBLL()
	{		
	}

    public DataSet GetAllCategories()
    {
        ProductTypeAccess prodtypeacc = new ProductTypeAccess();
        DataSet ds = prodtypeacc.GetAllProductType();
        return ds;
    }
}