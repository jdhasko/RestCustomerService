﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(int id, string firstName, string lastName, DateTime yearOfRegistration)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            YearOfRegistration = yearOfRegistration;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime YearOfRegistration { get; set; }

    }
}
