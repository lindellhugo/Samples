using System.Threading.Tasks;
using Blazored.LocalStorage;
using SimpleBlazorWASM.Client.Model.Security;

namespace SimpleBlazorWASM.Client
{
    class AuthenticationManager : IAccessTokenProvider
    {
        private readonly ILocalStorageService localStorageService;

        public AuthenticationManager(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var tokenResponse = await localStorageService.GetItemAsync<TokenResponse>(nameof(TokenResponse));
            string token = null;
            if (tokenResponse != null && !tokenResponse.IsExpired)
            {
                token = tokenResponse.AccessToken;
            }

            return token;
        }

        public ValueTask LogoutAsync()
        {
            return localStorageService.RemoveItemAsync(nameof(TokenResponse));
        }
    }
}
