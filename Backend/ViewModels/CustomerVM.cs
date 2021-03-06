﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string  FullName => $"{FirstName} {LastName}".Trim();

        public int Age => DateTime.Now.Year - this.DateOfBirth.Year;
    }
}