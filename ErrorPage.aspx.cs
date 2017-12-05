using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create safe error messages.
        string generalErrorMsg = "A problem has occurred on this web site. Please try again. " +
            "If this error continues, please contact support.";
        string httpErrorMsg401 = "You are not authorized to view this page";
        string httpErrorMsg404 = "An HTTP error occurred. Page Not found. Please try again.";
        string httpErrorMsg403 = "Page cannnot be accessed. Forbidden ";
        string serverError500 = "Internal server error. Please try again later";
        string unhandledErrorMsg = "The error was unhandled by application code.";

        // Display safe error message.
        FriendlyErrorMsg.Text = generalErrorMsg;
        ErrorType.InnerText = "Error";

        // Determine where error was handled.
        string errorHandler = Request.QueryString["handler"];
        if (errorHandler == null)
        {
            errorHandler = "Error Page";
        }

        // Get the last error from the server.
        Exception ex = Server.GetLastError();

        // Get the error number passed as a querystring value.
        string errorMsg = Request.QueryString["msg"];
        if (errorMsg == "404")
        {
            ex = new HttpException(404, httpErrorMsg404, ex);
            FriendlyErrorMsg.Text = ex.Message;
            ErrorType.InnerText = "Wrong Page";
        }
        else if (errorMsg == "403")
        {
            ex = new HttpException(403, httpErrorMsg403, ex);
            FriendlyErrorMsg.Text = ex.Message;
            ErrorType.InnerText = "Forbidden";
        }
        else if (errorMsg == "401")
        {
            ex = new HttpException(401, httpErrorMsg401, ex);
            FriendlyErrorMsg.Text = ex.Message;
            ErrorType.InnerText = "Authorization Required";
        }
        else if (errorMsg == "500")
        {
            ex = new HttpException(500, serverError500, ex);
            FriendlyErrorMsg.Text = ex.Message;
            ErrorType.InnerText = "Internal Server Error";
        }
        // If the exception no longer exists, create a generic exception.
        if (ex == null)
        {
            ex = new Exception(unhandledErrorMsg);
        }

        // Show error details to only you (developer). LOCAL ACCESS ONLY.
        if (Request.IsLocal)
        {
            // Detailed Error Message.
            ErrorDetailedMsg.Text = ex.Message;

            // Show where the error was handled.
            ErrorHandler.Text = errorHandler;

            // Show local access details.
            DetailedErrorPanel.Visible = true;

            if (ex.InnerException != null)
            {
                InnerMessage.Text = ex.GetType().ToString() + "<br/>" +
                    ex.InnerException.Message;
                InnerTrace.Text = ex.InnerException.StackTrace;
            }
            else
            {
                InnerMessage.Text = ex.GetType().ToString();
                if (ex.StackTrace != null)
                {
                    InnerTrace.Text = ex.StackTrace.ToString().TrimStart();
                }
            }
        }

        // Log the exception.
        ExceptionUtility.LogException(ex, errorHandler);

        // Clear the error from the server.
        Server.ClearError();
    }
}