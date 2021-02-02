using Alba;
using blackstore_firebase_api.Configuration;
using blackstore_firebase_api.Entity;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MisTests
{
    public class TestProducts : IClassFixture<ApiBlacksFixxture>
    {
        private readonly SystemUnderTest _system;
        
        public TestProducts(ApiBlacksFixxture app)
        {
            _system = app.systemUnderTest;
        }


        [Fact]
        public async Task Very_GetAll()
        {
            var results = await _system.GetAsJson<IList<Product>>("/api");
            results.Count.Should().Be(27);
        }
        [Fact]
        public async Task TestGetAll_Ok()
        {
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/api");
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }

        [Fact]
        public async Task TestCreateTable_Ok()
        {
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/api/CreateTable");
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }

        [Fact]
        public async Task TestDetailProduct_Ok()
        {
            String[] Nids = { "MCO557060514", "MCO471422802", "MCO564823319" };
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(0, 2);
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/api/item/"+Nids[value]);
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }

        [Fact]
        public async Task TestSearch_Ok()
        {
            String[] Nproducts = {"televisor", "Nevera", "mouse"};
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(0, 2);
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/api/search"+ "?q="+Nproducts[value]);
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }

        [Fact]
        public async Task TestSearch_Cantidad()
        {
            var results = await _system.GetAsJson<IList<Result>>("/api/search?q=televisor");
            results.Count.Should().Be(11);

        }

        [Fact]
        public async Task TestDelete_Ok()
        {
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/api/item/MCO481504317");
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }

       
    }
}
        