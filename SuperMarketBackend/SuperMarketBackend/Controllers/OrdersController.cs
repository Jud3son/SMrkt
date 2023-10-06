using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarketBackend.Data;
using SuperMarketBackend.DTO;
using SuperMarketBackend.Services;

namespace SuperMarketBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly OrderServices _orderServices;
        public OrdersController(IMapper mapper)
        {
            _orderServices = new ();
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder(OrderDTO order)
        {            
            var data = _orderServices.AddOrder(_mapper.Map<Order>(order));
            if(data !=null)
                return Ok(data);
            else
                return BadRequest(new OrderDTO { OrderId = -1 });
        }

        [HttpGet]
        [Route("GetOrder/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var data = _orderServices.GetOrderDetails(id);
            if (data != null)
                return Ok(data);
            else
                return BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrder()
        {
            var data = _orderServices.GetOrders();
            if (data != null)
                return Ok(data);
            else
                return BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var data = _orderServices.DeleteOrder(id);
            if (data)
                return Ok(data);
            else 
                return NotFound();
        }

        [HttpPost]
        [Route("ChangeOrderStatus")]
        public async Task<IActionResult> ChangeStatus(OrderDTO order)
        {
            var data = _orderServices.ChangeOrderStatus(order.OrderId,order.Status);
            if (data)
                return Ok(data);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetInvoiceNo")]

        public async Task<IActionResult> GetInvNo()
        {
            var data = _orderServices.GetInvNo();
            return Ok(data);
        }

    }
}
