namespace SecurityPhraseDetection.Models
{
    public class Conversation
    {
        public string ConversationId { get; set; }
        public string Title { get; set; }
        public List<Message> Messages { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
    }
}
