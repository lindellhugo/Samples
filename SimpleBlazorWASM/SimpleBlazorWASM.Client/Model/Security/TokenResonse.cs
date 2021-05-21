using System;

namespace SimpleBlazorWASM.Client.Model.Security
{
    public class TokenResponse
    {
        public TokenResponse()
        {
            Created = DateTime.UtcNow;
        }


        public DateTime Created { get; set; }

        public bool IsExpired => DateTime.UtcNow > Created.AddSeconds(ExpiresIn);

        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
    }
}
