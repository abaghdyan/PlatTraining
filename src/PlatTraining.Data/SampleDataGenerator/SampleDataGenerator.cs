using PlatTraining.Data.Helpers;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.SampleDataGenerator
{
    public static class SampleDataGenerator
    {
        public static List<Tenant> GenerateTenants(string encryptionKey)
        {
            return new List<Tenant>()
            {
                new Tenant()
                {
                    Id = "88",
                    Name = "88tenant",
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    Data = "TestData88",
                    IsDeleted = false,
                    Status = "Real",
                    TenantConnectionInfo = new TenantConnectionInfo()
                    {
                        Id = "88",
                        TenantId = "88",
                        DataSource = SecurityHelper.Encrypt(encryptionKey, "(localdb)\\MSSQLLocalDB"),
                        InitialCatalog = SecurityHelper.Encrypt(encryptionKey, "88tenant"),
                        UserId = SecurityHelper.Encrypt(encryptionKey, ""),
                        Password = SecurityHelper.Encrypt(encryptionKey, ""),
                        LoadBalanceTimeoutInSec = 500,
                        Pooling = true,
                        MinPoolSize = 0,
                        MaxPoolSize = 100
                    }
                },
                new Tenant()
                {
                    Id = "99",
                    Name = "99tenant",
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    Data = "TestData99",
                    IsDeleted = false,
                    Status = "Test",
                    TenantConnectionInfo = new TenantConnectionInfo()
                    {
                        Id = "99",
                        TenantId = "99",
                        DataSource = SecurityHelper.Encrypt(encryptionKey, "(localdb)\\MSSQLLocalDB"),
                        InitialCatalog = SecurityHelper.Encrypt(encryptionKey, "99tenant"),
                        UserId = SecurityHelper.Encrypt(encryptionKey, ""),
                        Password = SecurityHelper.Encrypt(encryptionKey, ""),
                        LoadBalanceTimeoutInSec = 500,
                        Pooling = true,
                        MinPoolSize = 0,
                        MaxPoolSize = 100,
                    }
                },
            };
        }
    }
}
