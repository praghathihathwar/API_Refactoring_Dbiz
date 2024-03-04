using LegacyApp.Api;
using LegacyApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
namespace API_Refactor.Tests
{
    public class UserControllerTestCase : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public UserControllerTestCase(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            
        }
        [Fact]
        public async Task CreateUser_ReturnsCreatedUser()
        {
            var clientFactory = _factory.CreateClient();

            var client = new Client
            {
                Id = 1,
                Name = "VeryImportantClient",
                ClientStatus = ClientStatus.Gold,
            };

            var user = new User
            {
                Client = client,
                DateOfBirth = DateTime.Parse("1992-08-22T22:07:45.772Z"),
                EmailAddress = "pragathi.hathwar@gmail.com",
                Firstname = "Pragathi",
                Surname = "Hathwar"
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await clientFactory.PostAsync("/Users", content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<User>(responseContent); // Assuming User is the type returned by your API

            // Additional assertions based on the expected behavior
            Assert.Equal(user.Firstname, createdUser.Firstname);
            Assert.Equal(user.Surname, createdUser.Surname);
            Assert.Equal(user.EmailAddress, createdUser.EmailAddress);

        }
    }
}