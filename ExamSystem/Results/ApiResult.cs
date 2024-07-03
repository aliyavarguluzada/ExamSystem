using System.Net;

namespace ExamSystem.Results
{
    public class ApiResult<T>
    {
        public T Response { get; set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public List<T>? Values { get; set; }
        public Dictionary<string, string> ErrorList { get; set; }

        public static ApiResult<T> Ok(T response)
        {
            return new ApiResult<T>
            {
                Response = response,
                StatusCode = (int)HttpStatusCode.OK,
                Description = "Operation successfull",
                ErrorList = null,
                Values = new List<T> { response }
            };
        }

        public static ApiResult<T> Error(string key, string value, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ApiResult<T>
            {
                Response = default,
                StatusCode = statusCode,
                ErrorList = new Dictionary<string, string> { { key, value } }

            };
        }
    }
}
