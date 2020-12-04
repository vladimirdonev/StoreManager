using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.Models
{
    public class Store
    {

        public Store()
        {
            this.Users = new HashSet<UsersStore>();
        }

        public int Id { get; set; }

        public string  Name { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public ICollection<UsersStore> Users { get; set; }

    }
}
