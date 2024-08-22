namespace SecurityPhraseDetection.Models
{
    public class ConversationModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ConversationId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public List<MessageModel> Messages { get; set; }
    }
}
