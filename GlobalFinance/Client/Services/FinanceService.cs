using System;
using GlobalFinance.Shared.Models;
namespace GlobalFinance.Client.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly HttpClient httpClient;

        public FinanceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public FinanceModel Finance { get; set; } = new FinanceModel();
    }
}

