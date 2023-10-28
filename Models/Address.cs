using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ApiAddressSearchBackEnd.Models
{
    public partial record Address
    {
        [GeneratedRegex("[^0-9a-zA-Z]")]
        private static partial Regex MyRegex();

        private string _cep;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;


        [JsonPropertyName("cep")]
        public string Cep
        {
            get => _cep;
            set => _cep = MyRegex().Replace(value, "");
        }


        [JsonPropertyName("logradouro")]
        [BsonElement("Logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        [JsonPropertyName("complemento")]
        [BsonElement("Complemento")]
        public string Complemento { get; set; } = string.Empty;

        [JsonPropertyName("bairro")]
        [BsonElement("Bairro")]
        public string Bairro { get; set; } = string.Empty;

        [JsonPropertyName("localidade")]
        [BsonElement("Localidade")]
        public string Localidade { get; set; } = string.Empty;

        [JsonPropertyName("uf")]
        [BsonElement("Uf")]
        public string Uf { get; set; } = string.Empty;

        [JsonPropertyName("ibge")]
        [BsonElement("Ibge")]
        public string Ibge { get; set; } = string.Empty;

        [JsonPropertyName("gia")]
        [BsonElement("Gia")]
        public string Gia { get; set; } = string.Empty;

        [JsonPropertyName("ddd")]
        [BsonElement("Ddd")]
        public string Ddd { get; set; } = string.Empty;

        [JsonPropertyName("siafi")]
        [BsonElement("Siafi")]
        public string Siafi { get; set; } = string.Empty;

        public Address(string id, string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string ddd, string siafi)
        {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Ibge = ibge;
            Gia = gia;
            Ddd = ddd;
            Siafi = siafi;
        }

        public Address()
        {
        }
    }
}
