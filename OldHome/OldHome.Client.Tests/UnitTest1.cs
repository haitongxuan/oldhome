using OldHome.DesktopApp.Services;
using OldHome.DTO;

namespace OldHome.Client.Tests
{
    public class Tests
    {
        IApiClient _api;
        [SetUp]
        public void Setup()
        {
            var client = new HttpClient() { BaseAddress = new Uri("http://localhost:5185") };
        }

        [Test]
        public async Task Test1()
        {
            var users = await _api.GetAsync<List<UserDto>>("/users");
        }

        [Test]
        public async Task Test2()
        {
        }
    }
}