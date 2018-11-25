﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyIdentity.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required(ErrorMessage ="Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be a number")]
        [StringLength(maximumLength:12,MinimumLength =12,ErrorMessage ="Must be 12 digits")]
        public string PhoneNumber { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int Price { get; set; }

        public OrderState State { get; set; }

        public DateTime TimeCreated { get; set; }
    }

    public enum OrderState
    {
        New=0,
        Delivered=1
    }
}
