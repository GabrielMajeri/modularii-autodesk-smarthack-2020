using System;
using Autodesk.Forge;
using Microsoft.Extensions.Configuration;

namespace SmartCityPlanner
{
    /// Helper class for accessing the Autodesk Forge APIs.
    public class ForgeService
    {
        private IConfiguration _configuration;
        private readonly TwoLeggedApi _client = new TwoLeggedApi();

        public string PublicToken { get; }

        public ForgeService(IConfiguration configuration)
        {
            _configuration = configuration;
            PublicToken = GetAuthToken(new Scope[] { Scope.ViewablesRead });
        }

        private string GetAuthToken(Scope[] scopes)
        {
            var forge = _configuration.GetSection("Forge");
            var clientId = forge.GetValue<string>("ClientId");
            var clientSecret = forge.GetValue<string>("ClientSecret");

            var bearer = _client.AuthenticateWithHttpInfo(clientId, clientSecret, "client_credentials", scopes);

            if (bearer.StatusCode != 200)
            {
                throw new Exception("Failed to authenticate with Forge");
            }

            return bearer.Data.access_token;
        }
    }
}
