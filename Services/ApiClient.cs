using System.Runtime.Caching;
using Ticketek.Models;

namespace Ticketek.Services;

public class ApiClient
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static readonly MemoryCache cache = new MemoryCache("apiResponse");

    public async Task<T> GetApi<T>(string apiUrl)
    {
        if (cache.Contains(apiUrl))
        {
            return (T)cache.Get(apiUrl);
        }
        else
        {
            var apiResponse = await httpClient.GetAsync(apiUrl);
            if(apiResponse.IsSuccessStatusCode)
            {
                T jsonToModel = await apiResponse?.Content?.ReadFromJsonAsync<T>();
                _ = cache.Add(apiUrl, jsonToModel, DateTimeOffset.Now.AddMinutes(5));
                return jsonToModel;
            }
            else
            {
                throw new Exception("Failed API call");
            }
        }
    }
}
    
