using MongoDB.Bson.Serialization.Attributes;

namespace AcidityV3Backend.Models
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonIgnore]
        public string ObjectId { get; set; }
    }
}