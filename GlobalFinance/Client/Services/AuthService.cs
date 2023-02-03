using System;
using System.Net.Http.Json;
namespace GlobalFinance.Client.Services
{
	public class AuthService
	{
        private readonly HttpClient httpClient;

        public AuthService(HttpClient httpClient)
		{
            this.httpClient = httpClient;
        }

        
	}
}

