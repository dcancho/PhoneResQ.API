using AutoMapper;
using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;


namespace PhoneResQ.API.Support.Application.Internal.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<OrderResource>> ReadAsync()
        {
            var orders = await _orderRepository.ListAsync();
            var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }

        public async Task<OrderResponse> SaveAsync(SaveOrderResource order)
        {
            if (order == null)
            {
                return new OrderResponse("Order is null.");
            }

            Order newOrder;
            try
            {
                var existingOrder = await _orderRepository.FindByCustomerAsync(order.Customer);
                if (existingOrder != null)
                    return new OrderResponse("Order already exists.");

                newOrder = _mapper.Map<SaveOrderResource, Order>(order);
            }
            catch (Exception ex)
            {
                return new OrderResponse($"An error occurred when processing the order: {ex.Message}");
            }

            try
            {
                await _orderRepository.AddAsync(newOrder);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new OrderResponse($"An error occurred when saving the order: {ex.Message}");
            }

            return new OrderResponse(_mapper.Map<Order, OrderResource>(newOrder));
        }

        public async Task<OrderResponse> DeleteAsync(int id)
        {
            var existingOrder = await _orderRepository.FindByIdAsync(id);

            if (existingOrder == null)
                return new OrderResponse("Order not found.");

            try
            {
                _orderRepository.Remove(existingOrder);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(_mapper.Map<Order, OrderResource>(existingOrder));
            }
            catch (Exception ex)
            {
                return new OrderResponse($"An error occurred when deleting the order: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _orderRepository.ListAsync();
        }
        
        public async Task<OrderResponse> UpdateAsync(int id, Order order)
        {
            var existingOrder = await _orderRepository.FindByIdAsync(id);

            if (existingOrder == null)
                return new OrderResponse("Order not found.");

            existingOrder.Customer = order.Customer;
            existingOrder.Device = order.Device;
            existingOrder.Status = order.Status;
            existingOrder.Description = order.Description;

            try
            {
                _orderRepository.Update(existingOrder);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(_mapper.Map<Order, OrderResource>(existingOrder));
            }
            catch (Exception ex)
            {
                return new OrderResponse($"An error occurred when updating the order: {ex.Message}");
            }
        }
    }

}