using Dapr.Client;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };

            var client = new DaprClientBuilder()
                .UseJsonSerializationOptions(jsonOptions)
                .Build();

            while (true)
            {
                await Task.Delay(1000);
                var messageId = Guid.NewGuid();
                await client.PublishEventAsync(DaprSettings.PubSubName, DaprSettings.Topic, $"{messageId}");
                Console.WriteLine($"Message Id:{messageId}");
            }
        }
    }
}
