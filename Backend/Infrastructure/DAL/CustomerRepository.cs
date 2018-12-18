using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Backend.Infrastructure.DAL.Interfaces;
using Backend.Models;
using Backend.ViewModels;

namespace Backend.Infrastructure.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private DBContext context;

        public CustomerRepository()
        {
            this.context = DBContext.GetContext();
        }

        public CustomerModel CustomerCreate(CustomerVM customer)
        {
            CustomerModel customerCreate = null;
            using (SqlCommand cmd = this.context.CreateCommand("dbo.CustomerGetById"))
            {
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = customer.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = customer.LastName;
                cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 30).Value = customer.Address1;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = customer.City;
                cmd.Parameters.Add("@ZIP", SqlDbType.VarChar, 5).Value = customer.ZIP;
                cmd.Parameters.Add("@State", SqlDbType.Char, 2).Value = customer.State;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.SmallDateTime).Value = customer.DateOfBirth;

                if (!string.IsNullOrEmpty(customer.Address2))
                {
                    cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 30).Value = customer.Address2;
                }

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            customerCreate = PrepareModel(rdr);
                        }
                    }
                }
            }

            return customerCreate;
        }

        public CustomerModel CustomerUpdate(CustomerVM customer)
        {
            CustomerModel customerUpdate = null;
            using (SqlCommand cmd = this.context.CreateCommand("dbo.CustomerGetById"))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = customer.Id;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = customer.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = customer.LastName;
                cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 30).Value = customer.Address1;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = customer.City;
                cmd.Parameters.Add("@ZIP", SqlDbType.VarChar, 5).Value = customer.ZIP;
                cmd.Parameters.Add("@State", SqlDbType.Char, 2).Value = customer.State;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.SmallDateTime).Value = customer.DateOfBirth;

                if (!string.IsNullOrEmpty(customer.Address2))
                {
                    cmd.Parameters.Add("@Address2", SqlDbType.VarChar,30).Value = customer.Address2;
                }

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            customerUpdate = PrepareModel(rdr);
                        }
                    }
                }
            }

            return customerUpdate;
        }

        public string CustomerDelete(int customerId)
        {
            string response = String.Empty;
            using (SqlCommand cmd = this.context.CreateCommand("dbo.CustomerDelete"))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = customerId;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Response";
                parameter.Direction = ParameterDirection.Output;
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 25;
                SqlParameter outParam =  cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();

                if (!(outParam.Value is DBNull))
                {
                    response = (string) outParam.Value;
                }
            }

            return response;
        }

        public IList<CustomerModel> CustomerGetAll()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            using (SqlCommand cmd = this.context.CreateCommand("dbo.CustomerGetAll"))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {

                        }
                    }
                }
            }

            return customers;
        }

        public CustomerModel CustomerGetById(int customerId)
        {
            CustomerModel customer = null;

            using (SqlCommand cmd = this.context.CreateCommand("dbo.CustomerGetById"))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = customerId;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {

                        }
                    }
                }
            }

            return customer;
        }

        public CustomerModel PrepareModel(SqlDataReader rdr)
        {
            CustomerModel customer = new CustomerModel();
            if (rdr["Id"] != DBNull.Value)
                customer.Id = (int)rdr["Id"];
            if (rdr["FirstName"] != DBNull.Value)
                customer.FirstName = (string)rdr["FirstName"];
            if (rdr["LastName"] != DBNull.Value)
                customer.LastName = (string)rdr["LastName"];
            if (rdr["Address1"] != DBNull.Value)
                customer.Address1 = (string)rdr["Address1"];
            if (rdr["Address2"] != DBNull.Value)
                customer.Address2 = (string)rdr["Address2"];
            if (rdr["City"] != DBNull.Value)
                customer.City = (string)rdr["City"];
            if (rdr["ZIP"] != DBNull.Value)
                customer.ZIP = (string)rdr["ZIP"];
            if (rdr["State"] != DBNull.Value)
                customer.State = (string) rdr["State"];
            if (rdr["DateOfBirth"] != DBNull.Value)
                customer.DateOfBirth = (DateTime)rdr["DateOfBirth"];
            return customer;
        }
    }
}