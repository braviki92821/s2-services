using Amazon.Runtime;
using Amazon.Runtime.SharedInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using s2_services.models;
using s2_services.Models;
using s2_services.Models.DataTransfer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace s2_services.repository
{
    public class userService
    {
        private readonly IMongoCollection<userBson> usersColl;
        private readonly IMongoCollection<userTransfer> userColl;
        private readonly IMongoCollection<token> tokenColl;
        private readonly IMongoCollection<tokenBson> tokensColl;
        IOptions<Jwt> _configuration;

        public userService(IOptions<MongoConnectionAuth> mongoconnection, IOptions<Jwt> configuration)
        {
            var mongoClient = new MongoClient(mongoconnection.Value.ConnectionString);
            var mongoDatabaseusers = mongoClient.GetDatabase(mongoconnection.Value.DataBaseName);
            usersColl = mongoDatabaseusers.GetCollection<userBson>(mongoconnection.Value.UsersCollectionName);
            userColl = mongoDatabaseusers.GetCollection<userTransfer>(mongoconnection.Value.UsersCollectionName);
            tokenColl = mongoDatabaseusers.GetCollection<token>(mongoconnection.Value.TokensCollectionName);
            tokensColl = mongoDatabaseusers.GetCollection<tokenBson>(mongoconnection.Value.TokensCollectionName);
            _configuration = configuration;
        }

        public async Task<userBson> GetUsuario(string nombre, string password)
        {
            var filter = Builders<userBson>.Filter;
            var filterDefinition = filter.And(filter.StringIn("Username", nombre), filter.StringIn("Password", password));
            return await usersColl.FindAsync(filterDefinition).Result.FirstOrDefaultAsync();
        }

        public userTransfer RegistrarUsuario(userTransfer users)
        {
            userColl.InsertOne(users);
            return users;
        }

        public List<userBson> obtenerUsuarios()
        {
            return usersColl.FindAsync(new BsonDocument()).Result.ToList();
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public JwtSecurityToken token(List<Claim> authClaims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Value.key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expire = DateTime.Now.AddSeconds(180);
            var token = new JwtSecurityToken(_configuration.Value.Issuer,
                _configuration.Value.Audience,
                authClaims,
                expires: expire,
                signingCredentials: singIn
               );

            return token;
        }

        public token InsertarToken(token tokens)
        {
            tokenColl.InsertOne(tokens);
            return tokens;
        }

        public async Task<bool> esTokenActivo(string token)
        {
            bool activo = false;
            var filter = Builders<tokenBson>.Filter;
            var filterDefinition = filter.And(filter.StringIn("Access_token", token));
            var _token = await tokensColl.FindAsync(filterDefinition).Result.FirstOrDefaultAsync();

            if (_token == null)
            {
                activo = false;
            }
            else if (token == _token.Access_token && DateTime.Now > _token.Expires_in)
            {
                activo = false;
            }
            else if (token == _token.Access_token && DateTime.Now < _token.Expires_in)
            {
                activo = true;
            }
            return activo;
        }

    }
}
