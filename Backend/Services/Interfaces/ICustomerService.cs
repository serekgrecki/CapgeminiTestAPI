using System.Collections.Generic;
using Backend.ViewModels;

namespace Backend.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerVM CustomerCreate(CustomerVM customer);
        CustomerVM CustomerUpdate(CustomerVM customer);
        string CustomerDelete(int customerId);
        IList<CustomerVM> CustomerGetAll();
        CustomerVM CustomerGetById(int customerId);
    }
}
