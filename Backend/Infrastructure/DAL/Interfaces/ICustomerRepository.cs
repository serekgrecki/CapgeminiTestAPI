using System.Collections.Generic;
using System.Data.SqlClient;
using Backend.Models;
using Backend.ViewModels;

namespace Backend.Infrastructure.DAL.Interfaces
{
    interface ICustomerRepository
    {
        CustomerModel CustomerCreate(CustomerVM customer);
        CustomerModel CustomerUpdate(CustomerVM customer);
        string CustomerDelete(int customerId);
        IList<CustomerModel> CustomerGetAll();
        CustomerModel CustomerGetById(int customerId);
        CustomerModel PrepareModel(SqlDataReader sqlDataReader);
    }
}
