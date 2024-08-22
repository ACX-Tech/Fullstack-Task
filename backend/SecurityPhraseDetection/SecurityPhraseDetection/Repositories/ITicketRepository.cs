using SecurityPhraseDetection.Models;

namespace SecurityPhraseDetection.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<User>> GetUsersWithConversationsAsync();
    }
}
