using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.UserRoles
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public bool IsSelected { get; set; }
    }
}
