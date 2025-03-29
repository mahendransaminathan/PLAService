

using System.Text.Json;
using Newtonsoft.Json;
namespace PLAService.CompanyServices
{
    public class CompanyServiceClient : ICompanyServiceClient
    {
        private readonly HttpClient mHttpClient;

        public CompanyServiceClient(HttpClient httpClient)
        {
            mHttpClient = httpClient;
        }

        public async Task<List<string>> GetCompanyNamesAsync()
        {
            HttpResponseMessage response = await mHttpClient.GetAsync("api/company/names");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<List<string>>(json, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver { NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy() } }) ?? new List<string>();

            }
            else
            {
                throw new HttpRequestException($"Failed to get company names. Status code: {response.StatusCode}");

            }
        }
    }
}