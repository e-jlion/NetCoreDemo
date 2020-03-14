using Grpc.Core;
using Jlion.NetCore.OrderService.Service.Grpc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static Jlion.NetCore.OrderService.Service.Grpc.JlionOrderService;

namespace Jlion.NetCore.OrderService.Service.Impls
{
    public partial class JlionOrderServiceImpl : JlionOrderServiceBase
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public JlionOrderServiceImpl(ILogger<JlionOrderServiceImpl> logger, IServiceProvider provider)
        {
            _logger = logger;
            _serviceProvider = provider;
        }

        public override async Task<OrderSearchResponse> Order_Search(OrderSearchRequest request, ServerCallContext context)
        {
            //TODO 从底层ES中查找订单数据，
            //可以设计成DDD 方式来进行ES的操作，这里我就为了演示直接硬编码了

            var response = new OrderSearchResponse();
            try
            {
                response.Data.Add(new OrderRepsonse()
                {
                    Amount = 100.00,
                    Count = 10,
                    Name = "订单名称测试",
                    OrderId = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Time = DateTime.Now.ToString()
                });

                response.Data.Add(new OrderRepsonse()
                {
                    Amount = 200.00,
                    Count = 10,
                    Name = "订单名称测试2",
                    OrderId = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Time = DateTime.Now.ToString()
                });

                response.Data.Add(new OrderRepsonse()
                {
                    Amount = 300.00,
                    Count = 10,
                    Name = "订单名称测试2",
                    OrderId = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Time = DateTime.Now.ToString()
                });
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMsg = ex.Message;
                _logger.LogWarning("异常");
            }
            return response;
        }
    }
}