using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttek.Infrastructure
{
    public static class ResponseFactory
    {
        public static IActionResult CreateSuccessResponse<T>(int statusCode, T? data)
        {
            var response = new ApiSuccessResponse<T>()
            {
                Status = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                 StatusCode = statusCode,
            };
        }

        public static IActionResult CreateSuccessResponse<T>(int statusCode, List<T>? data)
        {
            var response = new ApiSuccessResponseList<T>()
            {
                Status = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }
        public static IActionResult CreateErrorResponse(int statusCode,params string[] errors)
        {
            var response = new ApiErrorResponse()
            {
                Status = statusCode,
                Error = new List<ApiErrorResponse.ResponseError>()
            };

            foreach (var error in errors)
            {
                response.Error.Add(new ApiErrorResponse.ResponseError()
                {
                    Error = error
                });

            }

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }

    }
}
