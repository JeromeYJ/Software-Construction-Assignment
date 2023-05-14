using assignment9.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignment9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        OrderService orderService;
        public OrderController(OrderService o)
        {
            orderService = o;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return orderService.QueryAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order?> GetById(int id)
        {
            return orderService.QueryId(id);
        }

        [HttpGet("QueryByGoodsName/{name}")]
        public ActionResult<List<Order>> GetByName(string name)
        {
            return orderService.QueryName(name);
        }

        [HttpGet("QueryByClientName/{name}")]
        public ActionResult<List<Order>> GetByClient(string name)
        {
            return orderService.QueryClient(name);
        }

        [HttpGet("QueryByPrice/{price}")]
        public ActionResult<List<Order>> GetByPrice(double price)
        {
            return orderService.QueryPrice(price);
        }

        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderService.AddOrder(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        [HttpPut("{id}")]
        public ActionResult PutOrder(int id, Order order)
        {
            try
            {
                if (order.OrderId != id)
                    return BadRequest("It cannot be changed!");
                orderService.ChangeOrder(id, order.Client, order.Details);
            }
            catch (Exception e)
            {
                string errorInfo = e.Message;
                if (e.InnerException != null) 
                    errorInfo = e.InnerException.Message;
                return BadRequest(errorInfo);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id) 
        {
            try
            {
                var result = orderService.QueryId(id);
                if (result == null)
                    return BadRequest("It cannot be deleted!");
                orderService.DeleteOrder(id);
            }
            catch(Exception e)
            {
                string errorInfo = e.Message;
                if (e.InnerException != null)
                    errorInfo = e.InnerException.Message;
                return BadRequest(errorInfo);
            }
            return NoContent();
        }
    };
}