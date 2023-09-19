using static TpIntegradorSofttek.Infrastructure.ApiErrorResponse;

namespace TpIntegradorSofttek.Infrastructure
{
    public class ApiSuccessResponse<T>
    {
        public int Status { get; set; }
        public T? Data { get; set; }


    }
    public class ApiSuccessResponseList<T>
    {
        public int Status { get; set; }
        public List<T>? Data { get; set; }


    }
}
