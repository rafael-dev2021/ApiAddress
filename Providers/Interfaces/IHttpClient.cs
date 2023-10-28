namespace ApiAddressSearchBackEnd.Providers.Interfaces
{
    public interface IHttpClient
    {
        Task<string> GetCepAsync(string url);
    }
}
