using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserActivationAccess
/// </summary>
public class UserActivationAccess
{
	public UserActivationAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool addUserActivation(UserActivation userActivation)
    {
        bool status = false;
        try
        {
            if (DBConnection.conn == null)
            {
                DBConnection.conn.Open();
            }
            Random r = new Random();
            int num = r.Next(10, 20);
            string activationCode = PasswordGenerator.RandomString(num);
            string query = "INSERT INTO dbo.tblUserActivation (Email, ActivationCode,isActivated) VALUES (@Email,@ActivationCode,0)";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@Email", userActivation.Email);
            cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
                Email.sendActivationCode(userActivation.Email, activationCode);
            }
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        finally
        {
            if (DBConnection.conn != null)
            {
                DBConnection.conn.Close();
            }
        }
        return status;
    }

    public bool setActivated(UserActivation userActivation)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblUserActivation SET isActivated=1 WHERE Email=@Email AND ActivationCode=@ActivationCode";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@Email", userActivation.Email);
            cmd.Parameters.AddWithValue("@ActivationCode", userActivation.ActivationCode);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
                Email.sendActivatedMessage(userActivation.Email);
            }
        }
        catch (SqlException e)
        {
            ExceptionUtility.LogException(e, "Error Page");
        }
        finally
        {
            if (DBConnection.conn != null)
            {
                DBConnection.conn.Close();
            }
        }
        return status;
    }
}