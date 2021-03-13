namespace ExternalBase.Lgm.Utilities.Dto.Response
{
    public class GenericReponse<T>
    {
        public T Data { get; set; }
        public ErrorDto Error { get; set; }
    }
}
