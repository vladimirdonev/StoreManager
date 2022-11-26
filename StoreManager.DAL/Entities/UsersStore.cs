using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.DAL.Entities
{
    public class UsersStore
    {



        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
