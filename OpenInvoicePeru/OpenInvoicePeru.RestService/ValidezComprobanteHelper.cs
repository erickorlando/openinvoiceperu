using OpenInvoicePeru.RestService.ApiSunatDto;
using RestSharp;
using System;
using Newtonsoft.Json;

namespace OpenInvoicePeru.RestService
{
    public class ValidezComprobanteHelper
    {
        public BaseResponseDto<TokenResponseDto> GenerarToken(string clientId, string clientSecret)
        {
            var response = new BaseResponseDto<TokenResponseDto>();

            try
            {
                var restClient = new RestClient($"https://api-seguridad.sunat.gob.pe/v1/clientesextranet/{clientId}/oauth2/token");

                var restRequest = new RestRequest(Method.POST);

                var formUrlencoded = "application/x-www-form-urlencoded";
                var grandType = "client_credentials";
                var scope = "https://api.sunat.gob.pe/v1/contribuyente/contribuyentes";

                restRequest.AddHeader("Content-Type", formUrlencoded);

                restRequest.AddParameter(formUrlencoded,
                    $"grant_type={grandType}&scope={scope}&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);

                var responseMessage = restClient.Execute(restRequest);

                response.Success = responseMessage.IsSuccessful;

                if (responseMessage.IsSuccessful)
                {
                    response.Result = JsonConvert.DeserializeObject<TokenResponseDto>(responseMessage.Content);
                }
                else
                {
                    response.ErrorMessage = responseMessage.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ValidacionResponse Validar(string rucReceptor, string token, ValidacionRequest request)
        {
            var response = new ValidacionResponse();

            try
            {
                var restClient = new RestClient($"https://api.sunat.gob.pe/v1/contribuyente/contribuyentes/{rucReceptor}/validarcomprobante");

                var restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Authorization", $"Bearer {token}");
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", 
                    JsonConvert.SerializeObject(request),
                    ParameterType.RequestBody);

                var result = restClient.Execute(restRequest);
                response.Success = result.IsSuccessful;

                if (result.IsSuccessful)
                    response = JsonConvert.DeserializeObject<ValidacionResponse>(result.Content);
                else
                    response.Message = result.Content;
            }
            catch (Exception ex)
            {
                if (response != null) response.Message = ex.Message;
            }

            return response;

        }

    }
}
