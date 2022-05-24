using AzsWebApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AzsWebApi.Tests
{
    public class StationsTests
    {
        private readonly WebApplicationFactory<Program> _application;
        private readonly HttpClient _client;

        public StationsTests()
        {
            _application = new();
            _client = _application.CreateClient();
        }

        [Test]
        public async Task GetStationsByFuel()
        {
            var stations = await _client.GetFromJsonAsync<List<object>>($"/stations?fuel=95");
            Assert.IsNotNull(stations);
            Assert.IsNotEmpty(stations);
        }

        [Test]
        public async Task GetStationById()
        {
            var station = await _client.GetFromJsonAsync<object>($"/getStationInfo?id=1");
            Assert.IsNotNull(station);
        }

        [Test]
        public async Task SetStation()
        {
            var station = new Station
            {
                Station_ID = 99, 
                Address = "Тестовый адрес",
                Data = new List<Data>()
                {
                    new Data
                    {
                        Name = "92",
                        Price = 92,
                        AmountOfFuel = 92
                    },
                    new Data
                    {
                        Name = "95",
                        Price = 95,
                        AmountOfFuel = 95
                    },
                    new Data
                    {
                        Name = "98",
                        Price = 98,
                        AmountOfFuel = 98
                    },
                    new Data
                    {
                        Name = "Disel Fuel",
                        Price = 'D' + 'F',
                        AmountOfFuel = 'D' + 'F',
                    },
                }
            };

            using (var message = new HttpRequestMessage 
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("/setStation", UriKind.Relative),
                Content = new StringContent(JsonSerializer.Serialize(station), Encoding.UTF8, "application/json")
            })
            {
                var response = await _client.SendAsync(message);
                Assert.IsTrue(response.IsSuccessStatusCode);
            }
        }
    }
}