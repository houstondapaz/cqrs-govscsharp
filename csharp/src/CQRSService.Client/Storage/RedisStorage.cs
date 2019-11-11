using StackExchange.Redis;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CQRSService.Client.Storage
{
    public class RedisStorage : IStorage<Client>
    {
        private readonly IDatabaseAsync _database;
        private const string BASE_KEY = "CLIENTS";
        public RedisStorage(IConnectionMultiplexer connectionMultiplexer)
            => _database = connectionMultiplexer.GetDatabase();

        public async Task<IEnumerable<Client>> GetAll()
        {
            var keys = await _database.ExecuteAsync("keys", $"{BASE_KEY}:*");
            var clients = new List<Client>();

            foreach (var key in (RedisKey[])keys)
            {
                var client = await _database.StringGetAsync(key);
                clients.Add(JsonConvert.DeserializeObject<Client>(client));
            }

            return clients;
        }

        public async Task<Client> GetOne(Guid id)
        {
            var client = await _database.StringGetAsync($"{BASE_KEY}:{id}");
            
            if (client == RedisValue.Null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<Client>(client);
        }

        public Task Add(Client entity)
            => _database.StringSetAsync($"{BASE_KEY}:{entity.Id}", JsonConvert.SerializeObject(entity));

        public Task Update(Client entity)
            => _database.StringSetAsync($"{BASE_KEY}:{entity.Id}", JsonConvert.SerializeObject(entity));
    }
}
