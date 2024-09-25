using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Dapr.SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceInvocation : ControllerBase
    {
        //string baseURL = (Environment.GetEnvironmentVariable("BASE_URL") ?? "http://localhost") + ":" + (Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3501");
        string baseURL = "http://host.docker.internal:3501";
        [HttpGet]
        [Route("saveOrder")]
        public async Task<dynamic> SaveOrder(string value)
        {


            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            // Adding app id as part of the header
            client.DefaultRequestHeaders.Add("dapr-app-id", "order-processor");

            var order = new Order(value);
            var orderJson = JsonSerializer.Serialize<Order>(order);
            var content = new StringContent(orderJson, Encoding.UTF8, "application/json");

            Console.WriteLine("Http Url : " + $"{baseURL}/orders");
            // Invoking a service
            var response = await client.PostAsync($"{baseURL}/orders", content);
            return response;       
        }

        public record Order(
            [property: JsonPropertyName("orderId")] string OrderId
            );
    }
}
