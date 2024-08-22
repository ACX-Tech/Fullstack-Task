using SecurityPhraseDetection.Models;
using SecurityPhraseDetection.Repositories;
using SecurityPhraseDetection.Utilities;
using System.Text;

namespace SecurityPhraseDetection.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly Gpt3Utility _gpt3Utility;

        public TicketService(ITicketRepository ticketRepository, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _ticketRepository = ticketRepository;
            var apiKey = configuration["OpenAI:ApiKey"];
            _gpt3Utility = new Gpt3Utility(httpClientFactory.CreateClient(), apiKey);
        }

        public async Task<IEnumerable<User>> GetProcessedUsersWithConversationsAsync()
        {
            var users = await _ticketRepository.GetUsersWithConversationsAsync();
            var conversationMap = new Dictionary<string, Conversation>();

            var combinedText = BuildCombinedConversationText(users, conversationMap);

            var detectedPhrases = await _gpt3Utility.DetectSecurityPhrasesAsync(combinedText);

            ApplyDetectedPhrasesToConversations(conversationMap, detectedPhrases);

            return users;
        }

        private string BuildCombinedConversationText(IEnumerable<User> users, Dictionary<string, Conversation> conversationMap)
        {
            var sb = new StringBuilder();

            foreach (var user in users)
            {
                foreach (var conversation in user.Conversations)
                {
                    var conversationId = conversation.ConversationId;
                    var conversationText = BuildConversationText(conversation.Messages);

                    // Map conversation ID to conversation object
                    conversationMap[conversationId] = conversation;

                    // Append conversation ID and text to combined text
                    sb.AppendLine($"Conversation ID: {conversationId}");
                    sb.AppendLine(conversationText);
                    sb.AppendLine(); // Separate conversations with a new line
                }
            }

            return sb.ToString();
        }

        private string BuildConversationText(IEnumerable<Message> messages)
        {
            var sb = new StringBuilder();
            foreach (var message in messages)
            {
                sb.AppendLine(message.Content);
            }
            return sb.ToString();
        }

        private void ApplyDetectedPhrasesToConversations(Dictionary<string, Conversation> conversationMap, Dictionary<string, string> detectedPhrases)
        {
            foreach (var detectedPhrase in detectedPhrases)
            {
                var conversationId = detectedPhrase.Key;
                var actionWord = detectedPhrase.Value;

                if (conversationMap.ContainsKey(conversationId))
                {
                    var conversation = conversationMap[conversationId];
                    conversation.Messages.Add(new Message
                    {
                        Timestamp = DateTime.UtcNow,
                        UserTypeId = 2, // System message or summary
                        Content = $"Detected Security Issue: {actionWord}"
                    });
                }
            }
        }
    }
}
