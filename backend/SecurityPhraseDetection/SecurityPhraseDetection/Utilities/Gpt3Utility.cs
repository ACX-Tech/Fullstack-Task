using System.Text;
using Newtonsoft.Json;

namespace SecurityPhraseDetection.Utilities
{
    public class Gpt3Utility
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public Gpt3Utility(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<Dictionary<string, string>> DetectSecurityPhrasesAsync(string combinedText)
        {
            var prompt = $"Detect any security issues in the following conversations and map them to concise action words. Return a JSON object where the keys are conversation IDs, and the values are the corresponding action words:\n\n{combinedText}";

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                max_tokens = 300 // Adjust based on your need
            };

            var jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to connect to GPT-3.5 API: " + response.ReasonPhrase);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Gpt3Response>(responseContent);

            var detectedPhrases = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.choices[0].message.content);

            return detectedPhrases;
        }
    }

    // Existing classes for handling the GPT-3.5 response
    public class Gpt3Response
    {
        public List<Gpt3Choice> choices { get; set; }
    }

    public class Gpt3Choice
    {
        public Gpt3Message message { get; set; }
    }

    public class Gpt3Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
