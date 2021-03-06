﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Schudele
{
    public class EditScheduleViewModel
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        public string EmployeeFullName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
