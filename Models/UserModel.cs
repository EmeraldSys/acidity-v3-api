#nullable enable
using MongoDB.Bson.Serialization.Attributes;

namespace AcidityV3Backend.Models
{
    public class UserModel
    {
        [BsonId]
        public string? ObjectId { get; set; }
        [BsonElement("username")]
        public string? Username { get; set; }
        [BsonElement("active")]
        public bool? Active { get; set; }
        [BsonElement("admin")]
        public bool? Admin { get; set; }
        [BsonElement("key")]
        public string? Key { get; set; }
        [BsonElement("swFingerprint")]
        public string? SwFingerprint { get; set; }
        [BsonElement("synFingerprint")]
        public string? SynFingerprint { get; set; }
    }
}