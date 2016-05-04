using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ErickOrlando.FirmadoSunat
{
    public class PasswordDigestBehavior : IEndpointBehavior
    {

        public string Usuario { get; set; }
        public string Password { get; set; }

        public PasswordDigestBehavior(string username, string password)
        {
            Usuario = username;
            Password = password;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new PasswordDigestMessageInspector(Usuario, Password));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            return;
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            // Todo bien.
            return;
        }
    }
}
