﻿using Bussiness.Interface.OrderInterface.Dto;
using Bussiness.Services.Core;

namespace Bussiness.Interface.OrderInterface
{
    public interface IOrderAppService
    {
        Task<object> GetOrdersForAdmin(PaginationInput input);
        Task<object> GetOrdersForShop(int shopId, PaginationInput input);
        Task<OrderForViewDto> CreateOrder(OrderInput input);
        Task<OrderForViewDto> UpdateOrder(long id, UpdateOrderInput input);
        Task<OrderForViewDto> ForwardToTheStore(long id, UpdateOrderInput input);
        Task<OrderForViewDto?> GetOrder(long id);
        Task<OrderForViewDto?> GetOrder(string code);
        Task<IEnumerable<OrderForViewDto>> GetOrdersForCustomer(long userId);
        Task<OrderForViewDto> CustomerRecievedOrder(long orderId);
    }
}
