using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleBlazorWASM.Client
{
    class TokenBasedAuthenticationHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider accessTokenProvider;

        public TokenBasedAuthenticationHandler(HttpMessageHandler inner, IAccessTokenProvider accessTokenProvider)
            : base(inner)
        {
            this.accessTokenProvider = accessTokenProvider;
        }

        public TokenBasedAuthenticationHandler(IAccessTokenProvider accessTokenProvider)
            : base()
        {
            this.accessTokenProvider = accessTokenProvider;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await accessTokenProvider.GetAccessTokenAsync();

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
