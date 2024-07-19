using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Registration : Login
    {
        [BsonElement("CP"), Compare("P", ErrorMessage = "Password doesn't match."),BsonIgnoreIfNull,BsonIgnoreIfDefault]
        public string CPassword { get; set; }
    }
}
