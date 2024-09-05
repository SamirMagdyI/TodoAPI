using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using TodoAPI.Dtos;

namespace TodoAPI.Services
{
    public class ExternalTodoService : IExternalTodoService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/todos";
        private readonly HttpClient _httpClient;

        public ExternalTodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TodoDto>> FetchTodosAsync(int page = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?_page={page}&_limit={pageSize}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TodoDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
