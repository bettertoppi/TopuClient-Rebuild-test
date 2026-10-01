using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TopuClient.Models;

namespace TopuClient.Services
{
    public class ModrinthService
    {
        private readonly HttpClient _httpClient;

        public ModrinthService()
        {
            _httpClient = new HttpClient();
            // Required uniquely-identifying User-Agent format according to Modrinth API Docs
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "TopuOrganization/TopuClient/1.0.0 (contact@topuclient.org)");
        }

        public async Task<ModSearchResponse?> SearchModsAsync(string query, string loader = "fabric", string version = "1.20.1")
        {
            string url = $"https://api.modrinth.com/v2/search?query={query}&facets=[[\"loader:{loader}\"],[\"versions:{version}\"]]";
            try
            {
                return await _httpClient.GetFromJsonAsync<ModSearchResponse>(url);
            }
            catch
            {
                return null;
            }
        }
    }
}
