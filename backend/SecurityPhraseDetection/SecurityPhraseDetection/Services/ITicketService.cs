using SecurityPhraseDetection.Models;

namespace SecurityPhraseDetection.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<User>> GetProcessedUsersWithConversationsAsync();
    }
}
