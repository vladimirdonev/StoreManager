using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.Models
{
    public class Store
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }


    }
}
