using Newtonsoft.Json;

namespace OpenInvoicePeru.RestService.ApiSunatDto
{
    public class TokenResponseDto
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int Expires { get; set; }
    }
}