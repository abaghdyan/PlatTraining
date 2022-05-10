﻿using PlatTraining.Data.Entities.Tenant;

namespace PlatTraining.Services.Contracts
{
    public interface ISomeTenantDataService
    {
        Task<List<SomeTenantData>> GetAllDataAsync();
        Task<SomeTenantData> GetDataByIdAsync(int id);
        string GetGuid();
    }
}
