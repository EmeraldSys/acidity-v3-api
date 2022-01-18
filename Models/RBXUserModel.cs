using System;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
#nullable enable

namespace AcidityV3Backend.Models
{
    public class RBXUserModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; } = "";
        [JsonPropertyName("created")]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("isBanned")]
        public bool Banned { get; set; } = false;
        [JsonPropertyName("externalAppDisplayName")]
        public string? ExternalAppDisplayName { get; set; }
    }
}
