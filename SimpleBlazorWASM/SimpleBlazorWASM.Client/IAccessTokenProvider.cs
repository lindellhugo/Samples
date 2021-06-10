using System.Threading.Tasks;

namespace SimpleBlazorWASM.Client
{
    interface IAccessTokenProvider
    {
        Task<string> GetAccessTokenAsync();
    }
}
