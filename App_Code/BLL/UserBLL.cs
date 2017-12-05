using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBLL
/// </summary>
public class UserBLL
{
    UserAccess useracc = new UserAccess();
	public UserBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public User validateUser(string email, string password)
    {
        User oUser;
        oUser = useracc.validateUser(email, password);
        return oUser;
    }
    public bool addUser(User user)
    {
        bool status = useracc.addUser(user);       
        return status;
    }
    public bool updateUser(User user)
    {
        bool status = useracc.updateUser(user);
        return status;
    }
    public bool deleteUser(User user)
    {
        bool status = useracc.deleteUser(user);
        return status;
    }
    public bool disableUser(User user)
    {
        bool status = useracc.disableUser(user);
        return status;
    }
    public DataTable searchUser(string email, bool isAdmin)
    {
        DataTable dt = useracc.searchUser(email, isAdmin);
        return dt;
    }
    //1) Generate a random alphanumeric value as resetKey 2)save resetKey in user table 3) send it in a link to user's email to reset password
    public bool generatePasswordLink(string email)
    {
        Random r = new Random();
        User usr = new User();
        int num = r.Next(10, 20);
        string randomKeyString = PasswordGenerator.RandomString(num);
        usr.Email = email;
        usr.ResetKey = randomKeyString;
        bool status = useracc.insertResetPasswordKey(usr);
        if (status)
        {
            Email.sendResetPassword(usr);
        }
        return status;
    }
    // verify the resetKey exists for the user and change the password
    public bool removeResetPasswordKey(User user)
    {
        bool status = useracc.removeResetPasswordKey(user);
        return status;
    }

    public bool activateUser(UserActivation userActivation)
    {
        UserActivationAccess userActivationAccess = new UserActivationAccess();
        bool status = userActivationAccess.setActivated(userActivation);
        return status;
    }

}