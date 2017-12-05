using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for DBConnection
/// </summary>
public static class DBConnection
{
    public static SqlConnection conn = null;
	static DBConnection()
	{
		//
		// TODO: Add constructor logic here
		//    
        string config = ConfigurationManager.ConnectionStrings["BoutiqueConnectionString"].ConnectionString;
        conn = new SqlConnection(config);        
	}
   
}