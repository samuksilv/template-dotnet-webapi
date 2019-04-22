using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using template.API;
using template.IntegrationTest.Feature;
using Xunit;

namespace template.IntegrationTest.Scenaries {
    public class ValuesControllerIntegrationTest : IClassFixture<AppFactory<Startup>>{

        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Startup> _factory;

        public ValuesControllerIntegrationTest (AppFactory<Startup> factory) {            
            this._factory= factory;
            this._client= this._factory.CreateClient();
        }

        [Fact]
        public async Task CanGetValues () {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync ("/api/template/value");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode ();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync ();
            var values = JsonConvert.DeserializeObject (stringResponse);
            Assert.NotNull (values);
        }
    }
}