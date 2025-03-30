namespace PicPaySimplificado.Application.Communication
{
    public class Response<T>
    {
        public T? Data { get; private set; }
        public bool Success { get; private set; }

        public Response(T data)
        {
            Data = data;
            Success = true;
        }
    }
}
