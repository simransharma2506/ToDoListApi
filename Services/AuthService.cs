using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using ToDoList.DBModels;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class AuthService
    {
        private readonly IMongoCollection<Registration> _regDb;
        private readonly string key;
        public AuthService(IOptions<DBConfigration> dbconfig, IConfiguration configuration)
        {
            var mongoclient = new MongoClient(dbconfig.Value.ConnectionString);
            var mongoDatabase = mongoclient.GetDatabase(dbconfig.Value.Database);
            _regDb = mongoDatabase.GetCollection<Registration>("Login");
            this.key = configuration.GetSection("JwtKey").ToString();
        }

        public async Task<Registration> SaveUserInfo(string id, Registration model)
        {
            Registration registration;

            try
            {
                if (!id.IsNullOrEmpty())
                   registration = await _regDb.Aggregate().Match(i => i.Id == id).FirstOrDefaultAsync();
                else
                   registration = new Registration();
                registration.Id = id == null ? ObjectId.GenerateNewId().ToString() : model.Id;
                registration.Name = model.Name;
                registration.Email = model.Email;
                registration.PassWord = model.PassWord;
                registration.CPassword = model.CPassword;
                if (id.IsNullOrEmpty())
                {
                    await _regDb.InsertOneAsync(registration);
                }
                else
                {
                    await _regDb.ReplaceOneAsync(i => i.Id == id,registration);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return registration;

        }
    }
}
