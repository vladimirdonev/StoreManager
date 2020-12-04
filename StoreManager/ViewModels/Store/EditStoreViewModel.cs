using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Store
{
    public class EditStoreViewModel
    {
        public EditStoreViewModel()
        {
            this.Users = new HashSet<string>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public HashSet<string> Users { get; set; }
    }
}
