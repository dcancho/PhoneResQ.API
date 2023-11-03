using AutoMapper;
using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Application.Internal.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<CustomerResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerResource>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerResponse> SaveAsync(SaveCustomerResource customer)
        {
            var existingCustomer = await _customerRepository.FindByDNIAsync(customer.DNI);
            if (existingCustomer != null)
                return new CustomerResponse("Customer already exists.");

            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<SaveCustomerResource, Customer>()).CreateMapper();

            var customerEntity = _mapper.Map<Customer>(customer);
            customerEntity.Id = 0;

            try
            {
                await _customerRepository.AddAsync(customerEntity);
                await unitOfWork.CompleteAsync();

                var customerResource = _mapper.Map<CustomerResource>(customerEntity);
                return new CustomerResponse(customerResource);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CustomerResponse($"An error occurred when saving the customer: {ex.Message}");
            }
        }

        public Task<CustomerResponse> UpdateAsync(int id, SaveCustomerResource customer)
        {
            throw new NotImplementedException();
        }
    }
}
