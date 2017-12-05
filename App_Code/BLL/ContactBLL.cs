using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Contact
/// </summary>
public class ContactBLL
{
	public ContactBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void sendEmail(Contact contact)
    {
         Email.sendQueryEmail(contact);
    }
}