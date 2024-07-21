using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Registration : IdNameModel
    {
        [BsonElement("P"), BsonIgnoreIfNull]
        public string PassWord { get; set; }

        [BsonElement("E"), BsonIgnoreIfNull]
        public string Email { get; set; }
        [BsonElement("CP"), Compare("P", ErrorMessage = "Password doesn't match."),BsonIgnoreIfNull,BsonIgnoreIfDefault]
        public string CPassword { get; set; }
    }
}
