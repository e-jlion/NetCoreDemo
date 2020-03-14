using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jlion.NetCore.OrderService.Service.Grpc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overt.Core.Grpc;

namespace Jlion.NetCore.OrderApiService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGrpcClient<OrderService.Service.Grpc.JlionOrderService.JlionOrderServiceClient> _orderService;
        public OrderController(IGrpcClient<OrderService.Service.Grpc.JlionOrderService.JlionOrderServiceClient> orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public string Get()
        {
            return "test";
        }

        [HttpGet("getlist")]
        public async Task<List<OrderRepsonse>> GetList()
        {
            var respData =await _orderService.Client.Order_SearchAsync(new OrderService.Service.Grpc.OrderSearchRequest()
            {
                Name = "test",
                OrderId = "",
            });

            if ((respData?.Data?.Count ?? 0) <= 0)
            {
                return new List<OrderRepsonse>();
            }

            return respData.Data.ToList();
        }
    }
}