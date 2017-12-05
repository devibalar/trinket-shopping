using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;
using System.Configuration;
using System.Net.Configuration;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    public static string trinketsEmail = "";
    static Email()
    {     
        trinketsEmail = ""; //mailSettings.Smtp.Network.UserName; 
    }
 

    public static void sendResetPassword(User user)
    {
        try
        {
            MailMessage message = new MailMessage(trinketsEmail, user.Email);
            StringBuilder body = new StringBuilder();
            body.Append(" <p> Did you forget your password? No problem! Please click the link below to reset your password. </p><br/> ");
            body.Append("<p> http://localhost:53985/Trinkets/frmRestorePassword.aspx?key=" + user.ResetKey + " </p>")
                .Append("<p>If you cannot access this link, copy and paste the entire URL into your browser.<br/>")
                .Append("If you need further help, please email trinketsnz@gmail.com<br/>")
                .Append("Regards,<br/>")
                .Append("Trinkets Shop New Zealand.");
            message.Body = body.ToString();
            message.Subject = "Trinkets Shop | Reset your Trinkets Shop Account Password";
            message.IsBodyHtml = true;
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Send(message);
        }
        catch (Exception ex)
        {
            ExceptionUtility.LogException(ex, "Error logger");
        }
    }
    public static void sendActivationCode(string email, string activationCode)
    {
        try
        {
            MailMessage message = new MailMessage(trinketsEmail, email);
            StringBuilder body = new StringBuilder();
            body.Append(" <p> We are proud to welcome you as a new customer of Trinkets Shop New Zealand! <br/> ")
                .Append(" In order to reduce spam, we require that all email addresses to be confirmed before we send you any promotions.<br/>")
                .Append(" Please confirm your email by clicking on the link below.</p><br/> ")
                .Append("<p> http://localhost:53985/Trinkets/frmUserActivation.aspx?code=" + activationCode + "&email=" + email + " </p>")
                .Append("<p>If you are unable to click on the link above, please cut-n-paste the full link into the address bar of your internet browser and visit the webpage that way. This will activate your account.<br/>")
                .Append("If you need further help, please email trinketsnz@gmail.com. <br/>")
                .Append("Thank you for choosing Trinkets Shop. Enjoy the experience.<br/>")
                .Append("Regards,<br/>")
                .Append("Trinkets Shop New Zealand.</p>");
            message.Body = body.ToString();
            message.Subject = "Trinkets Shop | Welcome to Trinkets Shop New Zealand";
            message.IsBodyHtml = true;
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Send(message);
        }
        catch (Exception ex)
        {
             ExceptionUtility.LogException(ex, "Error logger");
        }
    }

    public static void sendActivatedMessage(string email)
    {
        try
        {
            MailMessage message = new MailMessage(trinketsEmail, email);
            StringBuilder body = new StringBuilder();
            body.Append(" <p> Congratulations. Your account is now active. Enjoy shopping in Trinkets </p><br/> ");
            body.Append("<p> http://localhost:53985/Trinkets/frmHome.aspx </p>")
                .Append("Regards,<br/>")
                .Append("Trinkets Shop New Zealand.");
            message.Body = body.ToString();
            message.Subject = "Trinkets Shop | Support";
            message.IsBodyHtml = true;
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Send(message);
        }
        catch (Exception ex)
        {
            ExceptionUtility.LogException(ex, "Error logger");
        }
    }

    public static void sendQueryEmail(Contact contact)
    {
        try
        {
            sendEmailToAdmin(contact);
            sendEmailToCustomer(contact);
        }
        catch (Exception ex)
        {
            ExceptionUtility.LogException(ex, "Error logger");
        }
    }
    private static void sendEmailToAdmin(Contact contact)
    {
        try
        {
            MailMessage message = new MailMessage(trinketsEmail, trinketsEmail);
            StringBuilder body = new StringBuilder();
            body.Append("<p> Name: " + contact.ContactName + "<br/> Email: " + contact.ContactEmail + "<br/> Query:" + contact.Query + "<br/> </p><br/> ")
                .Append("Regards,<br/>")
                .Append("Trinkets Shop New Zealand.");
            message.Body = body.ToString();
            message.Subject = "Trinkets Shop | Support - " + contact.Subject;
            message.IsBodyHtml = true;
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Send(message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private static void sendEmailToCustomer(Contact contact)
    {
        try
        {
            MailMessage message = new MailMessage(trinketsEmail, contact.ContactEmail);
            StringBuilder body = new StringBuilder();
            body.Append("<p>  Query:" + contact.Query + "<br/> Thank you for contacting us. Your queries will be answered shortly </p><br/> ")
                .Append("Regards,<br/>")
                .Append("Trinkets Shop New Zealand.");
            message.Body = body.ToString();
            message.Subject = "Trinkets Shop | Support";
            message.IsBodyHtml = true;
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Send(message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }    
}