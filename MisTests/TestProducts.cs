using Alba;
using blackstore_firebase_api.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    }
}
