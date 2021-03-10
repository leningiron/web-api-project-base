namespace ExternalBase.Lgm.Utilities.Dto
{
    public class ErrorDto
    {
        public int HttpCode { get; set; }
        public string HttpMessage { get; set; }
        public string DeveloperMessage { get; set; }
        public string[] ValidationErrors { get; set; }
    }
}
