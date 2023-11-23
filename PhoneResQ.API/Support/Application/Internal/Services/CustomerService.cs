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
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> CreateAsync(SaveCustomerResource customer)
        {
            var existingCustomer = await _customerRepository.FindByDNIAsync(customer.DNI);
            if (existingCustomer != null)
                return new CustomerResponse("Customer already exists.");

            var customerEntity = _mapper.Map<Customer>(customer);

            try
            {
                await _customerRepository.AddAsync(customerEntity);
                await unitOfWork.CompleteAsync();

                var customerResource = _mapper.Map<CustomerResource>(customerEntity);

                return new CustomerResponse(customerResource);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when saving the customer: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CustomerResource>> ReadAsync()
        {
            var customers = await _customerRepository.ListAsync();
            var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
            return resources;
        }

        public Task<CustomerResponse> UpdateAsync(int id, SaveCustomerResource customer)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);
            if (existingCustomer != null)
            {
                try
                {
                    _customerRepository.Remove(existingCustomer);
                    await unitOfWork.CompleteAsync();

                    return new CustomerResponse(_mapper.Map<CustomerResource>(existingCustomer));
                }
                catch (Exception ex)
                {
                    // Do some logging stuff
                    return new CustomerResponse($"An error occurred when deleting the customer: {ex.Message}");
                }
            }
            else
            {
                return new CustomerResponse("Customer not found.");
            }
        }

        public async Task<bool> LoginAsync(CustomerLoginResource customer)
        {
            var existingCustomer = await _customerRepository.FindByEmailAsync(customer.Email);
            if (existingCustomer != null)
            {
                if (existingCustomer.Password == customer.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
                // throw new Exception("Customer not found.");
            }
        }
    }
}
