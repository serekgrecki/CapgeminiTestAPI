using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Backend.Services.Interfaces;
using Backend.ViewModels;
using static AutoMapper.Mapper;

namespace Backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerService _customerService;

        public CustomerService(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public CustomerVM CustomerCreate(CustomerVM customer)
        {
            var dbModel = _customerService.CustomerCreate(customer);
            var res = Map<CustomerVM>(dbModel);
            return res;
        }

        public CustomerVM CustomerUpdate(CustomerVM customer)
        {
            var dbModel = _customerService.CustomerUpdate(customer);
            var res = Map<CustomerVM>(dbModel);
            return res;
        }

        public string CustomerDelete(int customerId)
        {
            var response = _customerService.CustomerDelete(customerId);
            return response;
        }

        public IList<CustomerVM> CustomerGetAll()
        {
            var dbModel = _customerService.CustomerGetAll();
            var res = Map<List<CustomerVM>>(dbModel);
            return res;
        }

        public CustomerVM CustomerGetById(int customerId)
        {
            var dbModel = _customerService.CustomerGetById(customerId);
            var res = Map<CustomerVM>(dbModel);
            return res;
        }
    }
}