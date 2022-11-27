using System.Text.Json.Serialization;

namespace KouArge.Core.DTOs
{
    //public class NoContentDto
    //{
    //    [JsonIgnore]
    //    public int StatusCode { get; set; }
    //    public List<string> Errors { get; set; }
    //    public static NoContentDTO Success(int statusCode)
    //    {
    //        return new NoContentDTO { StatusCode = statusCode, Errors = null };
    //    }
    //    public static NoContentDTO Fail(int statucCode, List<string> errors)
    //    {
    //        return new NoContentDTO { StatusCode = statucCode, Errors = errors };
    //    }
    //    public static NoContentDTO Fail(int statucCode, string error)
    //    {
    //        return new NoContentDTO { StatusCode = statucCode, Errors = new List<string>() { error } };
    //    }
    //}
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public int ErrorStatus { get; set; }
        //public List<string> Errors { get; set; }

        public List<ErrorViewModel> Errors { get; set; }


        public static CustomResponseDto<T> Success(int statusCode, T data)
        {

            return new CustomResponseDto<T>() { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<ErrorViewModel> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, ErrorViewModel error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<ErrorViewModel>() { error } };
        }

        public static CustomResponseDto<T> Fail(int statusCode, ErrorViewModel error, int errorStatus)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<ErrorViewModel>() { error }, ErrorStatus = errorStatus };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<ErrorViewModel> errors, int errorStatus)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors, ErrorStatus = errorStatus };
        }
    }
}
