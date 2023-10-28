using ApiAddressSearchBackEnd.Models;

namespace ApiAddressSearchBackEnd.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address> GetCepAsync(string cep);
        Task<Address> GetAsync(string cep);
        Task CreateAddressAsync(Address newAddres);
        Task<List<Address>> GetAllAddressAsync();
    }
}
