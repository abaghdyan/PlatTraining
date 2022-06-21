using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlatTraining.Data.Models;

namespace PlatTraining.Controllers
{
    [Authorize]
    [ApiController]
    public class TenantControllerBase : ControllerBase
    {
        protected readonly TenantInfo tenantInfo;

        protected TenantControllerBase(TenantInfo tenantInfo)
        {
            if (!tenantInfo.Initilized)
            {
                throw new ApplicationException($"{nameof(TenantInfo)} is not initilized.");
            }
            this.tenantInfo = tenantInfo;
        }
    }
}
