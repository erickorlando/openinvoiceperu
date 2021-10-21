namespace OpenInvoicePeru.RestService.ApiSunatDto
{
    public class BaseResponseDto<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}