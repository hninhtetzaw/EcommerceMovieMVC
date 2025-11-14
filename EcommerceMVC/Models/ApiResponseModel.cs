namespace EcommerceMVC.Models
{
    public class ApiResponseModel<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T Data { get; set; }
        public ErrorDetails Errors { get; set; }
    }
    public class ErrorDetails
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

    //we create ErrorClass 
    public class ErrorClass
    {
        public static ErrorDetails Invaild()
        {
            return new ErrorDetails
            {
                ErrorCode = "1000",
                ErrorDescription = "Invalid"
            };
        }
        public static ErrorDetails NotFound()
        {

            return new ErrorDetails
            {
                ErrorCode = "1001",
                ErrorDescription = "User Not Found"
            };
        }

        public static ErrorDetails SystemInvalid()
        {

            return new ErrorDetails
            {
                ErrorCode = "1005",
                ErrorDescription = "System Invalid"
            };

        }

        public static ErrorDetails PasswordInvaild()
        {
            return new ErrorDetails
            {
                ErrorCode = "1002",
                ErrorDescription = "Password Invalid"
            };

        }
    }


     //this must be in class , not only method Invalid()
      //public static ErrorDetails Invaild()

      //  {

      //      return new ErrorDetails
      //      {
      //          ErrorCode = "1000",
      //          ErrorDescription = "Invalid"
      //      };



      //  }

    }