using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using ToDoList.DBModels;

namespace ToDoList.Models
{
    public class Login : IdNameModel
    {
        [BsonElement("P"),BsonIgnoreIfNull]
        public string PassWord { get; set; }

        [BsonElement("E"), BsonIgnoreIfNull]
        public string Email { get; set; }
    }

    public partial class LoginDB
    {
        private readonly IMongoCollection<Registration> _regDb;
        private readonly string key;
        public LoginDB(IOptions<DBConfigration> dbconfig, IConfiguration configuration)
        {
            var mongoclient = new MongoClient(dbconfig.Value.ConnectionString);
            var mongoDatabase = mongoclient.GetDatabase(dbconfig.Value.Database);
            _regDb = mongoDatabase.GetCollection<Registration>("Login");
            this.key = configuration.GetSection("JwtKey").ToString();
        }

    }
}
