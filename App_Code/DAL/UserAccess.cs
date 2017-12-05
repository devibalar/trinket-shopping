using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAccess
/// </summary>
public class UserAccess
{
	public UserAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool addUser(User user)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string salt = PasswordGenerator.generateSalt();
            string hashPassword = PasswordGenerator.generateHash(user.Password+salt);   
            string query = "INSERT INTO dbo.tblUser (FirstName,LastName,Email,PhoneNumber,Password,Address,IsAdmin, Active, Salt) "
                            + " VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@Password,@Address,@IsAdmin, @Active, @Salt) ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.Phone);
            cmd.Parameters.AddWithValue("@Password", hashPassword);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin?1:0);
            cmd.Parameters.AddWithValue("@Active", user.IsActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@Salt", salt);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                UserActivation userActivation = new UserActivation();
                userActivation.Email = user.Email ;
                UserActivationAccess userActivationAccess = new UserActivationAccess();
                status =userActivationAccess.addUserActivation(userActivation);                               
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


    public bool updateUser(User user)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblUser SET FirstName=@FirstName,LastName=@LastName,Email=@Email,PhoneNumber=@PhoneNumber,"
                            + "Address=@Address WHERE UserId=@UserId ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.Phone);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@UserId", user.UserId);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
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
    public bool updateProfile(User user)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblUser SET FirstName=@FirstName,LastName=@LastName,Email=@Email,PhoneNumber=@PhoneNumber,"
                            + "Password=@Password,Address=@Address WHERE UserId=@UserId ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.Phone);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@UserId", user.UserId);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
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

    public bool deleteUser(User user)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string query = "DELETE FROM dbo.tblUser WHERE UserId=@UserId ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@UserId", user.UserId);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
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

    public bool disableUser(User user)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblUser SET Active=0 WHERE Email=@Email ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
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

    public DataTable searchUser(string email, bool isAdmin)
    {
        List<User> users = new List<User>();
        DataTable dt = null;
        try
        {
            DBConnection.conn.Open();
            string query = "SELECT UserId,FirstName,LastName,Email,PhoneNumber,Address FROM dbo.tblUser WHERE Email LIKE @Email AND isAdmin=@isAdmin AND Active=1 ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@Email", "%"+email+"%");
            cmd.Parameters.AddWithValue("@isAdmin", isAdmin ? 1 : 0);  
            dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
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
        return dt;
    }

    public User validateUser(string email, string password)
    {
        User user =null;
        try
        {
            DBConnection.conn.Open();
            string salt = "";
            string query = "SELECT salt from dbo.tblUser where LOWER(email) =LOWER(@Email)";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@Email",email);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                salt = reader["salt"].ToString();
            }
            reader.Close();
            if (salt != "")
            {
                string hashPassword = PasswordGenerator.generateHash(password+salt);
                string query1 = "SELECT FirstName,IsAdmin,UserId FROM dbo.tblUser WHERE Email=@email AND Password=@password AND Active=1 ";
                SqlCommand cmd1 = new SqlCommand(query1, DBConnection.conn);
                cmd1.Parameters.AddWithValue("@email", email);
                cmd1.Parameters.AddWithValue("@password", hashPassword);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    user = new User();

                    if (Boolean.Parse( reader1["IsAdmin"].ToString() ))
                    {
                        user.IsAdmin = true;
                    }
                    else
                    {
                        user.IsAdmin = false;
                    }
                    user.FirstName = reader1["FirstName"].ToString();
                    user.UserId = int.Parse(reader1["UserId"].ToString());

                }
            }
        }
        catch(SqlException e)
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
        return user;
    }

    public bool insertResetPasswordKey(User user)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string query = "UPDATE dbo.tblUser SET ResetKey=@ResetKey WHERE Email=@Email ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@ResetKey", user.ResetKey);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                status = true;
            }
        }
        catch(SqlException e)
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

    public bool removeResetPasswordKey(User user)
    {
        bool status = false;
        try
        {
            DBConnection.conn.Open();
            string email = "";
            string query = "SELECT Email FROM dbo.tblUser WHERE ResetKey = @ResetKey AND Active=1 ";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@ResetKey", user.ResetKey);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                email = reader["Email"].ToString();
            }
            reader.Close();
            string query1 = "UPDATE dbo.tblUser SET ResetKey=null WHERE Email=@Email ";
            SqlCommand cmd1 = new SqlCommand(query1, DBConnection.conn);
            cmd1.Parameters.AddWithValue("@Email", email);
            int result = cmd1.ExecuteNonQuery();
            if (result > 0)
            {
                user.Email = email;
                status = changePassword(user);              
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

    public bool changePassword(User user)
    {
        bool status = false;
        try
        {
            string salt = "";
            string query = "SELECT salt from dbo.tblUser where email =@Email";
            SqlCommand cmd = new SqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@Email",user.Email);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                salt = reader["salt"].ToString();
            }
            reader.Close();
            if (salt != "")
            {
                string hashPassword = PasswordGenerator.generateHash(user.Password + salt);
                string query1 = "UPDATE dbo.tblUser SET Password=@Password WHERE Email=@Email ";
                SqlCommand cmd1 = new SqlCommand(query1, DBConnection.conn);
                cmd1.Parameters.AddWithValue("@Email", user.Email);
                cmd1.Parameters.AddWithValue("@Password", hashPassword);
                int result = cmd1.ExecuteNonQuery();
                if (result > 0)
                {
                    status = true;
                }
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