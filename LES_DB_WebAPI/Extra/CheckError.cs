namespace LES_DB_WebAPI.Extra
{
    public class CheckError
    {

        public static Boolean IsNetworkIssue(string cExcepetion)
        {
            Boolean ret = false;
            try
            {
                if (cExcepetion.Contains("The remote server returned an error: (403) Forbidden"))
                    ret = true;
                else if (cExcepetion.Contains("The remote server returned an error: (405)"))
                    ret = true;
                else if (cExcepetion.Contains("The remote server returned an error: (404) Not Found"))
                    ret = true;
                else if (cExcepetion.Contains("Server Unavailable"))
                    ret = true;
                else if (cExcepetion.Contains("Could not get any response"))
                    ret = true;
                else if (cExcepetion.Contains("Unable to connect to the remote server"))
                    ret = true;
                else if (cExcepetion.Contains("Exception has been thrown by the target of an invocation"))
                    ret = true;
                else if (cExcepetion.Contains("(500) Internal Server Error"))
                    ret = true;
                else if (cExcepetion.Contains("Encrypted Message Required"))
                    ret = true;
                else if (cExcepetion.Contains("The operation has timed out"))
                    ret = true;
            }
            catch (Exception ex)
            {
                //InserLog("Error in checking network issue - " + ex.Message);
            }
            return ret;
        }


    }
}
