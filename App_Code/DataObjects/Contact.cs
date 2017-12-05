using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Contact
/// </summary>
public class Contact
{
    private string contactName;
    private string contactEmail;
    private string subject;
    private string query;

	public Contact()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string ContactName
    {
        get { return contactName; }
        set { contactName = value; }
    }

    public string ContactEmail
    {
        get { return contactEmail; }
        set { contactEmail = value; }
    }

    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }

    public string Query
    {
        get { return query; }
        set { query = value; }
    }
}