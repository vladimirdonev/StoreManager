using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.UserRoles
{
    public class EditRoleViewModel
    {

        public EditRoleViewModel()
        {
            this.Users = new HashSet<string>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public HashSet<string> Users { get; set; }
    }
}
