#nullable enable
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AcidityV3Backend.Models
{
    public class VersionModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("version")]
        public string? Version { get; set; }
        [BsonElement("hash")]
        public string? Hash { get; set; }
        [BsonElement("latestPre")]
        public bool? LatestPre { get; set; }
        [BsonElement("latestStable")]
        public bool? LatestStable { get; set; }
    }
}