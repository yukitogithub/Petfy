using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Data.Models
{
    public class AppUser: IdentityUser<int>
    {
        //public int ID { get; set; }
        //public string UserName { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}
