using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoList.Models
{
    public class Login : IdNameModel
    {
        [BsonElement("P"),BsonIgnoreIfNull]
        public string PassWord { get; set; }
    }
}
