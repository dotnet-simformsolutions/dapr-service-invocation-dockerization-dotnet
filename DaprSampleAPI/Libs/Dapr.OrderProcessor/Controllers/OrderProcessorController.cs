using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapr.OrderProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProcessorController : ControllerBase
    {

        [HttpPost("/orders")]
        public string Post(Order order)
        {
            Console.WriteLine("Order received : " + order);
            return order.ToString();
        }
    }

    public record Order(string orderId);
}
