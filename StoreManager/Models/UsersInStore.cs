using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class UsersStore
    {
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
    }
}
