using CQRSService.Client.Storage;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSService.Client
{
    [TestFixture]
    public class RedisStorageTest
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly Client _client;

        public RedisStorageTest()
        {
            _redisConnection = ConnectionMultiplexer.Connect("localhost");

            _client = new Client("teste");
            _redisConnection.GetDatabase().StringSet($"CLIENTS:{_client.Id}", Newtonsoft.Json.JsonConvert.SerializeObject(_client));
        }

        [TearDown]
        public void Dispose()
        {
            _redisConnection.GetDatabase().KeyDelete($"CLIENTS:{_client.Id}");
        }

        [Test(Description = "On getAll should return all itens")]
        public async Task getAll_returnAllItens()
        {
            var storage = new RedisStorage(_redisConnection);
            var clients = await storage.GetAll();
            Assert.AreEqual(1, clients.Count());
        }

        [Test(Description = "On getOne should return item with specified id")]
        public async Task getOne_returnSpecifiedId()
        {
            var storage = new RedisStorage(_redisConnection);
            var client = await storage.GetOne(_client.Id);
            Assert.AreEqual(client.Id, _client.Id);
        }
    }
}