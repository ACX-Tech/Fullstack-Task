namespace SecurityPhraseDetection.Models
{
    public class Message
    {
        public DateTime Timestamp { get; set; }
        public int UserTypeId { get; set; }
        public string Content { get; set; }
    }
}
