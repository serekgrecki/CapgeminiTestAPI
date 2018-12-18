using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Backend.Infrastructure.DAL.Interfaces;
using Backend.Services.Interfaces;
using Backend.ViewModels;
using static AutoMapper.Mapper;

namespace Backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository _customerRepository)
        {
            this.customerRepository = _customerRepository;
        }

        public CustomerVM CustomerCreate(CustomerVM customer)
        {
            var dbModel = customerRepository.CustomerCreate(customer);
            var res = Map<CustomerVM>(dbModel);
            return res;
        }

        public CustomerVM CustomerUpdate(CustomerVM customer)
        {
            var dbModel = customerRepository.CustomerUpdate(customer);
            var res = Map<CustomerVM>(dbModel);
            return res;
        }

        public string CustomerDelete(int customerId)
        {
            var response = customerRepository.CustomerDelete(customerId);
            return response;
        }

        public IList<CustomerVM> CustomerGetAll()
        {
            var dbModel = customerRepository.CustomerGetAll();
            var res = Map<List<CustomerVM>>(dbModel);
            return res;
        }

        public CustomerVM CustomerGetById(int customerId)
        {
            var dbModel = customerRepository.CustomerGetById(customerId);
            var res = Map<CustomerVM>(dbModel);
            return res;
        }
    }
}