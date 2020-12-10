using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Schudele
{
    public class CreateScheduleViewModel
    {
        public CreateScheduleViewModel()
        {
            this.Users = new Dictionary<string, string>();
            this.UsersTemplate = new SelectList(this.Users);
        }

        public IDictionary<string,string> Users { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public SelectList UsersTemplate { get; set; }
    }
}
