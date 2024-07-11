namespace AcmeStudios.Utilities
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = false;

        public string Message { get; set; } = string.Empty;

        public int StatusCode {  get; set; }

        public static ServiceResponse<T> SuccessMessage(int code = 200, string message = "", dynamic data = null, bool success = true)
        {
            return new ServiceResponse<T>
            {
                Data = (T)data,
                Message = message,
                Success = success,
                StatusCode = code,
            };
        }
        public static ServiceResponse<T> ErrorMessage(int code, string message = "")
        {
            return new ServiceResponse<T>
            {
                Message = message,
                Success = false,
                StatusCode = code,
            };
        }
        public static ServiceResponse<T> TokenMessage(string message = "")
        {
            return new ServiceResponse<T>
            {
                Message = message,
                Success = false,
                StatusCode = 401
            };
        }
        public static ServiceResponse<T> SystemError(string message = "")
        {
            return new ServiceResponse<T>
            {
                Message = message ?? "Unknown Error Occurred. Please try again later",
                Success = false,
                StatusCode = 500,
            };
        }
    }
}
