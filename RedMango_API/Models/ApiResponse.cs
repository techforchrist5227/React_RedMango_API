using System.Net;
/// <summary>
/// This is the API response model which describes the blueprint for the API response
/// </summary>
/// 

namespace RedMango_API.Models


{
    public class ApiResponse
    {
        public ApiResponse() 
        //initialize the errormessages in a string list with this constructor
        {
            ErrorMessages = new List<string>();
        }




        public HttpStatusCode StatusCode { get; set; }
        //200 ok 404 not found , bad request etc
        public bool IsSuccess { get; set; } = true;

        public List<string> ErrorMessages { get; set; }
        // any error messages
        public object Result { get; set; }
        //a single menu item, list of menu items, nothing .  This can be anything.  It's an object because we don't know the type
    }
}