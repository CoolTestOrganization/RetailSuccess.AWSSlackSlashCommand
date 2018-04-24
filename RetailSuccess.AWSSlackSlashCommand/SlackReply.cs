using Newtonsoft.Json;
using System.Collections.Generic;

namespace RetailSuccess.AWSSlackSlashCommand
{
    public sealed class SlackReply
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public List<Dictionary<string, string>> Attachments { get; set; }
    }
}
