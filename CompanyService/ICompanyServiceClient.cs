public interface ICompanyServiceClient
{
    Task<List<string>> GetCompanyNamesAsync();
}