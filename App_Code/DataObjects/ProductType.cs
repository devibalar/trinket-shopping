using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductType
/// </summary>
public class ProductType
{
	public ProductType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int typeId;

    private string typeName;

    public int TypeId
    {
        get { return typeId; }
        set { typeId = value; }
    }

    public string TypeName
    {
        get { return typeName; }
        set { typeName = value; }
    }

}