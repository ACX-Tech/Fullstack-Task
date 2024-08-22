using Newtonsoft.Json;
using SecurityPhraseDetection.Models;

namespace SecurityPhraseDetection.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly HttpClient _httpClient;

        public TicketRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetUsersWithConversationsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://goruen.free.beeceptor.com/tickets-history");
            var users = JsonConvert.DeserializeObject<ResponseWrapper>(response).Users;
            return users;
        }
    }

    // Wrapper class for deserializing the JSON response
    public class ResponseWrapper
    {
        public List<User> Users { get; set; }
    }
}
