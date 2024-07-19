using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoList.Models
{
    public class IdModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
    public class IdNameModel : IdModel
    {
        [BsonIgnoreIfDefault,BsonIgnoreIfNull]
        public string Name { get; set; }
    }
}
