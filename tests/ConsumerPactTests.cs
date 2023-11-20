using System.IO;
using Xunit;
using Xunit.Abstractions;
using Consumer;
using PactNet;
using PactNet.Output.Xunit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Text.Json;

namespace tests
{
    public class ConsumerPactTests
    {
        private IPactBuilderV3 pact;
        private string id = "8c36e86c-13b9-4102-a44f-646015dfd981";

        public ConsumerPactTests(ITestOutputHelper output)
        {
            // Configure pact mock server
        }

        [Fact]
        public async Task ItFindsAnExistingUser()
        {
            // Given
            // Setup stub

            // When
            // Start pact mock server
            // Create api with mockserver backend
            // call api
            // Then
            // assert            
        }

        [Fact]
        public async Task ItCannotFindUnExistingUser()
        {
            
            // Given, when, then
        }

        [Fact]
        public async Task ItCanCreateAnUser()
        {
            // Given, when, then
        }
    }
}
