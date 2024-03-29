﻿using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IFinanceService
    {
        FinanceModel Finance { get; set; }

        Task<int> AddFinance(FinanceModel finance);
        Task<FinanceModel> GetFinance(int enquiryId);
        Task<int> RemoveFinance(FinanceModel finance);
        Task<int> UpdateFinance(FinanceModel finance);
    }
}