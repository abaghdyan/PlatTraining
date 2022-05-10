﻿using Microsoft.EntityFrameworkCore;
using PlatTraining.Dal.Entities;
using PlatTraining.Services.Contracts;
using PlatTraining.TenantData;

namespace PlatTraining.Services.Impl
{
    public class PlatIndexService : IPlatIndexService
    {
        private readonly PlatTenantDbContext _dbContext;
        private readonly string _guid;
        public PlatIndexService(PlatTenantDbContext dbContext)
        {
            _dbContext = dbContext;
            _guid = Guid.NewGuid().ToString();
        }

        public async Task<List<PlatIndex>> GetPlatIndixes()
        {
            return await _dbContext.Indexes.ToListAsync();
        }

        public async Task<PlatIndex> GetPlatIndixeById(int id)
        {
            return await _dbContext.Indexes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public string GetGuid()
        {
            return _guid;
        }
    }
}