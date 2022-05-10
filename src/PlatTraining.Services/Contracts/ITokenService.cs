namespace PlatTraining.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateAccessToken(string userName, string tenantId);
    }
}
