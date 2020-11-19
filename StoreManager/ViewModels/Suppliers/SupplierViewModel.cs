﻿using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels.Suppliers
{
    public class SupplierViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string AgentName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
