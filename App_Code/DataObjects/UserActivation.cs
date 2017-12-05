using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserActivation
/// </summary>
public class UserActivation
{
    private string email;
    private string activationCode;
    private bool isActivated;

    public UserActivation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string ActivationCode
    {
        get { return activationCode; }
        set { activationCode = value; }
    }

    public bool IsActivated
    {
        get { return isActivated; }
        set { isActivated = value; }
    }
}