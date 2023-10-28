using ApiAddressSearchBackEnd.Errors;
using ApiAddressSearchBackEnd.Models;
using ApiAddressSearchBackEnd.Providers.Interfaces;
using ApiAddressSearchBackEnd.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Net.Http;
using System.Text.Json;

namespace ApiAddressSearchBackEnd.Services
{
    public class AddressService : IAddressService
    {
        private readonly IHttpClient _httpClient;
        private readonly IMongoCollection<Address> _addressCollections;
        public AddressService(IHttpClient httpClient, IOptions<MongoDbConfiguration> options)
        {
            _httpClient = httpClient;
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            _addressCollections = mongoDatabase.GetCollection<Address>(options.Value.CepsCollectionName);
        }

        public async Task<Address> GetCepAsync(string cep)
        {
            var responseDb = await GetAsync(cep).ConfigureAwait(false);
            if (responseDb != null)
                return responseDb;

            // Obtém resposta do serviço externo
            var response = await _httpClient.GetCepAsync(cep).ConfigureAwait(false);

            // Deserializa a resposta do serviço externo com o JsonSerializerOptions.PropertyNameCaseInsensitive
            var newCep = JsonSerializer.Deserialize<Address>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            await CreateAddressAsync(newCep).ConfigureAwait(false);
            return newCep;
        }
        public async Task<List<Address>> GetAllAddressAsync()
        {
            var allAddressFound = await _addressCollections
                .Find(_ => true)
                .ToListAsync()
                .ConfigureAwait(false);

            if (!allAddressFound.Any())
                throw new RequestException(new RequestError
                {
                    Message = "Não há endereços cadastrados!",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });

            return allAddressFound;
        }

        public async Task<Address> GetAsync(string cep) =>
          await _addressCollections
           .Find(x => x.Cep.ToLower().Contains(cep.ToLower()))
           .FirstOrDefaultAsync()
           .ConfigureAwait(false);

        public async Task CreateAddressAsync(Address newAddress) =>
            await _addressCollections.InsertOneAsync(newAddress);

    }
}
