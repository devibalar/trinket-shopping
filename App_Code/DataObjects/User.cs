using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private int userId;
    private string firstName;
    private string lastName;
    private string email;
    private string phone;
    private string address;
    private string password;
    private bool isAdmin;
    private bool isActive;
    private string salt;
    private string resetKey;

    public User()
    {
    }
    public User(int userId, string firstName, string lastName, string email, string phone, string address, 
                string password, bool isAdmin, bool isActive)
    {
        this.userId = userId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phone = phone;
        this.address = address;
        this.password = password;
        this.isAdmin = isAdmin;
        this.isActive = isActive;
    }

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    public bool IsAdmin
    {
        get { return isAdmin; }
        set { isAdmin = value; }
    }
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
    public string Salt
    {
        get { return salt; }
        set { salt = value; }
    }
    public string ResetKey
    {
        get { return resetKey; }
        set { resetKey = value; }
    }
}