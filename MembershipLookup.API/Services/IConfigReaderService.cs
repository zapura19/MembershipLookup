namespace MembershipLookup.API.Services
{
    public interface IConfigReaderService
    {
        string GetConfigValue(string keyName);
    }
}
