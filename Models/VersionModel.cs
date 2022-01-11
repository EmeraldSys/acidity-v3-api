#nullable enable
using MongoDB.Bson.Serialization.Attributes;

namespace AcidityV3Backend.Models
{
    public class VersionModel
    {
        [BsonElement("version")]
        public string? Version { get; set; }
        [BsonElement("latestPre")]
        public bool? LatestPre { get; set; }
        [BsonElement("latestStable")]
        public bool? LatestStable { get; set; }
    }
}