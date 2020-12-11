using Dapr.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var appId = "api";
            var methodName = "neworder";
            
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };

            var client = new DaprClientBuilder()
                .UseJsonSerializationOptions(jsonOptions)
                .Build();

            var orderId = 0;
            while(true)
            {
                await Task.Delay(1000);
                var order = new { orderId = orderId };
                await client.InvokeMethodAsync(appId, methodName, order );
                Console.WriteLine($"OrderId:{order.orderId}");
                orderId += 1;
            }
        }
    }
}
