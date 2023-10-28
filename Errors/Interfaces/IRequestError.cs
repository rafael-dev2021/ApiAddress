﻿using System.Net;

namespace ApiAddressSearchBackEnd.Errors.Interfaces
{
    public interface IRequestError
    {
        public string? Name { get; set; }
        public string? Severity { get; set; }
        public bool? Response { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
